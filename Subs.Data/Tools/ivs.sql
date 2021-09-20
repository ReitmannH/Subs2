select *
from Product2

select *
from Issue where productid = 84


-- All vets
Select c.*
from Customer as c inner join SUBSDW.dbo.DimCustomer as a on c.CustomerId = a.Customerid
where a.MostSpecificClassificationId in (8, 31,32,33,34,35)

-- Current IVS subscriptions
select *
from Subscription as a inner join Customer as b on a.ReceiverId = b.CustomerId
where productid in (7, 84, 85)
and a.status = 1

-- Electronic IVS after 2021
select 
from SubscriptionIssue as a inner join Issue as b on a.IssueId = b.IssueId
where
unitsleft > 0
and b.productid in (84)
and b.[year] > 2021
group by b.IssueId, b.IssueDescription

IssueId	IssueDescription	(No column name)
1046	IVS Electronic 2022-1	111
1047	IVS Electronic 2022-2	9
1048	IVS Electronic 2023-1	5
1049	IVS Electronic 2023-2	4
1050	IVS Electronic 2024-1	4
1051	IVS Electronic 2024-2	2
1052	IVS Electronic 2025-1	3
1053	IVS Electronic 2025-2	2


select 1097, a.Subscriptionid, 14, c.UnitsPerIssue, 0
from SubscriptionIssue as a inner join Issue as b on a.IssueId = b.IssueId
inner join Subscription as c on a.SubscriptionId = c.SubscriptionId
where
a.unitsleft > 0
and b.issueid in (1053)
order by c.ReceiverId, b.issueid


update Subscription
set Baserate = 0, DeliveryCost= 0, Vat=0, UnitPrice = 0 
where Subscriptionid in (
select distinct c.SubscriptionId
from SubscriptionIssue as a inner join Issue as b on a.IssueId = b.IssueId
inner join Subscription as c on a.SubscriptionId = c.SubscriptionId
where
a.unitsleft > 0
and b.issueid in (1047, 1049, 1051,1053)
and unitprice > 0)



select *
from SubscriptionIssue
where subscriptionid = 211014


