﻿#pragma checksum "..\..\AddressTypeControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "42A3B015F2945D50B013E0DE67CC4C4C74BB6313D46012E0B192078FEAE67D9A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// AddressTypeControl
    /// </summary>
    public partial class AddressTypeControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\AddressTypeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddressTypeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioStreet;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddressTypeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioInternational;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddressTypeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioUnassigned;
        
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
            System.Uri resourceLocater = new System.Uri("/Subs4.Presentation;component/addresstypecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddressTypeControl.xaml"
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
            this.radioBox = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\AddressTypeControl.xaml"
            this.radioBox.Click += new System.Windows.RoutedEventHandler(this.Click_RadioButton);
            
            #line default
            #line hidden
            return;
            case 2:
            this.radioStreet = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\AddressTypeControl.xaml"
            this.radioStreet.Click += new System.Windows.RoutedEventHandler(this.Click_RadioButton);
            
            #line default
            #line hidden
            return;
            case 3:
            this.radioInternational = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\AddressTypeControl.xaml"
            this.radioInternational.Click += new System.Windows.RoutedEventHandler(this.Click_RadioButton);
            
            #line default
            #line hidden
            return;
            case 4:
            this.radioUnassigned = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\AddressTypeControl.xaml"
            this.radioUnassigned.Click += new System.Windows.RoutedEventHandler(this.Click_RadioButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
