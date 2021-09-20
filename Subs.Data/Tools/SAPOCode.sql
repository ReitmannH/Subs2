



-- Start here


-- Load SA PostOffice from spreadsheet into SAPOCode table.  You got it at https://www.postoffice.co.za/questions/postalcode.html

-- This is a manual job.

-- But you have to pad the Postcodes - use MainWindow: Standardise postcodes.

select *
from SAPOCode


--  See FillSapoCcmplement SP.



-- Pick up StreetCodes   IF YOU want to load everything from scratch. BEWARE!!!!

--insert into Code(Code, [Type])
--select distinct StreetCode as Code, Type = 'PostStreet' 
--from PostCode
--where StreetCode is not null

--insert into AddressLine4(CodeId,AddressLine4, AddressLine4Old )
--select distinct b.CodeId, a.AddressLine3, a.AddressLine3
--from PostCode as a inner join Code as b on a.StreetCode = b.Code and b.[Type] = 'StreetCode' 
--where AddressLine3 is not null
--and  a.StreetCode is not null

--drop table #Address4

--select a.Code, b.AddressLine4, b.AddressLine4Id
--into #Address4 
--from Code as a inner join Addressline4 as b on a.CodeId = b.CodeId
--where a.Type = 'PostStreet'
 								

--select *
--into #StreetCodes
--from PostCode
--Where StreetCode is not null
--and AddressLine2 is not null  -- 14421

--insert into AddressLine3(AddressLine4Id, AddressLine3, AddressLine3Old )

--select distinct b.AddressLine4Id, a.AddressLine2, a.AddressLine2 
--from #StreetCodes as a inner join #Address4 as b on a.Addressline3 = b.AddressLine4 and a.StreetCode = b.Code
---- 14149


--select distinct StreetCode,  AddressLine3, AddressLine2
--from PostCode 
--where StreetCode is not null
--and AddressLine3 is not null
--and AddressLine2 is not null
----14149



---- Pick up Box Codes

--insert into Code(Code, [Type])
--select distinct BoxCode as Code, Type = 'PostBox' 
--from PostCode
--where BoxCode is not null

--insert into AddressLine4(CodeId,AddressLine4, AddressLine4Old )
--select distinct b.CodeId, a.AddressLine3, a.AddressLine3
--from PostCode as a inner join Code as b on a.BoxCode = b.Code and b.[Type] = 'BoxCode' 
--where AddressLine3 is not null
--and  a.BoxCode is not null

--drop table #Address4

--select a.Code, b.AddressLine4, b.AddressLine4Id
--into #Address4 
--from Code as a inner join Addressline4 as b on a.CodeId = b.CodeId
--where a.Type = 'PostBox'
 								

--select *
--into #BoxCodes
--from PostCode
--Where BoxCode is not null
--and AddressLine2 is not null  -- 9068

--insert into AddressLine3(AddressLine4Id, AddressLine3, AddressLine3Old )

--select distinct b.AddressLine4Id, a.AddressLine2, a.AddressLine2 
--from #BoxCodes as a inner join #Address4 as b on a.Addressline3 = b.AddressLine4 and a.BoxCode = b.Code
---- 8620


--select distinct BoxCode,  AddressLine3, AddressLine2
--from PostCode 
--where BoxCode is not null
--and AddressLine3 is not null
--and AddressLine2 is not null

---- Fix up Customer


--update Customer
--set Address4 = null
--where len(lTrim(rtrim(Address4))) = 0

--select *
--from Customer
--Where Address4 is not null

--Update Customer
--set Address4 = Address3

--Update Customer
--set Address3 = Address2

--Update Customer
--set Address2 = null


--select Type = 2, a.Code, b.AddressLine4, c.AddressLine3, c.AddressLine3Id
--into #Box 
--from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
--inner join AddressLine3 as c on b.AddressLine4Id =c.AddressLine4Id
--where a.[Type] = 'BoxCode'
--order by a.Code, b.AddressLine4, c.AddressLine3

--update Customer
--set PostAddressId = b.AddressLine3Id
--from Customer as a inner join #Box as b on a.Address5 = b.Code
--                                       and a.Address4 = b.AddressLine4
--									   and a.Address3 = b.AddressLine3
--									   and a.AddressType = b.Type  -- 17834



--select Type = 3, a.Code, b.AddressLine4, c.AddressLine3, c.AddressLine3Id
--into #Street 
--from Code as a inner join AddressLine4 as b on a.CodeId = b.CodeId
--inner join AddressLine3 as c on b.AddressLine4Id =c.AddressLine4Id
--where a.[Type] = 'StreetCode'
--order by a.Code, b.AddressLine4, c.AddressLine3  -- 14149

--update Customer
--set PostAddressId = b.AddressLine3Id
--from Customer as a inner join #Street as b on a.Address5 = b.Code
--                                       and a.Address4 = b.AddressLine4
--									   and a.Address3 = b.AddressLine3
--									   and a.AddressType = b.Type -- 7608






--select a.[Type], 
--a.Code, b.AddressLine3, b.AddressLine3Old, c.AddressLine2, c.AddressLine2Old, 
--a.CodeId, b.AddressLine3Id, c.AddressLine2Id 
--into #Street
--from Code as a inner join AddressLine3 as b on a.CodeId = b.CodeId
--inner join AddressLine2 as c on b.AddressLine3Id =c.AddressLine3Id
--where a.[Type] = 'Street'
--order by a.Code, b.AddressLine3,  b.AddressLine3Old, c.AddressLine2,c.AddressLine2Old

--update Customer
--set PostAddressId = b.AddressLine2Id
--from Customer as a inner join #Street as b on a.Address5 = b.Code
--                                       and a.Address3 = b.AddressLine3
--									   and a.Address2 = b.AddressLine2
--									   and a.AddressTypeString = b.[Type]
--where a.AddressTypeString = 'Street'











