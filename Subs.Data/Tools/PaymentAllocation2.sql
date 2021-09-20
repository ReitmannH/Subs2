select b.*
from paymentallocation as a inner join Transactions as b on a.DebitTransactionId = b.TransactionId 
where a.SubscriptionId is null
order by DateFrom




drop table #Temp

select b.VATInvoiceNumber,
	 b.SubscriptionId,
	 'FullValue' = max((b.NumberOfIssues * UnitsPerIssue * (UnitPrice + DeliveryCost))),
	 'AllocatedValue' = sum(isnull(a.Amount, 0))
into #Temp
from Subscription as b left outer join paymentallocation as a on a.SubscriptionId = b.SubscriptionId 
where b.Payer = 88483
group by b.VATInvoiceNumber, b.SubscriptionId

select *
from #Temp


select a.VatInvoiceNumber, 
a.SubscriptionId, 
b.[Status], 
c.ProductName, 
a.FullValue, 
a.AllocatedValue, 
'AllocatableValue' = a.FullValue - a.AllocatedValue
from #Temp as a inner join Subscription as b on a.SubscriptionId = b.SubscriptionId
inner join Product as c on c.ProductId = b.ProductId
where (a.FullValue - a.AllocatedValue)  > 1











select *
from Transactions
where transactionid in (596732, 611970)