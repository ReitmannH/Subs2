﻿#pragma checksum "..\..\SubscriptionDormantControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9B218A664D7785C52B2F3E5D139216C2B48F93D7260A56A5806C80BF86D1AA1"
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
using Subs4.Presentation;
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


namespace Subs4.Presentation {
    
    
    /// <summary>
    /// SubscriptionDormantControl
    /// </summary>
    public partial class SubscriptionDormantControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DormantDataGrid;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn lastDeliveryDateColumn;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn subscriptionIdColumn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn productNameColumn;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn payerColumn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn liabilityColumn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn lastSequenceByProductColumn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn lastsequenceBySubscriptionColumn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\SubscriptionDormantControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn lagByIssuesColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/Subs4.Presentation;component/subscriptiondormantcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SubscriptionDormantControl.xaml"
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
            
            #line 8 "..\..\SubscriptionDormantControl.xaml"
            ((Subs4.Presentation.SubscriptionDormantControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\SubscriptionDormantControl.xaml"
            ((Subs4.Presentation.SubscriptionDormantControl)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.UserControl_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DormantDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\SubscriptionDormantControl.xaml"
            this.DormantDataGrid.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Click_MouseRightButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lastDeliveryDateColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.subscriptionIdColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.productNameColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.payerColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.liabilityColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.lastSequenceByProductColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.lastsequenceBySubscriptionColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.lagByIssuesColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
