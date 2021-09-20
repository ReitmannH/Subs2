using System.Data.SqlClient;
namespace Subs.Data.SubscriptionDoc3TableAdapters
{

    partial class CommentTableAdapter
    {
        private SqlConnection myConnection = new SqlConnection();
        public event Subs.Data.Base.FeedbackEventHandler Feedback;
        private Subs.Data.Base.FeedbackEventArgs e = new Subs.Data.Base.FeedbackEventArgs();

        public bool AttachConnection()
        {
            try
            {
                // Set the connectionString for this object
                //;
                if (Settings.ConnectionString == "")
                {
                    // This makes it possible to use the Visual studio designer.
                    //myConnection.ConnectionString = global::Subs.Data.Properties.Settings.Default.SubsConnectionString;
                    if (Feedback != null)
                    {
                        e.Severity = 1;
                        e.Message = "No connectionstring was set for this connection";
                        e.Object = this.ToString();
                        e.Method = "AttachConnection";
                        e.Comment = "";
                        Feedback(this, e);
                    }
                    return false;
                }
                else
                {
                    myConnection.ConnectionString = Settings.ConnectionString;
                }


                // Replace the designer's connection with yor own one.
                foreach (SqlCommand myCommand in CommandCollection)
                {
                    myCommand.Connection = myConnection;
                }

                this.Adapter.UpdateCommand.Connection = myConnection;
                this.Adapter.InsertCommand.Connection = myConnection;
                this.Adapter.DeleteCommand.Connection = myConnection;

                return true;
            }
            catch (System.Exception Ex)
            {
                if (Feedback != null)
                {
                    e.Severity = 1;
                    e.Message = Ex.Message;
                    e.Object = this.ToString();
                    e.Method = "AttachConnection";
                    e.Comment = "";
                    Feedback(this, e);
                }
                return false;
            }
        }
    }



    partial class SubscriptionTableAdapter
    {
        public event Subs.Data.Base.FeedbackEventHandler Feedback;
        private Subs.Data.Base.FeedbackEventArgs e = new Subs.Data.Base.FeedbackEventArgs();
        private SqlConnection myConnection = new SqlConnection();

        public bool AttachTransaction(ref SqlTransaction myTransaction)
        {
            try
            {
                // Replace the designer's connection with yor own one.
                foreach (SqlCommand myCommand in CommandCollection)
                {
                    myCommand.Connection = myTransaction.Connection;
                    myCommand.Transaction = myTransaction;

                }

                this.Adapter.UpdateCommand.Transaction = myTransaction;
                this.Adapter.InsertCommand.Transaction = myTransaction;
                this.Adapter.DeleteCommand.Transaction = myTransaction;

                this.Adapter.UpdateCommand.Connection = myTransaction.Connection;
                this.Adapter.InsertCommand.Connection = myTransaction.Connection;
                this.Adapter.DeleteCommand.Connection = myTransaction.Connection;

                return true;
            }
            catch (System.Exception Ex)
            {
                if (Feedback != null)
                {
                    e.Severity = 1;
                    e.Message = Ex.Message;
                    e.Object = this.ToString();
                    e.Method = "AttachTransaction";
                    e.Comment = "";
                    Feedback(this, e);
                }
                return false;
            }
        }


        public bool AttachConnection()
        {
            try
            {
                // Set the connectionString for this object
                
                if (Settings.ConnectionString == "")
                {
                    // This makes it possible to use the Visual studio designer.
                    //myConnection.ConnectionString = global::Subs.Data.Properties.Settings.Default.SubsConnectionString;
                    if (Feedback != null)
                    {
                        e.Severity = 1;
                        e.Message = "No connectionstring was set for this connection";
                        e.Object = this.ToString();
                        e.Method = "AttachConnection";
                        e.Comment = "";
                        Feedback(this, e);
                    } 
                    return false;
                }
                else
                {
                    myConnection.ConnectionString = Settings.ConnectionString;
                }

                // Replace the designer's connection with yor own one.
                foreach (SqlCommand myCommand in CommandCollection)
                {
                    myCommand.Connection = myConnection;
                }

                this.Adapter.UpdateCommand.Connection = myConnection;
                this.Adapter.InsertCommand.Connection = myConnection;
                this.Adapter.DeleteCommand.Connection = myConnection;

                return true;
            }
            catch (System.Exception Ex)
            {
                if (Feedback != null)
                {
                    e.Severity = 1;
                    e.Message = Ex.Message;
                    e.Object = this.ToString();
                    e.Method = "AttachConnection";
                    e.Comment = "";
                    Feedback(this, e);
                }
                return false;
            }
        }
    }


    partial class SubscriptionDetailTableAdapter
    {
        private SqlConnection myConnection = new SqlConnection();
        public event Subs.Data.Base.FeedbackEventHandler Feedback;
        private Subs.Data.Base.FeedbackEventArgs e = new Subs.Data.Base.FeedbackEventArgs();

        public bool AttachConnection()
        {
            try
            {
                // Set the connectionString for this object
                ;
                if (Settings.ConnectionString == "")
                {
                    // This makes it possible to use the Visual studio designer.
                    //myConnection.ConnectionString = global::Subs.Data.Properties.Settings.Default.SubsConnectionString;
                    if (Feedback != null)
                    {
                        e.Severity = 1;
                        e.Message = "No connectionstring was set for this connection";
                        e.Object = this.ToString();
                        e.Method = "AttatchTransaction";
                        e.Comment = "";
                        Feedback(this, e);
                    }
                    return false;
                }
                else
                {
                    myConnection.ConnectionString = Settings.ConnectionString;
                }

                // Replace the designer's connection with your own one.
                foreach (SqlCommand myCommand in CommandCollection)
                {
                    myCommand.Connection = myConnection;
                }

                //this.Adapter.UpdateCommand.Connection = myConnection;
                //this.Adapter.InsertCommand.Connection = myConnection;
                //this.Adapter.DeleteCommand.Connection = myConnection;

                return true;
            }
            catch (System.Exception Ex)
            {
                if (Feedback != null)
                {
                    e.Severity = 1;
                    e.Message = Ex.Message;
                    e.Object = this.ToString();
                    e.Method = "AttachConnection";
                    e.Comment = "";
                    Feedback(this, e);
                }
                return false;
            }
        }
    }

    partial class SubscriptionIssueTableAdapter
    {
        public event Subs.Data.Base.FeedbackEventHandler Feedback;
        private Subs.Data.Base.FeedbackEventArgs e = new Subs.Data.Base.FeedbackEventArgs();
        private SqlConnection myConnection = new SqlConnection();

        public bool AttachTransaction(ref SqlTransaction myTransaction)
        {
            try
            {
                // Replace the designer's connection with yor own one.
                foreach (SqlCommand myCommand in CommandCollection)
                {
                    myCommand.Connection = myTransaction.Connection;
                    myCommand.Transaction = myTransaction;

                }

                this.Adapter.UpdateCommand.Transaction = myTransaction;
                this.Adapter.InsertCommand.Transaction = myTransaction;
                this.Adapter.DeleteCommand.Transaction = myTransaction;

                this.Adapter.UpdateCommand.Connection = myTransaction.Connection;
                this.Adapter.InsertCommand.Connection = myTransaction.Connection;
                this.Adapter.DeleteCommand.Connection = myTransaction.Connection;

                return true;
            }
            catch (System.Exception Ex)
            {
                if (Feedback != null)
                {
                    e.Severity = 1;
                    e.Message = Ex.Message;
                    e.Object = this.ToString();
                    e.Method = "AttachTransaction";
                    e.Comment = "";
                    Feedback(this, e);
                }
                return false;
            }
        }


        public bool AttachConnection()
        {
            try
            {
                // Set the connectionString for this object

                if (Settings.ConnectionString == "")
                {
                    // This makes it possible to use the Visual studio designer.
                    //myConnection.ConnectionString = global::Subs.Data.Properties.Settings.Default.SubsConnectionString;
                    if (Feedback != null)
                    {
                        e.Severity = 1;
                        e.Message = "No connectionstring was set for this connection";
                        e.Object = this.ToString();
                        e.Method = "AttachConnection";
                        e.Comment = "";
                        Feedback(this, e);
                    }
                    return false;
                }
                else
                {
                    myConnection.ConnectionString = Settings.ConnectionString;
                }

                // Replace the designer's connection with yor own one.
                foreach (SqlCommand myCommand in CommandCollection)
                {
                    myCommand.Connection = myConnection;
                }

                this.Adapter.UpdateCommand.Connection = myConnection;
                this.Adapter.InsertCommand.Connection = myConnection;
                this.Adapter.DeleteCommand.Connection = myConnection;

                return true;
            }
            catch (System.Exception Ex)
            {
                if (Feedback != null)
                {
                    e.Severity = 1;
                    e.Message = Ex.Message;
                    e.Object = this.ToString();
                    e.Method = "AttachConnection";
                    e.Comment = "";
                    Feedback(this, e);
                }
                return false;
            }
        }
    }

} 


namespace Subs.Data {


    partial class SubscriptionDoc3
    {
        partial class SubscriptionDataTable
        {
        }
    }
}
