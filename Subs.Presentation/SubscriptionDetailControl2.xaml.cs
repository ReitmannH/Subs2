using Subs.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;


namespace Subs.Presentation
{
    public partial class SubscriptionDetailControl2 : UserControl, ISubscriptionPicker
    {
        #region Globals

        private readonly SubscriptionDoc3.SubscriptionDerivedDataTable gSubscriptions;
        private System.Windows.Data.CollectionViewSource gSubscriptionViewSource;
        private SubscriptionPicker2 gContainer;

        #endregion

        public SubscriptionDetailControl2(SubscriptionPicker2 pContainer, SubscriptionDoc3.SubscriptionDerivedDataTable pSubscriptionDerived)
        {
            InitializeComponent();
            gContainer = pContainer;
            subscriptionDetailDataGrid.ContextMenu = gContainer.gContextMenu;
            gSubscriptions = pSubscriptionDerived;
            gSubscriptionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["subscriptionViewSource"];
            gSubscriptionViewSource.Source = gSubscriptions;
        }

        public int GetCurrentSubscriptionId()
        {
            try
            {
                System.Data.DataRowView lRowView = (System.Data.DataRowView)gSubscriptionViewSource.View.CurrentItem;
                if (lRowView != null)
                {
                    SubscriptionDoc3.SubscriptionDerivedRow lRow = (SubscriptionDoc3.SubscriptionDerivedRow)lRowView.Row;
                    return lRow.SubscriptionId;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetCurrentSubscriptionId", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return 0;
            }
        }

        private void Click_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Type lType = e.OriginalSource.GetType();
            if (lType.Name == "DataGridHeaderBorder")
            {
                // Do not consider the event handled. Invoke the context menu.
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            subscriptionDetailDataGrid.Height = this.ActualHeight - 50;
        }

        private void Click_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            gContainer.DisplayStatusAndHistory();
        }

     
    }
}
