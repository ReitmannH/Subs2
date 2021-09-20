select *
from Exception
where modifiedon > '2018/12/13'
and severity = 1


select a.DeliveryMethod, b.Description, count(*)
from Subscription as a left outer join EnumTable as b on a.DeliveryMethod = b.Id
where modifiedon > '2018/01/01'
and b.EnumName = 'DeliveryMethod'
and a.Status = 1
group by a.DeliveryMethod, b.Description
order by b.Description

update Subscription set DeliveryMethod = 4 where DeliveryMethod = 7
update Subscription set DeliveryMethod = 4 where DeliveryMethod = 3
update Subscription set DeliveryMethod = 16 where DeliveryMethod = 9

update Subscription set DeliveryMethod = 16 where DeliveryMethod = 11
update Subscription set DeliveryMethod = 32 where DeliveryMethod = 12
update Subscription set DeliveryMethod = 1 where DeliveryMethod = 5


