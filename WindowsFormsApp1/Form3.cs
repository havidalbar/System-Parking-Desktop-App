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
    public partial class Form3 : Form
    {
        Form2 f7;
        SqlConnection koneksi = new SqlConnection(@"Data Source = MSI\DBSS075; Initial Catalog = ""Project Akhir""; Integrated Security = True");
        public Form3(Form2 ParentForm)
        {
            f7 = ParentForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void dispData()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dataPetugas";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                int uname;
                uname = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM dataPribadi  WHERE ID='" +bunifuMetroTextbox1.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    MessageBox.Show("ID yang anda cari tidak ditemukan");
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM dataPetugas where ID like '%" +bunifuMetroTextbox1.Text + "%'";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    da.Fill(dataSet);
                    bunifuCustomDataGrid1.DataSource = dataSet.Tables[0].DefaultView;
                    MessageBox.Show("Find Successfull");
                }
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID terlebih dahulu");
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text != "" && bunifuMetroTextbox3.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT into dataPetugas VALUES ('" + bunifuMetroTextbox2.Text + "','" +bunifuMetroTextbox3.Text + "')";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Insert Successfull");
                reset();
            }
            else
            {
                MessageBox.Show("Silahkan melengkapi data diri terlebih dahulu");
            }

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dataPetugas where ID='" +bunifuMetroTextbox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Deleted Successfull");
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID data yang ingin dihapus");
            }
        }
        public void reset()
        {
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox3.Text = "";
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "" && bunifuMetroTextbox2.Text != "" &&bunifuMetroTextbox3.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE dataPetugas SET username = '" + bunifuMetroTextbox2.Text + "', password = '" +bunifuMetroTextbox3.Text + "' WHERE ID = '" + bunifuMetroTextbox1.Text + "';";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data Update Successfull");
                reset();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID dan melengkapi data yang ingin di update");
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            dispData();
        }

        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox2.Text = "";
        }
        
        private void bunifuMetroTextbox3_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox3.Text = "";
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                int uname;
                uname = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM dataPribadi  WHERE ID='" + bunifuMetroTextbox1.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    MessageBox.Show("ID yang anda cari tidak ditemukan");
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM dataPetugas where ID like '%" + bunifuMetroTextbox1.Text + "%'";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    da.Fill(dataSet);
                    bunifuCustomDataGrid1.DataSource = dataSet.Tables[0].DefaultView;
                    MessageBox.Show("Find Successfull");
                }
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID terlebih dahulu");
            }
        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
