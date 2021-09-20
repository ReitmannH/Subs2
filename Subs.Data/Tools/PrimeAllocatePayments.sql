-- Find what is deliverable the payerid

select a.SubscriptionId, 'PayerId' = a.Payer, a.UnitPrice,  'UnitsLeft' = sum(b.UnitsLeft)
into #UnitsLeft
from subscription as a inner join SubscriptionIssue as b on a.SubscriptionId = b.SubscriptionId 
where a.status in (1,2,3)
group by a.SubscriptionId, a.Payer, a.UnitPrice

select PayerId, 'Deliverable' = sum(isnull(UnitsLeft * unitprice, 0)) 
into #Results1
from #UnitsLeft
group by PayerId


-- Find Liability by PayerId

select 'PayerId' = a.CustomerId, a.Liability, 'Deliverable' =  isnull(Deliverable,0)
into #Customers
from Customer as a left outer join #Results1 as b on a.CustomerId = b.PayerId
left outer join Company as c on a.CompanyId = c.CompanyId

-- Calculate due by PayerId

select PayerId, Liability, Deliverable, 'Due' = Deliverable - Liability
into #Results2
from #Customers


--update SubscriptionIssue
--set Paid = 0

--select * from SubTransaction



-- Update up to date accounts.

update SubscriptionIssue
set Paid = 1
from Subscription as a inner join SubscriptionIssue as b on a.SubscriptionId = b.SubscriptionId 
where a.Payer in (
select a.PayerId
from #Results2 as a inner join Customer as b on a.PayerId = b.CustomerId
where b.[Status] = 1
and a.Due < 1 )

