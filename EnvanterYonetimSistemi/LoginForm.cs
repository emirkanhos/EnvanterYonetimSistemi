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

namespace EnvanterYonetimSistemi
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emirk\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            // Parola göster/gizleme işlemi
            if (checkBoxPass.Checked == false)
                txtpass.UseSystemPasswordChar = true;
            else
                txtpass.UseSystemPasswordChar = false;

        }

        private void lblclear_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı ve parola alanlarını temizleme
            txtname.Clear();
            txtpass.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Uygulamadan çıkış yapma
            if (MessageBox.Show("Uygulamadan Çıkış Yap","Emin Misiniz?",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcı adı ve parolayı kontrol etme
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", txtname.Text);
                cm.Parameters.AddWithValue("@password", txtpass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    // Giriş başarılıysa ana formu açma
                    MessageBox.Show("Hoşgeldiniz " + dr["fullname"].ToString() + "  |  ", "GİRİŞ ONAYLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                    this.Hide();
                }
                else
                {
                    // Giriş başarısızsa hata mesajı gösterme
                    MessageBox.Show("Hatalı kullanıcı adı veya parola!", "GİRİŞ REDDEDİLDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch(Exception ex)
            {


                // Hata durumunda hata mesajı gösterme
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
