using System;
using System.Data;
using System.Data.SqlClient;

namespace Subs.Data
{
    public class RenewalData
    {
        private readonly SqlConnection gConnection = new SqlConnection();
        private readonly SqlDataAdapter Adaptor = new SqlDataAdapter();

        public RenewalData()
        {
            gConnection.ConnectionString = Settings.ConnectionString;
        }


        public string Load(RenewalDoc1.RenewalRecordRow NewRow, int SubscriptionId)
        {
            RenewalDoc1.RenewalRecordDataTable myRenewal = new RenewalDoc1.RenewalRecordDataTable();

            try
            {
                SqlCommand Command = new SqlCommand();
                gConnection.Open();
                Command.Connection = gConnection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "dbo.[MIMS.RenewalData.Load]";
                SqlCommandBuilder.DeriveParameters(Command);
                Command.Parameters["@SubscriptionId"].Value = SubscriptionId;

                Adaptor.SelectCommand = Command;

                Adaptor.Fill(myRenewal);

                if (myRenewal.Count == 0)
                {
                    throw new Exception("No data found.");
                }

                NewRow.CustomerId = myRenewal[0].CustomerId.ToString();
                NewRow.SubscriptionId = SubscriptionId.ToString();

                if (!myRenewal[0].IsTitleNull())
                {
                    if (myRenewal[0].Title != "[None]")
                    {
                        NewRow.Title = myRenewal[0].Title;
                    }
                }

                if (!myRenewal[0].IsInitialsNull())
                {
                    NewRow.Initials = myRenewal[0].Initials;
                }

                if (!myRenewal[0].IsFirstNameNull())
                {
                    NewRow.FirstName = myRenewal[0].FirstName;
                }

                if (!myRenewal[0].IsSurnameNull())
                {
                    NewRow.Surname = myRenewal[0].Surname;
                }

                if (!myRenewal[0].IsNationalId1Null())
                {
                    NewRow.NationalId1 = myRenewal[0].NationalId1;
                }

                if (!myRenewal[0].IsNationalId2Null())
                {
                    NewRow.NationalId2 = myRenewal[0].NationalId2;
                }

                if (!myRenewal[0].IsNationalId3Null())
                {
                    NewRow.NationalId3 = myRenewal[0].NationalId3;
                }

                if (!myRenewal[0].IsVatRegistrationNull())
                {
                    NewRow.VatRegistration = myRenewal[0].VatRegistration;
                }

                if (!myRenewal[0].IsCompanyNull())
                {
                    if (myRenewal[0].Company != "[None]")
                    {
                        NewRow.Company = myRenewal[0].Company;
                    }
                }

                if (!myRenewal[0].IsDepartmentNull())
                {
                    NewRow.Department = myRenewal[0].Department;
                }

                if (!myRenewal[0].IsAddress1Null())
                {
                    NewRow.Address1 = myRenewal[0].Address1;
                }

                if (!myRenewal[0].IsAddress2Null())
                {
                    NewRow.Address2 = myRenewal[0].Address2;
                }

                if (!myRenewal[0].IsAddress3Null())
                {
                    NewRow.Address3 = myRenewal[0].Address3;
                }

                if (!myRenewal[0].IsAddress4Null())
                {
                    NewRow.Address4 = myRenewal[0].Address4;
                }

                if (!myRenewal[0].IsAddress5Null())
                {
                    NewRow.Address5 = myRenewal[0].Address5;
                }

                if (!myRenewal[0].IsCountryNull())
                {
                    if (myRenewal[0].Country != "[None]")
                    {
                        NewRow.Country = myRenewal[0].Country;
                    }
                }

                if (!myRenewal[0].IsPhoneNumberNull())
                {
                    NewRow.PhoneNumber = myRenewal[0].PhoneNumber;
                }

                if (!myRenewal[0].IsCellPhoneNumberNull())
                {
                    NewRow.CellPhoneNumber = myRenewal[0].CellPhoneNumber;
                }

               
                if (!myRenewal[0].IsEmailAddressNull())
                {
                    NewRow.EmailAddress = myRenewal[0].EmailAddress;
                }

                if (!myRenewal[0].IsAccountsEMailNull())
                {
                    NewRow.AccountsEMail = myRenewal[0].AccountsEMail;
                }

                if (!myRenewal[0].IsSpecialisationNull())
                {
                    NewRow.Specialisation = myRenewal[0].Specialisation;
                }

                if (!myRenewal[0].IsStreetNull())
                {
                    NewRow.Street = myRenewal[0].Street;
                }

                if (!myRenewal[0].IsStreetNoNull())
                {
                    NewRow.StreetNo = myRenewal[0].StreetNo;
                }

                if (!myRenewal[0].IsBuildingNull())
                {
                    NewRow.Building = myRenewal[0].Building;
                }

                if (!myRenewal[0].IsFloorNoNull())
                {
                    NewRow.FloorNo = myRenewal[0].FloorNo;
                }

                if (!myRenewal[0].IsRoomNull())
                {
                    NewRow.Room = myRenewal[0].Room;
                }

                if (!myRenewal[0].IsSuburbNull())
                {
                    NewRow.Suburb = myRenewal[0].Suburb;
                }

                if (!myRenewal[0].IsCityNull())
                {
                    NewRow.City = myRenewal[0].City;
                }

                if (!myRenewal[0].IsProvinceNull())
                {
                    NewRow.Province = myRenewal[0].Province;
                }

                if (!myRenewal[0].IsPostCodeNull())
                {
                    NewRow.PostCode = myRenewal[0].PostCode;
                }

                if (!myRenewal[0].IsSDINull())
                {
                    NewRow.SDI = myRenewal[0].SDI;
                }

                if (!myRenewal[0].IsCouncilNumberNull())
                {
                    NewRow.CouncilNumber = myRenewal[0].CouncilNumber;
                }

                if (!myRenewal[0].IsPracticeNumber1Null())
                {
                    NewRow.PracticeNumber1 = myRenewal[0].PracticeNumber1;
                }

                if (!myRenewal[0].IsPracticeNumber2Null())
                {
                    NewRow.PracticeNumber2 = myRenewal[0].PracticeNumber2;
                }

                if (!myRenewal[0].IsPracticeNumber3Null())
                {
                    NewRow.PracticeNumber3 = myRenewal[0].PracticeNumber3;
                }

                return "OK";

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Load", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return ex.Message;
            }
            finally
            {
                gConnection.Close();
            }

        }

    }
}
