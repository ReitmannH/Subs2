﻿#pragma checksum "..\..\AdministrationPromotion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0271619D92120BBA926D0C918197A4ED1F6362683D4DD5B2829070C1681196DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Subs.Data;
using Subs.Presentation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Subs.Presentation {
    
    
    /// <summary>
    /// AdministrationPromotion
    /// </summary>
    public partial class AdministrationPromotion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PromotionDataGrid;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemPayer;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemProduct;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemPayerClear;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PayerColumn;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ProductColumn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn DiscountPercentageColumn;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn StartDateColumn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn EndDateColumn;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAdd;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSubmit;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\AdministrationPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Subs.Presentation;component/administrationpromotion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdministrationPromotion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PromotionDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\AdministrationPromotion.xaml"
            this.PromotionDataGrid.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.ValidationError));
            
            #line default
            #line hidden
            return;
            case 2:
            this.MenuItemPayer = ((System.Windows.Controls.MenuItem)(target));
            
            #line 39 "..\..\AdministrationPromotion.xaml"
            this.MenuItemPayer.Click += new System.Windows.RoutedEventHandler(this.AddPayer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuItemProduct = ((System.Windows.Controls.MenuItem)(target));
            
            #line 40 "..\..\AdministrationPromotion.xaml"
            this.MenuItemProduct.Click += new System.Windows.RoutedEventHandler(this.AddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MenuItemPayerClear = ((System.Windows.Controls.MenuItem)(target));
            
            #line 41 "..\..\AdministrationPromotion.xaml"
            this.MenuItemPayerClear.Click += new System.Windows.RoutedEventHandler(this.PayerClear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PayerColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.ProductColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.DiscountPercentageColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.StartDateColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 9:
            this.EndDateColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 10:
            this.buttonAdd = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\AdministrationPromotion.xaml"
            this.buttonAdd.Click += new System.Windows.RoutedEventHandler(this.buttonAdd_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.buttonSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\AdministrationPromotion.xaml"
            this.buttonSubmit.Click += new System.Windows.RoutedEventHandler(this.buttonSubmit_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.buttonExit = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\AdministrationPromotion.xaml"
            this.buttonExit.Click += new System.Windows.RoutedEventHandler(this.buttonExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
