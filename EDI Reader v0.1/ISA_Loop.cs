using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Data;
using System.Security.Claims;

namespace EDI_Reader_v0._1
{
    internal class ISA_Loop
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Kasun Perera\source\repos\EDI Reader v0.1\EDI Reader v0.1\EDI_Reader.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        CheckBox checkBox1, checkBox2;

        CheckedListBox checkedListBox1, checkedListBox2;

        private string fileText;

        // Get the checked items
        List<string> checkedItems = new List<string>();

        String ISA_IEA_Loop, ISA01, ISA02, ISA03, ISA04, ISA05, ISA06, ISA07, ISA08, ISA09, ISA10, ISA11, ISA12,
                    ISA13, ISA14, ISA15, ISA16, ISA17, ISA18, ISA19, ISA20, ISA21, ISA22, ISA23, ISA24, folderPath;

        String ISA011, ISA021, ISA031, ISA041, ISA051, ISA061, ISA071, ISA081, ISA091, ISA101, ISA111, ISA121,
                    ISA131, ISA141, ISA151, ISA161, ISA171, ISA181, ISA191, ISA201, ISA211, ISA221, ISA231;

        Regex ISA_Regx, ISA01_Regx, ISA02_Regx, ISA03_Regx, ISA04_Regx, ISA05_Regx, ISA06_Regx, ISA07_Regx, ISA08_Regx,
            ISA09_Regx, ISA10_Regx, ISA11_Regx, ISA12_Regx, ISA13_Regx, ISA14_Regx, ISA15_Regx, ISA16_Regx, ISA17_Regx,
            ISA18_Regx, ISA19_Regx, ISA20_Regx, ISA21_Regx, ISA22_Regx, ISA23_Regx, ISA24_Regx;

        MatchCollection ISA_Loop1;

        Match ISA01_match, ISA02_match, ISA03_match, ISA04_match, ISA05_match, ISA06_match, ISA07_match, ISA08_match,
            ISA09_match, ISA10_match, ISA11_match, ISA12_match, ISA13_match, ISA14_match, ISA15_match, ISA16_match,
            ISA17_match, ISA18_match, ISA19_match, ISA20_match, ISA21_match, ISA22_match, ISA23_match, ISA24_match;

        public int int_ISA = 0;

        public ISA_Loop(string fileText, CheckBox checkBox1, CheckedListBox checkedListBox1, string folderPath, Label label2, CheckBox checkBox2, CheckedListBox checkedListBox2)
        {
            this.fileText = fileText;
            this.checkedListBox1 = checkedListBox1;
            this.checkBox1 = checkBox1;
            this.checkedListBox2 = checkedListBox2;
            this.checkBox2 = checkBox2;
            this.folderPath = folderPath;

            // Create a Regex object with the specified pattern for Find ISA Loop
            ISA_Regx = new Regex(@"ISA([\s\S]*?)IEA([*\d]*)+~");

            // Use the Matches method to find all matches in the input string
            ISA_Loop1 = ISA_Regx.Matches(fileText);

            // Iterate over the matches and display the matched values
            foreach (Match each_ISA in ISA_Loop1)
            {
                int_ISA = int_ISA + 1;

                ISA_IEA_Loop = each_ISA.Value;

                ISA01_Regx = new Regex(@"(?<=ISA\*)\d+(?=\*)*");
                ISA01_match = ISA01_Regx.Match(ISA_IEA_Loop);
                if (ISA01_match.Success)
                {
                    ISA01 = ISA01_match.Value;
                }
                else
                {
                    ISA01 = "";
                }

                if (checkedListBox1.GetItemChecked(0) == true)
                {
                    ISA011 = ISA01;
                }
                else
                {
                    ISA011 = "";
                }

                ISA02_Regx = new Regex(@"(?<=\*00\*)[^*]*(?=\*00\*)");
                ISA02_match = ISA02_Regx.Match(ISA_IEA_Loop);
                if (ISA02_match.Success)
                {
                    ISA02 = ISA02_match.Value;
                }
                else
                {
                    ISA02 = "";
                }

                if (checkedListBox1.GetItemChecked(1) == true)
                {
                    ISA021 = ISA02;
                }
                else
                {
                    ISA021 = "";
                }

                ISA03_Regx = new Regex(@"(?<=[\s]{10}\*).+?(?=\*[\s]{10})");
                ISA03_match = ISA03_Regx.Match(ISA_IEA_Loop);
                if (ISA03_match.Success)
                {
                    ISA03 = ISA03_match.Value;
                }
                else
                {
                    ISA03 = "";
                }

                if (checkedListBox1.GetItemChecked(2) == true)
                {
                    ISA031 = ISA03;
                }
                else
                {
                    ISA031 = "";
                }

                ISA04_Regx = new Regex(@"(?<=[\s]{10}\*" + ISA03 + @"\*).+?(?=\*)");
                ISA04_match = ISA04_Regx.Match(ISA_IEA_Loop);
                if (ISA04_match.Success)
                {
                    ISA04 = ISA04_match.Value;
                }
                else
                {
                    ISA04 = "";
                }

                if (checkedListBox1.GetItemChecked(3) == true)
                {
                    ISA041 = ISA04;
                }
                else
                {
                    ISA041 = "";
                }

                ISA05_Regx = new Regex(@"(?<=[\s]{10}\*" + ISA03 + @"\*\" + ISA04 + @"\*).+?(?=\*)");
                ISA05_match = ISA05_Regx.Match(ISA_IEA_Loop);
                if (ISA05_match.Success)
                {
                    ISA05 = ISA05_match.Value;
                }
                else
                {
                    ISA05 = "";
                }

                if (checkedListBox1.GetItemChecked(4) == true)
                {
                    ISA051 = ISA05;
                }
                else
                {
                    ISA051 = "";
                }

                ISA06_Regx = new Regex(@"(?<=" + ISA05 + @"\*).+?(?=\*)");
                ISA06_match = ISA06_Regx.Match(ISA_IEA_Loop);
                if (ISA06_match.Success)
                {
                    ISA06 = ISA06_match.Value;
                }
                else
                {
                    ISA06 = "";
                }

                if (checkedListBox1.GetItemChecked(5) == true)
                {
                    ISA061 = ISA06;
                }
                else
                {
                    ISA061 = "";
                }

                ISA07_Regx = new Regex(@"(?<=" + ISA05 + @"\*" + ISA06 + @"\*).+?(?=\*)");
                ISA07_match = ISA07_Regx.Match(ISA_IEA_Loop);
                if (ISA07_match.Success)
                {
                    ISA07 = ISA07_match.Value;
                }
                else
                {
                    ISA07 = "";
                }

                if (checkedListBox1.GetItemChecked(6) == true)
                {
                    ISA071 = ISA07;
                }
                else
                {
                    ISA071 = "";
                }

                ISA08_Regx = new Regex(@"(?<=" + ISA06 + @"\*" + ISA07 + @"\*).+?(?=\*)");
                ISA08_match = ISA08_Regx.Match(ISA_IEA_Loop);
                if (ISA08_match.Success)
                {
                    ISA08 = ISA08_match.Value;
                }
                else
                {
                    ISA08 = "";
                }

                if (checkedListBox1.GetItemChecked(7) == true)
                {
                    ISA081 = ISA08;
                }
                else
                {
                    ISA081 = "";
                }

                ISA09_Regx = new Regex(@"(?<=\*" + ISA08 + @"\*).+?(?=\*)");
                ISA09_match = ISA09_Regx.Match(ISA_IEA_Loop);
                if (ISA09_match.Success)
                {
                    ISA09 = ISA09_match.Value;
                }
                else
                {
                    ISA09 = "";
                }

                if (checkedListBox1.GetItemChecked(8) == true)
                {
                    ISA091 = ISA09;
                }
                else
                {
                    ISA091 = "";
                }

                ISA10_Regx = new Regex(@"(?<=\*" + ISA09 + @"\*).+?(?=\*)");
                ISA10_match = ISA10_Regx.Match(ISA_IEA_Loop);
                if (ISA10_match.Success)
                {
                    ISA10 = ISA10_match.Value;
                }
                else
                {
                    ISA10 = "";
                }

                if (checkedListBox1.GetItemChecked(9) == true)
                {
                    ISA101 = ISA10;
                }
                else
                {
                    ISA101 = "";
                }

                ISA11_Regx = new Regex(@"(?<=\*" + ISA09 + @"\*" + ISA10 + @"\*).+?(?=\*)");
                ISA11_match = ISA11_Regx.Match(ISA_IEA_Loop);
                if (ISA11_match.Success)
                {
                    ISA11 = ISA11_match.Value;
                }
                else
                {
                    ISA11 = "";
                }

                if (checkedListBox1.GetItemChecked(10) == true)
                {
                    ISA111 = ISA11;
                }
                else
                {
                    ISA111 = "";
                }

                ISA12_Regx = new Regex(@"(?<=\*" + ISA10 + @"\*\" + ISA11 + @"\*).+?(?=\*)");

                ISA12_match = ISA12_Regx.Match(ISA_IEA_Loop);
                if (ISA12_match.Success)
                {
                    ISA12 = ISA12_match.Value;
                }
                else
                {
                    ISA12 = "";
                }

                if (checkedListBox1.GetItemChecked(11) == true)
                {
                    ISA121 = ISA12;
                }
                else
                {
                    ISA121 = "";
                }

                ISA13_Regx = new Regex(@"(?<=\*\" + ISA11 + @"\*" + ISA12 + @"\*).+?(?=\*)");
                ISA13_match = ISA13_Regx.Match(ISA_IEA_Loop);
                if (ISA13_match.Success)
                {
                    ISA13 = ISA13_match.Value;
                }
                else
                {
                    ISA13 = "";
                }

                if (checkedListBox1.GetItemChecked(12) == true)
                {
                    ISA131 = ISA13;
                }
                else
                {
                    ISA131 = "";
                }

                ISA14_Regx = new Regex(@"(?<=\*" + ISA12 + @"\*" + ISA13 + @"\*).+?(?=\*)");
                ISA14_match = ISA14_Regx.Match(ISA_IEA_Loop);
                if (ISA14_match.Success)
                {
                    ISA14 = ISA14_match.Value;
                }
                else
                {
                    ISA14 = "";

                }
                if (checkedListBox1.GetItemChecked(13) == true)
                {
                    ISA141 = ISA14;
                }
                else
                {
                    ISA141 = "";
                }

                ISA15_Regx = new Regex(@"(?<=\*" + ISA13 + @"\*" + ISA14 + @"\*).+?(?=\*)");
                ISA15_match = ISA15_Regx.Match(ISA_IEA_Loop);
                if (ISA15_match.Success)
                {
                    ISA15 = ISA15_match.Value;
                }
                else
                {
                    ISA15 = "";
                }

                if (checkedListBox1.GetItemChecked(14) == true)
                {
                    ISA151 = ISA15;
                }
                else
                {
                    ISA151 = "";
                }

                ISA16_Regx = new Regex(@"(?<=GS\*).+?(?=\*)");
                ISA16_match = ISA16_Regx.Match(ISA_IEA_Loop);
                if (ISA16_match.Success)
                {
                    ISA16 = ISA16_match.Value;
                }
                else
                {
                    ISA16 = "";
                }

                if (checkedListBox1.GetItemChecked(15) == true)
                {
                    ISA161 = ISA16;
                }
                else
                {
                    ISA161 = "";
                }

                ISA17_Regx = new Regex(@"(?<=\*" + ISA16 + @"\*).+?(?=\*)");
                ISA17_match = ISA17_Regx.Match(ISA_IEA_Loop);
                if (ISA17_match.Success)
                {
                    ISA17 = ISA17_match.Value;
                }
                else
                {
                    ISA17 = "";
                }

                if (checkedListBox1.GetItemChecked(16) == true)
                {
                    ISA171 = ISA17;
                }
                else
                {
                    ISA171 = "";
                }

                ISA18_Regx = new Regex(@"(?<=\*" + ISA17 + @"\*).+?(?=\*)");
                ISA18_match = ISA18_Regx.Match(ISA_IEA_Loop);
                if (ISA18_match.Success)
                {
                    ISA18 = ISA18_match.Value;
                }
                else
                {
                    ISA18 = "";
                }

                if (checkedListBox1.GetItemChecked(17) == true)
                {
                    ISA181 = ISA18;
                }
                else
                {
                    ISA181 = "";
                }

                ISA19_Regx = new Regex(@"(?<=\*" + ISA18 + @"\*).+?(?=\*)");
                ISA19_match = ISA19_Regx.Match(ISA_IEA_Loop);
                if (ISA19_match.Success)
                {
                    ISA19 = ISA19_match.Value;
                }
                else
                {
                    ISA19 = "";
                }

                if (checkedListBox1.GetItemChecked(18) == true)
                {
                    ISA191 = ISA19;
                }
                else
                {
                    ISA191 = "";
                }

                ISA20_Regx = new Regex(@"(?<=\*" + ISA19 + @"\*).+?(?=\*)");
                ISA20_match = ISA20_Regx.Match(ISA_IEA_Loop);
                if (ISA20_match.Success)
                {
                    ISA20 = ISA20_match.Value;
                }
                else
                {
                    ISA20 = "";
                }

                if (checkedListBox1.GetItemChecked(19) == true)
                {
                    ISA201 = ISA20;
                }
                else
                {
                    ISA201 = "";
                }

                ISA21_Regx = new Regex(@"(?<=" + ISA19 + @"\*" + ISA20 + @"\*).+?(?=\*)");
                ISA21_match = ISA21_Regx.Match(ISA_IEA_Loop);
                if (ISA21_match.Success)
                {
                    ISA21 = ISA21_match.Value;
                }
                else
                {
                    ISA21 = "";
                }

                if (checkedListBox1.GetItemChecked(20) == true)
                {
                    ISA211 = ISA21;
                }
                else
                {
                    ISA211 = "";
                }

                ISA22_Regx = new Regex(@"(?<=" + ISA20 + @"\*" + ISA21 + @"\*).+?(?=\*)");
                ISA22_match = ISA22_Regx.Match(ISA_IEA_Loop);
                if (ISA22_match.Success)
                {
                    ISA22 = ISA22_match.Value;
                }
                else
                {
                    ISA22 = "";
                }

                if (checkedListBox1.GetItemChecked(21) == true)
                {
                    ISA221 = ISA22;
                }
                else
                {
                    ISA221 = "";
                }

                ISA23_Regx = new Regex(@"(?<=" + ISA21 + @"\*" + ISA22 + @"\*).+?(?=\~)");
                ISA23_match = ISA23_Regx.Match(ISA_IEA_Loop);
                if (ISA23_match.Success)
                {
                    ISA23 = ISA23_match.Value;
                }
                else
                {
                    ISA23 = "";
                }

                if (checkedListBox1.GetItemChecked(22) == true)
                {
                    ISA231 = ISA23;
                }
                else
                {
                    ISA231 = "";
                }

                if(ISA141 == "0")
                {
                    ISA141 = "No Acknowledgement Requested";
                }

                if (ISA151 == "P")
                {
                    ISA151 = "Production Data";
                }

                if (ISA161 == "HP")
                {
                    ISA161 = "Health Care Claim Payment Advice";
                }
                //await Task.Delay(1000);
                //MessageBox.Show("ISA01 =" + ISA01 + " ISA02 = " + ISA02 + " ISA03 = " + ISA03 + " ISA04 = " + ISA04);
                conn.Open();

                if (checkBox1.Checked == true)
                {
                    cmd = new SqlCommand("INSERT INTO ISA_Table (ISA01, ISA02,ISA03, ISA04,ISA05, ISA06,ISA07, ISA08,ISA09, ISA10,ISA11, ISA12,ISA13,ISA14,ISA15,GS01,GS02,GS03,GS04,GS05,GS06," +
                    "GS07,GS08) VALUES ('" + ISA011 + "','" + ISA021 + "','" + ISA031 + "','" + ISA041 + "','" + ISA051 + "','" + ISA061 + "','" + ISA071 + "','" + ISA081 + "'," +
                    "'" + ISA091 + "','" + ISA101 + "','" + ISA111 + "','" + ISA121 + "','" + ISA131 + "','" + ISA141 + "','" + ISA151 + "','" + ISA161 + "','" + ISA171 + "','" + ISA181 + "','" + ISA191 + "','" + ISA201 + "','" + ISA211 + "'" +
                    ",'" + ISA221 + "','" + ISA231 + "')", conn);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO ISA_Table (ISA01, ISA02,ISA03, ISA04,ISA05, ISA06,ISA07, ISA08,ISA09, ISA10,ISA11, ISA12,ISA13,ISA14,ISA15,GS01,GS02,GS03,GS04,GS05,GS06," +
                    "GS07,GS08) VALUES ('','','','','','','','','','','','','','','','','','','','','','','" + ISA231 + "')", conn);
                }

                
                
                cmd.ExecuteNonQuery();


                conn.Close();

                new TransactionSetHeaderLoop(ISA_IEA_Loop, folderPath, checkBox2, checkedListBox2);

                label2.Text = int_ISA.ToString();
            }

            // Create a new DataTable to hold the SQL data
            DataTable dataTable = new DataTable();

            conn.Open();

            cmd = new SqlCommand("SELECT * FROM ISA_Table", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            // Load the SQL data into the DataTable
            dataTable.Load(reader);

            conn.Close();

            
            String sheet = "Sheet1";

            new WriteExcelSheet(sheet, dataTable, folderPath);

            // Create a new DataTable to hold the SQL data
             dataTable = new DataTable();

            conn.Open();

            cmd = new SqlCommand("SELECT * FROM STSE_Table", conn);

             reader = cmd.ExecuteReader();

            // Load the SQL data into the DataTable
            dataTable.Load(reader);

            conn.Close();


             sheet = "Sheet2";

            new WriteExcelSheet(sheet, dataTable, folderPath);
        }
        }
}