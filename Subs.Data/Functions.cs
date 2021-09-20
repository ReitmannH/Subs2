using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Subs.Data
{
    public static class Functions
    {
        static public bool IsInteger(string myString)
        {
            bool Numeric = true;
            foreach (char i in myString)
            {
                if (!char.IsNumber(i)) { Numeric = false; }
            }
            if (!Numeric) { return false; }
            else return true;
        }

        static public bool IsDecimal(string myString)
        {
            Regex myRegEx = new Regex(@"^[\d.-]+$");
            return myRegEx.IsMatch(myString);
        }

        public static int GetCheckedList(CheckedListBox pControl)
        {
            int Number = 0;
            for (int i = 0; i < pControl.Items.Count; i++)
            {
                if (pControl.GetItemChecked(i))
                {
                    Number = Number + (int)Math.Pow(2, i);
                }
            }
            return Number;
        }


        public static void SetCheckedList(CheckedListBox pControl, int Number)
        {
            // Correspondence
            int Size = pControl.Items.Count;

            if (Number > (int)Math.Pow(2, Size) - 1)
            {
                throw new Exception("I cannot handle a number of that size.");
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                if (Number >= (int)Math.Pow(2, i))
                {
                    pControl.SetItemCheckState(i, CheckState.Checked);
                    Number = Number - (int)Math.Pow(2, i);
                }
                else
                {
                    pControl.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            pControl.Refresh();

        }
    }
}
