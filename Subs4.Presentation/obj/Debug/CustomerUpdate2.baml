   M S B A M L   `   `   `  ����M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 6?   (    "Subs4.Presentation.CustomerUpdate2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:Subs4.Presentation     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     6?   -   5          �Name$  CustomerUpdateWindow��5   	   $��4q�6'   
����  � � Title$ Customer Update Window��6N    � WindowStartupLocation$ CenterScreen=�6m   $	��915��5   .   $	��915��6;   $
��1199��6K   $	��950��6X    � 	Resources 5	       �� 
TargetType �� Property �� Value   
AlignRight*  $System.Windows.Controls.DataGridCell �� Triggers P� Property	 P� Value&    Subs4.Presentation.DateConverter  lDateConverter��%�  '��       '�� J     &	  �     '  �     &	 �    �� 5
   
   " ��6   .�5      ��  � ��
 ����6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 27��6'   5      �� 5   
   " �6#   .�5      ��  � ��$ Right=�64   5      �� 5   
   "  6    5      P� 5       �@ 
IsSelected	 . . �5      ��  � ��
 � ���63   �� 5       � ��
 �  ��63   5      5        5   
   6   5      .��5       � -   5        
 �Name$
 CustomerGrid��5       $
��Auto��6!   $
��auto��6.   $��Stretch=�6<   $��Stretch=�6Z   
������ � ColumnDefinitions 5!   
   �� 5"      $	��327 �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $
��Auto �6    � RowDefinitions 5)   
   �� 5*      $
��auto �6   �� 5+      $	��315 �6   �� 5,      $	��340 �6   �� 5-      $��* �6   .+�53   
   �� $��0��6   $��0��6"   .+�54      � .+�55      �� $��
CustomerId��6   �� 56      $��75��6   $��Right=�6B   ��6#   �� *
CustomerId+6B   58      � 5:      .+�5;      �� $��Title��6   
���  ��$
��Left=�69   $��0,0,20,0q�6T   �� 5<      -   5         ��Name$ 
ComboTitle��5<      $��63��6/    �� DisplayMemberPath$ Value��6:    �� SelectedValuePath$	 Key��6T   $��Right=�6�    �� SelectedValue 6l   ��  �� Path$ TitleId�6�   5=      � 5@      .+�5A      �� -   5         ��Name$ label1��5A   8   $��Initials��6   $��28��6,   $
��Left=�6H   $��0,0,20,0q�6c   �� 5B      -   5         ��Name$ textBoxInitials��5B      $��44��63   $��Right=�6a   .��6}   .��5C      �� $ Initials�6    �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=�6M    �� ValidationRules 5D      5  /System.Windows.Controls.ExceptionValidationRule  5E      5G      5H      5I      � 5J      .+�5K      �� -   5        $ label3��5K   ?   $��Phone��6   $��50��6(   $��28��63   
���  ��$��0,0,20,0q�6`   $
��Left=�6r   $��2��6�   �� 5L      -   5        $ textBoxPhoneNumber��5L      $	��114��66   $��Right=�6e   .��6�   .��5M      �� $ PhoneNumber�6    . $ 	LostFocus=�6P    5N        5O      5Q      5R      5S      5T      �� 5V   
   $��1��6   .+�5W      �� $��
First name��6   �� 5X      $��Status��6   �� 5Y      -   5        $ label4��5Y   /   $
��Cell��6   $��28��6#   6/   �� 5Z      $��Council number��6   5[      �� 5^   
   $��2��6   $��2��6%   $
��Left=�69   .+�5_      �� -	   5        $ TextFirstName��5_       �� TextWrapping$
 Wrap=�6-   $
��Auto��6A   .��6q   .��5`      �� $ 	FirstName�6    . $ 	LostFocus=�6J    5a        5b      5d      5e      �� 5i      -
   5        $ 
textStatus��5i   7   $
 Wrap=�6   $
��auto��6*    �� 
IsReadOnly . ��6]   �� *
StatusName+ �� Mode$ OneTime=��� 5k      -   5        $ textBoxCellPhoneNumber��5k      $
��auto��66   .��6f   .��5l      �� $ CellPhoneNumber�6    . $ 	LostFocus=�6P    5m        5n      5p      5q      �� 5r      $
��auto��6   ��6$   �� *CouncilNumber+$ TwoWay=�5t      �� 5w   
   $��4��6   .+�5x      �� -   5        $ label2��5x   2   $��Surname��6   $��28��6&   62   �� 5y      $��Login Email��6   �� 5z      -   5        $ label5��5z   ?   $��Correspondence Email��6   $��28��63   
���  ��6O   �� 5{      $��3,10,0,0q�6    d� IsThreeState .   d� 	IsChecked 6)   �� *	Marketing+.��6_   	Marketing6j   5}      �� 5   
   $��5��6   .+�5�      �� -   5        $ textBoxSurname��5�      $	��204��6Q   .��6]   .��5�      �� $ Surname�6    . $ 	LostFocus=�6H    5�        5�      5�      5�      �� 5�      -   5        $ textBoxLoginEmailAddress��5�      $	��202��6[    �� MaxLines$ 1��6g   .��6u   .��5�      �� $ 
LoginEmail�6    . $ 	LostFocus=�6K   $ TwoWay=�6k    5�        5�      5�      5�      �� 5�      -   5        $ textBoxEmailAddress��5�      $	��202��6V   .��6b   .��5�      �� $ EmailAddress�6    . $ 	LostFocus=�6M    5�        5�      5�      5�      � 5�      .+�5�      �� $��Correspondence��6   $��0,3,0,0q�61   .   (Subs4.Presentation.CorrespondenceControl  5�      -   5        $��71��5�   .   $��73��6:   $��Right=�6h      Correspondence 5�      �� 5�      $ Correspondence2�6"    . $ PropertyChanged=�6X   $ TwoWay=�6~    5�        5�   "   5�      5�      5�      5�      �� 5�   
   $��1��6   $��2��6"   .+�5�      �� $��Company��6   �� 5�      -   5        $" textBoxCompanyNameUnverified��5�      $
��auto��6<   $��Stretch=�6l   .��6�   .��5�      �� $ CompanyNameUnverified�6    . $ 	LostFocus=�6V    5�        5�      5�      5�      (   "Subs4.Presentation.CompanyControl2  5�      -   5          Name$ CompanyControl��5�   $   $	��600��6<      	CompanyId 5�   0   �� *	CompanyId+$ TwoWay=�$ PropertyChanged=��� 5�      -   5        $ 	CountryId��5�      $y�Visible=�6'   $��10��6_   $��10��6j   $��4q�6v     J� RenderTransformOrigin$  -0.3,1.4&�6�   .��5�      �� $ 	CountryId�6   $ TwoWay=�6+    . $ PropertyChanged=�6X    5�        5�      5�      5�      5�      �� 5�   
   $��1��6   $��1��6"   .+�5�      �� $��Practice number��6   �� 5�      $��Country��6   �� 5�      $��Address line 1��6   �� 5�      $��Address line 2��6   �� 5�      $��Address line 3��6   �� 5�      $��Address line 4��6   �� 5�      $��	Post code��6   5�      �� 5�   
   $��1��6   $��3��6"   5�      �� 5�   
   $��1��6   $��4��6#   .+�5�      �� $��Invoice Email��6   $	��129��6,   $
��Left=�68   �� 5�      $��Statement Email��6   $	��129��6.   $
��Left=�6:   �� 5�      $��WebUrl��6   �� 5�      $��National Id��6   �� 5�      $��
Department��6   5�      �� 5�   
   $��1��6   $��5��6"   .+�5�      �� -   5        $ textAccountEmail��5�   *   $
 Wrap=�6   $	��202��6g   .��6s   .��5�      �� $ InvoiceEmail�6    . $ 	LostFocus=�6M    5�        5�      5�      5�      �� 5�      -   5        $ textStatementEmail��5�   +   $
 Wrap=�6   $	��202��6j   .��6v   .��5�      �� $ StatementEmail�6    . $ 	LostFocus=�6O    5�        5�      5�      5�      �� 5�      -   5        $
 Wrap=�5�      $	��202��6M   .��6Z   .��5�      �� $ WebURL�6    . $ 	LostFocus=�6G    5�        5�      5�      5�      � 5�      $	��203��6   .+�5�      �� -   5        $ textNationalId1��5�   T   $
��Left=�6   $
 Wrap=�65   $��60��6I   ! �� 	MaxLength$! 6��6m   .��6�   .��5�      �� $ NationalId1�6    . $ 	LostFocus=�6L    5�        5�      5�      5�      �� 5�      -   5        $ textNationalId2��5�   V   $��Center=�6   $
 Wrap=�67   $��44��6K   $! 4��6o   .��6�   .��5�      �� $ NationalId2�6    . $ 	LostFocus=�6P    5�        5�      5�      5�      �� 5�      -   5        $ textNationalId3��5�   U   $��Right=�6   $
 Wrap=�66   $��33��6J   $! 3��6n   $  0.636,1.136&�6�   .��6�   .��5�      �� $ NationalId3�6    . $ 	LostFocus=�6P    5�        5�      5     5     5     �� 5     -   5        $ textDepartment��5     $
 Wrap=�6.   $	��203��6B   .��6q   .��5     �� $ 
Department�6    . $ 	LostFocus=�6K    5       5	     5     5     �� 5     -   5        " ��Name$%" checkAutomaticPaymentAllocation��5     $"��Automatic payment allocation��6@    .  $��	10,10,0,0q�5      5  g   �� *AutomaticPaymentAllocation+5  *   +   %Subs4.Presentation.AddressTypeControl  5     -   5        #  Name$# AddressTypeControl��5  '   +   %Subs4.Presentation.AddressTypeControl$   RadioButtonChanged$+$ %AddressTypeControl_RadioButtonChanged��5  '   $
��auto��5  D   $��82��6Q   $��	0,10,0,10q�5  b   %   AddressType% 5  ]   �� *AddressType+$ TwoWay=�5  b   5     �� 5  
   $��2��6   $��1��6#   $��2��64   .+�5     &   System.Windows.Controls.DataGrid  -   5        &  Name$& CodeDataGrid��5     '   AutoGenerateColumns' .  $	��300��6I   $
��auto��6X   (   
IsReadOnly( . )   SelectionMode$) Single=�6w   *   EnableRowVirtualization* .  +   Columns+ 5     0	  *System.Windows.Controls.DataGridTextColumn	  5     -   5        
codeColumn��,
  &System.Windows.Controls.DataGridColumn, 
  Header$
, Code��5  \   - 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
- Auto 6j   1  +System.Windows.Controls.DataGridBoundColumn.   Binding. 6=   �� $
 Code�6j   	  5     -    5        addressLine4Column��$, Address Line 4��5  k   $
- Auto 6�   . 6E   �� $ AddressLine4�6�   	  5     -!   5        addressLine3Column��$, Address Line 3��5  k   $
- Auto 6�   . 6E   �� $ AddressLine3�6�   5     �� 5     -"   5        $��buttonKeepCode��5     $
��Keep��6+   $��75��6:   $��0,10,0,0q�6b   5     �� 5   
   $��1��6   $��2��6"   $��2��62   $
��Left=�6F   $	��193��6a   .+�5!     � .+�5"     �� $��30��6   $
��Left=�6&   $! 3��6o   ��6A   �� *PracticeNumber1+$ TwoWay=�6o   �� 5#     $��30��6   $��Center=�6T   $! 3��6q   ��6&   �� *PracticeNumber2+$ TwoWay=�6q   �� 5$     $��70��6   $! 7��6U   $��Right=�6c   ��6'   �� *PracticeNumber3+$ TwoWay=�6c   5%     '   !Subs4.Presentation.CountryControl  5'     -#   5        /  Name$/ CountryControl��5'  #   $
��Auto��6;   $��26��6H   $
��Left=�6T   �� 5(     -$   5        $ textAddressLine1��5(     $! 50��60   $	��193��6?   $
��Left=�6n   .��6�   .��5)     �� $ Address1�6    . $ 	LostFocus=�6I   $ TwoWay=�6i    5*       5+     5-     5.     �� 5/     -%   5        $ textAddressLine2��5/     $! 50��61   $	��193��6@   $
��Left=�6f   ��6L   �� *
Address2+6f   �� 50     -&   5        $ textAddressLine3��50     $! 50��60   $	��193��6?   $
��Left=�6n   0 �� CharacterCasing$0 Upper=�51     .��6U   .��52     �� $ Address3�6    . $ Explicit=�6I   $ TwoWay=�6h    53       54     56     57     �� 59     -'   5        $ textAddressLine4��59     $! 50��61   $	��193��6@   $
��Left=�6�   $0 Upper=�5:     ��59  L   �� *
Address4+$ TwoWay=�$ Explicit=�5:  /   �� 5;     -(   5        $ textPostCode��5;     $! 50��6,   $	��193��6;   $
��Left=�5<     ��5;  G   �� *
Address5+$ TwoWay=�$ Explicit=�5<  1   �� 5=     -)   5        $��buttonKeepText��5=     $
��Keep��6+   $��75��6:   $y�Visible=�6b   $��0,10,0,0q�6w   5?     �� 5A  
   $��2��6   $��3��6"   $��2��63   .+�5B       -*   5        $& SuburbDataGrid��5B     ' .  * .  $	��300��6k   1   RowDetailsVisibilityMode$1 VisibleWhenSelected=�6y   2   CanUserAddRows2 .  $
��auto��5C  .   ( . $) Single=�6M   $��Stretch=�6d   + 5D     	  5E     -+   5        addressLine3Column2��$, Address Line 3��5E  g   $
- Auto 6   . 6F   �� *AddressLine3+6   	  5F     -,   5        addressLine4Column2��$, Address Line 4��5F  g   $
- Auto 6   . 6F   �� *AddressLine4+6   	  5G     --   5        codeColumn2��$
, Code��5G  W   $
- Auto 6e   . 6>   �� *Code+6e   5I     �� 5J     -.   5        $��buttonKeepSuburb��5J     $
��Keep��6-   $��75��6<   $��0,10,0,0q�6f   5K     �� 5M  
   $��2��6   $��5��6"   .+�5N     �� -/   5        $��Submit��5N     6&   �� 5O     -0   5        $��Cancel��5O     6&   �� 5P     $��Last verification date��6   �� 5Q     -1   5        $ textVerification��5Q     $��23��60   $
 Wrap=�6<    . 3 �� TextAlignment$3 Right=�5R  '   ��5Q  P   �� *VerificationDate+4 �� 	Converter#4 [ 5R  '   5T       5X  
   -2   5        $& CommentDataGrid��5X     * . $��3��6c   $��6��6p   $
��auto��6�   $1 VisibleWhenSelected=�5Y     5   CanUserDeleteRows5 . 2 . $
��auto��6x   ' .  $) Single=�6�   ��5X  K   �� + 5Z     	  5[     -3   5        commentIdColumn��$, 
Comment Id��5[  \   $- SizeToHeader 6p   6 
  
Visibility$6 Hidden=�6�   . 6>   �� *	CommentId+6�   	  5\     -4   5        customerIdColumn��$, Customer Id��5\  ^   $- SizeToHeader 6s   $6 Hidden=�6�   . 6?   �� *
CustomerId+6�   	  5]     -5   5        modifiedOnColumn��$, Modified On��5]  ?   $- SizeToHeader 6T   . 6i   �� *
ModifiedOn+#4 [ 	  5^     -6   5        commentColumn��$, Comment��5^  X   $
- auto 6i   . 6<   �� *	Comment+6i   	  5_     -7   5        modifiedByColumn��$, Modified By��5_  ^   $	- 150 6s   . 6?   �� *
ModifiedBy+6s   5a     5b     5c     