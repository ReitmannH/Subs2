
-- XML prefix
<?xml version="1.0" standalone="yes" ?>


select a.SubscriptionId
from dbo.Subscription as a inner join SubscriptionIssue as b on a.SubscriptionId = b.SubscriptionId
where a.ProductId = 20
and a.Status = 1
and b.UnitsLeft > 0
and b.IssueId = 389
for XML RAW('SubscriptionList'), Root('DocumentElement'), ELEMENTS, TYPE

-- After adding the prefix, the result looks like this. 

/*
<?xml version="1.0" standalone="yes" ?>
<DocumentElement>
  <SubscriptionList>
    <SubscriptionId>72748</SubscriptionId>
  </SubscriptionList>
</DocumentElement>
*/

Select *
from Product

