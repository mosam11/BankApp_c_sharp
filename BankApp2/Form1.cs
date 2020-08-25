using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankApp2
{
    public partial class Form1 : Form
    {

        SqlConnection con=new SqlConnection(@"Data Source = DESKTOP-F3VCQ0A\MYSERVER; Initial Catalog = Register; Integrated Security = True; Pooling=False");

        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string textbox1 = TextBox1.Text;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string textbox2 = TextBox2.Text;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            string textbox3 = TextBox3.Text;
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userEmail = TextBox2.Text;
            string userPassword = TextBox3.Text;
            bool isValid = IsValidEmail(userEmail);
            if (!isValid)
            {
                MessageBox.Show("Sorry your email is not correct");
                return;
            }
            if (userPassword.Length < 6)
            {
                MessageBox.Show("Please enter password minimum 6 character long");
                return;
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [register] (username,email,password,count) values('"+TextBox1.Text+"','"+ userEmail + "','"+ userPassword + "','" + 0 + "')";

            try 
            {
                cmd.ExecuteNonQuery();
                con.Close();
            } 
            catch (Exception err) 
            {
                MessageBox.Show(err.Message);
                return;
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            MessageBox.Show("Registion is complete");
            Dashboard_Fornm3 myDashboard = new Dashboard_Fornm3(TextBox1.Text, TextBox2.Text, 0);
            myDashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_Form2 myLogin = new Login_Form2();
            myLogin.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
