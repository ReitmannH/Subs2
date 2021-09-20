select 'Grant execute on [' + name + '] to [AVUSA\MIMSUser]' from sys.objects
where type IN ('P','FN') 
and substring(name, 1, 1) IN ('M','U')
union
select 'Grant execute on [' + name + '] to [AVUSA\MIMSBatch]' from sys.objects
where type IN ('P','FN') 
and substring(name, 1, 1) IN ('M','U')
union
select 'Grant execute on [' + name + '] to MIMSReader' from sys.objects
where type IN ('P','FN') 
and substring(name, 1, 1) IN ('U')
