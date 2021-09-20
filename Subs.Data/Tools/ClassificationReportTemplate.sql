
-- From Classification to Customer

-- Radiation oncologists

drop table #Temp

Select distinct f.Title, C.Initials, c.FirstName, c.Surname, e.CompanyName,c.Address1, c.Address2, 
c.Address3, c.Address4, c.Address5
into #Temp
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join Title as f on c.TitleId = f.TitleId
inner join Subscription as g on a.CustomerId = g.Receiver
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/1/5/')) = 1
and c.Correspondence2 <> 0
and c.status <> 2
and g.Status = 1
and g.ProductId = 1

select a.*
from TempDoctor as a inner join #Temp as b on a.Surname <> b.Surname


select *
from TempCompany






-- Urologists

Select distinct f.Title, C.Initials, c.FirstName, c.Surname, e.CompanyName,c.Address1, c.Address2, 
c.Address3, c.Address4, c.Address5
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join Title as f on c.TitleId = f.TitleId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/1/48/')) = 1
and c.Correspondence2 <> 0
and c.status <> 2



-- Pharmacies/Pharmacists

Select distinct f.Title, C.Initials, c.FirstName, c.Surname, e.CompanyName,c.Address1, c.Address2, 
c.Address3, c.Address4, c.Address5
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join Title as f on c.TitleId = f.TitleId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/6/5/')) = 1
and c.Correspondence2 <> 0
and c.status <> 2




-- All dentist

Select distinct f.City, f.Suburb
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join DeliveryAddress as f on c.CustomerId = f.CustomerId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/2/')) = 1
order by f.City, f.Suburb


-- Inverse query

Select distinct c.PhoneNumber, c.FaxPhoneNumber, c.EmailAddress, f.Province, f.City, f.Suburb, f.Street, 
f.StreetExtension, f.StreetSuffix, f.StreetNo, f.Building, f.[Floor], 
f.Room,  f.X, f.Y
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join DeliveryAddress as f on c.CustomerId = f.CustomerId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/1/')) = 1
and f.City = 'Bellville'
and f.Suburb = 'Bo-Oakdale'


-- All hospitals

Select distinct e.CompanyName, f.City, f.Suburb
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join DeliveryAddress as f on c.CustomerId = f.CustomerId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/5/')) = 1
order by f.City, f.Suburb

-- All pharmacies

Select distinct e.CompanyName, f.City, f.Suburb
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join DeliveryAddress as f on c.CustomerId = f.CustomerId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/6/5/')) = 1
order by f.City, f.Suburb


-- All vetenarians

Select distinct e.CompanyName, f.City, f.Suburb, c.CompanyId
from Customer_HierarchyClassification as a inner join Classification2 as b
on a.ClassificationIdInt = b.ClassificationidInt
inner join Customer as c on a.CustomerId = c.CustomerId
inner join Company as e on c.CompanyId = e.CompanyId
inner join DeliveryAddress as f on c.CustomerId = f.CustomerId
where a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/7/2/')) = 1
or a.ClassificationId.IsDescendantOf(hierarchyId::Parse('/7/5/')) = 1
order by f.City, f.Suburb


select distinct b.PhoneNumber, a.Province, a.City, a.Suburb, a.Street, 
a.StreetExtension, a.StreetSuffix, a.StreetNo, a.Building, a.[Floor], 
a.Room,  a.X, a.Y
from DeliveryAddress as a inner join Customer as b on a.CustomerId = b.CustomerId
where b.CompanyId = 6492








select a.*
from #Hospitals as a inner join HASA as b on a.CompanyName = b.Hospital
where b.[Vat Number] is not null

select *
from HASA

select distinct [Type of facility]
from HASA



-- From Customer to classification
-- Assumption: All Custoemrs are classified at least to level 2



-- First get the relevant customers

Select distinct Receiver
into #Receivers
From Subscription
Where ProductId = 1
And status = 1 -- There where 3492


Select distinct a.CustomerId -- Mims customers that are classified at level 1 only
from Customer_HierarchyClassification as a inner join #Receivers as b on a.CustomerId = b.Receiver
inner join Classification2 as c on a.ClassificationIdInt = c.ClassificationIdInt
where c.ClassificationLevel = 1 

Select distinct a.CustomerId, a.ClassificationIdInt
into #Classified
from Customer_HierarchyClassification as a inner join #Receivers as b on a.CustomerId = b.Receiver
inner join Classification2 as c on a.ClassificationIdInt = c.ClassificationIdInt
where c.ClassificationLevel > 1 -- There where 3764

SELECT 'Level1' = c.[Description], 'Level2' = d.[Description], COUNT(d.[Description])
FROM #Classified as a inner join dbo.Customer_HierarchyClassification as b 
	  on a.ClassificationIdInt = b.ClassificationIdInt and a.CustomerId = b.CustomerId
      INNER JOIN dbo.Classification2 c
            on b.ClassificationId.GetAncestor(b.ClassificationId.GetLevel() - 1) = c.ClassificationId
      INNER JOIN dbo.Classification2 d
            on b.ClassificationId.GetAncestor(b.ClassificationId.GetLevel() - 2) = d.ClassificationId
 Group by c.[Description], d.[Description]
 order by c.[Description], d.[Description]

  
