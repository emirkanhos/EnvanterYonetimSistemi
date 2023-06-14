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

namespace EnvanterYonetimSistemi
{
    public partial class CustomerModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emirk\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        // "Save" butonunun tıklama olayı
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bu müşteriyi kaydetmek istediğinizden emin misiniz?", "Kaydı kaydetmek istediğinizden emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbCustomer(cname,cphone)VALUES(@cname, @cphone)", con);
                    cm.Parameters.AddWithValue("@cname", txtCName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı başarıyla kaydedildi.");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Alanları temizler
        public void Clear()
        {
            txtCName.Clear();
            txtCPhone.Clear();
        }

        // "Clear" butonunun tıklama olayı
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
        }

        // Kapatma simgesi tıklama olayı
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // "Update" butonunun tıklama olayı
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try {
                 if (MessageBox.Show("Bu müşteriyi güncellemek istediğinizden emin misiniz?", "Kaydı güncellemek istediğinizden emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                cm = new SqlCommand("UPDATE tbCustomer SET cname=@cname,cphone=@cphone WHERE cid LIKE '" + lblCId.Text + "'", con);
                cm.Parameters.AddWithValue("@cname", txtCName.Text);
                cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Müşteri başarıyla güncellendi!");
                this.Dispose();
                 }
                 }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomerModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
