--Free MDRs:
-- Deliveries
select Customerid,
Title,
Initials,
Surname,
PhoneNumber,
sum(DebitValue) as NetValue,
sum(DebitUnits) as Quantity
from Transactions as a 
inner join Customer as b on b.Customerid = a.Receiverid
inner join Title as c on b.TitleId = c.TitleId
inner join Subscription as d on d.SubscriptionId = a.SubscriptionId 
where a.ProductId = 8
and a.Operation = 2
and DateFrom between '2009/01/01' and '2009/06/30'
and ((d.BaseRate * d.DiscountMultiplier) + d.DeliveryCost) <= 289.47
group by CustomerId,Title,
Initials,
Surname,
PhoneNumber

-- Paid MDRs:
--Deliveries
select Customerid,
Title,
Initials,
Surname,
PhoneNumber,
sum(DebitValue) as NetValue,
sum(DebitUnits) as Quantity
from Transactions as a 
inner join Customer as b on b.Customerid = a.Receiverid
inner join Title as c on b.TitleId = c.TitleId
inner join Subscription as d on d.SubscriptionId = a.SubscriptionId 
where a.ProductId = 8
and a.Operation = 2
and DateFrom between '2009/01/01' and '2009/06/30'
and ((d.BaseRate * d.DiscountMultiplier) + d.DeliveryCost) > 289.47
group by CustomerId,Title,
Initials,
Surname,
PhoneNumber

--All:
--Returns and write-offs
select Customerid,
Title,
Initials,
Surname,
PhoneNumber,
SUM(CreditValue) as NetValue,
sum(CreditUnits) as Quantity
from Transactions as a 
inner join Customer as b on b.Customerid = a.Receiverid
inner join Title as c on b.TitleId = c.TitleId
inner join Subscription as d on d.SubscriptionId = a.SubscriptionId 
where a.ProductId = 8
and a.Operation in (12,14)
and DateFrom between '2009/01/01' and '2009/06/30'
group by CustomerId,Title,
Initials,
Surname,
PhoneNumber


--*******************************************************************************************************

--Free MIMS:
-- Deliveries
select e.IssueDescription,
Customerid,
Title,
Initials,
Surname,
PhoneNumber,
sum(DebitValue) as NetValue,
sum(DebitUnits) as Quantity
from Transactions as a 
inner join Customer as b on b.Customerid = a.Receiverid
inner join Title as c on b.TitleId = c.TitleId
inner join Subscription as d on d.SubscriptionId = a.SubscriptionId
inner join Issue as e on a.IssueId = e.IssueId 
where a.ProductId = 1
and a.Operation = 2
and DateFrom between '2009/01/01' and '2009/06/30'
and ((d.BaseRate * d.DiscountMultiplier) + d.DeliveryCost) <= 350.88/11
group by e.sequence, e.IssueDescription,
CustomerId,Title,
Initials,
Surname,
PhoneNumber
 

-- Paid MIMS:
--Deliveries
select e.IssueDescription,
Customerid,
Title,
Initials,
Surname,
PhoneNumber,
sum(DebitValue) as NetValue,
sum(DebitUnits) as Quantity
from Transactions as a 
inner join Customer as b on b.Customerid = a.Receiverid
inner join Title as c on b.TitleId = c.TitleId
inner join Subscription as d on d.SubscriptionId = a.SubscriptionId 
inner join Issue as e on a.IssueId = e.IssueId 
where a.ProductId = 1
and a.Operation in (2)
and DateFrom between '2009/01/01' and '2009/06/30'
and ((d.BaseRate * d.DiscountMultiplier) + d.DeliveryCost) > 350.88/11
group by e.sequence, e.IssueDescription,
CustomerId,
Title,
Initials,
Surname,
PhoneNumber

--All:
--Returns and write-offs
select e.IssueDescription, Customerid,
Title,
Initials,
Surname,
PhoneNumber,
SUM(CreditValue) as NetValue,
sum(CreditUnits) as Quantity
from Transactions as a 
inner join Customer as b on b.Customerid = a.Receiverid
inner join Title as c on b.TitleId = c.TitleId
inner join Subscription as d on d.SubscriptionId = a.SubscriptionId 
inner join Issue as e on a.IssueId = e.IssueId 
where a.ProductId = 1
and a.Operation in (12,14)
and DateFrom between '2009/01/01' and '2009/06/30'
group by e.sequence, 
e.IssueDescription,
CustomerId,Title,
Initials,
Surname,
PhoneNumber
