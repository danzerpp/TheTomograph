using Dicom;
using Dicom.Imaging;
using Dicom.IO.Buffer;
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
        Bitmap bitmap;
        Image img;

        public RadonTransform _radonTransform;

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (_radonTransform != null)
            {
                var Bitmap = _radonTransform.CreateOutImage(trackBar.Value, chkIsFiltered.Checked);
                pictureBox2.Image = Bitmap;
                textRMSE.Text = _radonTransform.RMSE(Bitmap).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "Open DICOM file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileDICOM = DicomFile.Open(openFileDialog1.FileName);
                var imageDICOM = new DicomImage(openFileDialog1.FileName);
                imageDICOM.RenderImage().AsBitmap().Save(@"temp.jpg"); 
                Bitmap b = new Bitmap(@"temp.jpg");
                patientPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                DicomDataset dataset = fileDICOM.Dataset;
                var patientIdD = dataset.Get<string>(DicomTag.PatientID);
                var patientNameD = dataset.Get<string>(DicomTag.PatientName);
                try
                {
                    var patientDateD = dataset.Get<string>(DicomTag.PatientAlternativeCalendar);
                    patientDate.Text = patientDateD;

                }
                catch (Exception)
                {
                }
                //var patientCommentsD = dataset.Get<string>(DicomTag.PatientComments);
                patientId.Text = patientIdD;
                patientName.Text = patientNameD;
                //patientComments.Text = patientCommentsD;
                patientPicture.Image = b;
            }
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap b = (Bitmap)pictureBox2.Image;
            byte[] pixels = GetPixels(b);
            MemoryByteBuffer buffer = new MemoryByteBuffer(pixels);
            DicomDataset dataset = new DicomDataset();
            //FillDataset(dataset);
            dataset.Add(DicomTag.PhotometricInterpretation, PhotometricInterpretation.Rgb.Value);
            dataset.Add(DicomTag.Rows, (ushort)b.Height);
            dataset.Add(DicomTag.Columns, (ushort)b.Width);
            dataset.Add(DicomTag.BitsAllocated, (ushort)8);
            dataset.Add(DicomTag.SOPClassUID, "1.2.840.10008.5.1.4.1.1.2");
            dataset.Add(DicomTag.SOPInstanceUID, "1.2.840.10008.5.1.4.1.1.2.20181120090837121314");
            dataset.Add(DicomTag.PatientID, patientId.Text);
            dataset.Add(DicomTag.PatientName, patientName.Text);
            dataset.Add(DicomTag.StudyDescription, patientComments.Text);
            dataset.Add(DicomTag.StudyDate, DateTime.Now);
            DicomPixelData pixelData = DicomPixelData.Create(dataset, true);
            pixelData.BitsStored = 8;
            //pixelData.BitsAllocated = 8;
            pixelData.SamplesPerPixel = 3;
            pixelData.HighBit = 7;
            pixelData.PixelRepresentation = 0;
            pixelData.PlanarConfiguration = 0;
            pixelData.AddFrame(buffer);

            DicomFile dicomfile = new DicomFile(dataset);
            dicomfile.Save(@"C:\Users\darek\Desktop\temp.dcm");

            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //if (saveFileDialog1.ShowDialog() = DialogResult.OK)
            //{
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "C:";
            openFileDialog2.Title = "Open picture";
            
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(openFileDialog2.FileName);
                int scans, detectors, beam;
                if (int.TryParse(txtAlfa.Text, out scans) && int.TryParse(txtDetectors.Text, out detectors) && int.TryParse(txtRange.Text, out beam))
                {
                    bitmap = (Bitmap)img;
                    pictureBox2.Image = bitmap;
                    pictureBox1.Image = bitmap;
                    pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    _radonTransform = new RadonTransform(bitmap, scans, detectors, beam);
                    
                    pictureBox.Image = _radonTransform.CreateSinogram();
                    pictureBox2.Image = _radonTransform.CreateOutImage(12,chkIsFiltered.Checked);


                    patientPicture.SizeMode = PictureBoxSizeMode.AutoSize;
                    patientPicture.Image = pictureBox2.Image;

                }
                else
                {
                    MessageBox.Show("Wypełnij wymagane pola!");
                }
                
            }
           
        }

        public static byte[] GetPixels(Bitmap bitmap)
        {
            byte[] bytes = new byte[bitmap.Width * bitmap.Height * 3];
            int wide = bitmap.Width;
            int i = 0;
            int height = bitmap.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < wide; x++)
                {
                    var srcColor = bitmap.GetPixel(x, y);
                    //bytes[i] = (byte)(srcColor.R * .299 + srcColor.G * .587 + srcColor.B * .114);
                    bytes[i] = srcColor.R;
                    i++;
                    bytes[i] = srcColor.G;
                    i++;
                    bytes[i] = srcColor.B;
                    i++;
                }
            }
            return bytes;
        }

        private void chkIsFiltered_CheckedChanged(object sender, EventArgs e)
        {
            if (_radonTransform != null)
            {
                var Bitmap = _radonTransform.CreateOutImage(trackBar.Value, chkIsFiltered.Checked);
                pictureBoxSinoFiltered.Image = _radonTransform.CreateFilteredSinogram();
                pictureBoxSinoFiltered.Visible = chkIsFiltered.Checked;
                pictureBox2.Image = Bitmap;
                textRMSE.Text = textRMSE.Text = _radonTransform.RMSE(Bitmap).ToString();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
