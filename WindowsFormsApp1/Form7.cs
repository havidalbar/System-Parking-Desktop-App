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
    public partial class Form7 : Form
    {
        Form2 f2;
        SqlConnection koneksi = new SqlConnection(@"Data Source = MSI\DBSS075; Initial Catalog = ""Project Akhir""; Integrated Security = True");
        public Form7(Form2 ParentForm)
        {
            InitializeComponent();
            f2 = ParentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }
        public void dispData()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select dataPetugas.ID,dataPetugas.username,dataPribadi.NamaLengkap,dataPribadi.Jenis_Kelamin,dataPribadi.TTL,dataPribadi.Alamat,dataPribadi.Tahun_Masuk from dataPetugas inner join dataPribadi on dataPribadi.ID = dataPetugas.id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            koneksi.Close();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
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
                cmd.CommandText = "SELECT * FROM dataPribadi  WHERE id='" + bunifuMetroTextbox1.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    MessageBox.Show("ID yang anda cari belum menambahkan identitas");
                }
                else
                {
                    cmd.CommandText = "select dataPetugas.ID,dataPetugas.username,dataPribadi.NamaLengkap,dataPribadi.Jenis_Kelamin,dataPribadi.TTL,dataPribadi.Alamat,dataPribadi.Tahun_Masuk from dataPetugas inner join dataPribadi on dataPetugas.ID = dataPribadi.id where dataPetugas.id like '%" + bunifuMetroTextbox1.Text + "%'";
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
                MessageBox.Show("Silahkan memasukkan ID yang ingin dicari terlebih dahulu");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {
                koneksi.Open();
                int uname;
                uname = 0;
                String query = "SELECT * FROM dataPribadi  WHERE id='" + bunifuMetroTextbox1.Text + "';";
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, koneksi);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    String query1 = "INSERT into dataPribadi VALUES ('" + bunifuMetroTextbox1.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox6.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, koneksi);
                    sda.SelectCommand.ExecuteNonQuery();
                    koneksi.Close();
                    bunifuMetroTextbox1.Text = "";
                    reset();
                    MessageBox.Show("Insert Successfull");
                }
                else
                {
                    MessageBox.Show("ID ini sudah memiliki identitas");
                }
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID dan melengkapi data diri terlebih dahulu");
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                koneksi.Open();
                SqlDataAdapter sda = new SqlDataAdapter("delete from dataPribadi where ID='" + bunifuMetroTextbox1.Text + "'", koneksi);
                sda.SelectCommand.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Deleted Successfull");
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan id yang ingin dihapus terlebih dahulu");
            }
        }
        public void reset()
        {
            bunifuMetroTextbox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.ResetText();
            textBox6.Text = "";
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {
                koneksi.Open();
                int uname;
                uname = 0;
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dataPribadi  WHERE id='" + bunifuMetroTextbox1.Text + "';", koneksi);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    MessageBox.Show("ID yang anda cari belum menambahkan identitas");
                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter("UPDATE dataPribadi SET NamaLengkap = '" + textBox3.Text + "', Jenis_Kelamin = '" + comboBox1.Text + "', TTL = '" + textBox4.Text + "', Alamat= '" + textBox2.Text + "', Tahun_Masuk = '" + textBox6.Text + "' WHERE ID = '" + bunifuMetroTextbox1.Text + "';", koneksi);
                    sda.SelectCommand.ExecuteNonQuery();
                    reset();
                    MessageBox.Show("Data Update Successfull");
                }
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan ID yang ingin dicari terlebih dahulu");
            }
           
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            dispData();
        }

        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            
        }
    }
}
