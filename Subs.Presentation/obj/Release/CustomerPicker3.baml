   M S B A M L   `   `   `  ���� [  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data L HSubs.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Subs.PresentationSubs.Presentation '   !Subs.Presentation.CustomerPicker3   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9my*clr-namespace:Subs.Data;assembly=Subs.Data     1localclr-namespace:Subs.Presentation     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  CustomerPickerWindow�� � WindowState$ 	Maximized=� � WindowStartupLocation$ Manual=� � Left$ 0��
 � Top$ 20��
��� ���$	��920��$
��1000��$
��1330�� � 	Resources   Subs.Data.CustomerDoc2   customerDoc2  Subs.Data.LedgerDoc2  
ledgerDoc2  customerViewSource �� Source �� Source  transactionsViewSource �� Path ! InvoicesAndPaymentsViewSource  PaymentViewSource  InvoiceViewSource  SubscriptionsViewSource  TooMuchTooLittleViewSource%  Subs.Presentation.DateConverter 	 lIntegerConverter 
 lDateConverter%  Subs.Presentation.RandConverter  lRandConverter  
AlignRight	 �� 
TargetType
 �� Property �� Value:  4System.Windows.Controls.Primitives.DataGridRowHeader��%�  &	        &	      &	 
     7   &	 *     7  &	 P     7  &	 }     &	 �     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     '  �         ��  �� *
Customer+8   ��  �� $ Transactions�8   ��  �� $ InvoicesAndPayments�8   �� �� �� ��       �� "	 �.��� 
 � ��$ Right=��� "	  .��� 
 � ��
 � ����� 
 � ��$ 30���� 
 � ��
 �  ���� 
 � ��$ 3q�.���� -    ��Name$ tabControl1��$
��Auto��$��Stretch=�$��Stretch=�$
��Auto��$��0,0,0,0q�.@��� -    ��Name$ 	tabSearch��$��Search��$��0��.��� $��5q� � RowDefinitions �� $
��auto ��� $��* �.+��� -    ��Name$ SearchGroupBox��$Q��KSearch for an existing subscriber by choosing one of the following criteria��$	��172��$
��Left=�$��0,0,0,0q�$	��796��
������$
��1167��.���� $
��Auto��$
��Auto��$
��Left=�.+��� -    ��Name$ buttonSearchCustomerId��$��1��$��Search by Customer Id.��$��22��$	��147�� �� Left$ 20��
 �� Top$ 63�� �� 	IsDefault . �� -   $ buttonSearchSurname��$��1��$��Search by Surname��$��22��$	��147��$ 20��$	 112���� -   $ buttonSearchCompany��$��1��$��Search by Company��$��22��$	��147��$ 20��$ 12���� -   $ buttonSearchEmail��$��1��$��Search by Email��$��22��$	��147��$	 534��$ 12���� -	   $ buttonSearchInvoice��$��1��$��Search by Invoice��$��22��$	��147��$	 532��$	 112���� -
   $ buttonSearchPostalCode��$��1��$��Search by PostalCode��$��22��$	��147��$	 534��$ 63��7  1System.Windows.Forms.Integration.WindowsFormsHost  $	 185��$ 12��$��26��$	��310��   Child. #   System.Windows.Forms.ComboBox  -   comboCompany��"   System.Windows.Forms.Control   Enabled .    DropDownHeight$	 300���� -   $��	buttonNew��$	 956��$ 16��$��Capture a new customer��$��22��$	��184���� -   $��buttonNewResume��$	 956��$ 67��$$��Resume capture of new customer��$��22��$	��184��{�.  *	  $Subs.Presentation.AddressTypeControl	  -    	 Name$ AddressTypeSelector��$��78��$	 721��$ 12��$	��203���� -   $��Search by address type��$
��Left=�$��0,0,0,0q�$	��Top=�$	��203��$	 721��$	 118��$��22���� -   $��button1��$��Write result to XML��$��22��$	��184��$��Center=�$	 956��$	 118��&
   System.Windows.Controls.DataGrid
  -    
 Name$ customerDataGrid��$��1��$��1�� � DataContext# [ $ �� IsSynchronizedWithCurrentItem$
 TrueY� 
  AutoGenerateColumns .   
  EnableRowVirtualization . 
�������$
��Left=�$��0,10,0,0q� 
  SelectionUnit$ CellOrRowHeader=� 
  SelectionMode$ Single=� 
  
IsReadOnly .   
  CanUserAddRows  .  ! 
  	RowHeight$! 30Q�$
��auto��$��Stretch=�" 
  FrozenColumnCount$" 6��# 
  CanUserSortColumns# . $ 
  CanUserReorderColumns$ . ���� % 
  RowHeaderStyle% �� "	  .��� 
 � ��
 � ����� 
 � ��$ 30���� 
 � ��
 �  ���� 
 � ��$ 3q����� .��� 
 � ��$ 6q��� 
 � ��
 ����& 
  Columns& 0  *System.Windows.Controls.DataGridTextColumn  -   customerIdColumn��,  &System.Windows.Controls.DataGridColumn'   Header$' Customer Id��(   
IsReadOnly( . 1  +System.Windows.Controls.DataGridBoundColumn)   Binding) �� *
CustomerId+  -   titleColumn��$' Title��) �� *Title+  -   initialsColumn��$' Initials��) �� *
Initials+  -   firstNameColumn��$' 
First Name��) �� *	FirstName+  -   surnameColumn��$' Surname��) �� *	Surname+  -   countryNameColumn��$' Country Name��) �� *CountryName+  -   phoneNumberColumn��$' Phone Number��) �� *PhoneNumber+  -   cellPhoneNumberColumn��$' Cell Phone Number��) �� *CellPhoneNumber+  -   liabilityColumn��*   	CellStyle#* [ $' 	Liability��) �� *	Liability++ �� StringFormat$+ {0:R ### ### ##0.00}��  -   emailAddressColumn��$' Email Address��) �� *EmailAddress+  -   companyNaamColumn��$' Company Naam��) �� *CompanyNaam+  -   address1Column��$' 	Address 1��) �� *
Address1+  -   address3Column��$' 	Address 3��) �� *
Address3+  -   address4Column��$' 	Address 4��) �� *
Address4+  -    address5Column��$' 	Address 5��) �� *
Address5+  $' CPPaymentTransactionId��) �� * CheckpointPaymentTransactionId+  #* [ $' CPPaymentValue��) �� *CheckpointPaymentValue+, �� 	Converter#, [   $' CPPaymentDate��) �� *CheckpointPaymentDate+#, [
   $' CPInvoiceDate��) �� *CheckpointInvoiceDate+#, [
   -!   nationalId1Column��$' National Id 1��) �� *NationalId1+  -"   nationalId2Column��$' National Id 2��) �� *NationalId2+  -#   nationalId3Column��$' National Id 3��) �� *NationalId3+  -$   departmentColumn��$' 
Department��) �� *
Department+  -%   addressTypeColumn��$' Address Type��) �� *AddressTypeName+  -&   commentsColumn��$' Comments��) �� *
Comments+  -'   physicalAddressIdColumn��$' Physical Address Id��) �� *PhysicalAddressId+  -(   modifiedByColumn��$' Modified By��) �� *
ModifiedBy+  -)   modifiedOnColumn��$' Modified On��) �� *
ModifiedOn+#, [
 - � ContextMenu- �� .@�m� -*   $��Update��m� -+   $��Select��m� -,   . m�Name$. Profile��$��Profile��{�. m� --   $��Liability calculation��m� -.   $��Invoices��m� -/   $ ��Invoices Reset checkpoints��m� -0   $��DeliveryAddress��{��� *	IsEnabled+/ �� ElementName$/ Profile��m� -1   $��ConsolidateTarget��m� -2   $��ConsolidateSource��m� -3   $��Cancel���� -4   $��Tab_Invoice��$��Invoices��$��1��$y�Hidden=�.���  �� $��70 ��� $��40 ��� $
��Auto ��� $��40 ��� $��* �0 � ColumnDefinitions0 �� $	��19* ��� $��6* ��� $
��485* ��� $
��292* ��� $
��510* �.+�� -5   1 �Name$1 PaymentPanel��2 � Orientation$2 
Horizontal=�$��Stretch=�$
��Auto��$��0��$��5��$��	0,10,0,10q�.+��� $��0,0,20,0q�.+��� .��
CustomerId�� -6   3 ��Name$3 
CustomerId��4 �� TextAlignment$4 Right=�5 �� 
IsReadOnly5 . (  "System.Windows.Controls.DatePicker  -7   6  Name$6 PaymentDatePicker���� $��Center=�.��	Amount:�� -8   $3 textPaymentLeft��$��Center=�$��60������ $ PaymentAmount�#, [ 7 �� UpdateSourceTrigger$7 	LostFocus=�8 �� Mode$8 TwoWay=��� -9   $��comboMethod��$��Center=�$��Payment method���� -:   9 ��Name$9 comboPaymentMethod��$	 303��$ 30��$	��167��: �� DisplayMemberPath$: Value��; �� SelectedValuePath$	; Key��$��27��< �� SelectedValue< �� $ PaymentMethod�$8 OneWayToSource=�$7 	LostFocus=��� $��Reference type��$��Center=��� -;   $9 comboReferenceType��$	 350��$ 30��$	��167��$: Value��$	; Key��$��27��< �� $ ReferenceTypeId�$8 OneWayToSource=�$7 	LostFocus=��� $��	Reference��$��Center=��� -<   $��textPaymentReference��$	��208��= �� TextWrapping$
= Wrap=����� $ PaymentReference�$8 OneWayToSource=�$7 	LostFocus=��� -=   $ buttonPayManually��$��10,0,0,0q�
> � Tag$> AuthorityHigh��.��Pay manually�� ->   $��1��$��0��$��30��$
��Left=�$	��230��$> AuthorityHigh��$��3��.��Reset all checkpoints�� $��1��$��3��$��Center=�$��15(�
��� ���$	��100��.��
Payments�� -?   $ ButtonAllocate��$��1��$��5��$��Right=�$> AuthorityHigh��$	��230��.��Allocate all the payments
  -@   $ PaymentDataGrid��$��2��$��5�� .  $
��Auto��$��Stretch=�  .  ? 
  CanUserDeleteRows? .   .  . # .  $��	0,10,0,10q�$	��250������ # [ &   $' TransactionId��@   Width5  /System.Windows.Controls.DataGridLengthConverter$@ 80 ) �� *TransactionId+  $' 	Operation��$	@ 125 ) �� *	Operation+  $
' Date��$@ 80 ) �� *Date+#, [
 4  .System.Windows.Controls.DataGridTemplateColumn  $' 	Reference��$	@ 150 A   CellTemplateA �� .R��� $
��Auto��$��3q�$
= Wrap=�.������ $ 
Reference2�.��  $' Value��$	@ 100 #* [ ) �� *Value+#, [   $' Unallocated portion��$	@ 120 #* [ ) �� *InvoiceBalance+#, [   $' Unallocated balance��$	@ 120 #* [ ) �� *StatementBalance+#, [ - �� .@�m� -A   $!��Assign refund to payment...��$> AuthorityHigh��B � ToolTip$!B Allocate a historic refund.��m� -B   $��Bounce payment��m� -C   $��Highlight allocations��m� -D   $��Refund payment��m� -E   $��Reverse payment��m� -F   $#��Select payment for allocation��$> AuthorityHigh��m� -G   $��Set as checkpoint��$#B Use the current row as input.��$> AuthorityHigh��m� -H   $"��Set as reduced checkpoint...��$0B *You will  be prompted for a reduced value.��$> AuthorityHigh���� -I   $��3��$��0��$
��Left=�$	��230��$B Invoke input.��$> AuthorityHigh��$��3��.��Set a checkpoint for invoices�� $��3��$��3��$��Center=�$��15(�
��� ���$	��100��.��
Invoices�� -J   $��3��$��4��$��Right=�$	��230��$> AuthorityMedium��.��Create a statement
  -K   $ InvoiceDataGrid��$��4��$��5�� .  $
��Auto��$��Stretch=�$
��auto��$��Stretch=�  .  ? .   .  . # .  $��	0,10,0,10q�$
 TrueY�$��2������ # [ C �� 
GroupStyleC (  "System.Windows.Controls.GroupStyle  D   HeaderTemplateD �� .R��� $��30��$
��Bold"�
���  ��
�������$��0,20,0,0q�&   $' TransactionId��$@ 80 ) �� *TransactionId+  $' Invoice��$@ 80 ) �� *	InvoiceId+  $' 	Operation��$	@ 125 ) �� *	Operation+  $
' Date��$@ 80 ) �� *Date+#, [
   $' 	Reference��$	@ 150 A �� .R��� $
��Auto��$��3q�$
= Wrap=�.������ $ 
Reference2�.��  $' Value��$	@ 100 #* [ ) �� *Value+#, [   $' Invoice balance��$	@ 100 #* [ ) �� *InvoiceBalance+#, [   $' Statement balance��$	@ 110 #* [ ) �� *StatementBalance+#, [ - �� .@�m� -L   $��Allocate payment��$> AuthorityHigh��m� -M   $��Deallocate payment��$> AuthorityHigh��m� -N   $ ��Reverse  writeoff of money��$> AuthorityHigh��m� -O   $��Recreate the invoice��$> AuthorityHigh��m� -P   $��View Subscriptions��m� -Q   $ ��Write off a certain amount��$> AuthorityHigh���� -R   $ tabSubscription��$��Subscription��$��2��$y�Visible=�.��� # [ 0 �� $��16 ��� $	��437 ��� $
��Auto � �� $��* �.+��� $��0��$��2��.+��� $��Center=�.��INVOICES AND PAYMENTS
  -S   $ SubscriptionDataGrid�� .   . $��0,0,0,0q�E 
  RowDetailsVisibilityMode$E VisibleWhenSelected=�$
��Left=�$! 30Q�  .  ? .  $
��Auto��$
��auto��$��Stretch=����� # [ &   $' SubscriptionId��$	@ 100 #* [ ) �� *SubscriptionId+  $' Status��$	@ 100 ) �� *Status+  $' Product��$	@ 150 ) �� *ProductName+  $' Value��$	@ 100 #* [ ) �� *Value+#, [ - �� .@�m� -T   $��Status and history��m� -U   $��Deliver on credit��$> AuthorityMedium��9  3Subs.Presentation.SubscriptionStatusDisplayControl2  -V   F  Name$'F !gSubscriptionStatusDisplayControl��$��2��$��11,0,0,0q��� $"��Over payments and deliveries��$��3��$��23��$��Bottom=�.��� 0 �� $	��76* ��� $
��195* ��� $��7* ��� $��9 ��� $��91 ��� $
��278* ��� $
��278* ��� $	��100 ��� $
��278* � �� $��40 ��� $��* �.+��� -W   $��0��$��Who paid too much?��$��3���� -X   G ��Name$G label2��$��3��$��In excess of��$��28��$��2��$��0,6,0,7q��� -Y   $3 textOverPaid��$��5��$��23��$	��120��$4 Right=�$
��Left=�$	��0,9q�$��1���� -Z   $��6��$!��Deliveries without payment?���� -[   $G label3��$��7��$��In excess of��$��28��$��0,6,0,7q��� -\   $3 textOverDelivered��$��8��$��23��$	��120��$4 Right=�$
��Left=�$	��0,9q�$��1��
  -]   $ PaidTooMuchDataGrid��$��1��$��9�� .  .  $! 30Q� . $
��auto��$��Stretch=����� # [ &   $' Customer��$
@ Auto ) �� *
CustomerId+  $' Surname��$
@ Auto ) �� *	Surname+  $' Company��$
@ Auto ) �� *CompanyName+  #* [ $' Overpayment��$
@ Auto ) �� *Discrepancy+#, [ - �� .@�m� -^   $��Invoices��
  -_   $ OverDeliveredDataGrid��$��1��$��9�� .  .  $! 30Q�$y�Hidden=����� # [ &   $' Customer��$
@ Auto ) �� *
CustomerId+  $' Surname��$
@ Auto ) �� *	Surname+  $' Company��$
@ Auto ) �� *CompanyName+  #* [ $' Delivered without payment��$
@ Auto ) �� *	Liability+#, [ - �� .@�m� -`   $��Invoices���� -a   $ 
tabRunning��$��Liability calculation��$��4��.���  �� $��40 ��� $��* �.+�� .+��� -b   $ ButtonRunningToXML��.��Write to XML�� .��Your current liability is:�� -c   $3 textCurrentLiability��$��	10,0,10,0q�5 . �� -d   $> AuthorityHigh��.��Synchronise liability
  -e   $ LiabilityDataGrid�� .   . $
��auto��$��Stretch=�$��1��$��0,0,0,0q�$E VisibleWhenSelected=�$
��Left=�&   $' TransactionId��$@ 80 ) �� *TransactionId+  $
' Date��$@ 80 ) �� *Date+#, [
   $' 	Operation��$	@ 105 ) �� *	Operation+  $' 	InvoiceId��$	@ 105 ) �� *	InvoiceId+  $' SubscriptionId��$	@ 105 ) �� *SubscriptionId+  $' Value��$@ 70 #* [ ) �� *Value+#, [   $' Balance��$@ 70 #* [ ) �� *	Balance+#, [ �� $*��$Ad hoc invoice and payment statement��$��5��.��)  #Subs.Presentation.StatementControl2  -f   H  Name$H lStatementControl2���� -g   $ tabXps��$��	XPSViewer��$��3��$y�Hidden=�.��Z� -h   I Z�Name$I DocumentViewer1��$
��Auto��$
��Auto��