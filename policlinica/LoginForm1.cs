using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace policlinica
{

    public partial class LoginForm1 : Form

    {
        DataBase dataBase = new DataBase();
        public LoginForm1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {
            LoginField.MaxLength = 50;
            PasswordField.MaxLength = 50;
        }

        private void button1_click(object sender, EventArgs e)
        {
            var loginUser = LoginField.Text;
            var PasswordUser = PasswordField.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"select ID from Patient where login = '{loginUser}\r\n' and password = '{PasswordUser}\r\n'";
            SqlCommand sqlCommand = new SqlCommand(query, dataBase.getConnection());
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);
            if(table.Rows.Count == 1)
            {
                MessageBox.Show("WW!", "WW!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PagePatient PP = new PagePatient();
                this.Hide();
                PP.ShowDialog();
                this.Show();    
             }
            else
                MessageBox.Show("LL", "LL!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
