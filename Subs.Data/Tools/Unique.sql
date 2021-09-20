select *
from Exception
where modifiedon > '2019/06/18'



select vatregistration
into #Temp
from company
where VatRegistration is not null
group by VatRegistration
having count(*) > 1


select *
from Company
where Vatregistration in (select VatRegistration from #Temp)
order by VatRegistration, CompanyName