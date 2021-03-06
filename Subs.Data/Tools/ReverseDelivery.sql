-----------------------------------------------------------------------------------------
-- Reverse a delivery submission
-----------------------------------------------------------------------------------------
declare @Units int, @TotalUnits int
set @TotalUnits = 0
declare @Problem bit  -- 0 means true and 1 means false
set @Problem = 1
begin transaction
declare  @Status int
declare @SubscriptionId int, @PayerId int, @DebitValue decimal(12,6), @DebitUnits int  
declare myCursor cursor for 
select  distinct a.SubscriptionId, a.PayerId, a.DebitValue, a.DebitUnits
from transactions as a inner join subscription as b on a.SubscriptionId = b.SubscriptionId
where a.operation = 2
and a.issueid = 224
and a.modifiedon between '2008/06/06 12:37' and '2008/06/06 12:50'
and b.DeliveryMethod = 5
open myCursor
fetch next from myCursor into @SubscriptionId, @PayerId, @DebitValue, @DebitUnits 
while @@Fetch_status = 0
begin -- of cursor loop
-----------------------------------------------------------------------------------
-- Reset subscription
select @Status = Status  from Subscription where SubscriptionId = @SubscriptionId
if @@Error <> 0  
begin 
set @Problem = 0
goto Problem
end 
set @TotalUnits = @TotalUnits + @DebitUnits -- Add up all the units to be reset

if @Status = 5  -- This one is expired
begin
	delete from transactions
	where SubscriptionId = @SubscriptionId
	and operation = 10 -- Expired
	if @@Error <> 0  
	begin 
	set @Problem = 0
	goto Problem
	end 
	update subscription
	set Status = 1, -- Deliverable. Also Next Issue to deliver is already right.
	    ModifiedBy = SYSTEM_USER,
	    ModifiedOn = GetDate()
	where SubscriptionId = @SubscriptionId
	if @@Error <> 0  
	begin 
	set @Problem = 0
	goto Problem
	end 
end

-- Update SubscriptionIssue

update SubscriptionIssue
	set UnitsLeft =+ @DebitUnits
	where SubscriptionId = @SubscriptionId
   and IssueId = 224
   and UnitsLeft = 0
if @@Error <> 0  
begin 
set @Problem = 0
goto Problem
end 

-- Delete the delivery transaction
delete from transactions
from transactions as a inner join subscription as b on a.SubscriptionId = b.SubscriptionId
where a.operation in (2, 10)  -- Cater for both deliveries and expirations
and a.issueid = 224
and a.modifiedon between '2008/06/06 12:37' and '2008/06/06 12:50'
and b.DeliveryMethod = 5
and a.SubscriptionId = @SubscriptionId
if @@Error <> 0  
begin 
set @Problem = 0
goto Problem
end

 
-- Reset customer
Update Customer
Set Liability = Liability + @DebitValue, ModifiedBy = SYSTEM_USER, ModifiedOn = Getdate()
where Customerid = @PayerId
if @@Error <> 0  
begin 
set @Problem = 0
goto Problem
end 
fetch next from myCursor into @SubscriptionId, @PayerId, @DebitValue, @DebitUnits  
 
---------------------------------------------------------------------------------------
end -- End of cursor loop


-- Update the issue table
update Issue
set  StockDelivered = StockDelivered - @TotalUnits
where IssueId = 224
if @@Error <> 0  
begin 
set @Problem = 0
goto Problem
end 
Problem:
if @Problem = 1 commit transaction
else rollback transaction
close mycursor
deallocate myCursor
