using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp2
{

    public partial class Dashboard : Form
    {
        int myCounter = 0;
        string myEmail = "";
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F3VCQ0A\MYSERVER; Initial Catalog = Register; Integrated Security = True; Pooling=False");

        public Dashboard(string userName, string email, int count)
        {
            InitializeComponent();
            myCounter = count;
            myEmail = email;
        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, BackColor = Color.FromArgb(247, 209, 186) };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string value = Prompt.ShowDialog("Enter an amount", "Deposit");
                int val = int.Parse(value);
                myCounter = myCounter + val;
                textBox1.Text = myCounter.ToString();
                // Run an sql query here to update the count of user in database
                updateUserInDB();

            }
            catch (Exception err)
            {
                MessageBox.Show("Please add valid amount");
            };

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AmountPopUp withDrawPopUp = new AmountPopUp("withdraw");
                withDrawPopUp.Show();
                //string value = Prompt.ShowDialog("Enter an amount", "Withdraw");
                //int val = int.Parse(value);
                //myCounter = myCounter - val;
                //if (myCounter < 0)
                //{
                //    MessageBox.Show("Sorry Please Enter Valid Amount");
                //    return;
                //}
                //textBox1.Text = myCounter.ToString();
                //updateUserInDB();
            }
            catch (Exception err)
            {
                MessageBox.Show("pleaze enter valid amount");
            }

        }

        private void updateUserInDB()
        {
            // here get userEmail and myCounter
            // update the count value in database for user 
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update  [register] set count ='" + myCounter + "'  where email='" + myEmail + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Dashboard_Fornm3_Load(object sender, EventArgs e)
        {
            textBox1.Text = myCounter.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
