   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    	Subs.Data8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data 5   	    MIMS4.Presentation#   MIMS4.Presentation.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5   	   -   5        $��36(�5   	     � WindowState$  Normal=�5   	   $	��181��6   $��482.839��6+    � 	Resources 5      ��%    5
      .��5      � $��0,0,0,0q�6   $
��Auto��6   $
��Auto��6*   $��Stretch=�67   $��Stretch=�6S    � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��5* �6   .+�5   
   o� -   5         o�Name$ MainMenu��5      -  'System.Windows.Input.KeyboardNavigation   TabNavigation$ Cycle=�6!   $
��Auto��6J   $
��Auto��6X   $��Stretch=�6e   $��Stretch=�6�   
������$��0,0,0,0q�5   '   .@�5      m� $��Administration��6   .@�5      m� -   5        $��Company��5      
 � Tag$ AuthorityHigh��5      6/   m� 5      -   5        $��Country��5      $ AuthorityHigh��6B   6V   m� 5      -   5        $��Customer classification��5      $ AuthorityHigh��6a   6u   m� 5      -   5        $��DeliveryAddress��5      $ AuthorityHigh��6R   6f   m� 5      -   5        $��DeliveryCost��5      $ AuthorityHigh��6L   6`   m� 5!      -   5        $��	PostCodes��5!   q   $��
Post codes��6   $ AuthorityHigh��6F   6q   m� 5"      -	   5        $��Product��5"      $ AuthorityHigh��6Q   6e   m� 5#      -
   5        $��	Promotion��5#      $ AuthorityHigh��6G   6[   m� 5$      -   5        $��Refresh valid values��5$      69   5&      m� 5'      -   5        $��             Product��5'      $ AuthorityHigh��65   .@�5(      m� -   5        $��Deliver��5(      6,   m� 5)      -   5        $��Delivery reversal��5)      66   5*      m� 5,      $��Subscription��6   .@�5-      m� -   5        $
��GoTo��5-      6)   m� 5.      -   5        $��Quote��5.      6*   m� 5/      -   5        $��Global_Skip��5/      $ AuthorityHigh��6I   6]   50      m� 51      -   5         m�Name$ CustomerMenu��51      $��Customer��6-   .@�52      m� -   5        $��Go to��52      6+   m� 53      -   5        $��Communication��53      $ AuthorityMedium��6V   6l   m� 54      -   5        $��SB bank statement��54      $ AuthorityMedium��6T   6j   m� 55      -   5        $��FNB bank statement��55      $ AuthorityMedium��6V   6l   m� 56      -   5        $��DO bank statement��56      $ AuthorityMedium��6\   6r   m� 57      -   5        $��
CreditNote��57      $ AuthorityHigh��6H   6\   58      m� 5:      -   5        $��             Maintenance��5:      $ AuthorityHigh��69   .@�5;      m� -   5        $��Refresh enums��5;      62   m� 5<      -   5        $��Postcode standardisation��5<      6=   m� 5=      -   5        $"��Postcode Add Sapo Compliment��5=      6A   m� 5>      -   5        $
��Test��5>      6)   5?      5@      � 5B   
   $��1��6   .+�5C      �� $
��auto��6   $
��auto��6%   
������63   A� 5D      $
��auto��6   
��� ���
���  ��$��4��6>   �� 5E      -   5         ��Name$ labelCurrentCustomer��5E      $��Center=�62   $��Center=�6O   6m   5F      5G      5H      