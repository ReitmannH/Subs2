using System;

namespace Subs.Data
{
    public class PostCodeData
    {
        private static readonly Data.PostCodeDocTableAdapters.CodeTableAdapter gCodeAdapter = new PostCodeDocTableAdapters.CodeTableAdapter();
        private static readonly Data.PostCodeDocTableAdapters.AddressLine4TableAdapter gAddressLine4Adapter = new PostCodeDocTableAdapters.AddressLine4TableAdapter();
        private static readonly Data.PostCodeDocTableAdapters.AddressLine3TableAdapter gAddressLine3Adapter = new PostCodeDocTableAdapters.AddressLine3TableAdapter();
        private static readonly Data.PostCodeDocTableAdapters.PostCode_LinearTableAdapter gLinearAdapter = new PostCodeDocTableAdapters.PostCode_LinearTableAdapter();
        private static readonly Data.PostCodeDocTableAdapters.SAPOCodeFlatTableAdapter gSapoAdapter = new PostCodeDocTableAdapters.SAPOCodeFlatTableAdapter();

        static PostCodeData()
        {
            try
            {
                gCodeAdapter.AttachConnection();
                gAddressLine4Adapter.AttachConnection();
                gAddressLine3Adapter.AttachConnection();
                gLinearAdapter.AttachConnection();
                gSapoAdapter.AttachConnection();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "PostCodeData", "PostCodeData constructor", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }
        }

        public static int Merge(string pType, string pCode, string pAddressLine3, string pAddressLine4)
        {
            try
            {
                int lPostCodeId = (int)gCodeAdapter.Merge(pType, pCode);
                int lAddressLine4Id = (int)gAddressLine4Adapter.Merge(lPostCodeId, pAddressLine4);
                int lAddressLine3Id = (int)gAddressLine3Adapter.Merge(lAddressLine4Id, pAddressLine3);
                return lAddressLine3Id;
            }


            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "PostCodeData", "Merge", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return 0;
            }
        }

        public static bool AddSapoCompliment()
        {
            PostCodeDoc.SAPOCodeFlatDataTable lSource = new PostCodeDoc.SAPOCodeFlatDataTable();
            try
            {
                lSource.Clear();
                gSapoAdapter.FillSapoCompliment(lSource, "PostBox");
                foreach (PostCodeDoc.SAPOCodeFlatRow lRow in lSource)
                {
                    if (Merge("PostBox", lRow.Code, lRow.AddressLine3, lRow.AddressLine4) == 0)
                    {
                        return false;
                    }
                }

                lSource.Clear();
                gSapoAdapter.FillSapoCompliment(lSource, "PostStreet");
                foreach (PostCodeDoc.SAPOCodeFlatRow lRow in lSource)
                {
                    if (Merge("PostStreet", lRow.Code, lRow.AddressLine3, lRow.AddressLine4) == 0)
                    {
                        return false;
                    }
                }

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "PostCodeData", "AddLinearRow", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return false;
            }


        }

        public static bool AddLinearRow(PostCodeDoc.PostCode_LinearDataTable pPostCodeLinear, int pAddressLine3Id)
        {
            try
            {
                gLinearAdapter.ClearBeforeFill = false;
                gLinearAdapter.FillByAddressLine3Id(pPostCodeLinear, pAddressLine3Id);
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "PostCodeData", "AddLinearRow", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return false;
            }
        }




    }
}
