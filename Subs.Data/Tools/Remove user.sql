select *
from Customer
where LoginEmail like '%reitmannh%' 


--***************************************

declare @CustomerId int 
set @CustomerId = 117224

select *
from subscription
where payer in (@CustomerId) 


delete from subscription
where payer in (@CustomerId) 

Update Customer
set PhysicalAddressId = null
where CustomerId = @CustomerId


delete from DeliveryAddress
where CustomerId = @CustomerId

delete from Comment2
where CustomerId = @CustomerId


delete from Transactions
where PayerId in (@CustomerId)
or ReceiverId in (@CustomerId) 

delete from Customer
where customerid in (@CustomerId)

--****************************************

delete from GUIDTable


select * from Exception
where modifiedon > '2018/11/15'