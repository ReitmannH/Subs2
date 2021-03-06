
--set identity_insert Title on
--insert into title( TitleId, Title, ModifiedBy, ModifiedOn )
--select * 
--from MIMS3.dbo.Title
--set identity_insert Title off


set identity_insert CountryGroup on
insert into CountryGroup(CountryGroupId, GroupName,
ModifiedBy, ModifiedOn)
select * 
from MIMS3.dbo.CountryGroup
set identity_insert CountryGroup off


set identity_insert Country on
insert into Country(CountryId, CountryGroupId, CountryName,
ModifiedBy, ModifiedOn)
select * 
from MIMS3.dbo.Country
set identity_insert Country off


set identity_insert Province on
insert into Province(ProvinceId, ProvinceName)
select * 
from MIMS3.dbo.Province
set identity_insert Province off

set identity_insert City on
insert into City(CityId, ProvinceId, CityName)
select * 
from MIMS3.dbo.City
set identity_insert City off

set identity_insert Suburb on
insert into Suburb(SuburbId, CityId, SuburbName)
select * 
from MIMS3.dbo.Suburb
set identity_insert Suburb off

set identity_insert Street on
insert into Street(StreetId, SuburbId, StreetName, StreetExtension, StreetSuffix)
select * 
from MIMS3.dbo.Street
set identity_insert Street off

-- Postcode
insert into PostCode(AddressLine2, BoxCode, StreetCode, AddressLine3)
select * 
from MIMS3.dbo.PostCode

insert into Counter(CounterName, Value)
select * 
from MIMS3.dbo.Counter


insert into Vat
select * 
from MIMS3.dbo.Vat

set identity_insert Company on
insert into Company(CompanyId, CompanyName, ModifiedBy, ModifiedOn)
select *
from MIMS3.dbo.Company
where CompanyId = 1
set identity_insert Company off

--insert into ReferenceType(ReferenceTypeName,ModifiedBy , ModifiedOn)
--select ReferenceTypeName, system_user , getdate()
--from MIMS3.dbo.ReferenceType

set identity_insert [Source] on
insert into [Source](SourceId, [Description], ModifiedBy, ModifiedOn)
select SourceId, [Description], system_user , getdate()
from MIMS3.dbo.[Source]
where SourceId = 1
insert into [Source](SourceId, [Description], ModifiedBy, ModifiedOn)
select 4, 'Migrated', system_user , getdate()
set identity_insert [Source] off

-- Product

insert into Product (ProductName, ExpirationDuration, DefaultNumberOfIssues, ModifiedBy, ModifiedOn)
SELECT 'SA Mining', 90, 11,'AVUSA\ReitmannH', GETDATE()

-- Promotion

insert into Promotion ( PromotionName, DateFrom, DateTo, ModifiedBy, ModifiedOn)
select 'Voucher copy', Getdate(), DateAdd(YEAR, 10, GetDate()), 'AVUSA\ReitmannH', GETDATE()

insert into Product_Promotion (PromotionId, ProductId, Multiplier)
SELECT 1, 1, 0

insert into Product_Promotion (PromotionId, ProductId, Multiplier)
SELECT 1, 2, 0


-- Classification
set identity_insert [Classification2] on

insert into Classification2( ClassificationId,ClassificationIdInt, ParentIdInt, Description, ModifiedBy, ModifiedOn)
select ClassificationId,  ClassificationIdInt, ParentIdInt, Description, ModifiedBy, ModifiedOn
from MIMS3.dbo.Classification2
where ClassificationIdInt <= 2

insert into Classification2( ClassificationId,ClassificationIdInt, ParentIdInt, Description, ModifiedBy, ModifiedOn)
select ClassificationId,  ClassificationIdInt, ParentIdInt, Description, ModifiedBy, ModifiedOn
from MIMS3.dbo.Classification2
where ClassificationId = '/1/1/'
set identity_insert [Classification2] off

select *
from Classification2


update Classification2
set [Description] = 'Unclassified'
where ClassificationIdInt = 2

update Classification2
set [Description] = 'Unknown'
where ClassificationIdInt = 139















