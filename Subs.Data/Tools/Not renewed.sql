
drop table #Cancelled
drop table #Renewed

-- Find all subscriptions that has been cancelled this year
select subscriptionid, receiverid, productid
into #Cancelled
from transactions
where operation = 9
and datepart(yyyy, ModifiedOn) >= '2006'
--and datepart(mm, ModifiedOn) = '01'
and Reference = 'Expired for too long'

-- See if there are any of them that has subsequently been renewed
select a.subscriptionid
into #Renewed
from #Cancelled as a inner join subscription as b on a.receiverid = b.receiver
inner join issue as c on b.LastIssue = c.IssueId
where c.productid = a.productid
and b.status = 1

-- Keep only those who has not been renewed

delete 
from #Cancelled
where SubscriptionId in (select * from #Renewed)

-- Make a listing of the remainders


select c.ProductName, a.ReceiverId, d.Title, b.Initials, b.Surname, b.PhoneNumber
from #Cancelled as a inner join Customer as b on a.receiverid = b.CustomerId
inner join Product as c on a.ProductId = c.ProductId
left outer join Title as d on b.TitleId = d.TitleId
order by c.ProductName, b.Surname 

-- Ensure that you do not pick them up again?

