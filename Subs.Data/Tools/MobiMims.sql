select EmailAddress, 'Count' = count(*)
into #Dup
from Customer
group by EmailAddress
having count(*) > 1

update Customer
set LoginEmail = convert(nvarchar(80), CustomerId)


update Customer
set LoginEmail = EmailAddress
where CustomerId not in 
( 
select CustomerId
from Customer as a inner join #Dup as b on a.EmailAddress = b.EmailAddress
)
and EmailAddress is not null






/*
select Replace(Substring(Comment, Charindex('=', Comment) + 1, 50), '-', ', ')
from Exception
where Modifiedon > '2018/05/01'
and Method = 'PaidUntil'

exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil] 1, 115292
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil] 17, 115292
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil] 1, 104536
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  1, 100244
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  32, 100244
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  1, 114921
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil] 17, 114921
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  32, 114921
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  1, 114462
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  17, 114462
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  32, 114462
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil]  1, 110510
exec [dbo].[MIMS.SubscriptionDoc.SubscriptionIssue.PaidUntil] 17, 110510


select *
from Product


drop table #Mobi

select b.Receiver, b.ProductId,'ExpiryDate' = max(c.EndDate)
into #Mobi
from SubscriptionIssue as a inner join Subscription as b on a.SubscriptionId = b.SubscriptionId
inner join Issue as c on a.IssueId = c.IssueId
where b.ProductId in (17, 32, 47)
and b.Status = 1
and (a.Paid = 1 or b.UnitPrice = 0 or a.DeliverOnCredit = 1)
group by b.Receiver, b.ProductId 
order by Receiver

select b.EmailAddress, a.Receiver, d.ProductName, a.ExpiryDate, c.UnitPrice, c.UnitsPerIssue
into #Dup
from #Mobi as a inner join Customer as b on a.Receiver = b.CustomerId
inner join Subscription as c on a.Receiver=c.Receiver and a.ProductId = c.ProductId
inner join Product as d on a.ProductId = d.ProductId
where ExpiryDate >= GetDate()
and c.Status = 1
order by b.EmailAddress

drop table #Dup2

select distinct EmailAddress, Receiver
into #Dup2
from #Dup
Where EmailAddress in (select EmailAddress
from #Dup
group by EmailAddress
having count(*) > 1)


select *
from #Dup
Where EmailAddress in 

(select EmailAddress
from #Dup2
Group by EmailAddress
having count(*) > 1)






