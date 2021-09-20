declare @ClosingLiability numeric
declare @EndingLiability numeric
declare @Delta numeric
declare @Revenue numeric

select 'PayerId' = a.Payer, a.ProductId,
	'ContractualLiability' = SUM(b.UnitsLeft * a.UnitPrice),
	'ActualLiability' = AVG(c.Liability)  
from Subscription as a 
	inner join SubscriptionIssue as b on a.subscriptionId = b.SubscriptionId
	inner join Customer as c on a.Payer = c.CustomerId
where a.Status = 1
and b.UnitsLeft > 0
and c.CustomerId = 86824
-- and DateFrom between '2012/04/01' and '2012/05/01'
-- Maybe you need to record the contractual liability as the difference between two months.

group by a.Payer, a.ProductId

-- Closing liability as at   2012/03/31

select @ClosingLiability = SUM(CreditValue) - SUM(Debitvalue)
from Transactions
where PayerId = 86824
and DateFrom < '2012/04/01'


-- Change in overall liability during period
select @Delta = SUM(CreditValue) - SUM(Debitvalue)
from Transactions
where PayerId = 86824
-- and operation not in(2,23,4)
and DateFrom between '2012/04/01' and '2012/05/01'

-- Gross Revenue during period

select @Revenue = SUM(CreditValue) - SUM(Debitvalue)
from Transactions
where PayerId = 86824
and operation in (2) 
and DateFrom between '2012/04/01' and '2012/05/01'

-- Writeoff

select 'Writeoff'  = isnull(SUM(CreditValue) - SUM(Debitvalue),0)
from Transactions
where PayerId = 86824
and operation in (23) 
and DateFrom between '2012/04/01' and '2012/05/01'

-- Refund

select 'Refund'  = isnull(SUM(CreditValue) - SUM(Debitvalue),0)
from Transactions
where PayerId = 86824
and operation in (4) 
and DateFrom between '2012/04/01' and '2012/05/01'

-- Return

select 'Return'  = isnull(SUM(CreditValue) - SUM(Debitvalue),0)
from Transactions
where PayerId = 86824
and operation in (12) 
and DateFrom between '2012/04/01' and '2012/05/01'


-- Net liability at end of period.

select @EndingLiability = @ClosingLiability + @Delta
select 'ClosingLiability' = @ClosingLiability, 'Change during period' = @Delta, 'EndingLiability' = @EndingLiability

-- Summarise the results

if @EndingLiability < 0
begin
    Select 'Net Liability' = 0, 'Gross revenue' = -@Revenue, 'Net revenue'  = -@Revenue + @EndingLiability,
           'Debtors' = -@EndingLiability
end
else
begin
Select 'Net liability' = @EndingLiability, 'Gross revenue' = -@Revenue, 'Net revenue'  = @Revenue, 
    'Debtors' = 0
end






--select 'EndLiability'  = SUM(CreditValue) - SUM(Debitvalue)
--from Transactions
--where PayerId = 86824
--and DateFrom < '2012/05/01'









