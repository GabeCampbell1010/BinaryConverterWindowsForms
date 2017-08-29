using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class BinaryConverter : Form
    {
        public BinaryConverter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startupPath = Application.StartupPath;
            string file = startupPath + @"\binaryFile";
            StreamWriter writer = new StreamWriter(file);
            

            while (true)
            {
                string response = "";
                do
                {
                    response = Microsoft.VisualBasic.Interaction.InputBox("enter a new binary number?", "New Number?", "", 200, 200);
                    if (response == "")
                    {
                        writer.Close();
                        return;
                    }
                }
                while (response != "y" && response != "n");

                if (response == "n")
                    break;

                string binaryNumber;
                do
                {
                    binaryNumber = Microsoft.VisualBasic.Interaction.InputBox("Type the new number in Binary", "Binary Number", "", 200, 200);
                    binaryNumber = binaryNumber.Trim();
                    if (binaryNumber == "")
                    {
                        writer.Close();
                        return;
                    }
                }
                while (!Regex.IsMatch(binaryNumber, "^[01]+$"));

                string signed = "";
                do
                {
                    signed = Microsoft.VisualBasic.Interaction.InputBox("Would you like the signed binary decimal? 'y' for signed and 'n' for unsigned.", "Signed or Unsigned", "", 200, 200);
                    if (signed == "")
                    {
                        writer.Close();
                        return;
                    }
                }
                while (signed != "y" && signed != "n");

                writer.WriteLine(binaryNumber);
                writer.WriteLine(signed);
            }

            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string startupPath = Application.StartupPath;
            string file = startupPath + @"\binaryFile";

            StreamReader reader = new StreamReader(file);

            string contents = "";
            string binaryNumber;
            string signed;
            bool isSigned;
            
            while (true)
            { 
                binaryNumber = reader.ReadLine();
                signed = reader.ReadLine();
                isSigned = signed == "y" ? true : false;

                if (binaryNumber == null)
                    break;
                
                if (isSigned)
                {
                    contents += "The signed binary number " + binaryNumber + " in decimal form is: " + BinaryConversion.GetSignedBinaryValue(binaryNumber).ToString() + Environment.NewLine;
                }
                else if(!isSigned)
                {
                    contents += "The unsigned binary number " + binaryNumber + " in decimal form is: " + BinaryConversion.GetUnsignedBinaryValue(binaryNumber).ToString() + Environment.NewLine;
                }
                
            }
            reader.Close();
            textBox1.Text = contents;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
