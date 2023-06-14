using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvanterYonetimSistemi
{
    public partial class CustomerButton : PictureBox
    {
        public CustomerButton()
        {
            InitializeComponent();
        }

        // Normal görüntüyü tutan değişken
        private Image NormalImage;
        // Üzerine gelindiğindeki görüntüyü tutan değişken
        private Image HoverImage;

        // Normal görüntüyü almak ve ayarlamak için özellik
        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }

        // Üzerine gelindiğindeki görüntüyü almak ve ayarlamak için özellik
        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        // Fare üzerine gelindiğinde görüntüyü değiştirme olayı
        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImage;
        }

        // Fare ayrıldığında görüntüyü esas durumuna döndürme olayı
        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImage;
        }
    }
}
