using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace EDI_Reader_v0._1
{
    internal class TransactionSetHeaderLoop
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Kasun Perera\source\repos\EDI Reader v0.1\EDI Reader v0.1\EDI_Reader.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        private string iSA_IEA_Loop;
        private string folderPath;

        Regex ST_SE, ST01_Regx, ST02_Regx, BPR01_Regx, BPR02_Regx, BPR03_Regx, BPR04_Regx, BPR05_Regx, BPR06_Regx, BPR07_Regx, BPR08_Regx, BPR09_Regx, BPR10_Regx, BPR11_Regx, BPR12_Regx, BPR13_Regx,
            BPR14_Regx, BPR15_Regx, BPR16_Regx, TRN01_Regx, TRN02_Regx, TRN03_Regx, TRN04_Regx, REF01_Regx, REF02_Regx, DTM01_Regx, DTM02_Regx;

        MatchCollection ST_SE_Loop1;

        Match ST_SE_match, ST_SE_01, ST_SE_02, BPR_01, BPR_02, BPR_03, BPR_04, BPR_05, BPR_06, BPR_07, BPR_08, BPR_09, BPR_10, BPR_11, BPR_12, BPR_13, BPR_14, BPR_15, BPR_16, TRN_01, TRN_02, TRN_03, TRN_04, REF_01, REF_02, DTM_01, DTM_02;

        String ST_SE_Loop, ST01, ST02, BPR01, BPR02, BPR03, BPR04, BPR05, BPR06, BPR07, BPR08, BPR09, BPR10, BPR11, BPR12, BPR13, BPR14, BPR15, BPR16,TRN01, TRN02, TRN03, TRN04, REF01, REF02, DTM01, DTM02;

        String ST011, ST021, BPR011, BPR021, BPR031, BPR041, BPR051, BPR061, BPR071, BPR081, BPR091, BPR101, BPR111, BPR121, BPR131, BPR141, BPR151, BPR161, TRN011, TRN021, TRN031, TRN041, REF011, REF021, DTM011, DTM021;

        System.Windows.Forms.CheckBox checkBox2;

        CheckedListBox checkedListBox2;

        public TransactionSetHeaderLoop(string iSA_IEA_Loop, string folderPath, System.Windows.Forms.CheckBox checkBox2, CheckedListBox checkedListBox2)
        {
            this.iSA_IEA_Loop = iSA_IEA_Loop;
            this.folderPath = folderPath;
            this.checkBox2 = checkBox2;
            this.checkedListBox2 = checkedListBox2;

            // Create a Regex object with the specified pattern for Find ST_SE Loop
            ST_SE = new Regex(@"(ST)([\s\S]*?)SE([*\d])+~");

            // Use the Matches method to find all matches in the input string
            ST_SE_Loop1 = ST_SE.Matches(iSA_IEA_Loop);

            // Iterate over the matches and display the matched values
            foreach (Match each_ST_SE in ST_SE_Loop1)
            {
                ST_SE_Loop = each_ST_SE.Value;

                ST01_Regx = new Regex(@"(?<=ST\*).+?(?=\*)");
                ST_SE_01 = ST01_Regx.Match(ST_SE_Loop);
                if (ST_SE_01.Success)
                {
                    ST01 = ST_SE_01.Value;
                }
                else
                {
                    ST01 = "";
                }

                if (checkedListBox2.GetItemChecked(0) == true)
                {
                    ST011 = ST01;
                }
                else
                {
                    ST011 = "";
                }

                ST02_Regx = new Regex(@"(?<=""+str_ST01+""\*).+?(?=\~)");
                ST_SE_02 = ST02_Regx.Match(ST_SE_Loop);
                if (ST_SE_02.Success)
                {
                    ST02 = ST_SE_02.Value;
                }
                else
                {
                    ST02 = "";
                }

                if (checkedListBox2.GetItemChecked(1) == true)
                {
                    ST021 = ST02;
                }
                else
                {
                    ST021 = "";
                }

                BPR01_Regx = new Regex(@"(?<=BPR\*).+?(?=\*)");
                BPR_01 = BPR01_Regx.Match(ST_SE_Loop);
                if (BPR_01.Success)
                {
                    BPR01 = BPR_01.Value;
                }
                else
                {
                    BPR01 = "";
                }

                if (checkedListBox2.GetItemChecked(2) == true)
                {
                    BPR011 = BPR01;
                }
                else
                {
                    BPR011 = "";
                }

                BPR02_Regx = new Regex(@"(?<=BPR\*"+ BPR01 + @"\*).+?(?=\*)");
                BPR_02 = BPR02_Regx.Match(ST_SE_Loop);
                if (BPR_02.Success)
                {
                    BPR02 = BPR_02.Value;
                }
                else
                {
                    BPR02 = "";
                }

                if (checkedListBox2.GetItemChecked(3) == true)
                {
                    BPR021 = BPR02;
                }
                else
                {
                    BPR021 = "";
                }

                BPR03_Regx = new Regex(@"(?<=BPR\*"+BPR01+@"\*"+BPR02+@"\*).+?(?=\*)");
                BPR_03 = BPR03_Regx.Match(ST_SE_Loop);
                if (BPR_03.Success)
                {
                    BPR03 = BPR_03.Value;
                }
                else
                {
                    BPR03 = "";
                }

                if (checkedListBox2.GetItemChecked(4) == true)
                {
                    BPR031 = BPR03;
                }
                else
                {
                    BPR031 = "";
                }

                BPR04_Regx = new Regex(@"(?<=BPR\*"+BPR01+@"\*"+BPR02+@"\*"+BPR03+@"\*).+?(?=\*)");
                BPR_04 = BPR04_Regx.Match(ST_SE_Loop);
                if (BPR_04.Success)
                {
                    BPR04 = BPR_04.Value;
                }
                else
                {
                    BPR04 = "";
                }

                if (checkedListBox2.GetItemChecked(5) == true)
                {
                    BPR041 = BPR04;
                }
                else
                {
                    BPR041 = "";
                }

                BPR05_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*).+?(?=\*)");
                BPR_05 = BPR05_Regx.Match(ST_SE_Loop);
                if (BPR_05.Success)
                {
                    BPR05 = BPR_05.Value;
                }
                else
                {
                    BPR05 = "";
                }

                if (checkedListBox2.GetItemChecked(6) == true)
                {
                    BPR051 = BPR05;
                }
                else
                {
                    BPR051 = "";
                }

                if (BPR05 == "*")
                {
                    BPR05 = "";
                    BPR051 = BPR05;

                    BPR06_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*).+?(?=\*)");
                    BPR_06 = BPR06_Regx.Match(ST_SE_Loop);
                    if (BPR_06.Success)
                    {
                        BPR06 = BPR_06.Value;
                    }
                    else
                    {
                        BPR06 = "";
                    }

                    if (checkedListBox2.GetItemChecked(7) == true)
                    {
                        BPR061 = BPR06;
                    }
                    else
                    {
                        BPR061 = "";
                    }
                }
                else
                {
                    BPR06_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*).+?(?=\*)");
                    BPR_06 = BPR06_Regx.Match(ST_SE_Loop);
                    if (BPR_06.Success)
                    {
                        BPR06 = BPR_06.Value;
                    }
                    else
                    {
                        BPR06 = "";
                    }

                    if (checkedListBox2.GetItemChecked(7) == true)
                    {
                        BPR061 = BPR06;
                    }
                    else
                    {
                        BPR061 = "";
                    }
                }

                if (BPR06 == "*")
                {
                    BPR06 = "";
                    BPR061 = BPR06;

                    BPR07_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*).+?(?=\*)");
                    BPR_07 = BPR07_Regx.Match(ST_SE_Loop);
                    if (BPR_07.Success)
                    {
                        BPR07 = BPR_07.Value;
                    }
                    else
                    {
                        BPR07 = "";
                    }

                    if (checkedListBox2.GetItemChecked(8) == true)
                    {
                        BPR071 = BPR07;
                    }
                    else
                    {
                        BPR071 = "";
                    }
                }
                else
                {
                    BPR07_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*).+?(?=\*)");
                    BPR_07 = BPR07_Regx.Match(ST_SE_Loop);
                    if (BPR_07.Success)
                    {
                        BPR07 = BPR_07.Value;
                    }
                    else
                    {
                        BPR07 = "";
                    }

                    if (checkedListBox2.GetItemChecked(8) == true)
                    {
                        BPR071 = BPR07;
                    }
                    else
                    {
                        BPR071 = "";
                    }
                }

                if (BPR07 == "*")
                {
                    BPR07 = "";
                    BPR071 = BPR07;

                    BPR08_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*).+?(?=\*)");
                    BPR_08 = BPR08_Regx.Match(ST_SE_Loop);
                    if (BPR_08.Success)
                    {
                        BPR08 = BPR_08.Value;
                    }
                    else
                    {
                        BPR08 = "";
                    }

                    if (checkedListBox2.GetItemChecked(9) == true)
                    {
                        BPR081 = BPR08;
                    }
                    else
                    {
                        BPR081 = "";
                    }
                }
                else
                {
                    BPR08_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*).+?(?=\*)");
                    BPR_08 = BPR08_Regx.Match(ST_SE_Loop);
                    if (BPR_08.Success)
                    {
                        BPR08 = BPR_08.Value;
                    }
                    else
                    {
                        BPR08 = "";
                    }

                    if (checkedListBox2.GetItemChecked(9) == true)
                    {
                        BPR081 = BPR08;
                    }
                    else
                    {
                        BPR081 = "";
                    }
                }

                if (BPR08 == "*")
                {
                    BPR08 = "";
                    BPR081 = BPR08;

                    BPR09_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*).+?(?=\*)");
                    BPR_09 = BPR09_Regx.Match(ST_SE_Loop);
                    if (BPR_09.Success)
                    {
                        BPR09 = BPR_09.Value;
                    }
                    else
                    {
                        BPR09 = "";
                    }

                    if (checkedListBox2.GetItemChecked(10) == true)
                    {
                        BPR091 = BPR09;
                    }
                    else
                    {
                        BPR091 = "";
                    }
                }
                else
                {
                    BPR09_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*).+?(?=\*)");
                    BPR_09 = BPR09_Regx.Match(ST_SE_Loop);
                    if (BPR_09.Success)
                    {
                        BPR09 = BPR_09.Value;
                    }
                    else
                    {
                        BPR09 = "";
                    }

                    if (checkedListBox2.GetItemChecked(10) == true)
                    {
                        BPR091 = BPR09;
                    }
                    else
                    {
                        BPR091 = "";
                    }
                }

                if (BPR09 == "*")
                {
                    BPR09 = "";
                    BPR091 = BPR09;

                    BPR10_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*).+?(?=\*)");
                    BPR_10 = BPR10_Regx.Match(ST_SE_Loop);
                    if (BPR_10.Success)
                    {
                        BPR10 = BPR_10.Value;
                    }
                    else
                    {
                        BPR10 = "";
                    }

                    if (checkedListBox2.GetItemChecked(11) == true)
                    {
                        BPR101 = BPR10;
                    }
                    else
                    {
                        BPR101 = "";
                    }
                }
                else
                {
                    BPR10_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*).+?(?=\*)");
                    BPR_10 = BPR10_Regx.Match(ST_SE_Loop);
                    if (BPR_10.Success)
                    {
                        BPR10 = BPR_10.Value;
                    }
                    else
                    {
                        BPR10 = "";
                    }

                    if (checkedListBox2.GetItemChecked(11) == true)
                    {
                        BPR101 = BPR10;
                    }
                    else
                    {
                        BPR101 = "";
                    }
                }

                if (BPR10 == "*")
                {
                    BPR10 = "";
                    BPR101 = BPR10;

                    BPR11_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*\*).+?(?=\*)");
                    BPR_11 = BPR11_Regx.Match(ST_SE_Loop);
                    if (BPR_11.Success)
                    {
                        BPR11 = BPR_11.Value;
                    }
                    else
                    {
                        BPR11 = "";
                    }

                    if (checkedListBox2.GetItemChecked(12) == true)
                    {
                        BPR111 = BPR11;
                    }
                    else
                    {
                        BPR111 = "";
                    }
                }
                else
                {
                    BPR11_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*" + BPR10 + @"\*).+?(?=\*)");
                    BPR_11 = BPR11_Regx.Match(ST_SE_Loop);
                    if (BPR_11.Success)
                    {
                        BPR11 = BPR_11.Value;
                    }
                    else
                    {
                        BPR11 = "";
                    }

                    if (checkedListBox2.GetItemChecked(12) == true)
                    {
                        BPR111 = BPR11;
                    }
                    else
                    {
                        BPR111 = "";
                    }
                }

                if (BPR11 == "*01")
                {
                    BPR11 = "";
                    BPR111 = "";
                }

                if (BPR11 == "*")
                {
                    BPR11 = "";
                    BPR111 = BPR11;

                    BPR12_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*\*\*).+?(?=\*)");
                    BPR_12 = BPR12_Regx.Match(ST_SE_Loop);
                    if (BPR_12.Success)
                    {
                        BPR12 = BPR_12.Value;
                    }
                    else
                    {
                        BPR12 = "";
                    }

                    if (checkedListBox2.GetItemChecked(13) == true)
                    {
                        BPR121 = BPR12;
                    }
                    else
                    {
                        BPR121 = "";
                    }
                }
                else
                {
                    BPR12_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*" + BPR10 + @"\*" + BPR11 + @"\*).+?(?=\*)");
                    BPR_12 = BPR12_Regx.Match(ST_SE_Loop);
                    if (BPR_12.Success)
                    {
                        BPR12 = BPR_12.Value;
                    }
                    else
                    {
                        BPR12 = "";
                    }

                    if (checkedListBox2.GetItemChecked(13) == true)
                    {
                        BPR121 = BPR12;
                    }
                    else
                    {
                        BPR121 = "";
                    }
                }

                if (BPR12 == "*")
                {
                    BPR12 = "";
                    BPR121 = BPR12;

                    BPR13_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*\*\*\*).+?(?=\*)");
                    BPR_13 = BPR13_Regx.Match(ST_SE_Loop);
                    if (BPR_13.Success)
                    {
                        BPR13 = BPR_13.Value;
                    }
                    else
                    {
                        BPR13 = "";
                    }

                    if (checkedListBox2.GetItemChecked(14) == true)
                    {
                        BPR131 = BPR13;
                    }
                    else
                    {
                        BPR131 = "";
                    }
                }
                else
                {
                    BPR13_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*" + BPR10 + @"\*" + BPR11 + @"\*" + BPR12 + @"\*).+?(?=\*)");
                    BPR_13 = BPR13_Regx.Match(ST_SE_Loop);
                    if (BPR_13.Success)
                    {
                        BPR13 = BPR_13.Value;
                    }
                    else
                    {
                        BPR13 = "";
                    }

                    if (checkedListBox2.GetItemChecked(14) == true)
                    {
                        BPR131 = BPR13;
                    }
                    else
                    {
                        BPR131 = "";
                    }
                }

                if (BPR13 == "*")
                {
                    BPR13 = "";
                    BPR131 = BPR13;

                    BPR14_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*\*\*\*\*).+?(?=\*)");
                    BPR_14 = BPR14_Regx.Match(ST_SE_Loop);
                    if (BPR_14.Success)
                    {
                        BPR14 = BPR_14.Value;
                    }
                    else
                    {
                        BPR14 = "";
                    }

                    if (checkedListBox2.GetItemChecked(15) == true)
                    {
                        BPR141 = BPR14;
                    }
                    else
                    {
                        BPR141 = "";
                    }
                }
                else
                {
                    BPR14_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*" + BPR10 + @"\*" + BPR11 + @"\*" + BPR12 + @"\*" + BPR13 + @"\*).+?(?=\*)");
                    BPR_14 = BPR14_Regx.Match(ST_SE_Loop);
                    if (BPR_14.Success)
                    {
                        BPR14 = BPR_14.Value;
                    }
                    else
                    {
                        BPR14 = "";
                    }

                    if (checkedListBox2.GetItemChecked(15) == true)
                    {
                        BPR141 = BPR14;
                    }
                    else
                    {
                        BPR141 = "";
                    }
                }

                if (BPR14 == "*")
                {
                    BPR14 = "";
                    BPR141 = BPR14;

                    BPR15_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*\*\*\*\*).+?(?=\*)");
                    BPR_15 = BPR15_Regx.Match(ST_SE_Loop);
                    if (BPR_15.Success)
                    {
                        BPR15 = BPR_14.Value;
                    }
                    else
                    {
                        BPR15 = "";
                    }

                    if (checkedListBox2.GetItemChecked(16) == true)
                    {
                        BPR151 = BPR15;
                    }
                    else
                    {
                        BPR151 = "";
                    }
                }
                else
                {
                    BPR15_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*" + BPR10 + @"\*" + BPR11 + @"\*" + BPR12 + @"\*" + BPR13 + @"\*" + BPR14 + @"\*).+?(?=\*)");
                    BPR_15 = BPR15_Regx.Match(ST_SE_Loop);
                    if (BPR_15.Success)
                    {
                        BPR15 = BPR_15.Value;
                    }
                    else
                    {
                        BPR15 = "";
                    }

                    if (checkedListBox2.GetItemChecked(16) == true)
                    {
                        BPR151 = BPR15;
                    }
                    else
                    {
                        BPR151 = "";
                    }
                }

                if (BPR15 == "*")
                {
                    BPR15 = "";
                    BPR151 = BPR15;

                    BPR16_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*\*\*\*\*\*\*\*\*\*\*).+?(?=\*)");
                    BPR_16 = BPR16_Regx.Match(ST_SE_Loop);
                    if (BPR_16.Success)
                    {
                        BPR16 = BPR_16.Value;
                    }
                    else
                    {
                        BPR16 = "";
                    }

                    if (checkedListBox2.GetItemChecked(17) == true)
                    {
                        BPR161 = BPR16;
                    }
                    else
                    {
                        BPR161 = "";
                    }
                }
                else
                {
                    BPR16_Regx = new Regex(@"(?<=BPR\*" + BPR01 + @"\*" + BPR02 + @"\*" + BPR03 + @"\*" + BPR04 + @"\*" + BPR05 + @"\*" + BPR06 + @"\*" + BPR07 + @"\*" + BPR08 + @"\*" + BPR09 + @"\*" + BPR10 + @"\*" + BPR11 + @"\*" + BPR12 + @"\*" + BPR13 + @"\*" + BPR14 + @"\*" + BPR15 + @"\*).+?(?=\~)");
                    BPR_16 = BPR16_Regx.Match(ST_SE_Loop);
                    if (BPR_16.Success)
                    {
                        BPR16 = BPR_16.Value;
                    }
                    else
                    {
                        BPR16 = "";
                    }

                    if (checkedListBox2.GetItemChecked(17) == true)
                    {
                        BPR161 = BPR16;
                    }
                    else
                    {
                        BPR161 = "";
                    }
                }

                TRN01_Regx = new Regex(@"(?<=TRN\*).+?(?=\*)");
                TRN_01 = TRN01_Regx.Match(ST_SE_Loop);
                if (TRN_01.Success)
                {
                    TRN01 = TRN_01.Value;
                }
                else
                {
                    TRN01 = "";
                }

                if (checkedListBox2.GetItemChecked(18) == true)
                {
                    TRN011 = TRN01;
                }
                else
                {
                    TRN011 = "";
                }

                TRN02_Regx = new Regex(@"(?<=TRN\*" + TRN01 + @"\*).+?(?=\*)");
                TRN_02 = TRN02_Regx.Match(ST_SE_Loop);
                if (TRN_02.Success)
                {
                    TRN02 = TRN_02.Value;
                }
                else
                {
                    TRN02 = "";
                }

                if (checkedListBox2.GetItemChecked(19) == true)
                {
                    TRN021 = TRN02;
                }
                else
                {
                    TRN021 = "";
                }

                TRN03_Regx = new Regex(@"(?<=TRN\*" + TRN01 + @"\*" + TRN02 + @"\*).+?(?=\*)");
                TRN_03 = TRN03_Regx.Match(ST_SE_Loop);
                if (TRN_03.Success)
                {
                    TRN03 = TRN_03.Value;
                }
                else
                {
                    TRN03 = "";
                }

                if (checkedListBox2.GetItemChecked(20) == true)
                {
                    TRN031 = TRN03;
                }
                else
                {
                    TRN031 = "";
                }

                if (TRN03 == "")
                {
                    TRN031 = TRN03;

                    TRN04_Regx = new Regex(@"(?<=TRN\*" + TRN01 + @"\*" + TRN02 + @"\*).+?(?=\~)");
                    TRN_04 = TRN04_Regx.Match(ST_SE_Loop);
                    if (TRN_04.Success)
                    {
                        TRN04 = TRN_04.Value;
                    }
                    else
                    {
                        TRN04 = "";
                    }

                    if (checkedListBox2.GetItemChecked(21) == true)
                    {
                        TRN041 = TRN04;
                    }
                    else
                    {
                        TRN041 = "";
                    }
                }
                else
                {
                    TRN04_Regx = new Regex(@"(?<=TRN\*" + TRN01 + @"\*" + TRN02 + @"\*" + TRN03 + @"\*).+?(?=\~)");
                    TRN_04 = TRN04_Regx.Match(ST_SE_Loop);
                    if (TRN_04.Success)
                    {
                        TRN04 = TRN_04.Value;
                    }
                    else
                    {
                        TRN04 = "";
                    }

                    if (checkedListBox2.GetItemChecked(21) == true)
                    {
                        TRN041 = TRN04;
                    }
                    else
                    {
                        TRN041 = "";
                    }
                }

                REF01_Regx = new Regex(@"(?<=REF\*).+?(?=\*)");
                REF_01 = REF01_Regx.Match(ST_SE_Loop);
                if (REF_01.Success)
                {
                    REF01 = REF_01.Value;
                }
                else
                {
                    REF01 = "";
                }

                if (checkedListBox2.GetItemChecked(22) == true)
                {
                    REF011 = REF01;
                }
                else
                {
                    REF011 = "";
                }

                REF02_Regx = new Regex(@"(?<=REF\*" + REF01 + @"\*).+?(?=\~)");
                REF_02 = REF02_Regx.Match(ST_SE_Loop);
                if (REF_02.Success)
                {
                    REF02 = REF_02.Value;
                }
                else
                {
                    REF02 = "";
                }

                if (checkedListBox2.GetItemChecked(23) == true)
                {
                    REF021 = REF02;
                }
                else
                {
                    REF021 = "";
                }

                DTM01_Regx = new Regex(@"(?<=DTM\*).+?(?=\*)");
                DTM_01 = DTM01_Regx.Match(ST_SE_Loop);
                if (DTM_01.Success)
                {
                    DTM01 = DTM_01.Value;
                }
                else
                {
                    DTM01 = "";
                }

                if (checkedListBox2.GetItemChecked(24) == true)
                {
                    DTM011 = DTM01;
                }
                else
                {
                    DTM011 = "";
                }

                DTM02_Regx = new Regex(@"(?<=DTM\*" + DTM01 + @"\*).+?(?=\~)");
                DTM_02 = DTM02_Regx.Match(ST_SE_Loop);
                if (DTM_02.Success)
                {
                    DTM02 = DTM_02.Value;
                }
                else
                {
                    DTM02 = "";
                }

                if (checkedListBox2.GetItemChecked(25) == true)
                {
                    DTM021 = DTM02;
                }
                else
                {
                    DTM021 = "";
                }

                conn.Open();
                if (checkBox2.Checked == true)
                {
                    cmd = new SqlCommand("INSERT INTO STSE_Table (ST01, ST02, BPR01, BPR02, BPR03, BPR04, BPR05, BPR06, BPR07, BPR08, BPR09, BPR10, BPR11, BPR12, BPR13, " +
                        "BPR14, BPR15, BPR16,TRN01, TRN02, TRN03, TRN04, REF01, REF02, DTM01, DTM02) VALUES ('" + ST011 + "','" + ST021 + "','" + BPR011 + "','" + BPR021 + "','" + BPR031 + "','" + BPR041 + "','" + BPR051 + "','" + BPR061 + "'," +
                    "'" + BPR071 + "','" + BPR081 + "','" + BPR091 + "','" + BPR101 + "','" + BPR111 + "','" + BPR121 + "','" + BPR131 + "','" + BPR141 + "','" + BPR151 + "','" + BPR161 + "','" + TRN011 + "','" + TRN021 + "','" + TRN031 + "'" +
                    ",'" + TRN041 + "','" + REF011 + "','" + REF021 + "','" + DTM011 + "','" + DTM021 + "')", conn);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO STSE_Table (ST01, ST02, BPR01, BPR02, BPR03, BPR04, BPR05, BPR06, BPR07, BPR08, BPR09, BPR10, BPR11, BPR12, BPR13, " +
                        "BPR14, BPR15, BPR16,TRN01, TRN02, TRN03, TRN04, REF01, REF02, DTM01, DTM02) VALUES ('','','','','','','','','','','','','','','','','','','','','','','" + TRN041 + "','','','')", conn);
                }



                cmd.ExecuteNonQuery();


                conn.Close();
            }

            
        }
    }
}