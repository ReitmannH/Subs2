   M S B A M L   `   `   `  ����M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  5   	   D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 5   	   0    *Subs4.Presentation.AdministrationPromotion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Subs4.Presentation     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5   	   $
��1000��5        � Title$  AdministrationPromotion��5	   	   $
��auto��6)    � 	Resources 5
         promotionViewSource  
AlignRight �� 
TargetType �� Property �� Value&    Subs4.Presentation.RandConverter  lRandConverter��%�   &	        &	      &	 ^     �� 5   
   6   �� 5   
   " �6#   .�5      ��  � ��$ Right=�64   5        5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PromotionDataGrid��5       � DataContext# [  6.      AutoGenerateColumns .  	   EnableRowVirtualization	 . 
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�5   7   $
��auto��6f      CanUserDeleteRows .    CanUserAddRows .     SelectionUnit$ FullRow=�5   O      SelectionMode$ Extended=�5      $
��auto��69   $��Stretch=�6G   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6c   ��5      ��    RowHeaderStyle 5      �� 5      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5      ��  � ��
 � ���64   �� 5       � ��$ 30��6/   �� 5        � ��
 �  ��64   �� 5!       � ��$ 3q�69   5"       � ContextMenu 5%      �� 5&      .@�5'      m� -   5         m�Name$ MenuItemPayer��5'      $��Insert a payer��67   6Q   m� 5(      -   5        $ MenuItemProduct��5(      $��Insert a product��68   6S   m� 5)      -   5        $ MenuItemPayerClear��5)      $��Clear a payer��6;   6S   5*         Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5/      -   5        PayerColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Payer��5/   h      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6w      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *PayerSurname+ �� Mode$ OneWay=�6�     51      -   5        ProductColumn��$ Product��51   i   $
 auto 6z    .  6<   �� *ProductName+$ OneWay=�6�     53      -   5        DiscountPercentageColumn��$ Percentage discount��53   �      	CellStyle# [ 54   1   $
 Auto 6Z    53   G   �� *DiscountPercentage+ �� 	Converter# [ 54   Z   4  .System.Windows.Controls.DataGridTemplateColumn  56      -   5        StartDateColumn��$ 
Start date��56   B   $
 auto 6V      CanUserSort .    SortMemberPath$ 	StartDate��6v      CellTemplate 57      �� 58      .R�59      (	  "System.Windows.Controls.DatePicker	   	  SelectedDate 6)   �� *	StartDate+$ TwoWay=� �� NotifyOnValidationError .   �� ValidatesOnExceptions  . ! �� UpdateSourceTrigger$! PropertyChanged=�5:      5<        5>      -	   5        EndDateColumn��$ End date��5>   @   $
 auto 6R    . $ EndDate��6r    5?      �� 5@      .R�5A      	   5B   "   �� 5C   &   " �� Path$" EndDate�6.   $ TwoWay=�6=    .   . $! PropertyChanged=�6�   # �� ValidationRules# 5D   *   5
  /System.Windows.Controls.ExceptionValidationRule
  5E   .   5G   '   5I      5J      5L      5N      �� 5P   
   $ �� Orientation$$ 
Horizontal=�6   $��1��6.   $��10q�6;   .+�5Q   
   �� -
   5        % ��Name$% 	buttonAdd��5Q      $��Add a promotion��6$   $��	0,10,10,0q�6>   $	��145��6Q   6]   �� 5R      -   5        $% buttonSubmit��5R      $��Submit��6+   $��	0,10,10,0q�6<   $	��145��6O   6[   �� 5S      -   5        $% 
buttonExit��5S      $��Exit without saving��6)   $��	0,10,10,0q�6G   $	��145��6Z   6f   5T      5U      5V      