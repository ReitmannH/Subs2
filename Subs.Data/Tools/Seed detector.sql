select a.CustomerId
into #Temp
from Customer a
left join MIMSCustomer b 
	on a.CustomerId = b.CustomerId 
where b.PracticeNumber1 is null or len(b.PracticeNumber1) = 0
and a.[Status] = 1
except
select distinct c.CustomerId from Subscription a
inner join Customer c
	on c.CustomerId = a.Receiver or c.CustomerId = a.Payer 

select b.CustomerId, min(a.ModifiedOn) as CreationDate
into #Temp2
from Transactions a
	inner join #Temp b
		on a.PayerId = b.CustomerId 
		or a.ReceiverId = b.CustomerId
Where a.Operation = 20
group by b.CustomerId
having MIN(a.Modifiedon) between '1 July 2008' and '28 feb 2009'

select a.* 
from Customer a
	inner join #Temp2 b
		on a.CustomerId = b.CustomerId

	
	