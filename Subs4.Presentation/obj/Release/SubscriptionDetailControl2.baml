   M S B A M L   `   `   `  ���� D  @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data  M ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation 3   -Subs4.Presentation.SubscriptionDetailControl2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     2local clr-namespace:Subs4.Presentation     -     >�Name$  UserControl��$
��auto��$
��auto��$
��Left=�
����  �$��3q� � 	Resources &   Subs4.Presentation.DateConverter   lDateConverter&   Subs4.Presentation.RandConverter  lRandConverter    Subs.Data.SubscriptionDoc3  subscriptionDoc3  subscriptionViewSource �� Source �� Source  
AlignRight �� 
TargetType �� Property �� Value��%�   &	        &	      &	 
     &	      7  &	 :     '�� `           ��  �� *SubscriptionDerived+8   �� " �.���  � ��$ Right=��� " ��.���  � ��
 ����.���  � DataContext# [ $��0,0,0,0q�$
��Auto��$
��Auto��$��Stretch=�$��Stretch=� � RowDefinitions �� $��* �.+�&   System.Windows.Controls.DataGrid  -   	  Name$ 	 subscriptionDetailDataGrid��
   AutoGenerateColumns
 .     EnableRowVirtualization . $
��auto��$��Stretch=�$��10,10,10,10q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�   SelectionMode$ Single=�   SelectionUnit$ CellOrRowHeader=�   AlternatingRowBackground# � ��   CanUserAddRows .     CanUserDeleteRows .     FrozenColumnCount$ 5��   
IsReadOnly .    	RowHeight$ 30Q�����    RowHeaderStyle �� :  4System.Windows.Controls.Primitives.DataGridRowHeader"  .���  � ��
 � �����  � ��$ 30����  � ��
 ��  ���  � ��$ 3q�   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � ��$ 16(���  � ��$ 3q���  � ��
 � �����  � ��
 ��  ���  � ��$ 3q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   subscriptionIdColumn��,  &System.Windows.Controls.DataGridColumn   	CellStyle# [    Header$ Subscription Id��   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *SubscriptionId+  -   statusNameColumn��$ Status Name��$
 auto	  �� *StatusString+  -   payerSurnameColumn��$ Payer Surname��$
 auto	  �� *PayerSurname+  -   receiverSurnameColumn��$ Receiver Surname��$
 auto	  �� *ReceiverSurname+  -   productNameColumn��$ Product Name��$
 auto	  �� *ProductName+  $ 	InvoiceId��$
 auto	  �� *	InvoiceId+  $ 
ProFormaId��$
 auto	  �� *
ProFormaId+4  .System.Windows.Controls.DataGridCheckBoxColumn  -   renewColumn��$ Renewal notice��$
 auto	  �� *RenewalNotice+  -	   automaticrenewColumn��$ Automatic renew��$
 auto	  �� *AutomaticRenewal+  -
   payerColumn��# [ $ PayerId��$
 auto	  �� *	PayerId+  -   receiverColumn��# [ $ 
ReceiverId��$
 auto	  �� *
ReceiverId+  -   unitsPerIssueColumn��# [ $ Units Per Issue��$
 auto	  �� *UnitsPerIssue+  -   payerCompanyColumn��$ Payer Company��$
 Auto	  �� *PayerCompany+