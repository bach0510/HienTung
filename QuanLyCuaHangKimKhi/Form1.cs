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

namespace QuanLyCuaHangKimKhi
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=kimkhi;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username, password;
            username = userNameTxt.Text;
            password = passwordTxt.Text;

            try
            {
                string query = "Select * from users where username = '" + username + "' and password = '" + password + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    Form2 main = new Form2();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Vui long kiem tra lai thong tin dang nhap");
                }
            }
            catch
            {
                MessageBox.Show("co loi xay ra");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
