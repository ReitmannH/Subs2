   M S B A M L   `   `   `  ���� M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data (    "Subs4.Presentation.CustomerUpdate2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2local clr-namespace:Subs4.Presentation     9System&clr-namespace:System;assembly=mscorlib     ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     -     �Name$  CustomerUpdateWindow��$��4q�
����  � � Title$ Customer Update Window�� � WindowStartupLocation$ CenterScreen=�$	��915��$	��915��$
��1199��$	��950�� � 	Resources  �� 
TargetType �� Property �� Value   
AlignRight*  $System.Windows.Controls.DataGridCell �� Triggers P� Property	 P� Value&    Subs4.Presentation.DateConverter  lDateConverter��%  '��       '�� %     &	  H     '  n     &	 �     �� " ��.���  � ��
 ������ " ��.���  � ��$ 27���� " �.���  � ��$ Right=��� "   P�  �@ 
IsSelected	 . . ���  � ��
 � �����  � ��
 �  ��  .��� -   
 �Name$
 CustomerGrid��$
��Auto��$
��auto��$��Stretch=�$��Stretch=�
������ � ColumnDefinitions �� $	��327 ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��Auto � � RowDefinitions �� $
��auto ��� $	��315 ��� $	��340 ��� $��* �.+��� $��0��$��0��.+�� .+��� $��
CustomerId���� $��75��$��Right=����� *
CustomerId+� .+��� $��Title��
���  ��$
��Left=�$��0,0,20,0q��� -    ��Name$ 
ComboTitle��$��63�� �� DisplayMemberPath$ Value�� �� SelectedValuePath$	 Key��$��Right=� �� SelectedValue ��  �� Path$ TitleId�� .+��� -    ��Name$ label1��$��Initials��$��28��$
��Left=�$��0,0,20,0q��� -    ��Name$ textBoxInitials��$��44��$��Right=�.��.���� $ Initials� �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=� �� ValidationRules 5  /System.Windows.Controls.ExceptionValidationRule  � .+��� -   $ label3��$��Phone��$��50��$��28��
���  ��$��0,0,20,0q�$
��Left=�$��2���� -   $ textBoxPhoneNumber��$	��114��$��Right=�.��.���� $ PhoneNumber� . $ 	LostFocus=�   �� $��1��.+��� $��
First name���� $��Status���� -   $ label4��$
��Cell��$��28���� $��Council number���� $��2��$��2��$
��Left=�.+��� -	   $ TextFirstName�� �� TextWrapping$
 Wrap=�$
��Auto��.��.���� $ 	FirstName� . $ 	LostFocus=�   �� -
   $ 
textStatus��$
 Wrap=�$
��auto�� �� 
IsReadOnly . ���� *
StatusName+ �� Mode$ OneTime=��� -   $ textBoxCellPhoneNumber��$
��auto��.��.���� $ CellPhoneNumber� . $ 	LostFocus=�   �� $
��auto������ *CouncilNumber+$ TwoWay=��� $��4��.+��� -   $ label2��$��Surname��$��28���� $��Login Email���� -   $ label5��$��Correspondence Email��$��28��
���  ���� $��3,10,0,0q� d� IsThreeState .   d� 	IsChecked �� *	Marketing+.��	Marketing�� $��5��.+��� -   $ textBoxSurname��$	��204��.��.���� $ Surname� . $ 	LostFocus=�   �� -   $ textBoxLoginEmailAddress��$	��202�� �� MaxLines$ 1��.��.���� $ 
LoginEmail� . $ 	LostFocus=�$ TwoWay=�   �� -   $ textBoxEmailAddress��$	��202��.��.���� $ EmailAddress� . $ 	LostFocus=�   � .+��� $��Correspondence��$��0,3,0,0q�.   (Subs4.Presentation.CorrespondenceControl  -   $��71��$��73��$��Right=�   Correspondence �� $ Correspondence2� . $ PropertyChanged=�$ TwoWay=�   �� $��1��$��2��.+��� $��Company���� -   $" textBoxCompanyNameUnverified��$
��auto��$��Stretch=�.��.���� $ CompanyNameUnverified� . $ 	LostFocus=�   (   "Subs4.Presentation.CompanyControl2  -     Name$ CompanyControl��$	��600��   	CompanyId �� *	CompanyId+$ TwoWay=�$ PropertyChanged=��� -   $ 	CountryId��$y�Visible=�$��10��$��10��$��4q�  J� RenderTransformOrigin$  -0.3,1.4&�.���� $ 	CountryId�$ TwoWay=� . $ PropertyChanged=�   �� $��1��$��1��.+��� $��Practice number���� $��Country���� $��Address line 1���� $��Address line 2���� $��Address line 3���� $��Address line 4���� $��	Post code���� $��1��$��3���� $��1��$��4��.+��� $��Invoice Email��$	��129��$
��Left=��� $��Statement Email��$	��129��$
��Left=��� $��WebUrl���� $��National Id���� $��
Department���� $��1��$��5��.+��� -   $ textAccountEmail��$
 Wrap=�$	��202��.��.���� $ InvoiceEmail� . $ 	LostFocus=�   �� -   $ textStatementEmail��$
 Wrap=�$	��202��.��.���� $ StatementEmail� . $ 	LostFocus=�   �� -   $
 Wrap=�$	��202��.��.���� $ WebURL� . $ 	LostFocus=�   � $	��203��.+��� -   $ textNationalId1��$
��Left=�$
 Wrap=�$��60��! �� 	MaxLength$! 6��.��.���� $ NationalId1� . $ 	LostFocus=�   �� -   $ textNationalId2��$��Center=�$
 Wrap=�$��44��$! 4��.��.���� $ NationalId2� . $ 	LostFocus=�   �� -   $ textNationalId3��$��Right=�$
 Wrap=�$��33��$! 3��$  0.636,1.136&�.��.���� $ NationalId3� . $ 	LostFocus=�   �� -   $ textDepartment��$
 Wrap=�$	��203��.��.���� $ 
Department� . $ 	LostFocus=�   �� -   " ��Name$%" checkAutomaticPaymentAllocation��$"��Automatic payment allocation�� .  $��	10,10,0,0q� �� *AutomaticPaymentAllocation++   %Subs4.Presentation.AddressTypeControl  -   #  Name$# AddressTypeControl��+   %Subs4.Presentation.AddressTypeControl$   RadioButtonChanged$+$ %AddressTypeControl_RadioButtonChanged��$
��auto��$��82��$��	0,10,0,10q�%   AddressType% �� *AddressType+$ TwoWay=��� $��2��$��1��$��2��.+�&   System.Windows.Controls.DataGrid  -   &  Name$& CodeDataGrid��'   AutoGenerateColumns' .  $	��300��$
��auto��(   
IsReadOnly( . )   SelectionMode$) Single=�*   EnableRowVirtualization* .  +   Columns+ 0	  *System.Windows.Controls.DataGridTextColumn	  -   
codeColumn��,
  &System.Windows.Controls.DataGridColumn, 
  Header$
, Code��- 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
- Auto 1  +System.Windows.Controls.DataGridBoundColumn.   Binding. �� $
 Code�	  -    addressLine4Column��$, Address Line 4��$
- Auto . �� $ AddressLine4�	  -!   addressLine3Column��$, Address Line 3��$
- Auto . �� $ AddressLine3��� -"   $��buttonKeepCode��$
��Keep��$��75��$��0,10,0,0q��� $��1��$��2��$��2��$
��Left=�$	��193��.+�� .+��� $��30��$
��Left=�$! 3������ *PracticeNumber1+$ TwoWay=��� $��30��$��Center=�$! 3������ *PracticeNumber2+$ TwoWay=��� $��70��$! 7��$��Right=����� *PracticeNumber3+$ TwoWay=�'   !Subs4.Presentation.CountryControl  -#   /  Name$/ CountryControl��$
��Auto��$��26��$
��Left=��� -$   $ textAddressLine1��$! 50��$	��193��$
��Left=�.��.���� $ Address1� . $ 	LostFocus=�$ TwoWay=�   �� -%   $ textAddressLine2��$! 50��$	��193��$
��Left=����� *
Address2+�� -&   $ textAddressLine3��$! 50��$	��193��$
��Left=�0 �� CharacterCasing$0 Upper=�.��.���� $ Address3� . $ Explicit=�$ TwoWay=�   �� -'   $ textAddressLine4��$! 50��$	��193��$
��Left=�$0 Upper=����� *
Address4+$ TwoWay=�$ Explicit=��� -(   $ textPostCode��$! 50��$	��193��$
��Left=����� *
Address5+$ TwoWay=�$ Explicit=��� -)   $��buttonKeepText��$
��Keep��$��75��$y�Visible=�$��0,10,0,0q��� $��2��$��3��$��2��.+�  -*   $& SuburbDataGrid��' .  * .  $	��300��1   RowDetailsVisibilityMode$1 VisibleWhenSelected=�2   CanUserAddRows2 .  $
��auto��( . $) Single=�$��Stretch=�+ 	  -+   addressLine3Column2��$, Address Line 3��$
- Auto . �� *AddressLine3+	  -,   addressLine4Column2��$, Address Line 4��$
- Auto . �� *AddressLine4+	  --   codeColumn2��$
, Code��$
- Auto . �� *Code+�� -.   $��buttonKeepSuburb��$
��Keep��$��75��$��0,10,0,0q��� $��2��$��5��.+��� -/   $��Submit���� -0   $��Cancel���� $��Last verification date���� -1   $ textVerification��$��23��$
 Wrap=� . 3 �� TextAlignment$3 Right=����� *VerificationDate+4 �� 	Converter#4 [   -2   $& CommentDataGrid��* . $��3��$��6��$
��auto��$1 VisibleWhenSelected=�5   CanUserDeleteRows5 . 2 . $
��auto��' .  $) Single=����� + 	  -3   commentIdColumn��$, 
Comment Id��$- SizeToHeader 6 
  
Visibility$6 Hidden=�. �� *	CommentId+	  -4   customerIdColumn��$, Customer Id��$- SizeToHeader $6 Hidden=�. �� *
CustomerId+	  -5   modifiedOnColumn��$, Modified On��$- SizeToHeader . �� *
ModifiedOn+#4 [ 	  -6   commentColumn��$, Comment��$
- auto . �� *	Comment+	  -7   modifiedByColumn��$, Modified By��$	- 150 . �� *
ModifiedBy+