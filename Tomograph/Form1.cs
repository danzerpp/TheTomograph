using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tomograph
{
    public partial class Form1 : Form
    {

        public RadonTransform _radonTransform;

        public Form1()
        {
            InitializeComponent();
            trackBar.Minimum = 1;
            trackBar.Maximum = 13;
            
            int aa = (int)Math.Sqrt(1024 * 1024 + 880 * 880);
            Bitmap bitmap = new Bitmap(@"D:\tomo\Kropka.jpg");
            pictureBox2.Image = bitmap;
            pictureBox1.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _radonTransform = new RadonTransform(bitmap,90,180,180);
            bitmap = _radonTransform.CreateSinogram();
            pictureBox.Image = bitmap;
            pictureBox2.Image = _radonTransform.CreateOutImage(90);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = _radonTransform.CreateOutImage(trackBar.Value);
        }
    }
}
