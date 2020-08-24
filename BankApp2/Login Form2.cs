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
    public partial class Login_Form2 : Form
    {
        private string loginUserEmail = "";
        private string loginUserPassword = "";
        private string loginUserName = "";
        private string loginUserCount = "0";
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F3VCQ0A\MYSERVER; Initial Catalog = Register; Integrated Security = True; Pooling=False");
        public Login_Form2()
        {
            InitializeComponent();

        }

        private void Login_Form2_Load(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginUserEmail = loginEmail.Text;
            loginUserPassword = loginPassword.Text;

            // User Input Validation
            if (
                loginUserEmail == "" || loginUserPassword == "" ||
                loginUserEmail.Length < 4 || loginUserPassword.Length < 6
                )
            {
                MessageBox.Show("Please Provide Proper Input");
                // It means function will stop executing
                return;
            }
            fetchUserFromDb();
        }

        private void fetchUserFromDb()
        {
            SqlCommand cmd = new SqlCommand("Select username, password, count From[register] where email = '" + loginUserEmail + "'", con);
            con.Open();

            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                loginUserName = dr[0].ToString();
                string userPasswordFromDb = dr[1].ToString();
                loginUserCount = dr[2].ToString();
                dr.Close();
                if (loginUserPassword != userPasswordFromDb) {
                    MessageBox.Show("Sorry password is not correct");
                    con.Close();
                    return;
                }
                con.Close();
                displayDashboadrd();
                return;
            }
            else
            {
                MessageBox.Show("Sorry Email Not Found");
                dr.Close();
                con.Close();
                return;
            }
        }

        private void displayDashboadrd() 
        {
            this.Hide();
            Dashboard_Fornm3 myDashboard = new Dashboard_Fornm3(loginUserName, loginUserEmail, int.Parse(loginUserCount));
            myDashboard.Show();
        }
    }
}
