   M S B A M L   `   `   `  ����D  @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data  5      M ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation 5      3   -Subs4.Presentation.SubscriptionDetailControl2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5      2local clr-namespace:Subs4.Presentation     5      -   5          >�Name$  UserControl��5	   I   $
��auto��5      $
��auto��6,   $
��Left=�6:   
����  �$��3q�5	   5    � 	Resources 5
      &   Subs4.Presentation.DateConverter   lDateConverter&   Subs4.Presentation.RandConverter  lRandConverter    Subs.Data.SubscriptionDoc3  subscriptionDoc3  subscriptionViewSource �� Source �� Source  
AlignRight �� 
TargetType �� Property �� Value��%L  &	        &	      &	 &     &	 9     7  &	 r     '�� �       5   
   6     5   
   6     5   
   6    �� 5   
    6>   �� *SubscriptionDerived+8   �� 5   
   " �6#   .�5      ��  � ��$ Right=�64   6D   5      �� 5   
   " ��6   .�5      ��  � ��
 ����6+   5      5      .��5      �  � DataContext# [ 6   $��0,0,0,0q�6A   $
��Auto��6R   $
��Auto��6`   $��Stretch=�6m   $��Stretch=�6�    � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$ 	 subscriptionDetailDataGrid��5      
   AutoGenerateColumns
 .     EnableRowVirtualization . $
��auto��6�   $��Stretch=�6�   $��10,10,10,10q�5         RowDetailsVisibilityMode$ VisibleWhenSelected=�6      SelectionMode$ Single=�6K      SelectionUnit$ CellOrRowHeader=�6b      AlternatingRowBackground# � ��5         CanUserAddRows .     CanUserDeleteRows .     FrozenColumnCount$ 5��6�      
IsReadOnly .    	RowHeight$ 30Q�5   E   ��5   r   ��    RowHeaderStyle 5      �� 5      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5       ��  � ��
 � ���64   �� 5!       � ��$ 30��6/   �� 5"       � ��
 ��  �64   �� 5#       � ��$ 3q�69   5$         ColumnHeaderStyle 5'      �� 5(      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5)      ��  � ��$ 16(�61   �� 5*       � ��$ 3q�60   �� 5+       � ��
 � ���64   �� 5,       � ��
 ��  �64   �� 5-       � ��$ 3q�69   5.         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      -   5        subscriptionIdColumn��,  &System.Windows.Controls.DataGridColumn   	CellStyle# [ 51   f      Header$ Subscription Id��6�      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6�   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6C   �� *SubscriptionId+6�     52      -   5        statusNameColumn��$ Status Name��52   `   $
 auto	 6u    6?   �� *StatusString+6u     53      -   5        payerSurnameColumn��$ Payer Surname��53   b   $
 auto	 6y    6A   �� *PayerSurname+6y     54      -   5        receiverSurnameColumn��$ Receiver Surname��54   h   $
 auto	 6�    6D   �� *ReceiverSurname+6�     55      -   5        productNameColumn��$ Product Name��55   `   $
 auto	 6v    6@   �� *ProductName+6v     56      $ 	InvoiceId��6C   $
 auto	 6V    6%   �� *	InvoiceId+6V     57      $ 
ProFormaId��6D   $
 auto	 6X    6%   �� *
ProFormaId+6X   4  .System.Windows.Controls.DataGridCheckBoxColumn  58      -   5        renewColumn��$ Renewal notice��58   `   $
 auto	 6x    6>   �� *RenewalNotice+6x     59      -	   5        automaticrenewColumn��$ Automatic renew��59   l   $
 auto	 6�    6G   �� *AutomaticRenewal+6�     5:      -
   5        payerColumn��# [ 5:   V   $ PayerId��6~   $
 auto	 6�    6:   �� *	PayerId+6�     5;      -   5        receiverColumn��# [ 5;   \   $ 
ReceiverId��6�   $
 auto	 6�    6=   �� *
ReceiverId+6�     5<      -   5        unitsPerIssueColumn��# [ 5<   d   $ Units Per Issue��6�   $
 auto	 6�    6B   �� *UnitsPerIssue+6�     5=      -   5        payerCompanyColumn��$ Payer Company��5=   b   $
 Auto	 6y    6A   �� *PayerCompany+6y   5?      5@      5A      