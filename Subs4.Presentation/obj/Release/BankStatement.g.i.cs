#pragma checksum "..\..\BankStatement.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "707C5ACD02FEF22BB72B0DA04E9B15F2"
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


namespace Subs4.Presentation
{


    /// <summary>
    /// BankStatement
    /// </summary>
    public partial class BankStatement : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 24 "..\..\BankStatement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonLoad;

#line default
#line hidden


#line 31 "..\..\BankStatement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSelectAll;

#line default
#line hidden


#line 32 "..\..\BankStatement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSelectOnly;

#line default
#line hidden


#line 34 "..\..\BankStatement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonValidate;

#line default
#line hidden


#line 35 "..\..\BankStatement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPost;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Subs4.Presentation;component/bankstatement.xaml", System.UriKind.Relative);

#line 1 "..\..\BankStatement.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.buttonLoad = ((System.Windows.Controls.Button)(target));

#line 24 "..\..\BankStatement.xaml"
                    this.buttonLoad.Click += new System.Windows.RoutedEventHandler(this.buttonLoad_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.buttonSelectAll = ((System.Windows.Controls.Button)(target));

#line 31 "..\..\BankStatement.xaml"
                    this.buttonSelectAll.Click += new System.Windows.RoutedEventHandler(this.buttonSelectAll_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.buttonSelectOnly = ((System.Windows.Controls.Button)(target));

#line 32 "..\..\BankStatement.xaml"
                    this.buttonSelectOnly.Click += new System.Windows.RoutedEventHandler(this.buttonSelectOnly_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.buttonValidate = ((System.Windows.Controls.Button)(target));

#line 34 "..\..\BankStatement.xaml"
                    this.buttonValidate.Click += new System.Windows.RoutedEventHandler(this.buttonSelectAll_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.buttonPost = ((System.Windows.Controls.Button)(target));

#line 35 "..\..\BankStatement.xaml"
                    this.buttonPost.Click += new System.Windows.RoutedEventHandler(this.buttonSelectOnly_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.DataGrid fNBBankStatementDataGrid;
        internal System.Windows.Controls.DataGridTextColumn statementNoColumn;
        internal System.Windows.Controls.DataGridTemplateColumn transactionDateColumn;
        internal System.Windows.Controls.DataGridTextColumn transactionIdColumn;
        internal System.Windows.Controls.DataGridTextColumn amountColumn;
        internal System.Windows.Controls.DataGridTextColumn referenceColumn;
        internal System.Windows.Controls.DataGridTextColumn invoiceNumberColumn;
        internal System.Windows.Controls.DataGridTextColumn customerIdColumn;
        internal System.Windows.Controls.DataGridTextColumn errorMessageColumn;
        internal System.Windows.Controls.DataGridTextColumn bankTransactionTypeColumn;
        internal System.Windows.Controls.DataGridTextColumn bankPaymentMethodColumn;
    }
}

