   M S B A M L   `   `   `  ����M  ISubs4.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Subs4.PresentationSubs4.Presentation  5   	   $    Subs4.Presentation.Maintenance   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Subs4.Presentation     5   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5   	     � Title$  Maintenance��5	   	   $��623.333��6   $	��800��6.   
���P��$��4q�6N    � 	Resources 5
       �� 
TargetType �� Property �� Value   
AlignRight��%�   '��       &	  �     �� 5   
   " ��6   .�5      ��  � ��
 ����6+   �� 5       � ��$ 3q�6'   �� 5       � ��$ 2q�6(   5      �� 5   
   " �6#   .�5      ��  � ��$ Right=�64   5       5!      .��5"      �� .@�5#   
   �� $��Tasks��6   .��5$      �  � ShowGridLines .  $��0,0,0,0q�6)    � ColumnDefinitions 5&      �� 5'      �� 5(       � RowDefinitions 5+      �� 5,      $
��Auto �6%   �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   .+�53      �� $#��Statement for non-debitorders��6   
����  �$��2q�6U   .��54      �� .+�55      �� -   5         ��Name$" buttonNonDebitOrderDirective��55   !   $��Create directives��6G   $
��Left=�6c   $��3q�6   $��5q�6�   $y�Visible=�6�   �� 56      -   5        $ buttonRenderNonDebitOrder��56   !   $��Render��6D   $
��Left=�6U   $��3q�6q   $��5q�6}   {�.  6�   ]� 57      .+�58      �� -   5        $ buttonEmailNonDebitOrder��58   %   $��Email��6G   $
��Left=�6W   $��3q�6s   $��5q�6   {�.  6�   �� 59      $��Right=�6&   $	��100��6=   	 �� TextAlignment$	 Right=�6I   $��5q�6_   .��6j   06m   �� 5:      $��0,7,0,0q�6$   $��Right=�65   .��6L   after CustomerId:6_   5;      5<      5=      �� 5?      $��Statement for debitorders��6   $��1��6>   
����  �$��2q�6a   .��5@      �� .+�5A      �� -   5        $ buttonDebitOrderDirective��5A   !   $��Create directives��6D   $
��Left=�6`   $��3q�6{   $��5q�6�   $y�Visible=�6�   �� 5B      -   5        $ buttonRenderDebitOrder��5B   !   $��Render��6A   $
��Left=�6R   $��3q�6n   $��5q�6z   {�.  6�   ]� 5C      .+�5D      �� -   5        $ buttonEmailDebitOrder��5D   %   $��Email��6D   $
��Left=�6T   $��3q�6o   $��5q�6{   {�.  6�   �� 5E      -   5        
 ��Name$
 textDebitOrderCustomerId��5E   &   $��Right=�6I   $	��100��6`   $	 Right=�6l   $��5q�6�   .��6�   06�   �� 5F      $��0,7,0,0q�6$   $��Right=�65   .��6L   after CustomerId:6_   5G      5H      5I      � 5K      -   5         �Name$ ProgressBar��5K      $�� 1��63   $��2��6B   $��30��6V   $��15q�6b   6p   �� 5M      $��Invoice��6   $��2��6,   $��0��69   
����  �$��2q�6\   .��5N      �  5O      �� 5P      $��30 �6,   �� 5Q      $��30 �6,   �� 5R      $��30 �6,   �� 5S      $��30 �6,    5V      �� 5W      $	��140 �6/   6=   �� 5X      $	��120 �6/   6=   �� 5Y      $	��100 �6/   6=   .+�5[      �� -	   5        $ buttonInvoiceDirective��5[   !   $��Create directives��6A   $��3q�6]   $��3q�6i   5\   %   �� 5]      $��1��6    .��60   from TransactionId:6E   �� 5^      -
   5        $
 textFromTransactionId��5^   "   $��2��6B   $	 Right=�6R    �� 
IsReadOnly . .��6z   06}   �� 5f      -   5        $ buttonInvoiceRender��5f   !   $��2��6?   $��0��6L   $��Render��6\   $��3q�6n   $��25��5g   ;   $��Bottom=�6G   �� 5j      -   5        $ buttonInvoiceEmail��5j   !   $��Email��6=   $��3��6N   $��0��6[   $��3q�6k   $��3q�6w   5k      �� 5l      -   5        $
 textInvoiceCustomerId��5l   "   $��3��6C   $��3��6P   $	 Right=�6a   .��6w   06z   �� 5m      $��3��6"   $��1��6/   .��6?   after CustomerId:6R   5o      5p      �� 5r      $��Global skip��6   $��2��60   $��2��6=   
����  �$��2q�6`   .��5s      �� .+�5t      ]� .+�5u      �� -   5         ��Name$ labelSkipSelectedIssue��5u   $   $��Right=�6D   6]   �� 5v      -   5        $ buttonSelectSkipIssue��5v   %   $��Right=�6D   $��Select issue��6[   $
��Left=�6r   $��3q�6�   $��5q�6�   5w      5y      �� 5z      -   5        $ buttonGlobalSkip��5z   !   $��Skip globally��6;   $
��Left=�6S   $��3q�6n   $��5q�6z   {�.  5{      5|      5}      �� 5      $��Reverse delivery run��6   $��3��69   $��2��6F   
����  �$��2q�6m   .��5�      �� .+�5�      ]� .+�5�      �� -   5        $  labelSelectedReversalIssue��5�   $   $��Right=�6H   6a   �� 5�      -   5        $ buttonSelectReversalIssue��5�   %   $��Select issue��6H   $
��Left=�6_   $��3q�6{   $��5q�6�   6�   5�      ]� 5�      .+�5�      �� $ ��Select delivery start time��6$   $��5,0,0,0q�6J   $
��Left=�6[   6s   (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ DateTimePicker��5�   )   $��Right=�6A   $��15q�6X   $	��306��6d   5�      �� 5�      -   5        $ buttonReverse��5�   !   $��Reverse��68   $
��Left=�6J   $��3q�6f   $��5,0,0,5q�6r   5�      5�      5�      �� 5�      $��Miscelaneous��6   $��4��61   $��2��6>   
����  �$��2q�6e   .��5�      ��  �� Orientation$ 
Horizontal=�6!   .+�5�      �� -   5        $ buttonLiability��5�   !   $��Calculate liabilities��6:   $
��Left=�6Z   $��3q�6v   $��5q�6�   
 � Tag$ AuthorityHighest��5�   9   6P   �� 5�      -   5        $ buttonInvoiceDistribution��5�   !   $��Reallocate all invoices��6D   $
��Left=�6f   $��3q�6�   $��5q�6�   $ AuthorityHighest��5�   C   6Z   5�      5�      5�      5�      �� 5�   
   $	��Log��6   .��5�      �� -   5         ��Name$ ListBox1��5�      6*   5�      5�      5�      