DECLARE @Year int = 2013

CREATE TABLE #Liability
(ReportDescription nvarchar(50),
Amount money,
[Month] nvarchar(20),
[Year] int)

--Insert the descriptions
insert into #Liability
select convert(nvarchar(3),ReportSequence) + '. ' + LiabilityReportDescription as ReportDescription, Amount, DateName(m,Convert(nvarchar(4),[Year]) + '/' + Convert(nvarchar(2),[Month]) + '/' + '01') as [Month], [Year]
from LiabilityReport a
	inner join LiabilityReportDescription b
		on a.LiabilityReportDescriptionId = b.LiabilityReportDescriptionId
where a.[Year] = @Year
and a.LiabilityReportDescriptionId <> 9

select * from #Liability

drop table #Liability 


select ItemDescription, CONVERT(nvarchar, CONVERT(money, Amount),1) from #Liability

--Breakdowns
------------
--Debtors Per customer
select CustomerId, FirstName, Surname, CompanyName, CONVERT(nvarchar, CONVERT(money, Owing),1)
from #Results2

--Refunds
select b.CustomerId, b.FirstName, b.Surname, c.CompanyName, CONVERT(nvarchar, CONVERT(money, SUM(DebitValue)),1) as [Refund Amount]
from Transactions a 
	inner join Customer b
		on a.PayerId = b.CustomerId
	left outer join Company c 
		on b.CompanyId = c.CompanyId
where Operation = 4
and DateFrom >= '01 Feb 2013' 
and DateFrom < '01 March 2013'
group by b.CustomerId, b.FirstName, b.Surname, c.CompanyName 

--Write-Off stock (e.g. Missing in the post so still liable for delivery)
select b.CustomerId, b.FirstName, b.Surname, c.CompanyName, CONVERT(nvarchar, CONVERT(money, SUM(CreditValue)),1) as [Write-Off Stock Amount]
from Transactions a 
	inner join Customer b
		on a.PayerId = b.CustomerId
	left outer join Company c 
		on b.CompanyId = c.CompanyId
where Operation = 14
and DateFrom >= '01 Feb 2013' 
and DateFrom < '01 March 2013'
group by b.CustomerId, b.FirstName, b.Surname, c.CompanyName

--Returns (e.g. The book is returned as postal address is incorrect so still liable for delivery)
select b.CustomerId, b.FirstName, b.Surname, c.CompanyName, CONVERT(nvarchar, CONVERT(money, SUM(CreditValue)),1) as [Return Stock Amount]
from Transactions a 
	inner join Customer b
		on a.PayerId = b.CustomerId
	left outer join Company c 
		on b.CompanyId = c.CompanyId
where Operation = 12
and DateFrom >= '01 Feb 2013' 
and DateFrom < '01 March 2013'
group by b.CustomerId, b.FirstName, b.Surname, c.CompanyName

--Write-Off money (There has been a delivery but it won't be paid for, so it reduces revenue)
select b.CustomerId, b.FirstName, b.Surname, c.CompanyName, CONVERT(nvarchar, CONVERT(money, SUM(CreditValue - DebitValue)),1) as [Write-Off Money Amount]
from Transactions a 
	inner join Customer b
		on a.PayerId = b.CustomerId
	left outer join Company c 
		on b.CompanyId = c.CompanyId
where Operation in (23, 25) --Write-off money and reverse write-off money
and DateFrom >= '01 Feb 2013' 
and DateFrom < '01 March 2013'
group by b.CustomerId, b.FirstName, b.Surname, c.CompanyName

