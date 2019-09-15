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
    public partial class Form9 : Form
    {
        Form2 f2;
        SqlConnection koneksi = new SqlConnection(@"Data Source = MSI\DBSS075; Initial Catalog = ""Project Akhir""; Integrated Security = True");
        public Form9(Form2 ParentForm)
        {
            InitializeComponent();
            f2 = ParentForm;
        }
       public void dispData()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select dataPetugas.ID,dataPetugas.username,Absensi.CheckIn,Absensi.CheckOut from dataPetugas inner join Absensi on dataPetugas.ID = Absensi.Id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            koneksi.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            int uname;
            uname = 0;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Absensi  WHERE Id='" + bunifuMetroTextbox1.Text + "';";
            cmd.ExecuteNonQuery();
            DataTable user = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(user);
            uname = Convert.ToInt32(user.Rows.Count.ToString());
            if (uname == 0)
            {
                MessageBox.Show("ID yang anda cari belum melakukan absensi");
            }
            else
            {
                cmd.CommandText = "select dataPetugas.ID,dataPetugas.username,Absensi.CheckIn,Absensi.CheckOut from dataPetugas inner join Absensi on dataPetugas.ID = Absensi.Id where dataPetugas.id like '%" + bunifuMetroTextbox1.Text + "%'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                bunifuCustomDataGrid1.DataSource = dataSet.Tables[0].DefaultView;
                MessageBox.Show("Find Successfull");
            }
            koneksi.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Absensi  WHERE Id='" + bunifuMetroTextbox1.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                cmd.CommandText = "INSERT into Absensi VALUES ('" + bunifuMetroTextbox1.Text + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "')";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                dispData();
                bunifuMetroTextbox1.Text = "";
                MessageBox.Show("Insert Successfull");
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID terlebih dahulu");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Absensi WHERE Id='" + bunifuMetroTextbox1.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                cmd.CommandText = "UPDATE Absensi set CheckOut = '" + DateTime.Now.ToString() + "' where Id = '" + bunifuMetroTextbox1.Text + "' ";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                dispData();
                bunifuMetroTextbox1.Text = "";
                MessageBox.Show("Check Out Successfull");
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID terlebih dahulu");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "" && bunifuMetroTextbox1.Text != "Cari Pegawai")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Absensi where Id='" + bunifuMetroTextbox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                dispData();
                MessageBox.Show("Deleted Successfull");
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID data yang ingin dihapus");
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            dispData();
        }

        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
