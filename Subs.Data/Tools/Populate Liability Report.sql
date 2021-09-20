ALTER PROCEDURE [dbo].[MIMS.PopulateLiabilityReport]
@Date datetime = null
As

DECLARE @DebtorAmount money,
		@PreviousMonthDebtorAmount money,
		@DebtorDifference money,
		@PreviousMonthExcessPayments money
		--@Date datetime = getdate()
		
SET @Date = coalesce (@Date, Getdate ())

--Opening Balance
--Equals the closing balance of the previous month
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 1, ISNULL(Amount,0), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from LiabilityReport
where LiabilityReportDescriptionId = 9
and [MONTH] = DATEPART(m,DATEADD(m,-1,@Date))
and [YEAR] = DATEPART(yyyy,DATEADD(m,-1,@Date))

--Total Debtors
select @DebtorAmount = ISNULL(SUM(OutstandingAmount),0)
from DebtorHistory
where DATEPART(m,RecordedDate) = DATEPART(m,@Date)
and DATEPART(yyyy,RecordedDate) = DATEPART(yyyy,@Date)

select @PreviousMonthDebtorAmount = ISNULL(Amount,0)
from LiabilityReport
where LiabilityReportDescriptionId = 2
and [MONTH] = DATEPART(m,DATEADD(m,-1,@Date))
and [YEAR] = DATEPART(yyyy,DATEADD(m,-1,@Date))

Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
values(2, @DebtorAmount - @PreviousMonthDebtorAmount, DATEPART(m,@Date), DATEPART(yyyy,@Date))

--Payments
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 3, SUM(CreditValue - DebitValue), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from Transactions
where Operation in (1, 24) -- Payment and reverse payment
and DATEPART(m,Datefrom) = DATEPART(m,@Date)
and DATEPART(yyyy,DateFrom) = DATEPART(yyyy,@Date)

--Refunds
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 4, SUM(CreditValue - DebitValue), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from Transactions
where Operation =4
and DATEPART(m,Datefrom) = DATEPART(m,@Date)
and DATEPART(yyyy,DateFrom) = DATEPART(yyyy,@Date)

--Deliveries
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 5, SUM(CreditValue - DebitValue), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from Transactions
where Operation in (2,27) --Delivery and reverse delivery
and DATEPART(m,Datefrom) = DATEPART(m,@Date)
and DATEPART(yyyy,DateFrom) = DATEPART(yyyy,@Date)

--Write-Off stock (e.g. Missing in the post so still liable for delivery)
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 6, SUM(CreditValue - DebitValue), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from Transactions
where Operation = 14
and DATEPART(m,Datefrom) = DATEPART(m,@Date)
and DATEPART(yyyy,DateFrom) = DATEPART(yyyy,@Date)

--Returns (e.g. The book is returned as postal address is incorrect so still liable for delivery)
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 7, SUM(CreditValue - DebitValue), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from Transactions
where Operation = 12
and DATEPART(m,Datefrom) = DATEPART(m,@Date)
and DATEPART(yyyy,DateFrom) = DATEPART(yyyy,@Date)

--Write-Off money (There has been a delivery but it won't be paid for, so it reduces revenue)
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 8, SUM(CreditValue - DebitValue), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from Transactions
where Operation in (23, 25) --Write-off money and reverse write-off money
and DATEPART(m,Datefrom) = DATEPART(m,@Date)
and DATEPART(yyyy,DateFrom) = DATEPART(yyyy,@Date)

Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 9, SUM(Amount), DATEPART(m,@Date), DATEPART(yyyy,@Date)
from LiabilityReport
where [MONTH] = DATEPART(m,@Date)
and [YEAR] = DATEPART(yyyy,@Date)

--Excess Payments
select a.SubscriptionId, a.Payer, a.UnitPrice,  'UnitsLeft' = sum(b.UnitsLeft)
into #UnitsLeft
from subscription as a inner join SubscriptionIssue as b on a.SubscriptionId = b.SubscriptionId 
where a.status in (1,2,3)
group by a.SubscriptionId, a.Payer, a.UnitPrice

select Payer, 'Outstanding' = sum(isnull(UnitsLeft * unitprice, 0)) 
into #Results1
from #UnitsLeft
group by Payer

select CustomerId, Liability, 'DeliveriesOutstanding' =  isnull(sum(Outstanding),0)
into #Customers
from Customer as a left outer join #Results1 as b on a.CustomerId = b.Payer
left outer join Company as c on a.CompanyId = c.CompanyId
group by CustomerId, Liability

select @PreviousMonthExcessPayments = ISNULL(Amount,0)
from LiabilityReport
where LiabilityReportDescriptionId = 10
and [MONTH] = DATEPART(m,DATEADD(m,-1,@Date))
and [YEAR] = DATEPART(yyyy,DATEADD(m,-1,@Date))

Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 10, SUM(Liability - DeliveriesOutstanding) - @PreviousMonthExcessPayments, DATEPART(m,@Date), DATEPART(yyyy,@Date) 
from #Customers
where (Liability - DeliveriesOutstanding) > 0

--Deliveries Outstanding
Insert into LiabilityReport(LiabilityReportDescriptionId, Amount, [Month], [Year])
select 12, sum(isnull(UnitsLeft * unitprice, 0)), DATEPART(m,@Date), DATEPART(yyyy,@Date) 
from #UnitsLeft