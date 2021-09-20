exec  [dbo].[MIMS.DataContext.InvoicesAndPayments] 86824, '2019/09/01'
exec  [dbo].[MIMS.DataContext.InvoicesAndPayments] 86824, '2019/11/01'
exec  [dbo].[MIMS.DataContext.InvoicesAndPayments] 86824, '2019/04/26'

exec  [dbo].[MIMS.DataContext.InvoicesAndPayments] 93828, '2004/01/01'


select 'Balance' = sum(DebitValue) - sum(CreditValue)
from Transactions
where payerid = 93828
and operation in (1, 2, 4, 12, 13, 22,23,24,25, 27)



select *
from Transactions
where payerid = 93828
and operation in (13)