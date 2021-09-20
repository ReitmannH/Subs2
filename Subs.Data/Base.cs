using System;
using System.Windows;
using System.Windows.Threading;

namespace Subs.Data
{
    public static class ExtensionMethods
    {

        private static readonly Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)

        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

    }



    public static class Base
    {
        static Base()
        {
        }
  
        public class CounterEventArgs : EventArgs
        {
            public int Counter;
        }

        public delegate void CounterEventHandler(object sender, CounterEventArgs e);

    }


    public enum SubscriptionType
    {
        Any = 1,
        Single = 2,
        Subscription = 3
    }

    public enum SubscriptionMedium
    {
        Both = 1,
        Print = 2,
        Electronic = 3
    }

    public enum ProductCategory
    {
        MedicinesInformation = 1,
        TreatmentAppoaches = 2,
        VetenaryMedicines = 3
    }



    public struct ProgressType
    {
        public int Counter;
        public int Counter2;
        public int StockShortCount;
    }



    public enum SubStatus
    {
        Deliverable = 1,
        Suspended = 2,
        Hold = 3,
        Cancelled = 4,
        Expired = 5,
        Proposed = 6
    }

    public enum AddressType
    {
        Unknown = 0,
        International = 1,
        PostBox = 2,
        PostStreet = 3,
        UnAssigned = 4

    }

    public enum CustomerStatus
    {
        Active = 1,
        Cancelled = 2,
        Dormant = 3, // Not a receiver or payer of any subscriptions
        Unknown = 4
    }


    public enum Title
    {
        None = 1,
        Capt = 2,
        Col = 3,
        Dr = 4,
        Drs = 5,
        Lt = 6,
        LtCol = 7,
        Maj = 8,
        Matron = 9,
        Mej = 10,
        Mev = 11,
        Miss = 12,
        Mnr = 13,
        Mr = 14,
        Mrs = 15,
        Ms = 16,
        Prof = 17,
        Sgt = 18,
        Sr = 19,
        Supd = 20,
        Insp = 21,
        WOO = 22,
        Cpl = 23,
        Adv = 24,
        Ssgt = 25,
        Rev = 26,
        Pastor = 27,
        Ds = 28
    }

    public enum PaymentMethod
    {
        Cash = 1,
        Cheque = 2,
        Debitorder = 3,
        DirectDeposit = 4,
        Creditcard = 5,
        Migration = 6,
        DebitOrderContinuous = 7,
        EFTDeposit = 8,
        PayU = 9
    }


    public enum ReferenceType
    {
        ChequeNumber = 2,
        TrackingNumber = 3,
        ReceiptNumber = 4,
        AllocationNumber = 5,
        DirectDeposit = 6,
        ReductionInUnits = 7
    }


    public enum Operation
    {
        Pay = 1,
        Deliver = 2,
        Extend = 3,
        Refund = 4,
        Hold = 5,
        Suspend = 6,
        Resume = 7,
        //UpdateCreditLimit = 8,
        CancelSubscription = 9,
        Expire = 10,
        Skip = 11,
        Return = 12,
        Initialise = 13,
        Credit = 14,
        CancelCustomer = 15,
        Init_Sub = 16,
        DeliverableUpTo = 17,
        Balance = 18,
        VATInvoice = 19,
        UpdateCustomer = 20,
        ChangeUnitsPerIssue = 21,
        CreditNote = 22,
        WriteOffMoney = 23,
        ReversePayment = 24,
        ReverseWriteOffMoney = 25,
        //ArchivedBalance = 26,
        ReverseDelivery = 27,
        ChangeReceiver = 28,
        BroughtForward = 29,
        ChangeRenewalNotice = 30,
        ChangeAutomaticRenewal = 31,
        AllocatePaymentToInvoice = 32,
        Statement = 33, 
        PayU = 34
    }

    public enum ReturnAction
    {
        Redeliver = 1,
        Skip = 2
    }

    public enum Correspondence
    {
        EMail = 1,
        SMS = 2,
        WhatsUp = 4,
        Phone = 8
    }

    public enum DeliveryMethod
    {
        Mail = 1,
        Collect = 2,
        Courier = 4,
        RegisteredMail = 8,
        ElectronicSingle = 16,
        ElectronicMultiple = 32
    }

}
