   M S B A M L   `   `   `  ���� D  @Subs.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Subs.Data;assembly=Subs.Data	Subs.Data   Subs4.Presentation6   0Subs4.Presentation.AdministrationDeliveryAddress   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;Data*clr-namespace:Subs.Data;assembly=Subs.Data     -     � Title$%  Delivery address administration��$	��749��$
��1250��$
��1250�� � WindowState$ Normal=� � WindowStartupLocation$ Manual=� � 	Resources "   Subs.Data.DeliveryAddressDoc   deliveryAddressDoc  countryViewSource �� Source �� Source  provinceViewSource  provinceCityViewSource   provinceCitySuburbViewSource & "provinceCitySuburbStreetViewSource&   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value �� RelativeSource �� Path��%�  &	        &	      7   &	 $     7  &	 O     7  &	 w     7  &	 �     7  '  �       ��  �� *	Country+8   ��  �� *FK_Province_Country+8   ��  �� *FK_City_Province+8   ��  �� *FK_Suburb_City+8   ��  �� *FK_Street_Suburb+8   �� "  .���  � ��$ 	10,10,0,0q�	 P� 
 �@=�HasError . . ���  �@�ToolTip ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�.��� -   $��AddressTree��$��Stretch=�$
��auto�� � ColumnDefinitions �� $��3* ��� $��3* ��� $
��2.5* ��� $��5* � � RowDefinitions �� $��* ��� $��* ��� $��40 �.+�  -     Name$ countryDataGrid��   AutoGenerateColumns .     EnableRowVirtualization .     RowDetailsVisibilityMode$ VisibleWhenSelected=�$
��auto��   
IsReadOnly . ���� # [    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   countryNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Country Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *CountryName+  -   countryIdColumn��$ 	CountryId��$
 auto    
IsReadOnly .  �� *CountryName+  -   $ Province_DataGrid��$ VisibleWhenSelected=�$��0,0,0,0q� .  .  $
��auto��$��1������ # [    -   provinceNameColumn��$
 Auto $ Province Name�� �� *ProvinceName+  $
 Auto $ 	CountryId�� �� *	CountryId+  -   provinceIdColumn��$
 Auto $ 
ProvinceId�� .  �� *
ProvinceId+  -	   $ City_DataGrid�� .   . $
��auto��$ VisibleWhenSelected=�$��1��$��2������ # [    -
   cityNameColumn��$ 	City Name��$
 auto  �� *
CityName+  -   cityIdColumn��$ CityId��$ SizeToHeader  .  �� *CityId+  $ 
ProvinceId��$ SizeToHeader  �� *
ProvinceId+  -   $ Suburb_DataGrid�� .   . $ VisibleWhenSelected=�$��2��$
��auto��$��2������ # [    -   suburbNameColumn��$ Suburb Name��$
 auto  �� *
SuburbName+  -   suburbIdColumn��$ SuburbId��$ SizeToHeader  .  �� *
SuburbId+  $ CityId��$ SizeToHeader  �� *CityId+  -   $ Street_DataGrid�� .   . $
��auto��$��2��$ VisibleWhenSelected=�$��3������ # [    -   streetNameColumn��$ Street Name��$
 auto  �� *
StreetName+  -   streetExtensionColumn��$ Street Extension��$
 auto  �� *StreetExtension+  -   streetSuffixColumn��$ Street Suffix��$
 auto  �� *StreetSuffix+  $ SuburbId��$
 auto  �� *
SuburbId+  $ StreetId��$
 auto  .  �� *
StreetId+�� -   $��Submit Country��$��2��$	��101��$
��Left=��� -   $��Submit Province��$��2��$��97��$��Right=��� -   $��Submit City��$��2��$��1��$��75���� -   $��Submit Suburb��$��2��$��2���� -   $��Submit Street��$��2��$��3��$��83��