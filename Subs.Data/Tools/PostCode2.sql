
insert into PostBox(Code, AddressLine4, AddressLine3)
select PostBox, AddressLine4, AddressLine3
from PostCodes
where PostBox is not null

insert into PostStreet(Code, AddressLine4, AddressLine3)
select PostStreet, AddressLine4, AddressLine3
from PostCodes
where PostStreet is not null

-- At this point you have to run that Maintenance taks - for postcodes to recover the leading zeros. 


drop table #PostCode
--  PostCode 

Select *
into #Code
from Code  -- 4875

select *
from Code
where [Type] = 'PostBox' -- 3873 to 

select distinct Code, Type
from #Code

MERGE Code as [Target]  -- Just bring it up to date. 
USING (select distinct Code, Type = 'PostBox'
from PostBox) as Source
ON Target.Code = Source.Code and Target.[Type] = Source.[Type]
WHEN NOT MATCHED THEN
	Insert (Code, Type) 
	VALUES(Code, 'PostBox');


MERGE Code as [Target]  -- Just bring it up to date. 
USING (select distinct Code, Type = 'PostStreet'
from PostStreet) as Source
ON Target.Code = Source.Code and Target.[Type] = Source.[Type]
WHEN NOT MATCHED THEN
	Insert (Code, Type) 
	VALUES(Code, 'PostStreet');



-- Pick up Box AddressLines4

drop table #NewAddress4Box

select distinct Code, AddressLine4
into #NewAddress4Box
from PostBox -- 4435
except
select distinct a.Code, b.AddressLine4
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join PostBox as c on a.Code = c.Code and b.AddressLine4 = c.AddressLine4
where a.Type = 'PostBox' -- 4358

insert into AddressLine4(CodeId,AddressLine4, AddressLine4Old )

select b.CodeId, a.AddressLine4, a.AddressLine4
From #NewAddress4Box as a inner join Code as b on a.Code = b.Code
where b.Type = 'PostBox'

-- *********************8

drop table #NewAddress4Street

select distinct Code, AddressLine4
into #NewAddress4Street
from PostStreet -- 
except
select distinct a.Code, b.AddressLine4
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join PostStreet as c on a.Code = c.Code and b.AddressLine4 = c.AddressLine4
where a.Type = 'PostStreet' -- 1172

insert into AddressLine4(CodeId,AddressLine4, AddressLine4Old )
select b.CodeId, a.AddressLine4, a.AddressLine4
From #NewAddress4Street as a inner join Code as b on a.Code = b.Code
where b.Type = 'PostStreet'



select *
from AddressLine4
where CodeId not in (select CodeId from Code)


select *
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join PostBox as c on a.Code = c.Code and c.AddressLine4 = b.AddressLine4
 where a.Type = 'PostBox'

-- ******************************************************************************





-- Pick up Box AddressLines3

drop table  #NewAddress3Box


select distinct Code, AddressLine4, AddressLine3
into #NewAddress3Box
from PostBox -- 11393
except
select distinct a.Code, b.AddressLine4, z.AddressLine3
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join AddressLine3 as z on z.AddressLine4Id = b.AddressLine4Id
where a.Type = 'PostBox' -- 11022

insert into AddressLine3(AddressLine4Id, AddressLine3, AddressLine3Old )
select distinct b.AddressLine4Id, z.AddressLine3, z.AddressLine3
From Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join #NewAddress3Box as z on a.Code = z.Code and 
b.AddressLine4 = z.AddressLine4 
where a.[Type] = 'PostBox'


drop table #NewAddress3Street 

select distinct Code, AddressLine4, AddressLine3
into #NewAddress3Street
from PostStreet -- 
except
select distinct a.Code, b.AddressLine4, z.AddressLine3
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join AddressLine3 as z on z.AddressLine4Id = b.AddressLine4Id
where a.Type = 'PostStreet' -- 

insert into AddressLine3(AddressLine4Id, AddressLine3, AddressLine3Old )
select distinct b.AddressLine4Id, z.AddressLine3, z.AddressLine3
From Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join #NewAddress3Street as z on a.Code = z.Code and 
b.AddressLine4 = z.AddressLine4 
where a.[Type] = 'PostStreet'




















drop table #Address4

select a.Code, b.AddressLine4, b.AddressLine4Id
into #Address4 
from Code as a inner join Addressline4 as b on a.CodeId = b.CodeId
where a.Type = 'PostBox'
 								

select *
into #BoxCodes
from PostCode
Where BoxCode is not null
and AddressLine2 is not null  -- 9068

insert into AddressLine3(AddressLine4Id, AddressLine3, AddressLine3Old )

select distinct b.AddressLine4Id, a.AddressLine2, a.AddressLine2 
from #BoxCodes as a inner join #Address4 as b on a.Addressline3 = b.AddressLine4 and a.BoxCode = b.Code
-- 8620


select distinct BoxCode,  AddressLine3, AddressLine2
from PostCode 
where BoxCode is not null
and AddressLine3 is not null
and AddressLine2 is not null


-- Start here


-- Pick up StreetCodes

insert into Code(Code, [Type])
select distinct StreetCode as Code, Type = 'PostStreet' 
from PostCode
where StreetCode is not null

insert into AddressLine4(CodeId,AddressLine4, AddressLine4Old )
select distinct b.CodeId, a.AddressLine3, a.AddressLine3
from PostCode as a inner join Code as b on a.StreetCode = b.Code and b.[Type] = 'StreetCode' 
where AddressLine3 is not null
and  a.StreetCode is not null

drop table #Address4

select a.Code, b.AddressLine4, b.AddressLine4Id
into #Address4 
from Code as a inner join Addressline4 as b on a.CodeId = b.CodeId
where a.Type = 'PostStreet'
 								

select *
into #StreetCodes
from PostCode
Where StreetCode is not null
and AddressLine2 is not null  -- 14421

insert into AddressLine3(AddressLine4Id, AddressLine3, AddressLine3Old )

select distinct b.AddressLine4Id, a.AddressLine2, a.AddressLine2 
from #StreetCodes as a inner join #Address4 as b on a.Addressline3 = b.AddressLine4 and a.StreetCode = b.Code
-- 14149


select distinct StreetCode,  AddressLine3, AddressLine2
from PostCode 
where StreetCode is not null
and AddressLine3 is not null
and AddressLine2 is not null
--14149




-- Fix up Customer


update Customer
set Address4 = null
where len(lTrim(rtrim(Address4))) = 0

select *
from Customer
Where Address4 is not null

Update Customer
set Address4 = Address3

Update Customer
set Address3 = Address2

Update Customer
set Address2 = null


select Type = 2, a.Code, b.AddressLine4, c.AddressLine3, c.AddressLine3Id
into #Box 
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join AddressLine3 as c on b.AddressLine4Id =c.AddressLine4Id
where a.[Type] = 'BoxCode'
order by a.Code, b.AddressLine4, c.AddressLine3

update Customer
set PostAddressId = b.AddressLine3Id
from Customer as a inner join #Box as b on a.Address5 = b.Code
                                       and a.Address4 = b.AddressLine4
									   and a.Address3 = b.AddressLine3
									   and a.AddressType = b.Type  -- 17834



select Type = 3, a.Code, b.AddressLine4, c.AddressLine3, c.AddressLine3Id
into #Street 
from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
inner join AddressLine3 as c on b.AddressLine4Id =c.AddressLine4Id
where a.[Type] = 'StreetCode'
order by a.Code, b.AddressLine4, c.AddressLine3  -- 14149

update Customer
set PostAddressId = b.AddressLine3Id
from Customer as a inner join #Street as b on a.Address5 = b.Code
                                       and a.Address4 = b.AddressLine4
									   and a.Address3 = b.AddressLine3
									   and a.AddressType = b.Type -- 7608

select a.[Type], 
a.Code, b.AddressLine3, b.AddressLine3Old, c.AddressLine2, c.AddressLine2Old, 
a.CodeId, b.AddressLine3Id, c.AddressLine2Id 
into #Street
from Code as a inner join AddressLine3 as b on a.CodeId = b.CodeId
inner join AddressLine2 as c on b.AddressLine3Id =c.AddressLine3Id
where a.[Type] = 'Street'
order by a.Code, b.AddressLine3,  b.AddressLine3Old, c.AddressLine2,c.AddressLine2Old

update Customer
set PostAddressId = b.AddressLine2Id
from Customer as a inner join #Street as b on a.Address5 = b.Code
                                       and a.Address3 = b.AddressLine3
									   and a.Address2 = b.AddressLine2
									   and a.AddressTypeString = b.[Type]
where a.AddressTypeString = 'Street'






