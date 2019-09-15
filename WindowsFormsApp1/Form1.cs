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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static Form2 form7;
        SqlConnection koneksi = new SqlConnection(@"Data Source = MSI\DBSS075; Initial Catalog = ""Project Akhir""; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
            form7 = new Form2(this);
        }
        public void Login()
        {
            if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "")
            {
                int uname;
                uname = 0;
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM dataPetugas  WHERE username='" + bunifuMaterialTextbox1.Text + "' AND password='" + bunifuMaterialTextbox2.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    MessageBox.Show("ID atau password yang anda masukkan salah");
                }
                else
                {

                    this.Hide();
                    form7.Show();
                }
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID dan password terlebih dahulu");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text != "User Name" && bunifuMaterialTextbox2.Text != "Password")
            {
                Login();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID dan password terlebih dahulu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() =="Return")
            {
                Login();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                Login();
            }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
