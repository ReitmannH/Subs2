select b.*
from Subscription as a inner join Transactions as b on a.SubscriptionId = b.SubscriptionId
where a.VatInvoiceNumber is null
and b.Operation = 1

-- Phanton invoices - Get subscriptions with deliveries and returns but without invoices 

select a.SubscriptionId, 'PhantonInvoiceValue' = SUM(b.DebitValue - b.CreditValue)
into #Phantom
from  subscription as a inner join Transactions as b on a.SubscriptionId = b.SubscriptionId
where a.VatInvoiceNumber is null
and b.Operation in (2, 12)
group by a.SubscriptionId

select *
into #PhantomNet
from #Phantom 
where PhantonInvoiceValue <> 0

select a.SubscriptionId,'LastActivity' = MAX(b.DateFrom) 
from #PhantomNet as a inner join Transactions as b on a.SubscriptionId = b.SubscriptionId
where b.Operation in (1,12)
group by a.SubscriptionId
order by 2

	-- Generate phantom invoices per legacy subsription

select b.Payer, a.SubscriptionId, a.PhantonInvoiceValue 
from #PhantomNet as a inner join Subscription as b on a.SubscriptionId = b.SubscriptionId
order by 1,2,3


-- Get payments not allocated to invoices

select TransactionId
into #LinkedPayments
		from  transactions
		where Operation = 1
		and ReferenceType2 = 'Invoice number'
		and Reference2 like 'INV%'
		order by DateFrom desc

select *
from  transactions
where Operation = 1
and TransactionId not in (select TransactionId from #LinkedPayments)
order by DateFrom desc


-- Get invoices not paid at all

select 'VatInvoiceNumber' = Reference2, 'TotalPayment' = SUM(CreditValue)
into #PaymentOfInvoices  
from  transactions
where Operation = 1
and ReferenceType2 = 'Invoice number'
and Reference2 like 'INV%'
group by Reference2

select distinct VatInvoiceNumber
into #AllInvoices
from Subscription

Select *
from #AllInvoices
where VATInvoiceNumber not in (select VATInvoiceNumber from #PaymentOfInvoices) 


-- Get invoices not paid in full or overpaid

select VatInvoiceNumber, 'InvoiceValue' = SUM(UnitsPerIssue * NumberOfIssues * Unitprice)
into #InvoiceValues 
from Subscription 
where VatInvoiceNumber is not null
group by VatInvoiceNumber

drop table #underpayment

select a.VatINvoiceNumber, 'Underpayment' = b.InvoiceValue - a.TotalPayment
into #UnderPayment  
from #PaymentOfInvoices as a inner join #InvoiceValues as b on a.VatInvoiceNumber = b.VatInvoiceNumber

select *
from #UnderPayment
where Underpayment not between -1 and 1

-- Get invoices overpaid