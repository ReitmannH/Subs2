   M S B A M L   `   `   `  ����M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  5   	   D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 5   	   0    *Subs4.Presentation.DebitOrderBankStatement   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Subs4.Presentation     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5   	   -   5          � Title$  DebitOrder processing��5	   	   $��890.265��6'   $��1427.794��68    � 	Resources 5      &    Subs4.Presentation.DateConverter   lDateConverter)   #Subs4.Presentation.IntegerConverter  lIntegerConverter&    Subs4.Presentation.RandConverter  lRandConverter �� 
TargetType �� Property �� Value  
AlignRight  Subs.Data.PaymentDoc  
paymentDoc % !DebitOrderBankStatementViewSource �� Source �� Source  Subs.Data.SBDebitOrderDoc  sBDebitOrderDoc  sBDebitOrderViewSource��%�  &	        &	      &	 &     '�� 9     &	 �     &	 �     &	 �     7  &	 #    &	 6    7    5   
   6     5   
   6!     5   
   6   �� 5   
   " ��6   .�5      ��  � ��
 ����6+   5      �� 5   
   " �6#   .�5      ��  � ��$ Right=�64   6D   5        5   
   6   �� 5   
    6I   �� *DebitOrderBankStatement+8     5   
   6   �� 5   
    6>   �� *SBDebitOrder+8   5      .��5      �� $��0,0,0,0q�6   .@�5   
   �� $��Manage debitorder users��6   .��5      �  � DataContext# [ 6   $	��Top=�6I    � ColumnDefinitions 5      �� 5      $	��22* �6'   �� 5      $
��127* �6'   �� 5       $
��429* �6'   	 � RowDefinitions	 5"      �� 5#      $
��Auto �6$   �� 5$      $��40 �6$   .+�5&      &   System.Windows.Controls.DataGrid  
   AutoGenerateColumns
 .     EnableRowVirtualization . $��0,0,0,0q�6n      RowDetailsVisibilityMode$ VisibleWhenSelected=�6   $	��554��6�      CanUserAddRows .  $��3��6�   ��6V   ��    Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      -   5        customerIdColumn1��,  &System.Windows.Controls.DataGridColumn   Header$ Customer Id��5(   g      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6|      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6H   �� *
CustomerId+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5)      -   5        suspendedColumn��$ 	Suspended��5)   h   $
 Auto	 6{    6J   �� *	Suspended+6{     5*      -   5        accountHolderColumn��$ Account Holder��5*   l   $
 Auto	 6�    6J   �� *AccountHolder+6�     5+      -   5        
bankColumn��$
 Bank��5+   Z   $
 Auto	 6h    6A   �� *Bank+6h     5,      -   5        bankCodeColumn��$ 	Bank Code��5,   b   $
 Auto	 6u    6E   �� *
BankCode+6u     5-      -   5        accountNoColumn��$ 
Account No��5-   d   $
 Auto	 6x    6F   �� *	AccountNo+6x     5.      -   5        commentColumn��$ Comment��5.   `   $
 Auto	 6q    6D   �� *	Comment+6q   50      �� 51      $��1��6    �� Orientation$ 
Horizontal=�6*   $��3��6C   .+�52      �� -	   5        $	��100��52      $��10q�6J   .��6V   Load specific user6j   �� 53      -
   5        $	��100��53      $��10q�6C   .��6O   
Load all6Y   �� 54      -   5        $	��100��54      $��10q�6A   .��6M   Add6R   �� 55      -   5        $	��100��55      $��10q�6B   .��6N   Save6T   �� 56      -   5        $	��100��56      $��10q�6B   .��6N   Cancel6V   57      58      59      �� 5;   
   $��Propose debitors��6   .��5<      �� $��0,0,0,0q�6   .+�5=      (  "System.Windows.Controls.DatePicker  -   5          Name$ calenderDeliver��5=       �� Left$ 22��66   
 �� Top$ 41��6G      SelectedDateFormat$
 Long=�6W   $	��191��6q   �� 5>      $'��!Select the planned delivery month��6   $ 22��6D   $ 10��6U     5@      -   5          Name$ ProposalDataGrid��5@      
 .   . $	��551��6p   $
��1076��6}   $ 22��5A      $ VisibleWhenSelected=�6(   $	 110��6W      	RowHeight$ 30Q�6h    .     CanUserDeleteRows .  5B        5C      $ Customer Id��6L   $
 Auto	 6a    6-   �� *
CustomerId+6a     5D      -   5        productNameColumn��$ Product Name��5D   h   $
 Auto	 6~    6H   �� *ProductName+6~     5E      -   5        subscriptionIdColumn��$ Subscription Id��5E   n   $
 Auto	 6�    6K   �� *SubscriptionId+6�     5F      -   5        issueIdColumn��$ Issue Id��5F   `   $
 Auto	 6r    6D   �� *	IssueId+6r     5G      -   5        issueDescriptionColumn��$ Issue Description��5G   r   $
 Auto	 6�    6M   �� *IssueDescription+6�     5H      -   5        classificationColumn��$ Classification��5H   n   $
 Auto	 6�    6K   �� *Classification+6�     5I      -   5        subtractColumn��   	CellStyle# [ 5J   *   $ Subtract��6R   $
 Auto	 6d    5I   E   �� *
Subtract+ �� 	Converter# [ 5J   d      RowHeaderStyle 5L      �� 5M      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6    .�5N      ��  � ��
 � ���6<   �� 5O       � ��$ 30��67   �� 5P       � ��
 �  ��6<   �� 5Q       � ��$ 3q�6A   5R      5T      �� 5U      -   5         ��Name$ buttonProposeDebitOrder��5U      $ ��Propose debit order values��6:   $	 423��6_   $ 14��6q   $	��167��6�   5V      �� 5W      -   5        $��Write to XML��5W      $	 688��60   $ 16��6B   $	��167��6R   5X      5Y      5[      �� 5\   
   $��Bank statement��6   .��5]      �� $��0,0,0,0q�6   # [ 6&   .+�5^      �� -   5        $ 
buttonLoad��5^      $+��%Load a new bank statement from a file��6-   $ 10��6]   $ 10��6n   $	��270��6~   6�     5`      -   5        $ pickerMonth��5`      $��0,0,0,0q�63   $	 178��6D   $ 91��6V   �� 5a      -   5        $ buttonSelectRange��5a      $	 523��64   $ 75��6F   $��Load the month��6v   $	��270��6�   �� 5b      -   5        $ buttonNotPosted��5b      $	 523��62   $	 111��6D   $%��Load the month - not posted yet��6s   $	��270��6�   �� 5d      -   5        $ buttonValidate��5d      $ 10��61   $	 766��6B   $��Validate the payments��6p   �� 5e      -   5        $ 
buttonPost��5e      $	 264��6-   $	 766��6?   $ ��Post the validated entries��6i   {�.  6�   �� 5g      $	 820��6   $ 75��6*   .��6:   Balance over period6O   �� 5i      -   5         ��Name$ textBalanceOverPeriod��5i      $	 960��69   $ 75��6K   $	��132��6[   $��26��6g     �� TextAlignment$  Right=�6s   6�   �� 5j      $��}��6   $	��122��6$   $	 427��61   $ 36��6C   $��46��6S   $��80(�6^   �� 5l      $��Select the month��6   $ 10��63   $ 91��6D     5n      -   5        $ SBBankStatementDataGrid��5n      
 .   . $	��554��6w   $ 10��6�   !   SelectionUnit$! CellOrRowHeader=�6�   $	 187��5o      $
��1371��6$   $ 30Q�61   $" �� IsSynchronizedWithCurrentItem$
" TrueY�6@    .  #   
IsReadOnly# .  .  ��5n   �   ��  5r      �� 5s      "  6    .�5t      ��  � ��
 � ���6<   �� 5u       � ��$ 30��67   �� 5v       � ��
 �  ��6<   �� 5w       � ��$ 3q�6A   5x       5{        5|      -    5        transactionDateColumn��# [ 5|   L   $ Payment date��6t    6�   �� *TransactionDate+# [    5}      -!   5        allocationNoColumn��$ Allocation No��5}   j   $ SizeToHeader	 6�    6I   �� *AllocationNo+6�     5~      -"   5        amountColumn��$ Amount��5~   �   $ SizeToHeader	 6�   # [ 6�    6C   �� *Amount+# [ 6�     5      -#   5        referenceColumn��$ 	Reference��5   d   $	 200	 6w    6F   �� *	Reference+6w     5�      -$   5        bankPaymentMethodColumn��$ Bank Payment Method��5�   t   $ SizeToHeader	 6�    6N   �� *BankPaymentMethod+6�     5�      -%   5        customerIdColumn��$ Customer Id��5�   �   $ SizeToHeader	 6�   # [ 5�   %    5�   G   �� *
CustomerId+$ �� Mode$$ TwoWay=�# [ % �� UpdateSourceTrigger$% 	LostFocus=�5�   %     5�      -&   5        errorMessageColumn��$ Message��5�   j   $
 auto	 6{    6I   �� *ErrorMessage+6{     5�      $ Posted��6L   $ SizeToHeader	 6\    61   �� *Posted+6\     5�      $ Payment Transaction Id��6V   $ SizeToHeader	 6v   # [ 5�   %    5�   -   �� *PaymentTransactionId+5�   %   & � ContextMenu& 5�      �� 5�      .@�5�      m� -'   5        $��Find Customer��5�   '   6>   m� 5�      -(   5        $��GoTo Customer��5�   '   6>   m� 5�      -)   5        $��Accept the payment��5�   '   6C   m� 5�      -*   5        $#��Mark as incorrectly deposited��5�   '   6N   m� 5�      -+   5        $��Mark as internal transfer��5�   '   6J   5�      5�      5�      5�      5�      5�      