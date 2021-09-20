insert into BoxCode(BoxCode)
select distinct BoxCode 
from PostCode
where BoxCode is not null

insert into BoxAddressLine3(BoxCode, BoxAddressLine3)
select distinct b.BoxCode, a.AddressLine3
from PostCode as a inner join BoxCode as b on a.BoxCode = b.BoxCode 
where AddressLine3 is not null

insert into BoxAddressLine2([BoxAddressLine3Id],[BoxAddressLine2])
select BoxAddressLine3Id, b.AddressLine2
from BoxAddressLine3 as a inner join PostCode as b on a.BoxCode = b.BoxCode and a.BoxAddressLine3 = b.AddressLine3

select count(*)
from PostCode
Where BoxCode is not null -- 9073