   M S B A M L   `   `   `  ����D  @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data  5   	    Subs4.Presentation6   0Subs4.Presentation.AdministrationDeliveryAddress   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     5   	   -   5          � Title$%  Delivery address administration��5   	   $	��749��61   $
��1250��6>   $
��1250��6N    � WindowState$ Normal=�6r    � WindowStartupLocation$ Manual=�6�    � 	Resources 5      "   Subs.Data.DeliveryAddressDoc   deliveryAddressDoc  countryViewSource �� Source �� Source  provinceViewSource  provinceCityViewSource   provinceCitySuburbViewSource & "provinceCitySuburbStreetViewSource&   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value �� RelativeSource �� Path��%m  &	        &	      7   &	 @     7  &	 y     7  &	 �     7  &	 �     7  '        5   
   6"   �� 5   
    69   �� *	Country+8   �� 5	   
    6:   �� *FK_Province_Country+8   �� 5
   
    6>   �� *FK_City_Province+8   �� 5   
    6D   �� *FK_Suburb_City+8   �� 5   
    6J   �� *FK_Street_Suburb+8   �� 5   
   "  6   .�5      ��  � ��$ 	10,10,0,0q�6'   	 5      P� 5      
 �@=�HasError . . �5      ��  �@�ToolTip 5      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      � -   5        $��AddressTree��5      $��Stretch=�6   $
��auto��6<    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5       $��3* �6   �� 5!      $
��2.5* �6   �� 5"      $��5* �6    � RowDefinitions 5$   
   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $��40 �6   .+�5,   
     -   5          Name$ countryDataGrid��5,         AutoGenerateColumns .     EnableRowVirtualization .     RowDetailsVisibilityMode$ VisibleWhenSelected=�5-   U   $
��auto��5.         
IsReadOnly . ��5-      �� # [    Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      -   5        countryNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Country Name��50   `      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *CountryName+6v     51      -   5        countryIdColumn��$ 	CountryId��51   ^   $
 auto 6q      
IsReadOnly .  6>   �� *CountryName+6~   53        55   
   -   5        $ Province_DataGrid��55      $ VisibleWhenSelected=�6.   $��0,0,0,0q�6]    .  .  $
��auto��57   N   $��1��6[   ��56      �� # [  58        59      -   5        provinceNameColumn��$
 Auto 59   A   $ Province Name��6N    6e   �� *ProvinceName+  5:      $
 Auto 6%   $ 	CountryId��62    6E   �� *	CountryId+  5;      -   5        provinceIdColumn��$
 Auto 5;   ?   $ 
ProvinceId��6L    .  6`   �� *
ProvinceId+6   5=        5>   
   -	   5        $ City_DataGrid��5>       .   . $
��auto��6f   $ VisibleWhenSelected=�5?   Z   $��1��5@      $��2��6#   ��5?      �� # [  5A        5B      -
   5        cityNameColumn��$ 	City Name��5B   Z   $
 auto 6m    6=   �� *
CityName+6m     5C      -   5        cityIdColumn��$ CityId��5C   V   $ SizeToHeader 6f    .  6;   �� *CityId+6{     5D      $ 
ProvinceId��6E   $ SizeToHeader 6Y    6&   �� *
ProvinceId+6Y   5F        5G   
   -   5        $ Suburb_DataGrid��5G       .   . $ VisibleWhenSelected=�5I      $��2��6B   $
��auto��6R   $��2��6_   ��5H      �� # [  5J        5K      -   5        suburbNameColumn��$ Suburb Name��5K   ^   $
 auto 6s    6?   �� *
SuburbName+6s     5L      -   5        suburbIdColumn��$ SuburbId��5L   Z   $ SizeToHeader 6l    .  6=   �� *
SuburbId+6�     5M      $ CityId��6A   $ SizeToHeader 6Q    6&   �� *CityId+6Q   5O        5P   
   -   5        $ Street_DataGrid��5P       .   . $
��auto��6g   $��2��6t   $ VisibleWhenSelected=�5Q   f   $��3��6�   ��6   �� # [  5R        5S      -   5        streetNameColumn��$ Street Name��5S   ^   $
 auto 6s    6?   �� *
StreetName+6s     5T      -   5        streetExtensionColumn��$ Street Extension��5T   h   $
 auto 6�    6D   �� *StreetExtension+6�     5U      -   5        streetSuffixColumn��$ Street Suffix��5U   b   $
 auto 6y    6A   �� *StreetSuffix+6y     5V      $ SuburbId��6B   $
 auto 6T    6%   �� *
SuburbId+6T     5W      $ StreetId��6C   $
 auto 6U    .  6&   �� *
StreetId+6b   5Y      �� 5Z   
   -   5        $��Submit Country��5Z      $��2��6*   $	��101��67   $
��Left=�6C   6`   �� 5[   
   -   5        $��Submit Province��5[      $��2��6+   $��97��68   $��Right=�6D   6a   �� 5\   
   -   5        $��Submit City��5\      $��2��6'   $��1��64   $��75��6D   6O   �� 5]   
   -   5        $��Submit Suburb��5]      $��2��6*   $��2��67   6G   �� 5^   
   -   5        $��Submit Street��5^      $��2��6)   $��3��66   $��83��6F   6Q   5_      5`      