
-- This is used to link subscriptions to deliveryaddresses where it can safely be done. 

select SubscriptionId
into #Temp
from subscription
where ProductId = 1
and Status = 1
and DeliveryAddressId is null


select distinct Receiver
into #Receiver
from subscription
where ProductId = 1
and Status = 1
and DeliveryAddressId is null

select CustomerId
into #Customer
from DeliveryAddress
where  CustomerId in (Select Receiver from #Receiver)
group by CustomerId
Having COUNT(*) = 1


Select CustomerId, DeliveryAddressId
into #Link
from DeliveryAddress
where CustomerId in (Select CustomerId from #Customer)


update Subscription
set DeliveryAddressId = b.DeliveryAddressId
from Subscription as a inner join #Link as b on a.Receiver = b.CustomerId
where a.SubscriptionId in (select SubscriptionId from #Temp)

-- See what is left
select SubscriptionId, Receiver
from subscription
where ProductId = 1
and Status = 1
and DeliveryAddressId is null
