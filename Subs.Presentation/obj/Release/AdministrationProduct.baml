   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms L HSubs.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Subs.PresentationSubs.Presentation D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data -   'Subs.Presentation.AdministrationProduct   2xctk)http://schemas.xceed.com/wpf/xaml/toolkit  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      @d2http://schemas.microsoft.com/expression/blend/2008      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase      Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms      1localclr-namespace:Subs.Presentation      ;Data*clr-namespace:Subs.Data;assembly=Subs.Data      -     � Title$  AdministrationProduct��$	��700��$
��1050�� � WindowStartupLocation$ Manual=� � 	Resources   Subs.Data.ProductDoc   
productDoc3  -Subs.Presentation.DeliveryOptionsToDictionary   lDeliveryOptionsToDictionary  product2ViewSource �� Source �� Source  issueViewSource �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName  baseRateViewSource*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property �� Value  
AlignRight  WrappedColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader,  &Subs.Presentation.SubscriptionCategory  lSubscriptionCategory%  Subs.Presentation.DateConverter  lDateConverter%  Subs.Presentation.RandConverter 	 lRandConverter2	  ,Subs.Presentation.SubscriptionMediumInt2Type 
 lSubscriptionMediumInt2Type��%�  &	        &	      &	 
     7   &	 *     7  &	 r     7  '  �     &	 �     &	 !    '  x    '�� �    '�� �    &	 	    &	     &		     &	
         ��  �� *
Product2+8   ��  �� *Product2_Issue+8      $
 Year��  $ No����  �� *Product2_BaseRate+8   �� "   P� 	 �@ 
IsSelected
 . . ���  � ��
 � �����  � ��
 �   ��� " �.���  � ��$ Right=��� "  .���  � �� �� .R��� $
��Wrap=����� ��  � ��
 ���@��� "  .���  � ��
 ���@���  � ��$ 3q��� " ��.���  �@��BorderThickness$ 4q��� " ��.���  � ��
 ����      	  .���� -    ��Name$ 
TabControl��$��
18,10,10,7q�.@��� -    ��Name$ 
ProductTab��$��Product�� � DataContext# [ .��� $��10q� � ColumnDefinitions �� $��* ��� $��3* ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�&
   System.Windows.Controls.DataGrid
  -    
 Name$ product2DataGrid�� 
  RowDetailsVisibilityMode$ VisibleWhenSelected=�$��0,0,0,0q� 
  EnableRowVirtualization .  
  AutoGenerateColumns .  $��Stretch=�$
��Auto�� 
  AlternatingRowBackground
 ��·� 
  CanUserDeleteRows .   
  CanUserAddRows .   
  SelectionUnit$ CellOrRowHeader=�$ �� IsSynchronizedWithCurrentItem$
 TrueY� 
  SelectionMode$ Single=�$��0��$��0��$��2��$	��Top=�����  
  RowHeaderStyle �� :  4System.Windows.Controls.Primitives.DataGridRowHeader"  .���  � ��
 � �����  � ��$ 30����  � ��
 �  ����  � ��$ 3q� 
  Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    Header$ Status��    CanUserSort  .  !   
IsReadOnly! . 1  +System.Windows.Controls.DataGridBoundColumn"   Binding" �� *Status+# �� Mode$# OneTime=�4  .System.Windows.Controls.DataGridTemplateColumn  $ Product name��$	 290   . $   CanUserReorder$ .  %   SortMemberPath$% ProductName��! . &   CellTemplate& �� .R��� -   $
��Auto��$��3q�' �� TextWrapping$
' Wrap=�.������ ( �� Path$( ProductName�) �� NotifyOnValidationError) . * �� UpdateSourceTrigger$* 	LostFocus=�+ �� ValidationRules+ 5  /System.Windows.Controls.ExceptionValidationRule  .��  $ SizeToHeader $ Medium��! . " �� *Medium+, �� 	Converter#, [
   -   displaySequenceColumn��$ 65 $ Display sequence��-   HeaderStyle#- [ .   	CellStyle#. [ " �� *DisplaySequence+$# TwoWay=�  -   expirationDurationColumn��$ 65 #. [ " �� *ExpirationDuration+ �� $��Expiration duration��/ � ToolTip$Q/ KThe number of days that a subscription is expired before it gets cancelled.��$
��Wrap=�  -   defaultNumberOfIssuesColumn��$ 60 $ Default number of issues��#- [ #. [ " �� *DefaultNumberOfIssues+  -	   weightColumn��$ SizeToHeader $ Weight��#. [ " �� *Weight+  -
   lengthColumn��$ 50 $ 	Length mm��#. [ #- [ " �� *Length+  -   wydteColumn��$ 50 $ Width mm��#. [ #- [ " �� *Wydte+  -   hoogteColumn��$ 50 $ 	Height mm��#. [ #- [ " �� *Hoogte+4  .System.Windows.Controls.DataGridCheckBoxColumn  -   allowMultipleCopiesColumn��$ 60 $ Allow multiple copies��#- [ " �� *AllowMultipleCopies+  -   classificationColumn��$
 Auto $ Classification��#. [ ! . " �� *Classification+�� -   0 ��Name$0 ProductImage��$��0��$��2��$��Stretch=�$
��Auto��$
��Auto��$��10,0,0,0q�$	��Top=����� *	Picture+�� -   1 ��Name$1 buttonAddPicture��$��Add picture��$��1��$��0��$��0,10,0,0q�$��90��$
��Left=��� -   $1 buttonAddProduct��$��Add a product��$��90��$��1��$��1��$��0,10,0,0q�$��Right=��� 2 �� Orientation$2 Vertical=�$��2��$��0��$��0,10,0,0q�$	��Top=�.+��� $
��Name��$��25���� -   3 ��Name$
3 Naam��$��30��4 �� 	MaxLength$	4 200������ *ProductName+$# TwoWay=��� $��Heading��$��25���� -   $3 Heading��$��70��"5 �� VerticalScrollBarVisibility$5 Visible=���. $
' Wrap=����� *	Heading+$# TwoWay=��� $2 Vertical=�$��2��$��1��$��2��$��0,10,0,0q�$	��Top=�.+��� $��Description��$��25��$��5,0,0,0q��� -   $3 Description��$	��125��$��Stretch=�$
��auto��$��10,0,0,0q�$5 Visible=�6 �� AcceptsReturn6 . 7 �� AutoWordSelection7 . ��. $
' Wrap=�.������ $( ProductDescription�) . $* 	LostFocus=�$# TwoWay=�+   .���� $2 Vertical=�$��3��$��0��$	��138��$
��Left=�$��0,10,0,0q�.+��� $��Valid delivery options��.  (Subs.Presentation.DeliveryOptionsControl  -   .  (Subs.Presentation.DeliveryOptionsControl8   	LostFocus$8 DeliveryOptionsLostFocus��$	��100��$	��138��$
��Left=�9   DeliveryOptions9 �� $( DeliveryOptions�) . $* 	LostFocus=�$# TwoWay=�+   �� $��3��$��1��$��2��$��0,10,0,0q�$	��125��.+��� $��Medium��$��29��: �� Left$	: 281��$	��100���� -   $	: 281��
; �� Top$; 27��< �� SelectedValuePath$	< Key��= �� DisplayMemberPath$= Value��$	��248��> �� SelectedValue> �� $( Medium�$# TwoWay=����� # [ $( SubscriptionMedium��� $��Classification��$: 10���� -   $3 textClassification��$��27��$: 10��$; 26��$	��224��$
' Wrap=�$4 20������ *Classification+$# TwoWay=��� $��Default delivery option��$: 10��$; 58���� -   ? ��Name$? DefaultDeliveryOption��$= Value��$	< Key��$: 10��$; 90��$	��224������ *DeliveryOptions+#, [ > �� $( DefaultDeliveryOption�$# TwoWay=��� -   $1 buttonSubmit��$��Submit��$	: 281��$; 90��$	��117���� -   $
1 Exit��$��Exit without changes��$	: 412��$; 90��$	��117���� -   $ TabIssue��$��Issue��.��� # [  �� $��* ��� $
��auto � �� $
��auto ��� $	��100 �.+�
  -   $ issueDataGrid�� .   . $
��auto��$��Stretch=�$ VisibleWhenSelected=�$��Stretch=�$
��Auto��# [  .  .  $ CellOrRowHeader=�$
 TrueY�����  �� "  .���  � ��
 � �����  � ��$ 30����  � ��
 �  ����  � ��$ 3q�   -   issueIdColumn��$ Issue��$ 40 #. [ " �� *	IssueId+  $ Issue description��$
 auto   . $ .  $% Issue��& �� .R��� -   $
��Auto��$��3q�$
' Wrap=�.������ $( IssueDescription�) . $* 	LostFocus=�+   .��  -   
yearColumn��$
 Year��$ 40 #. [ " �� *Year+  -    noColumn��$ No��$ SizeToHeader #. [ " �� *No+  -!   sequenceColumn��$ Sequence��$ SizeToHeader ! . #. [ " �� *
Sequence+  -"   PromotionPriceColumn��#- [ $ Promotion price��$ 60 #. [ " �� *PromotionPrice+#, [	   -#   stockProducedColumn��$ Stock produced��$ 60 #- [ #. [ " �� *StockProduced+  -$   stockDeliveredColumn��$ Stock delivered��! . #- [ $ 60 #. [ " �� *StockDelivered+  -%   stockLostColumn��$ 
Stock lost��! . #- [ $ 40 #. [ " �� *	StockLost+  -&   stockReturnedColumn��$ Stock returned��! . #- [ $ 60 #. [ " �� *StockReturned+  -'   startDateColumn��$ 
Start Date��$	 100 & �� .R�(  "System.Windows.Controls.DatePicker  @   SelectedDate@ �� *	StartDate+$# TwoWay=�) . A �� ValidatesOnExceptionsA . $* 	LostFocus=�  -(   endDateColumn��$ End Date��$	 100 & �� .R�  @ �� *	EndDate+$# TwoWay=�) . A . $* 	LostFocus=�� $��1��$��0��$��0,10,0,0q� �� $
��auto � �� $��* ��� $��* ��� $��* �.+��� -)   $1 buttonAddIssue��$��0��$��Add an issue��$��30��$��75���� -*   $1 buttonSubmitIssue��$��1��$��Submit��$��75��$��30���� -+   $1 buttonExitIssue��$��2��$��Exit without saving��$	��115��$��30��$��0,0,10,0q��� -,   $ TabBaseRate��$��BaseRate��# [ .���� $��0,1,0,-1q�.+�
  --   $ BaseRateDataGrid�� .   . $
��auto��$: 10��$ VisibleWhenSelected=�$; 10��$	��400�� .  .  $ CellOrRowHeader=�����  �� "  .���  � ��
 � �����  � ��$ 30����  � ��
 �  ����  � ��$ 3q�   -.   dateFromColumn��$ 	Date From��$	 100 & �� .R�  @ �� *
DateFrom+$# TwoWay=�) . A . $* PropertyChanged=�  -/   valueColumn��$ Value��#. [ $ 60 ! . " �� *Value+#, [	   -0   modifiedByColumn��$ Modified By��$
 Auto ! . " �� *
ModifiedBy+  -1   modifiedOnColumn��$ Modified On��$
 Auto ! . " �� *
DateFrom+#, [ �� -2   $1 buttonCalculateBaseRate��$��Calculate a base rate��$	: 481��$; 54��$	��134���� $	: 477��$; 81��$	��134��.��Proposed base rate�� -3   $3 TextProposedBaseRate��$	: 481��$	; 112��$	��134��B �� 
IsReadOnlyB . �� -4   $1 buttonAddBaseRate��$ ��Add the proposed base rate��$	: 481��$	; 158��$	��134���� -5   $1 buttonSubmitBaseRate��$��Submit��$	: 481��$	; 379��$	��134���� -6   $1 buttonExitBaseRate��$��Exit without saving��$	: 481��$	; 421��$	��134��