select distinct a.*
from Customer as a left outer join MIMSCustomer as b on a.CustomerId = b.CustomerId
where a.CustomerId not in (Select distinct Receiver from Subscription)
and EmailAddress is not null
and a.modifiedon  > '2008/01/01'
and b.CustomerId is null
and (NationalId1 is null or LTRIM(RTRIM(a.NationalId1)) = '')
and (VatRegistration is null or LTRIM(RTRIM(a.VatRegistration)) = '')
and a.CompanyId = 1
and (Comments is null or LTRIM(RTRIM(a.Comments)) = '')
union
select distinct a.*
from Customer as a inner join MIMSCustomer as b on a.CustomerId = b.CustomerId
where a.CustomerId not in (Select distinct Receiver from Subscription)
and EmailAddress is not null
and a.modifiedon  > '2008/01/01'
and (b.CouncilNumber is null or LTRIM(RTRIM(b.CouncilNumber)) = '')
and (b.PracticeNumber1 is null or LTRIM(RTRIM(b.PracticeNumber1)) = '')
and (NationalId1 is null or LTRIM(RTRIM(a.NationalId1)) = '')
and (VatRegistration is null or LTRIM(RTRIM(a.VatRegistration)) = '')
and a.CompanyId = 1
and (Comments is null or LTRIM(RTRIM(a.Comments)) = '')





select *
from MIMSCustomer
where CustomerId = 95709