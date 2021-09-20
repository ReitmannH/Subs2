
-- Find all subscriptions that has been cancelled this year
select a.subscriptionid, a.ReceiverId, a.productid
into #Cancelled
from transactions as a
where a.operation = 9
and a.ModifiedOn between '2009/01/01' and '2009/06/08'
and a.Reference = 'Expired for too long'

-- See if there are any of them that has subsequently been renewed
select a.subscriptionid
into #Renewed
from #Cancelled as a inner join subscription as b on a.receiverid = b.receiver
where b.productid = a.productid
and b.status = 1

-- Keep only those who has not been renewed

delete 
from #Cancelled
where SubscriptionId in (select * from #Renewed)

-- Count the number of subs not renewed in this year

select c.ProductName, 'Count' = count(*)
into #NotRenewed
from #Cancelled as a inner join Product as c on a.ProductId = c.ProductId
group by c.ProductName  

-- Count the number of new subscriptions this year

select b.productname, b.ExpirationDuration, 'Count' = count(*) 
into #New
from transactions as a inner join Product as b on a.productid = b.productid
where operation = 16
and a.ModifiedOn between '2009/01/01' and '2009/06/08'
Group by b.productname, b.expirationduration


-- Consolidate the result

Select 'The new subscriptions has been recorded only from 01 Jan 2009.'

select a.Productname, 'New' = a.[Count], 'Not renewed' = isnull(b.[Count],0), a.ExpirationDuration
from #New as a left outer join #NotRenewed as b on a.productname = b.productname
order by a.ProductName




--------------------------------------------------------------------------------------------------
-- Average subscription lifetime
--------------------------------------------------------------------------------------------------

-- Count the subscriptions that has not been renewed

--select SubscriptionId, a.ProductId, Receiver
--into #Temp
--from subscription as a
--where subscriptionid not in ( select a.subscriptionid
--From subscription as a inner join transactions as b on a.subscriptionid = b.subscriptionid
--where b.operation = 9
--and b.Reference <> 'Subscription has been renewed' )

--select ProductId, Receiver, 'Repeats' = cast(count(*) as decimal)
--into #Temp2
--from #Temp
--group by ProductId, Receiver


--select b.Productname, 'Average number of subscriptions per product per person' = avg(a.Repeats), 'Maximum'  = max(a.Repeats)
--from #Temp2 as a inner join Product as b on a.productid = b.productid
--group by b.productname
--order by b.productname

--drop table #Cancelled