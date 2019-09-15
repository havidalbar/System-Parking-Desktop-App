using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public static Form3 form3;
        public static Form4 form4;
        public static Form5 form5;
        public static Form6 form6;
        public static Form7 form7;
        public static Form9 form9;
        public Form2(Form1 ParentForm)
        {
            InitializeComponent();
            form3 = new Form3(this);
            form3.MdiParent = this;
            form4 = new Form4(this);
            form4.MdiParent = this;
            form5 = new Form5(this);
            form5.MdiParent = this;
            form6 = new Form6(this);
            form6.MdiParent = this;
            form7 = new Form7(this);
            form7.MdiParent = this;
            form9 = new Form9(this);
            form9.MdiParent = this;
            form1 = ParentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            form6.Hide();
            form5.Hide();
            form4.Hide();
            showForm(form3);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            form6.Hide();
            form5.Hide();
            showForm(form4);
            form3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;
            form6.Hide();
            showForm(form5);
            form4.Hide();
            form3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            panel3.Top = button4.Top;
            showForm(form6);
            form5.Hide();
            form4.Hide();
            form3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showForm(object formshow)
        {
            if (this.panelShow.Controls.Count > 0)
                this.panelShow.Controls.RemoveAt(0);
            Form fshow = formshow as Form;
            fshow.TopLevel = false;
            fshow.Dock = DockStyle.Fill;
            this.panelShow.Controls.Add(fshow);
            this.panelShow.Tag = fshow;
            fshow.Show();
        }

        public void showLabel(object labelshow)
        {
            if (this.panelShow.Controls.Count > 0)
                this.panelShow.Controls.RemoveAt(0);
            Label lshow = labelshow as Label;
            this.panelShow.Controls.Add(lshow);
            this.panelShow.Tag = lshow;
            lshow.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Height = button6.Height;
            panel3.Top = button6.Top;
            form6.Hide();
            form5.Hide();
            form4.Hide();
            form3.Hide();
            showLabel(label1);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Height = button7.Height;
            panel3.Top = button7.Top;
            form6.Hide();
            form5.Hide();
            form4.Hide();
            form3.Hide();
            showForm(form7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Height = button8.Height;
            panel3.Top = button8.Top;

            form6.Hide();
            form5.Hide();
            form4.Hide();
            form3.Hide();
            form7.Hide();
            showForm(form9);
        }

        private void panelShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Enter(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
