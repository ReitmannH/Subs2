Update Transactions
set SubscriptionValue =  convert(decimal, a.Reference2)

drop table #Temp


select a.TransactionId, a.SubscriptionId, a.Reference2, convert(decimal(18,6),a.Reference2)
from Transactions as a 
where a.operation = 16
and a.reference2 is not null
and ReferenceType2= 'Total value'
--and a.SubscriptionId <> 155477

update Transactions
set Reference2 =  replace(Reference2,',', '.')
from Transactions as a 
where a.operation = 16
and a.reference2 is not null
and ReferenceType2= 'Total value'
and charindex(',', Reference2) <> 0



select *
from #Temp
where Result is null


select Reference2, charindex(',', Reference2)
from Transactions
where transactionid = 1416794 




select TRY_CONVERT(int, 210)


select min(SubscriptionValue)
from #Temp

select *
from #Temp
where SubscriptionValue < -1168364.000000


select *
from Subscription
where SubscriptionId = 155477



select *
from Transactions
where SubscriptionId = 137903


