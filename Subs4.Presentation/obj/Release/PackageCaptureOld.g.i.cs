﻿#pragma checksum "..\..\PackageCaptureOld.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "019F5A4D7306F1E1E09EADC9163D1F9C"
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
    /// PackageCaptureOld
    /// </summary>
    public partial class PackageCaptureOld : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\PackageCaptureOld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid promotionDataGrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\PackageCaptureOld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn promotionIdColumn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\PackageCaptureOld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn promotionNameColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/Subs4.Presentation;component/packagecaptureold.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PackageCaptureOld.xaml"
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
            
            #line 5 "..\..\PackageCaptureOld.xaml"
            ((Subs4.Presentation.PackageCaptureOld)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.promotionDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\PackageCaptureOld.xaml"
            this.promotionDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.promotionDataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.promotionIdColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.promotionNameColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            
            #line 53 "..\..\PackageCaptureOld.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Capture);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

