

select *
from Subscription
where payer between 7408 and 7424

select *
from Customer
where CustomerId in (7773)



-- I used this to create subscriptions for Absolute Energy in batch mode

Delete from dbo.AE

-- Import the data

-- Check for duplicates
select customerId
from dbo.AE
group by CustomerId
having COUNT(*) > 1

Select *
from Product
select *
from 
BaseRate

Select *
from Subscription
where ProductId = 1


-- Subscriptions

insert into Subscription (PackageId, Payer, Receiver, [Status],
 DeliveryMethod, UnitsPerIssue, NumberOfIssues, ProductId,
 BaseRate, DeliveryCost, VatPercentage, Vat,
 UnitPrice, PromotionId, DiscountMultiplier, DeliveryAddressId,
 OrderNumber, VatInvoiceNumber, Renew, ModifiedBy,
 ModifiedOn)
select null, CustomerId, CustomerId, 1,
 1, 1, 1, 1,
21.885964, 0, 14.00, 2.042690,
0, 1, 0, null,
 null, null, 1, 'ReitmannH\AVUSA',
 GETDATE()
from Customer
where CustomerId in (select CustomerId from dbo.AE)


select *
from Subscription
where Modifiedon > '2011/09/01' 


-- Initialise subscription

insert into Transactions(SubscriptionId, Operation, DebitValue, DebitUnits,
 CreditValue, CreditUnits, DateFrom, ReferenceTypeId,
 Reference, ReferenceType2, Reference2, ReferenceType3,
 Reference3, Explanation, PaymentMethod, IssueId,
 ProductId, PayerId, ReceiverId, ModifiedBy,
 ModifiedOn)
 Select SubscriptionId, 16, 0, 0,
 0, 0, GETDATE(), null,
 null, null, null, null,
 null, null, null, null,
 ProductId, Payer, Receiver, 'ReitmannH\AVUSA',
 GETDATE()
 from Subscription
 where SubscriptionId > 23589
 
select * from Issue


-- SubscriptionIssue

insert into dbo.SubscriptionIssue( IssueId, SubscriptionId, Sequence, UnitsLeft)

select 5, SubscriptionId, 5, 1 from Subscription where SubscriptionId > 23589





union
select 46, SubscriptionId, 2, 1 from Subscription where SubscriptionId > 22992
union
select 47, SubscriptionId, 3, 1 from Subscription where SubscriptionId > 22992
union
select 48, SubscriptionId, 4, 1 from Subscription where SubscriptionId > 22992
