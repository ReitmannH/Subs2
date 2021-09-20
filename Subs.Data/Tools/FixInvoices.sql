





--update Subscription set VatInvoiceNumber = 'INV0062385' where SubscriptionId = 190758
--update Subscription set VatInvoiceNumber = 'INV0062386' where SubscriptionId = 190755
--update Subscription set VatInvoiceNumber = 'INV0062387' where SubscriptionId = 190756
--update Subscription set VatInvoiceNumber = 'INV0062387' where SubscriptionId = 190757
--update Subscription set VatInvoiceNumber = 'INV0062388' where SubscriptionId = 190742
--update Subscription set VatInvoiceNumber = 'INV0062389' where SubscriptionId = 190748
--update Subscription set VatInvoiceNumber = 'INV0062389' where SubscriptionId = 190749
--update Subscription set VatInvoiceNumber = 'INV0062389' where SubscriptionId = 190750
--update Subscription set VatInvoiceNumber = 'INV0062389' where SubscriptionId = 190751
--update Subscription set VatInvoiceNumber = 'INV0062389' where SubscriptionId = 190752

--update Subscription set VatInvoiceNumber = 'INV0062390' where SubscriptionId = 190763
--update Subscription set VatInvoiceNumber = 'INV0062390' where SubscriptionId = 190764
--update Subscription set VatInvoiceNumber = 'INV0062390' where SubscriptionId = 190765
--update Subscription set VatInvoiceNumber = 'INV0062391' where SubscriptionId = 190759
--update Subscription set VatInvoiceNumber = 'INV0062391' where SubscriptionId = 190760
--update Subscription set VatInvoiceNumber = 'INV0062392' where SubscriptionId = 190761
--update Subscription set VatInvoiceNumber = 'INV0062392' where SubscriptionId = 190762





--update Subscription set VatInvoiceNumber = 'INV0062393' where SubscriptionId = 190782

--update Subscription set VatInvoiceNumber = 'INV0062394' where SubscriptionId = 190771
--update Subscription set VatInvoiceNumber = 'INV0062394' where SubscriptionId = 190772

--update Subscription set VatInvoiceNumber = 'INV0062395' where SubscriptionId = 190611

--update Subscription set VatInvoiceNumber = 'INV0062396' where SubscriptionId = 190775
--update Subscription set VatInvoiceNumber = 'INV0062396' where SubscriptionId = 190776

--update Subscription set VatInvoiceNumber = 'INV0062397' where SubscriptionId = 190769
--update Subscription set VatInvoiceNumber = 'INV0062397' where SubscriptionId = 190770

--update Subscription set VatInvoiceNumber = 'INV0062398' where SubscriptionId = 190763

--update Subscription set VatInvoiceNumber = 'INV0062399' where SubscriptionId = 190777
--update Subscription set VatInvoiceNumber = 'INV0062399' where SubscriptionId = 190778

--update Subscription set VatInvoiceNumber = 'INV0062400' where SubscriptionId = 190773
--update Subscription set VatInvoiceNumber = 'INV0062400' where SubscriptionId = 190774

--update Subscription set VatInvoiceNumber = 'INV0062401' where SubscriptionId = 190781

--update Subscription set VatInvoiceNumber = 'INV0062402' where SubscriptionId = 190768
--update Subscription set VatInvoiceNumber = 'INV0062402' where SubscriptionId = 190780


--update Subscription set VatInvoiceNumber = 'INV0062403' where SubscriptionId = 190779


--update Subscription set VatInvoiceNumber = 'INV0062404' where SubscriptionId = 190785
--update Subscription set VatInvoiceNumber = 'INV0062404' where SubscriptionId = 190786

--update Subscription set VatInvoiceNumber = 'INV0062405' where SubscriptionId = 190784


--update Subscription set VatInvoiceNumber = 'INV0062406' where SubscriptionId = 190806
--update Subscription set VatInvoiceNumber = 'INV0062406' where SubscriptionId = 190807

--update Subscription set VatInvoiceNumber = 'INV0062407' where SubscriptionId = 190810
--update Subscription set VatInvoiceNumber = 'INV0062407' where SubscriptionId = 190811
--update Subscription set VatInvoiceNumber = 'INV0062407' where SubscriptionId = 190812


--update Subscription set VatInvoiceNumber = 'INV0062408' where SubscriptionId = 190813

--update Subscription set VatInvoiceNumber = 'INV0062409' where SubscriptionId = 190803
--update Subscription set VatInvoiceNumber = 'INV0062409' where SubscriptionId = 190804

update Subscription set VatInvoiceNumber = 'INV0062410' where SubscriptionId = 190814
update Subscription set VatInvoiceNumber = 'INV0062411' where SubscriptionId = 190805





















select *
from Exception
where modifiedon > '2018/01/25'
and Object = 'Subs.Invoice.Generator'





select *
from Transactions
where PayerId = 88344
order by ModifiedOn


select SubscriptionId, VatInvoiceNumber
from Subscription
where SubscriptionId in (

select 'VatInvoiceNumber' = a.Reference2
from Transactions as a
where a.operation = 19
and a.transactionid > 1830851




select *
from Transactions
where TransactionId in 
(1830922, 1830844)
