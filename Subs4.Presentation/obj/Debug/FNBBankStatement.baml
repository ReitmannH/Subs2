   M S B A M L   `   `   `  ����M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  5   	   D @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 5   	   )    #Subs4.Presentation.FNBBankStatement   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Subs4.Presentation     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5   	   -   5          � Title$  FNB bank statement��5	   	   $��838.235��6$   $��1246.794��65    � 	Resources 5      &    Subs4.Presentation.DateConverter   lDateConverter)   #Subs4.Presentation.IntegerConverter  lIntegerConverter&    Subs4.Presentation.RandConverter  lRandConverter �� 
TargetType �� Property �� Value  
AlignRight  Subs.Data.PaymentDoc  
paymentDoc  FNBBankStatementViewSource �� Source �� Source��%f  &	        &	      &	 &     '�� 9     &	 �     &	 �     &	 �     7    5   
   6     5   
   6!     5   
   6   �� 5   
   " ��6   .�5      ��  � ��
 ����6+   5      �� 5   
   " �6#   .�5      ��  � ��$ Right=�64   6D   5        5   
   6   �� 5   
    6B   �� *FNBBankStatement+8   5      .��5      �� $��0,0,0,0q�6    � DataContext# [ 6   .+�5   
   �� -   5         ��Name$ 
buttonLoad��5      $+��%Load a new bank statement from a file��6%   	 �� Left$	 10��6U   

 �� Top$
 10��6f   $	��270��6v   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��pickerStartDate��5      $��0,0,0,0q�6-   $	 93��6>   $
 94��6O     5   
   -   5        $��pickerEndDate��5      $��0,0,0,0q�6+   $		 282��6<   $
 95��6N   �� 5!   
   -   5        $ buttonSelectRange��5!      $		 523��6,   $
 75��6>   $(��"Select loaded entries in the range��6n   $	��270��6�   �� 5"   
   -   5        $ buttonNotPosted��5"      $		 523��6*   $	
 111��6<   $3��-Select loaded entries in range not posted yet��6k   $	��270��6�   �� 5$   
   -   5        $ buttonValidate��5$      $	 10��6)   $	
 766��6:   $��Validate the payments��6h   �� 5%   
   -   5        $ 
buttonPost��5%      $		 264��6%   $	
 766��67   $ ��Post the validated entries��6a   {�.  6�   �� 5&   
   $��}��6   $	��122��6   $		 427��6)   $
 36��6;   $��46��6K   $��80(�6V   �� 5(   
   $
��From��6   $	 10��6   $
 91��60   �� 5)   
   $��to��6   $		 229��6   $
 94��6/    J� RenderTransformOrigin$ 10.102,0.457&�6?   &   System.Windows.Controls.DataGrid  5+   
   -	   5          Name$ FNBBankStatementDataGrid��5+         AutoGenerateColumns .     EnableRowVirtualization . $	��554��6p   $	 10��6�      SelectionUnit$ CellOrRowHeader=�6�   $	
 187��5,      $
��Auto��6$   $ �� IsSynchronizedWithCurrentItem$
 TrueY�61      CanUserAddRows .     CanUserDeleteRows .  ��5+   }   ��    RowHeaderStyle 5.      �� 5/      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�50      ��  � ��
 � ���64   �� 51       � ��$ 30��6/   �� 52       � ��
 �  ��64   �� 53       � ��$ 3q�69   54         Columns 57      0  *System.Windows.Controls.DataGridTextColumn  5:      -
   5        transactionDateColumn��,	  &System.Windows.Controls.DataGridColumn 	  	CellStyle# [ 5:   D    	  Header$ Payment date��6l    	  
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6�   �� *TransactionDate+ �� 	Converter# [  6�     5;      -   5        allocationNoColumn��$ Allocation No��5;   b    	  Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6y    .  6A   �� *AllocationNo+6�     5<      -   5        amountColumn��$ Amount��5<   �   $ SizeToHeader 6�    .  6;   �� *Amount+# [ 6�   4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ 	Reference��6)   $	 250 6<    .    CellTemplate 5?      �� 5@      .R�5A      �� $
��Auto��6&   $��3q�64    �� TextWrapping$
 Wrap=�6?   .��6S   ��5B   "   �� 5C   &    �� Path$ 	Reference�6.   5D   '   .��5E   0   5F      5G      5I        5L      -   5        bankPaymentMethodColumn��$ Bank Payment Method��5L   l   $ SizeToHeader 6�    .  6F   �� *BankPaymentMethod+6�     5M      -   5        invoiceIdColumn��$ 	InvoiceId��5M   \   $ SizeToHeader 6o    .  # [ 5N   %    5M   >   �� *	InvoiceId+5N   %     5O      -   5        statementIdColumn��$ StatementId��5O   `   $ SizeToHeader 6u    .  # [ 5P   %    5O   @   �� *StatementId+5P   %     5Q      -   5        customerIdColumn��$ Customer Id��5Q   �   $ SizeToHeader 6�   # [ 5R   %    .  5Q   ?   �� *
CustomerId+ �� Mode$ TwoWay=�# [  �� UpdateSourceTrigger$ 	LostFocus=�5R   M     5T      $ Message��6)   $	 250 6:    .  5U      �� 5V      .R�5W      �� $
��Auto��6&   $��3q�64   $
 Wrap=�6?   .��6S   ��5X   "   �� 5Y   &   $ ErrorMessage�6.   5Z   '   .��5[   0   5\      5]      5_      4  .System.Windows.Controls.DataGridCheckBoxColumn  5a      $ Posted��6D   $ SizeToHeader 6T    .  6)   �� *Posted+6i     � ContextMenu  5e      �� 5f      .@�5g      m� -   5        $��Find customer��5g       67   m� 5h      -   5        $ ��Find customer by Statement��5h      6C   m� 5i      -   5        $��Override��5i      61   m� 5j      -   5        $#��Mark as incorrectly deposited��5j      6F   m� 5k      -   5        $��Mark as internal transfer��5k      6B   5l      5n      5o      5p      