   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   M ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation 5   	   D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 5	   	   .   (Subs4.Presentation.AdministrationProduct   5   	   2xctk)http://schemas.xceed.com/wpf/xaml/toolkit  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase      5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms      5   	   2local clr-namespace:Subs4.Presentation      5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data      5	   	   -   5          � Title$  AdministrationProduct��5   	   $	��700��6'   $
��1050��67    � WindowStartupLocation$ Manual=�6G    � 	Resources 5        Subs.Data.ProductDoc   
productDoc4  .Subs4.Presentation.DeliveryOptionsToDictionary   lDeliveryOptionsToDictionary  product2ViewSource �� Source �� Source  issueViewSource �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName  baseRateViewSource*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property �� Value  
AlignRight  WrappedColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader-  'Subs4.Presentation.SubscriptionCategory  lSubscriptionCategory&   Subs4.Presentation.DateConverter  lDateConverter&   Subs4.Presentation.RandConverter 	 lRandConverter3	  -Subs4.Presentation.SubscriptionMediumInt2Type 
 lSubscriptionMediumInt2Type��%�  &	        &	      &	 &     7   &	 T     7  &	 �     7  '      &	 �    &	     '  �    '�� 1    '�� �    &	 �    &	 �    &		 �    &	
       5   
   6     5   
   6,   �� 5   
    6:   �� *
Product2+8   �� 5   
    67   �� *Product2_Issue+8    5        5      $
 Year��6&     5      $ No��6&   5      �� 5   
    6:   �� *Product2_BaseRate+8   �� 5   
   "  6    5      P� 5      	 �@ 
IsSelected
 . . �5      ��  � ��
 � ���63   �� 5       � ��
 �   �63   5      5       �� 5"   
   " �6#   .�5#      ��  � ��$ Right=�64   5$      �� 5&   
   "  61   .�5'      ��  � �� 5(      �� 5)      .R�5*      �� $
��Wrap=�6$   ��68   �� 5+      5-      �� 5.       � ��
 ���@�6+   50      �� 52   
   "  6   .�53      ��  � ��
 ���@�6+   �� 54       � ��$ 3q�6(   55      �� 57   
   " ��6   .�58      ��  �@��BorderThickness$ 4q�66   59      �� 5?   
   " ��6   .�5@      ��  � ��
 ����6+   5A        5C   
   6%     5D   
   6     5E   
   6   	  5F   
   6+   5H      .��5J      �� -   5         ��Name$ 
TabControl��5J      $��
18,10,10,7q�6%   .@�5K   
   �� -   5         ��Name$ 
ProductTab��5K      $��Product��6&    � DataContext# [ 67   .��5L      � $��10q�6    � ColumnDefinitions 5M      �� 5N      $��* �6'   �� 5O      $��3* �6'   �� 5P      $
��Auto �6'    � RowDefinitions 5S      �� 5T      $
��Auto �6$   �� 5U      $
��Auto �6$   �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$   .+�5\      &
   System.Windows.Controls.DataGrid
  -   5         
 Name$ product2DataGrid��5\       
  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   $��0,0,0,0q�6d    
  EnableRowVirtualization .  
  AutoGenerateColumns .  $��Stretch=�5]   5   $
��Auto��6S    
  AlternatingRowBackground
 ��·� 
  CanUserDeleteRows .   
  CanUserAddRows .   
  SelectionUnit$ CellOrRowHeader=�5^   0   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6P    
  SelectionMode$ Single=�6u   $��0��5_      $��0��6'   $��2��67   $	��Top=�6K   ��5\   u   ��  
  RowHeaderStyle 5a      �� 5b      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6    .�5c      ��  � ��
 � ���6<   �� 5d       � ��$ 30��67   �� 5e       � ��
 �  ��6<   �� 5f       � ��$ 3q�6A   5g       
  Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6-      Header$ Status��6:       CanUserSort  .  !   
IsReadOnly! . 1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6J   �� *Status+# �� Mode$# OneTime=�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5k      $ Product name��61   $	 290 6G     . $   CanUserReorder$ .  %   SortMemberPath$% ProductName��6}   ! . &   CellTemplate& 5l      �� 5m   "   .R�5n   &   �� -   5        $
��Auto��5n   .   $��3q�6<   ' �� TextWrapping$
' Wrap=�6G   .��6   ��5o   *   �� 5p   .   ( �� Path$( ProductName�66   ) �� NotifyOnValidationError) . * �� UpdateSourceTrigger$* 	LostFocus=�6h   + �� ValidationRules+ 5q   2   5  /System.Windows.Controls.ExceptionValidationRule  5r   6   5t   /   .��5u   8   5v   '   5w   #   5y        5{      $ SizeToHeader 6-   $ Medium��6B   ! . " 6R   �� *Medium+, �� 	Converter#, [
 5|   -     5~      -   5        displaySequenceColumn��$ 65 5~   L   $ Display sequence��6W   -   HeaderStyle#- [ 5   -   .   	CellStyle#. [ 6f   " 5~   q   �� *DisplaySequence+$# TwoWay=�5   f     5�      -   5        expirationDurationColumn��$ 65 5�   O   #. [ 6�   " 6Z   �� *ExpirationDuration+ 5�      �� 5�   "   $��Expiration duration��6,   / � ToolTip$Q/ KThe number of days that a subscription is expired before it gets cancelled.��5�   1   $
��Wrap=�5�   1   5�   #   5�        5�      -   5        defaultNumberOfIssuesColumn��$ 60 5�   R   $ Default number of issues��6]   #- [ 5�   -   #. [ 6f   " 5�      �� *DefaultNumberOfIssues+5�   f     5�      -	   5        weightColumn��$ SizeToHeader 5�   C   $ Weight��6X   #. [ 6�   " 6h   �� *Weight+6�     5�      -
   5        lengthColumn��$ 50 5�   C   $ 	Length mm��6N   #. [ 6|   #- [ 6�   " 6a   �� *Length+6�     5�      -   5        wydteColumn��$ 50 5�   B   $ Width mm��6M   #. [ 6y   #- [ 6�   " 6_   �� *Wydte+6�     5�      -   5        hoogteColumn��$ 50 5�   C   $ 	Height mm��6N   #. [ 6|   #- [ 6�   " 6a   �� *Hoogte+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      -   5        allowMultipleCopiesColumn��$ 60 5�   T   $ Allow multiple copies��6_   #- [ 5�      " 5�   ~   �� *AllowMultipleCopies+5�        5�      -   5        classificationColumn��$
 Auto 5�   K   $ Classification��6Y   #. [ 6�   ! . " 6q   �� *Classification+5�   -   5�      �� 5�      -   5        0 ��Name$0 ProductImage��5�      $��0��6/   $��2��6<   $��Stretch=�6g   $
��Auto��6�   $
��Auto��6�   $��10,0,0,0q�6�   $	��Top=�6�   ��6L   �� *	Picture+6�   �� 5�      -   5        1 ��Name$1 buttonAddPicture��5�      $��Add picture��64   $��1��6L   $��0��6Y   $��0,10,0,0q�6i   $��90��6{   $
��Left=�6�   6�   �� 5�      -   5        $1 buttonAddProduct��5�      $��Add a product��64   $��90��6M   $��1��6X   $��1��6e   $��0,10,0,0q�6u   $��Right=�6�   6�   �� 5�      2 �� Orientation$2 Vertical=�6   $��2��64   $��0��6A   $��0,10,0,0q�6Q   $	��Top=�6c   .+�5�      �� $
��Name��6   $��25��6,   �� 5�      -   5        3 ��Name$
3 Naam��5�      $��30��6-   4 �� 	MaxLength$	4 200��6c   ��69   �� *ProductName+$# TwoWay=�6c   �� 5�      $��Heading��6   $��25��6/   �� 5�      -   5        $3 Heading��5�      $��70��60   "5 �� VerticalScrollBarVisibility$5 Visible=�6b   ��. $
' Wrap=�6�   ��6<   �� *	Heading+$# TwoWay=�6�   5�      �� 5�      $2 Vertical=�6   $��2��64   $��1��6A   $��2��6Q   $��0,10,0,0q�6e   $	��Top=�6w   .+�5�      �� $��Description��6   $��25��62   $��5,0,0,0q�6>   �� 5�      -   5        $3 Description��5�      $	��125��63   $��Stretch=�6@   $
��auto��6^   $��10,0,0,0q�6k   $5 Visible=�5�      6 �� AcceptsReturn6 . 7 �� AutoWordSelection7 . ��. $
' Wrap=�5�   B   .��6z   ��5�      �� 5�      $( ProductDescription�6&   ) . $* 	LostFocus=�6_   $# TwoWay=�6   + 5�   "     5�   &   5�      .��5�   (   5�      5�      �� 5�      $2 Vertical=�6   $��3��64   $��0��6A   $	��138��6Q   $
��Left=�6]   $��0,10,0,0q�6x   .+�5�      �� $��Valid delivery options��6   /  )Subs4.Presentation.DeliveryOptionsControl  5�      -   5        /  )Subs4.Presentation.DeliveryOptionsControl8   	LostFocus$8 DeliveryOptionsLostFocus��5�   1   $	��100��5�   3   $	��138��6A   $
��Left=�6M   9   DeliveryOptions9 5�      �� 5�      $( DeliveryOptions�6&   ) . $* 	LostFocus=�6\   $# TwoWay=�6|   + 5�   "     5�   &   5�      5�      5�      �� 5�      $��3��6   $��1��6&   $��2��66   $��0,10,0,0q�6J   $	��125��6\   .+�5�      �� $��Medium��6   $��29��6-   : �� Left$	: 281��69   $	��100��6K   �� 5�      -   5        $	: 281��5�   R   
; �� Top$; 27��6d   < �� SelectedValuePath$	< Key��5�      = �� DisplayMemberPath$= Value��65   $	��248��6O   > �� SelectedValue> 5�      �� $( Medium�$# TwoWay=���5�      �� # [ $( SubscriptionMedium�5�   O   �� 5�      $��Classification��6   $: 10��65   �� 5�      -   5        $3 textClassification��5�      $��27��6:   $: 10��6F   $; 26��6W   $	��224��6g   $
' Wrap=�6�   $4 20��6�   ��6s   �� *Classification+$# TwoWay=�6�   �� 5�      $��Default delivery option��6   $: 10��6>   $; 58��6O   �� 5�      -   5        ? ��Name$? DefaultDeliveryOption��5�      $= Value��5�      $	< Key��63   $: 10��5�   [   $; 90��6l   $	��224��6|   ��5�      �� *DeliveryOptions+#, [ > 5�      �� $( DefaultDeliveryOption�$# TwoWay=�5�      �� 5�      -   5        $1 buttonSubmit��5�      $��Submit��63   $	: 281��6E   $; 90��6W   $	��117��6g   6s   �� 5�      -   5        $
1 Exit��5�      $��Exit without changes��6+   $	: 412��6K   $; 90��6]   $	��117��6m   6y   5�      5�      5�      �� 5�   
   -   5        $ TabIssue��5�      $��Issue��6$   .��5�      � # [ 6    5�      �� 5�      $��* �6$   �� 5�      $
��auto �6$    5�      �� 5�      $
��auto �6'   �� 5�      $	��100 �6'   .+�5�      
  -   5        $ issueDataGrid��5�       .   . $
��auto��6m   $��Stretch=�6{   $ VisibleWhenSelected=�5�      $��Stretch=�6L   $
��Auto��6j   # [ 6x    .  .  $ CellOrRowHeader=�5�   M   $
 TrueY�6m   ��5�   �   ��  5�      �� 5�      "  6    .�5�      ��  � ��
 � ���6<   �� 5�       � ��$ 30��67   �� 5�       � ��
 �  ��6<   �� 5�       � ��$ 3q�6A   5�       5�        5�      -   5        issueIdColumn��$ Issue��5�   `   $ 40 6o   #. [ 6{   " 6D   �� *	IssueId+6{     5�      $ Issue description��61   $
 auto 6L     . $ .  $% Issue��6�   & 5�      �� 5�   "   .R�5�   &   �� -   5        $
��Auto��5�   .   $��3q�6<   $
' Wrap=�6G   .��6~   ��5�   *   �� 5�   .   $( IssueDescription�66   ) . $* 	LostFocus=�6m   + 5   2     5  6   5  /   .��5  8   5  '   5  #   5       5     -   5        
yearColumn��$
 Year��5  Z   $ 40 6h   #. [ 6t   " 6A   �� *Year+6t     5     -    5        noColumn��$ No��5  V   $ SizeToHeader 6b   #. [ 6x   " 6?   �� *No+6x     5     -!   5        sequenceColumn��$ Sequence��5  b   $ SizeToHeader 6t   ! . #. [ 5  1   " 5  E   �� *
Sequence+5  1     5     -"   5        PromotionPriceColumn��#- [ 5  1   $ Promotion price��6i   $ 60 6�   #. [ 6�   " 5  K   �� *PromotionPrice+#, [	 5  �     5     -#   5        stockProducedColumn��$ Stock produced��5  l   $ 60 6�   #- [ 5  1   #. [ 6i   " 5  J   �� *StockProduced+5  i     5     -$   5        stockDeliveredColumn��$ Stock delivered��5  n   ! . #- [ 5  1   $ 60 6i   #. [ 6u   " 5  K   �� *StockDelivered+5  u     5     -%   5        stockLostColumn��$ 
Stock lost��5  d   ! . #- [ 5  1   $ 40 6j   #. [ 6v   " 5  F   �� *	StockLost+5  v     5     -&   5        stockReturnedColumn��$ Stock returned��5  l   ! . #- [ 5  -   $ 60 6e   #. [ 6q   " 5  J   �� *StockReturned+5  q     5     -'   5        startDateColumn��$ 
Start Date��5  J   $	 100 6^   & 5     �� 5  "   .R�5  &   (  "System.Windows.Controls.DatePicker  @   SelectedDate@ 61   �� *	StartDate+$# TwoWay=�) . A �� ValidatesOnExceptionsA . $* 	LostFocus=�5   #   5"       5#     -(   5        endDateColumn��$ End Date��5#  H   $	 100 6Z   & 5$     �� 5%  "   .R�5&  &     @ 61   �� *	EndDate+$# TwoWay=�) . A . $* 	LostFocus=�5'  #   5)     5+     � 5-     $��1��6   $��0��6$   $��0,10,0,0q�64    5.     �� 5/     $
��auto �6(    51     �� 52     $��* �6+   �� 53     $��* �6+   �� 54     $��* �6+   .+�58     �� -)   5        $1 buttonAddIssue��58     $��0��65   $��Add an issue��6E   $��30��6\   $��75��6h   6s   �� 59     -*   5        $1 buttonSubmitIssue��59     $��1��68   $��Submit��6H   $��75��6Y   $��30��6�   �� 5:     -+   5        $1 buttonExitIssue��5:     $��2��66   $��Exit without saving��6F   $	��115��6d   $��30��6�   $��0,0,10,0q�6�   5;     5<     5=     �� 5?  
   -,   5        $ TabBaseRate��5?     $��BaseRate��6'   # [ 69   .��5@     �� $��0,1,0,-1q�6   .+�5A     
  --   5        $ BaseRateDataGrid��5A      .   . $
��auto��6p   $: 10��5B  5   $ VisibleWhenSelected=�6F   $; 10��6u   $	��400��6�    .  .  $ CellOrRowHeader=�5C  M   ��5B     ��  5D     �� 5E     "  6    .�5F     ��  � ��
 � ���6<   �� 5G      � ��$ 30��67   �� 5H      � ��
 �  ��6<   �� 5I      � ��$ 3q�6A   5J      5M       5N     -.   5        dateFromColumn��$ 	Date From��5N  I   $	 100 6\   & 5O     �� 5P  "   .R�5Q  &     @ 61   �� *
DateFrom+$# TwoWay=�) . A . $* PropertyChanged=�5R  #   5T       5U     -/   5        valueColumn��$ Value��5U  �   #. [ 5V  -   $ 60 6V   ! . " 5U  B   �� *Value+#, [	 5V  a     5W     -0   5        modifiedByColumn��$ Modified By��5W  f   $
 Auto 6{   ! . " 6G   �� *
ModifiedBy+6�     5X     -1   5        modifiedOnColumn��$ Modified On��5X  G   $
 Auto 6\   ! . " 5Y  -   �� *
DateFrom+#, [ 5\     �� 5]     -2   5        $1 buttonCalculateBaseRate��5]     $��Calculate a base rate��6:   $	: 481��6Z   $; 54��6l   $	��134��6|   6�   �� 5^     $	: 477��6   $; 81��6*   $	��134��6:   .��6F   Proposed base rate6Z   �� 5_     -3   5        $3 TextProposedBaseRate��5_     $	: 481��68   $	; 112��6J   $	��134��6[   B �� 
IsReadOnlyB . 6{   �� 5`     -4   5        $1 buttonAddBaseRate��5`     $ ��Add the proposed base rate��64   $	: 481��6Y   $	; 158��6k   $	��134��6|   6�   �� 5a     -5   5        $1 buttonSubmitBaseRate��5a     $��Submit��67   $	: 481��6H   $	; 379��6Z   $	��134��6k   6w   �� 5b     -6   5        $1 buttonExitBaseRate��5b     $��Exit without saving��65   $	: 481��6S   $	; 421��6e   $	��134��6v   6�   5d     5e     5f     5g     