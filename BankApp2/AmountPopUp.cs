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
    public partial class AmountPopUp : Form
    {

        int myCounter = 0;
        string myEmail = "";
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F3VCQ0A\MYSERVER; Initial Catalog = Register; Integrated Security = True; Pooling=False");

        public AmountPopUp(string operation, string email, int count)
        {
            InitializeComponent();
            myCounter = count;
            myEmail = email;
            if (operation == "withdraw")
            {
                actionBtn.Text = "Withdraw";
            }
            else 
            {
                actionBtn.Text = "Deposit";
            }

        }

        private void actionBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
