using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        Form2 f7;
        SqlConnection koneksi = new SqlConnection(@"Data Source=MSI\DBSS075;Initial Catalog=Project Akhir;Integrated Security=True");
        public Form5(Form2 ParentForm)
        {
            InitializeComponent();
            f7 = ParentForm;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (plat.Text != "" && jenis.SelectedItem.ToString() != "")
            {
                koneksi.Open();
                String query = "INSERT into merkKendaraan VALUES ('" + plat.Text + "', '" + jenis.Text + "', '" + merk.Text + "', '" + tipe.Text + "', '" + tahun.Text + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, koneksi);
                sda.SelectCommand.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data sudah dimasukkan");
                reset();
            }
            else
            {
                MessageBox.Show("Silahkan melengkapi data terlebih dahulu");
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (plat.Text != "" && jenis.SelectedItem.ToString() != "")
            {
                koneksi.Open();
                String query = "UPDATE merkKendaraan SET Merk = '" + merk.Text + "', Tipe = '" + tipe.Text + "', Tahun = '" + tahun.Text + "' WHERE noPlat = '" + plat.Text + "';";
                SqlDataAdapter sda = new SqlDataAdapter(query, koneksi);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate");
                reset();
                koneksi.Close();
            }
            else
            {
                MessageBox.Show("Silahkan melengkapi data terlebih dahulu");
            }
            jenis.Enabled = true;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (plat.Text != "")
            {
                koneksi.Open();
                String query = "delete from merkKendaraan where noPlat='" + plat.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, koneksi);
                sda.SelectCommand.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Deleted Successfull");
            }
            else
            {
                MessageBox.Show("Silahkan memasukkan data nomor polisi yang ingin dihapus");
            }
        }
        public void reset()
        {
            plat.Text = "";
            jenis.Text = "";
            merk.Text = "";
            tipe.Text = "";
            tahun.Text = "";
            jenis.Enabled = true;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            String query = "select listKendaraan.NomorPolisi,listKendaraan.Nama,merkKendaraan.jenis,merkKendaraan.Merk,merkKendaraan.Tipe,merkKendaraan.Tahun,listKendaraan.CheckIn from merkKendaraan inner join listKendaraan on merkKendaraan.noPlat = listKendaraan.NomorPolisi";
            SqlDataAdapter sda = new SqlDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            koneksi.Close();
        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            plat.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            jenis.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            merk.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            tipe.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            tahun.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            jenis.Enabled = false;
        }
    }
}
