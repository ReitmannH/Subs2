   M S B A M L   `   `   `  ����M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  5   	   D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 5   	   .    (Subs4.Presentation.AdministrationCompany   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Subs4.Presentation     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5   	     � Title$  Company administration��5	   	   $��903.787��6(   $	��400��69   $
��1100��6I   $
��1226��6Y    � WindowStartupLocation$ Manual=�5
   	    � 	Resources 5      !  Subs.Data.AdministrationDoc   administrationDoc  companyViewSource �� Source �� Source �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius*  $System.Windows.Controls.DataGridCell
 �� Triggers P� Property P� Value��%�  &	        &	      7   '�� @     '  �      5   
   6!   �� 5   
    69   �� *	Company+8   �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 20��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��
borderZero��6!   $��2q�63   
���   �
������$	 10��6s   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      �� 5   
   "  6   
 5      P� 5        �@ 
IsSelected . . �5!      ��  � ��
 � ���63   �� 5"       � ��
 �  ��63   5#      5%      5&      .��5'      �  � RowDefinitions 5(   
   �� 5)      $��80 �6   �� 5*      $��* �6   �� 5+      $��* �6    � ColumnDefinitions 5.   
   �� 5/      $��* �6   �� 50      $��* �6   �� 51      $��* �6   �� 52      $��* �6   .+�56   
   �� -   5        $��SearchString��56      $��23��6&    �� TextWrapping$
 Wrap=�62   $	��231��6F   $	��Top=�6R   $��0,10,0,0q�6j   �� 57   
   $��1��6   .+�58      �� -   5        $��buttonSearchOnCompany��58      $��Search on company name��62   $	��284��6T   $��23��6�   $��0,10,0,0q�6�   �� 59      -   5        $#��buttonSearchOnVatregistration��59      $��Search on VatRegistration��6:   $	��284��6^   $��24��6�   $��0,10,0,0q�6�   5:      �� 5;   
   $��2��6   .+�5<      �� -   5        $ ��buttonSearchOnVendorNumber��5<      $��Search on VendorNumber��67    �� Left$	 604��6X   
 �� Top$ 14��6j   $	��254��6z   $��0,10,0,0q�6�   �� 5=      -   5        $-��'buttonSearchOnCompanyRegistrationNumber��5=      $)��#Search on CompanyRegistrationNumber��6D   $	 604��6r   $ 59��6�   $	��254��6�   $��22��5>      $��0,10,0,0q�6   5?      &   System.Windows.Controls.DataGrid  5A   
   -   5          Name$ companyDataGrid��5A      $��1��6,   $��2��69   $��3��6J      AutoGenerateColumns .     EnableRowVirtualization . $
��Auto��6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�5B      $��Stretch=�6@   $��0,0,0,10q�6\   $
��Auto��5C      $��Stretch=�6      CanUserDeleteRows .     	RowHeight$ 30Q�6Z   ��5D      �� 5E       �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=�69   # [ 6Y    �� ValidationRules 5F      5  /System.Windows.Controls.ExceptionValidationRule  5G      5  /System.Windows.Controls.DataErrorValidationRule  5H      ;  5System.Windows.Controls.NotifyDataErrorValidationRule  5I      5K         RowHeaderStyle 5N      �� 5O      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5P      ��  � ��
 � ���64   �� 5Q       � ��$ 30��6/   �� 5R       � ��
 ��  �64   �� 5S       � ��$ 3q�69   5T         Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      -   5        CompanyColumn��,	  &System.Windows.Controls.DataGridColumn 	  Header$ Company��5W   =    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 auto
 6N    	  MinWidth$	 250Q�6[     	  CanUserSort  . 1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5X      �� 5Y      " �� Path$" CompanyName�6"   5Z      5]        5^      -   5        VatRegistrationColumn��$ VatRegistration��5^   h   $
 auto
 6�     . $ 80Q�5_   4   ! 5^   D   �� *VatRegistration+5_   4     5`      -	   5        VendorNumber��$ VendorNumber��5`   \   $
 auto
 6r     . $ 90Q�5a   4   ! 5`   ;   �� *VendorNumber+5a   4     5b      -
   5        CompanyRegistrationNumber��$ CompanyRegistrationNumber��5b   v   $
 auto
 6�     . $ 90Q�5c   4   ! 5b   H   �� *CompanyRegistrationNumber+5c   4   5e      �� 5g   
   $��0��6   $��3��6!   $��2��61   $��Consolidate��6D   $	��200��6Y   $	��Top=�6f   .��5h      �� .+�5i      �� -   5        $��buttonSelectSource��5i      $��Mark selection as source��63   $	��164��6V   $��0,10,0,0q�6�   �� 5j      -   5        $��
textSource��5j      $	��273��6,   $��0,10,0,0q�68   �� 5l      -   5        $��buttonSelectTarget��5l      $��Mark selection as target��63   $	��164��6W   $��0,10,0,0q�6�   �� 5m      -   5        $��
textTarget��5m      $	��273��6,   $��0,10,0,0q�68   �� 5o      -   5        $��buttonConsolidateCompany��5o      $��Consolidate��69   $	��164��6P   $��0,10,0,0q�6�   5p      5r      �� 5s   
   $��3��6   $��3��6%   $��Bottom=�62   .+�5t      �� -   5        $��buttonUpdateCompany��5t      $��Update��60   $	��164��6A   $��0,10,0,0q�6o   �� 5u      -   5        $��buttonAddCompany��5u      $	��Add��6.   $	��164��6<   $	 391��6H   $��25��6x   $��0,10,0,0q�6�   �� 5v      -   5        $��buttonRemoveCompany��5v      $��Remove unlinked companies��60   $	��164��6T   $��	0,10,0,10q�5w      # � ToolTip$2# ,Remove companies not linked to any customer.��6(   $��30��6_   5x      5y      5z      