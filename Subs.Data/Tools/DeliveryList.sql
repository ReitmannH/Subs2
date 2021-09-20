Select distinct 
'AccountNumber' = '6010531',
'ServiceDate' = DateName(dd, getDate()) + ' ' + DateName(mm, getDate()) + ' ' +  DateName(yyyy, getDate()),
'ServiceType Fdx1=06/Fdx2=07/Fdx3=08' = 'Fdx1=06', 
'DestinationContact NameAndSurname' = d.Title + '  ' + Initials + '  ' + Surname,
'DestinationCompany' = b.CompanyName,
'DestinationAddress1 UnitorComplexNameifNoneLeaveBlank' = ltrim(rtrim(isnull(h.Building, '') + ' ' +  isnull(h.[Floor], '') + ' ' + isnull(h.Room, ''))),   
'DestinationAddress2'  = ltrim(rtrim(isnull(h.StreetNo, '') + ' ' + isnull(h.Street, '') + ' ' +  isnull(h.StreetExtension, '') + ' ' + isnull(h.StreetSuffix, ''))),
'DestinationAddress3 SuburbIfnoSuburbRepeatCity' = h.Suburb,
'DestinationAddress4 CityOnly' = h.City,
'DestinationPostCode PostalCode' = h.PostCode,
'DestinationCountryID AlwaysZA' = i.CountryName,
'ContactWork/Cell Phonenumbermustbesupplied' = ltrim(rtrim(isnull(c.PhoneNumber, '') + ' ' + isnull(c.CellPhoneNumber, ''))),
C.CellPhoneNumber,
c.emailaddress,
'Weight'= p.[Weight] * f.UnitsPerIssue,
'Lenght'= p.[Length],
'Width'= p.Wydte,
'Height'= p.Hoogte * f.UnitsPerIssue,
'Value' = f.UnitPrice * f.UnitsPerIssue,
'Weekenddelivery' = 'No',
'Insured' = 'No',
'IsCollection',
'UniqueReferenceNumber' = f.SubscriptionId,
'Pieces' = f.UnitsPerIssue, 
h.SDI,
'Product' = ' ',
'Classification' = p.Classification
from Subscription as f 
inner join Customer as c on f.Receiver = c.CustomerId
left outer join Title as d on c.titleid = d.titleid
left outer join Company as b on c.Companyid = b.Companyid
left outer join DeliveryAddress as h on h.DeliveryAddressId = f.DeliveryAddressId
left outer  join Product as p on p.ProductId = f.ProductId
left outer join Country as i on i.CountryId = c.CountryId
--where f.SubscriptionId = 170792
