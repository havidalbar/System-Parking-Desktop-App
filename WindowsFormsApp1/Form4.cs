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
    public partial class Form4 : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source = MSI\DBSS075; Initial Catalog = ""Project Akhir""; Integrated Security = True");
        Form2 f7;
        int bayar;
        public Form4(Form2 ParentForm)
        {
            InitializeComponent();
            f7 = ParentForm;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void dispData()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from listKendaraan";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            koneksi.Close();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedItem.ToString() != "")
            {
                koneksi.Open();
                TimeSpan ts = new TimeSpan();
                ts = bunifuDatePicker2.Value.Subtract(bunifuDatePicker1.Value);
                int selisih = (int)Math.Round(ts.TotalDays);
                if (comboBox1.SelectedItem.ToString().Equals("Motor"))
                {
                    bayar = selisih * 3000;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Mobil"))
                {
                    bayar = selisih * 5000;
                }
                bunifuMaterialTextbox1.Enabled = false;
                bunifuMaterialTextbox1.Text = bayar.ToString();
                String query = "INSERT into listKendaraan VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + bunifuDatePicker1.Value.ToString() + "', '" + bunifuDatePicker2.Value.ToString() + "',  '" + bayar + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, koneksi);
                sda.SelectCommand.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Insert Successfull");
                textBox1.Text = "";
                textBox2.Text = "";
                bunifuMaterialTextbox1.Text = "";
                comboBox1.Text = "";
                bunifuDatePicker1.ResetText();
                bunifuDatePicker2.ResetText();
            }
            else
            {
                MessageBox.Show("Silahkan melengkapi data terlebih dahulu");
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedItem.ToString() != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                int uname;
                uname = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM listKendaraan  WHERE NomorPolisi ='" + textBox1.Text + "';";
                cmd.ExecuteNonQuery();
                DataTable user = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(user);
                uname = Convert.ToInt32(user.Rows.Count.ToString());
                if (uname == 0)
                {
                    MessageBox.Show("Nomor polisi yang anda cari belum memiliki data, silahkan menginputkan data terlebih dahulu");
                }
                else
                {
                    TimeSpan ts = new TimeSpan();
                    ts = bunifuDatePicker2.Value.Subtract(bunifuDatePicker1.Value);
                    int selisih = (int)Math.Round(ts.TotalDays);
                    if (comboBox1.SelectedItem.ToString().Equals("Motor"))
                    {
                        bayar = selisih * 3000;
                    }
                    else if (comboBox1.SelectedItem.ToString().Equals("Mobil"))
                    {
                        bayar = selisih * 5000;
                    }
                    bunifuMaterialTextbox1.Enabled = false;
                    bunifuMaterialTextbox1.Text = bayar.ToString();
                    cmd.CommandText = "UPDATE listKendaraan SET  Nama = '" + textBox2.Text + "', CheckIn = '" + bunifuDatePicker1.Value.ToString() + "', CheckOut = '" + bunifuDatePicker2.Value.ToString() + "', Tarif = '" + bayar + "' WHERE NomorPolisi = '" + textBox1.Text + "';";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Update Successfull");
                    reset();
                }
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan melengkapi data yang ingin di update terlbih dahulu");
            }
            comboBox1.Enabled = true;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from listKendaraan where NomorPolisi='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                dispData();
                MessageBox.Show("Deleted Successfull");
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan data nomor polisi yang ingin dihapus");
            }
        }
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            bunifuMaterialTextbox1.Text = "";
            comboBox1.Text = "";
            bunifuDatePicker1.ResetText();
            bunifuDatePicker2.ResetText();
            comboBox1.Enabled = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            dispData();
        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
