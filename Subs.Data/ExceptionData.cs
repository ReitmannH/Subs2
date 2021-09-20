using System;
using System.Data;
using System.Data.SqlClient;


namespace Subs.Data
{
    /// <summary>
    /// Summary description for ExceptionData.
    /// </summary>
    public static class ExceptionData
    {
        private static readonly SqlConnection Connection = new SqlConnection();

        static ExceptionData()
        {
            Connection.ConnectionString = Settings.ConnectionString;// This prevents a default constructor from being created.
        }

        public static void WriteException(int Severity, string Message, string Object, string Method,
            string Comment)
        {
            try
            {
                //Remember the stuff in the database

                SqlCommand Command = new SqlCommand();
                SqlDataAdapter Adaptor = new SqlDataAdapter();

                Connection.Open();
                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "dbo.[MIMS.ExceptionData.WriteException]";
                SqlCommandBuilder.DeriveParameters(Command);

                Command.Parameters["@Severity"].Value = Severity;
                Command.Parameters["@Message"].Value = Message;
                Command.Parameters["@Object"].Value = Object;
                Command.Parameters["@Method"].Value = Method;
                Command.Parameters["@Comment"].Value = Comment;
                Command.Parameters["@Version"].Value = Settings.Version;
 
                Command.ExecuteScalar();
            }
            finally
            {
                Connection.Close();
            }

        }
    }
}
