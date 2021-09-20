
-- Populate all the Province fields 

--select *
--from DeliveryAddress
--where Province is null
--and ProvinceId is not null

--update DeliveryAddress
--set Province = b.ProvinceName
--from DeliveryAddress as a inner join Province as b on a.ProvinceId = b.ProvinceId 

-- Remove the relation to Province from DeliveryAddress
-- Remove the ProvinceId from DeliveryAddress

--Add two fields to the DeliveryTable, i.e. StreetExtension and StreetSuffix nvarchar(20)
-- Populate the field with what we have 

--update DeliveryAddress
--set StreetExtension = b.StreetExtentionName
--from DeliveryAddress as a inner join StreetExtention as b on a.StreetExtentionId = b.StreetExtentionId

--update DeliveryAddress
--set StreetSuffix = b.StreetSuffixName
--from DeliveryAddress as a inner join StreetSuffix as b on a.StreetSuffixId = b.StreetSuffixId
 
-- OK, now you can delete the two relationships and the two fields in DeliveryAddress, i.e. StreetExtentionId and StreetSuffixId
-- I guess you can also delete the StreetExtensionTable and StreetSuffix

-- Reorganise the columns in DeliveryAddress. Add where necessary

-- Set the validation and usage fields

--Update DeliveryAddress
--set AddressValidation = 1, AddressUsage = 3
--where X is not null 


-- Massage the Mapit data - I think it is currently on the test machine


update [MapitAddress].[dbo].[RSearch]
set PROVINCE = Ltrim(RTrim(Province)), TOWN = LTRIM(Rtrim(TOWN)), SUBURB = LTRIM(rtrim(Suburb)),
    RD_Name = ltrim(rtrim(RD_NAME)), RD_EXT = LTRIM(rtrim(RD_Ext)), RD_SUFFIX = LTRIM(rtrim(RD_Suffix))

update [MapitAddress].[dbo].[RSearch]
set PROVINCE = null
where Province = '';

update [MapitAddress].[dbo].[RSearch]
set Town = null
where Town = '';

update [MapitAddress].[dbo].[RSearch]
set Suburb = null
where Suburb = '';

update [MapitAddress].[dbo].[RSearch]
set RD_Name = null
where RD_Name = '';

update [MapitAddress].[dbo].[RSearch]
set RD_EXT = null
where RD_EXT = '';

update [MapitAddress].[dbo].[RSearch]
set RD_SUFFIX = null
where RD_SUFFIX = '';


SELECT PROVINCE,
    TOWN,
    [SUBURB],
	[RD_NAME],
    [RD_EXT],
    [RD_SUFFIX]
  FROM [MapitAddress].[dbo].[RSearch]
  where PROVINCE is not null
	    and TOWN is not null
	    and [SUBURB]is not null
        and [RD_NAME] is not null
        and [RD_EXT] is not null  --It turns out that there are 433179 rows and that some RD_SUFFIX fields are null 


select *
from [MapitAddress].[dbo].[RSearch]
where PROVINCE is  null
	    or TOWN is  null
	    or [SUBURB]is  null
        or [RD_NAME] is  null
        or [RD_EXT] is  null  

select COUNT(*) from [MapitAddress].[dbo].[RSearch]


-- OK delete the useless ones.

delete from [MapitAddress].[dbo].[RSearch]
where PROVINCE is  null
	    or TOWN is  null
	    or [SUBURB]is  null
        or [RD_NAME] is  null
        or [RD_EXT] is  null  

-- Use MIMS

Drop table street
Drop table suburb
Drop table city
Drop table province



CREATE TABLE Province
(
	ProvinceId  integer  IDENTITY (1,1) ,
	ProvinceName  nvarchar(50)  NOT NULL ,
	CONSTRAINT  PK__Province__689D8392 PRIMARY KEY   CLUSTERED (ProvinceId  ASC)
)
go


CREATE TABLE City
(
	CityId  integer  IDENTITY (1,1) ,
	ProvinceId  integer  NOT NULL ,
	CityName  nvarchar(50)  NOT NULL ,
	CONSTRAINT  XPKCity PRIMARY KEY   NONCLUSTERED (CityId  ASC),
	CONSTRAINT  FK_City_Province FOREIGN KEY (ProvinceId) REFERENCES Province(ProvinceId)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)
go


CREATE TABLE Suburb
(
	SuburbId  integer  IDENTITY (1,1) ,
	CityId  integer  NOT NULL ,
	SuburbName  nvarchar(80)  NOT NULL ,
	CONSTRAINT  XPKSuburb PRIMARY KEY   NONCLUSTERED (SuburbId  ASC),
	CONSTRAINT  FK_Suburb_City FOREIGN KEY (CityId) REFERENCES City(CityId)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)
go


CREATE TABLE Street
(
	StreetId  integer  IDENTITY (1,1) ,
	SuburbId  integer  NOT NULL ,
	StreetName  nvarchar(100)  NOT NULL ,
	StreetExtension  nvarchar(20)  NULL ,
	StreetSuffix  nvarchar(20)  NULL ,
	CONSTRAINT  XPKStreet PRIMARY KEY   NONCLUSTERED (StreetId  ASC),
	CONSTRAINT  FK_Street_Suburb FOREIGN KEY (SuburbId) REFERENCES Suburb(SuburbId)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)
go


-- Built the Province table

insert into Province(ProvinceName)
select distinct Province
from [MapitAddress].[dbo].[RSearch]

-- Build the City Table


--SELECT PROVINCE,
--    TOWN,
--    [SUBURB],
--	[RD_NAME],
--    [RD_EXT],
--    [RD_SUFFIX]
--  FROM [MapitAddress].[dbo].[RSearch]
--  where PROVINCE is not null


insert into City(ProvinceId, CityName)
SELECT distinct ProvinceId = (Select ProvinceId from Province where a.PROVINCE = ProvinceName), Town
  FROM [MapitAddress].[dbo].[RSearch] as a

  
-- Build the Suburb table

insert into Suburb(CityId, SuburbName)
SELECT distinct CityId = 
(
Select x.CityId 
from City as x inner join Province as y
  on x.ProvinceId = y.ProvinceId
     and a.Town = x.CityName
     and a.Province = y.ProvinceName
)
, Suburb
  FROM [MapitAddress].[dbo].[RSearch] as a


insert into Street (SuburbId, StreetName, StreetExtension, StreetSuffix)
Select distinct
SuburbId = (
select z.SuburbId  
from Suburb as z inner join City as x on z.CityId = x.CityId
     inner join Province as y on x.ProvinceId = y.ProvinceId
 where a.Suburb = z.SuburbName
     and a.Town = x.CityName
     and a.Province = y.ProvinceName
)
, RD_Name, RD_EXT, RD_Suffix
FROM [MapitAddress].[dbo].[RSearch] as a







 
 


  
 
  
