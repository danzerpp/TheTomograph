using Dicom;
using Dicom.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            trackBar.Maximum = 12;
            
            int aa = (int)Math.Sqrt(1024 * 1024 + 880 * 880);
            Bitmap bitmap = new Bitmap(@"C:\Users\darek\Pictures\Kropka.jpg");
            pictureBox2.Image = bitmap;
            pictureBox1.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _radonTransform = new RadonTransform(bitmap,90,180,180);
            bitmap = _radonTransform.CreateSinogram();
            pictureBox.Image = bitmap;
            pictureBox2.Image = _radonTransform.CreateOutImage(12);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = _radonTransform.CreateOutImage(trackBar.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "Open DICOM file";
            openFileDialog1.ShowDialog();
            var fileDICOM = DicomFile.Open(openFileDialog1.FileName);
            var imageDICOM = new DicomImage(openFileDialog1.FileName);
            imageDICOM.RenderImage().AsBitmap().Save(@"temp.jpg");
            Bitmap b = new Bitmap(@"temp.jpg");
            patientPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            DicomDataset dataset = fileDICOM.Dataset;
            var patientIdD = dataset.Get<string>(DicomTag.PatientID);
            var patientNameD = dataset.Get<string>(DicomTag.PatientName);
            //var patientDateD = dataset.Get<string>(DicomTag.PatientAlternativeCalendar);
            //var patientCommentsD = dataset.Get<string>(DicomTag.PatientComments);

            patientId.Text = patientIdD;
            patientName.Text = patientNameD;
            //patientDate.Text = patientDateD;
            //patientComments.Text = patientCommentsD;
            patientPicture.Image = b;

        }
    }
}
