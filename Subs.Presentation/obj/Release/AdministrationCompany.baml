   M S B A M L   `   `   `  ���� L  HSubs.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Subs.PresentationSubs.Presentation  D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data -    'Subs.Presentation.AdministrationCompany   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:Subs.Presentation     ;Data*clr-namespace:Subs.Data;assembly=Subs.Data       � Title$  Company administration��$��903.787��$	��400��$
��1100��$
��1226�� � WindowStartupLocation$ Manual=� � 	Resources !  Subs.Data.AdministrationDoc   administrationDoc  companyViewSource �� Source �� Source �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius*  $System.Windows.Controls.DataGridCell
 �� Triggers P� Property P� Value��%�  &	        &	      7   '�� $     '        ��  �� *	Company+8   �� " ��.���  �@�OverridesDefaultStyle . ��  �@�Cursor$
 Hand����  � ��$ 20����  � �� �� " ��.R��� $��
borderZero��$��2q�
���   �
������$	 10��._��� $��Center=�$��Center=��� "  
 P�  �@ 
IsSelected . . ���  � ��
 � �����  � ��
 �  ��.���  � RowDefinitions �� $��80 ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $��SearchString��$��23�� �� TextWrapping$
 Wrap=�$	��231��$	��Top=�$��0,10,0,0q��� $��1��.+��� -   $��buttonSearchOnCompany��$��Search on company name��$	��284��$��23��$��0,10,0,0q��� -   $#��buttonSearchOnVatregistration��$��Search on VatRegistration��$	��284��$��24��$��0,10,0,0q��� $��2��.+��� -   $ ��buttonSearchOnVendorNumber��$��Search on VendorNumber�� �� Left$	 604��
 �� Top$ 14��$	��254��$��0,10,0,0q��� -   $-��'buttonSearchOnCompanyRegistrationNumber��$)��#Search on CompanyRegistrationNumber��$	 604��$ 59��$	��254��$��22��$��0,10,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ companyDataGrid��$��1��$��2��$��3��   AutoGenerateColumns .     EnableRowVirtualization . $
��Auto��   RowDetailsVisibilityMode$ VisibleWhenSelected=�$��Stretch=�$��0,0,0,10q�$
��Auto��$��Stretch=�   CanUserDeleteRows .     	RowHeight$ 30Q�����  �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=�# [  �� ValidationRules 5  /System.Windows.Controls.ExceptionValidationRule  5  /System.Windows.Controls.DataErrorValidationRule  ;  5System.Windows.Controls.NotifyDataErrorValidationRule     RowHeaderStyle �� :  4System.Windows.Controls.Primitives.DataGridRowHeader"  .���  � ��
 � �����  � ��$ 30����  � ��
 ��  ���  � ��$ 3q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   CompanyColumn��,	  &System.Windows.Controls.DataGridColumn 	  Header$ Company�� 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 auto
  	  MinWidth$	 250Q�  	  CanUserSort  . 1  +System.Windows.Controls.DataGridBoundColumn!   Binding! �� " �� Path$" CompanyName�  -   VatRegistrationColumn��$ VatRegistration��$
 auto
   . $ 80Q�! �� *VatRegistration+  -	   VendorNumber��$ VendorNumber��$
 auto
   . $ 90Q�! �� *VendorNumber+  -
   CompanyRegistrationNumber��$ CompanyRegistrationNumber��$
 auto
   . $ 90Q�! �� *CompanyRegistrationNumber+�� $��0��$��3��$��2��$��Consolidate��$	��200��$	��Top=�.���� .+��� -   $��buttonSelectSource��$��Mark selection as source��$	��164��$��0,10,0,0q��� -   $��
textSource��$	��273��$��0,10,0,0q��� -   $��buttonSelectTarget��$��Mark selection as target��$	��164��$��0,10,0,0q��� -   $��
textTarget��$	��273��$��0,10,0,0q��� -   $��buttonConsolidateCompany��$��Consolidate��$	��164��$��0,10,0,0q��� $��3��$��3��$��Bottom=�.+��� -   $��buttonUpdateCompany��$��Update��$	��164��$��0,10,0,0q��� -   $��buttonAddCompany��$	��Add��$	��164��$	 391��$��25��$��0,10,0,0q��� -   $��buttonRemoveCompany��$��Remove unlinked companies��$	��164��$��	0,10,0,10q�# � ToolTip$2# ,Remove companies not linked to any customer.��$��30��