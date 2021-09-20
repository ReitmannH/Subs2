using System;
using System.Data;
using System.Data.SqlClient;


namespace Subs.Data
{
    /// <summary>
    /// Summary description for LedgerData.
    /// </summary>
    public class DeliveryData
    {
        private readonly SqlConnection Connection = new SqlConnection();

        public DeliveryData()
        {
            // Set the connectionString for this object
            ;
            if (Settings.ConnectionString == "")
            {
                // This makes it possible to use the Visual studio designer.
                Connection.ConnectionString = global::Subs.Data.Properties.Settings.Default.MIMSConnectionString;
            }
            else
            {
                Connection.ConnectionString = Settings.ConnectionString;
            }
        }

        public bool LoadLabelByCustomer(int CustomerId, ref Data.DeliveryDoc pDeliveryDoc)
        {
            try
            {
                // Cleanup before you start a new one

                pDeliveryDoc.Label.Clear();

                // Get new data
                SqlCommand Command = new SqlCommand();
                SqlDataAdapter Adaptor = new SqlDataAdapter();
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "dbo.[MIMS.DeliveryData.LoadLabelByCustomer]";
                SqlCommandBuilder.DeriveParameters(Command);
                Adaptor.SelectCommand = Command;
                Command.Parameters["@Type"].Value = "ByCustomer";
                Command.Parameters["@Id"].Value = CustomerId;
                Adaptor.Fill(pDeliveryDoc.Label);

                if (pDeliveryDoc.Label.Rows.Count == 0)
                {
                    ExceptionData.WriteException(3, "There are no labels for " + CustomerId.ToString(), this.ToString(), "LoadLabelByCustomer", "");
                    return false;
                }
                else return true;
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "LoadLabelByCustomer", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return false;
            }

            finally
            {
                Connection.Close();
            }

        }

        public bool DefragSingleLabel(ref DeliveryDoc pDeliveryDoc)
        {
            int y = 0;  // y for column 
            int yMax = 8; //Maximum index for the array

            Array myArray = Array.CreateInstance(typeof(string), yMax + 1);
            myArray.Initialize();

            try
            {
                // Start with a clean slate
                pDeliveryDoc.Accross.Clear();

                // Get the first and only row

                DeliveryDoc.LabelRow myRow = (DeliveryDoc.LabelRow)pDeliveryDoc.Label.Rows[0];

                // Load the appropriate column

                if (!myRow.IsCompanyNull())
                {
                    if (myRow.Company != "[None]")
                    {
                        myArray.SetValue(myRow.Company.Trim(), y);
                        y++;
                    }
                }

                if (!myRow.IsDepartmentNull())
                {
                    if (myRow.Department.Trim() != "")
                    {
                        myArray.SetValue(myRow.Department.Trim(), y);
                        y++;
                    }
                }


                if (!myRow.IsTitleNull())
                {
                    if (myRow.Title != "[None]")
                        myArray.SetValue(myRow.Title.Trim() + " ", y);
                }

                if (!myRow.IsInitialsNull())
                    myArray.SetValue(myArray.GetValue(y) + myRow.Initials.Trim() + " ", y);

                if (!myRow.IsSurnameNull())
                    myArray.SetValue(myArray.GetValue(y) + myRow.Surname.Trim() + " ", y);

                if (myArray.GetValue(y) != null) y++;


                if (!myRow.IsAddress1Null())
                {
                    if (myRow.Address1.Trim() != "")
                    {
                        myArray.SetValue(myRow.Address1.Trim(), y);
                        y++;
                    }
                }

                if (!myRow.IsAddress2Null())
                {
                    if (myRow.Address2.Trim() != "")
                    {
                        myArray.SetValue(myRow.Address2.Trim(), y);
                        y++;
                    }
                }

                if (!myRow.IsAddress3Null())
                {
                    if (myRow.Address3.Trim() != "")
                    {
                        myArray.SetValue(myRow.Address3.Trim(), y);
                        y++;
                    }
                }

                if (!myRow.IsAddress4Null())
                {
                    if (myRow.Address4.Trim() != "")
                    {
                        myArray.SetValue(myRow.Address4.Trim(), y);
                        y++;
                    }
                }

                if (!myRow.IsCountryNull())
                {
                    if (myRow.Country != "[None]")
                    {
                        myArray.SetValue(myRow.Country.Trim(), y);
                        y++;
                    }
                }

                if (!myRow.IsAddress5Null())
                {
                    if (myRow.Address5.Trim() != "")
                    {
                        myArray.SetValue(myRow.Address5.Trim(), y);
                        y++;
                    }
                }

                //Test for overflow. At this point y will be ready for the next entry.
                // So decrement it
                y--;
                if (y > yMax)
                {
                    throw new Exception("You are trying to generate too many lines for this label.");
                }


                // Create a new row

                DeliveryDoc.AccrossRow NewRow = pDeliveryDoc.Accross.NewAccrossRow();

                for (int Row = 0; Row <= y; Row++)
                {
                    NewRow[Row * 3] = myArray.GetValue(Row);
                }

                pDeliveryDoc.Accross.AddAccrossRow(NewRow);

                return true;
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "DefragSingleLabel", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return false;
            }

        }
    }
}
