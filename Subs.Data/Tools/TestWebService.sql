select *
from update Customer
set status = 1
where customerid = 1474


select top 6 CustomerId, ProductId, c.SubscriptionId
from Customer as a inner join Subscription as b on a.CustomerId = b.Payer
inner join subscriptionissue as c on b.Subscriptionid = c.SubscriptionId
where c.Paid = 1
order by c.SubscriptionId desc

exec [dbo].[MIMS.IssueDoc.PaidUntil] 6, 114350