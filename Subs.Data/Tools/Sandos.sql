insert into [dbo].[ZANDOS]([Medpages Code], samdc, Full_Name,[Email address] )


select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['Cape N$']
union 
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['Cape S$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['East Rand$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].[EL$]
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['Free State$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['JHB N$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['KZN Coastal$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['KZN Inland$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].[PE$]
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['PTA NW$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['PTA SE$']
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].[Vaal$]
union
select [Medpages Code], samdc, Full_Name,[Email address] from [dbo].['West Rand$']