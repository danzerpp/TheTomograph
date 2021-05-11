namespace Tomograph
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtAlfa = new System.Windows.Forms.TextBox();
            this.txtDetectors = new System.Windows.Forms.TextBox();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkIsFiltered = new System.Windows.Forms.CheckBox();
            this.pictureBoxSinoFiltered = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.DICOM = new System.Windows.Forms.TabPage();
            this.patientId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.patientComments = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.patientName = new System.Windows.Forms.TextBox();
            this.patientPicture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSinoFiltered)).BeginInit();
            this.DICOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Silver;
            this.pictureBox.Location = new System.Drawing.Point(52, 612);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(180, 90);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // txtAlfa
            // 
            this.txtAlfa.Location = new System.Drawing.Point(215, 51);
            this.txtAlfa.Margin = new System.Windows.Forms.Padding(6);
            this.txtAlfa.Name = "txtAlfa";
            this.txtAlfa.Size = new System.Drawing.Size(184, 34);
            this.txtAlfa.TabIndex = 1;
            this.txtAlfa.Text = "90";
            // 
            // txtDetectors
            // 
            this.txtDetectors.Location = new System.Drawing.Point(215, 102);
            this.txtDetectors.Margin = new System.Windows.Forms.Padding(6);
            this.txtDetectors.Name = "txtDetectors";
            this.txtDetectors.Size = new System.Drawing.Size(184, 34);
            this.txtDetectors.TabIndex = 2;
            this.txtDetectors.Text = "180";
            // 
            // txtRange
            // 
            this.txtRange.Location = new System.Drawing.Point(215, 154);
            this.txtRange.Margin = new System.Windows.Forms.Padding(6);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(184, 34);
            this.txtRange.TabIndex = 3;
            this.txtRange.Text = "180";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(47, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scans";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(47, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detectors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(47, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Beam extent";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(692, 259);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(550, 341);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(52, 259);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 341);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(692, 121);
            this.trackBar.Maximum = 12;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(550, 56);
            this.trackBar.TabIndex = 9;
            this.trackBar.Value = 12;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.DICOM);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1298, 1046);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkIsFiltered);
            this.tabPage1.Controls.Add(this.pictureBoxSinoFiltered);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.trackBar);
            this.tabPage1.Controls.Add(this.txtRange);
            this.tabPage1.Controls.Add(this.pictureBox);
            this.tabPage1.Controls.Add(this.txtDetectors);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtAlfa);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1290, 1004);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analiza";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkIsFiltered
            // 
            this.chkIsFiltered.AutoSize = true;
            this.chkIsFiltered.Location = new System.Drawing.Point(52, 202);
            this.chkIsFiltered.Name = "chkIsFiltered";
            this.chkIsFiltered.Size = new System.Drawing.Size(228, 33);
            this.chkIsFiltered.TabIndex = 14;
            this.chkIsFiltered.Text = "Filter Sinogram?";
            this.chkIsFiltered.UseVisualStyleBackColor = true;
            this.chkIsFiltered.CheckedChanged += new System.EventHandler(this.chkIsFiltered_CheckedChanged);
            // 
            // pictureBoxSinoFiltered
            // 
            this.pictureBoxSinoFiltered.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxSinoFiltered.Location = new System.Drawing.Point(434, 98);
            this.pictureBoxSinoFiltered.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxSinoFiltered.Name = "pictureBoxSinoFiltered";
            this.pictureBoxSinoFiltered.Size = new System.Drawing.Size(180, 90);
            this.pictureBoxSinoFiltered.TabIndex = 13;
            this.pictureBoxSinoFiltered.TabStop = false;
            this.pictureBoxSinoFiltered.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(52, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(347, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "Otwórz zdjęcie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(599, 671);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(42, 45);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "1. Pierwsza strona wartosci suwak, checkbox z firtrowaniem, wybieranie pliku img " +
    "dialog kotrolka, tworzenie DICOMA z parametrami okreslonymi w regulach";
            // 
            // DICOM
            // 
            this.DICOM.Controls.Add(this.patientId);
            this.DICOM.Controls.Add(this.label6);
            this.DICOM.Controls.Add(this.button2);
            this.DICOM.Controls.Add(this.patientComments);
            this.DICOM.Controls.Add(this.label4);
            this.DICOM.Controls.Add(this.patientName);
            this.DICOM.Controls.Add(this.patientPicture);
            this.DICOM.Controls.Add(this.button1);
            this.DICOM.Location = new System.Drawing.Point(4, 38);
            this.DICOM.Name = "DICOM";
            this.DICOM.Padding = new System.Windows.Forms.Padding(3);
            this.DICOM.Size = new System.Drawing.Size(1290, 1004);
            this.DICOM.TabIndex = 1;
            this.DICOM.Text = "DICOM";
            this.DICOM.UseVisualStyleBackColor = true;
            // 
            // patientId
            // 
            this.patientId.Location = new System.Drawing.Point(996, 49);
            this.patientId.Name = "patientId";
            this.patientId.Size = new System.Drawing.Size(215, 34);
            this.patientId.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(785, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "ID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1025, 622);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 74);
            this.button2.TabIndex = 10;
            this.button2.Text = "Zapisz plik DICOM";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // patientComments
            // 
            this.patientComments.Location = new System.Drawing.Point(790, 188);
            this.patientComments.Name = "patientComments";
            this.patientComments.Size = new System.Drawing.Size(421, 395);
            this.patientComments.TabIndex = 9;
            this.patientComments.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(785, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Imie i nazwisko";
            // 
            // patientName
            // 
            this.patientName.Location = new System.Drawing.Point(996, 115);
            this.patientName.Name = "patientName";
            this.patientName.Size = new System.Drawing.Size(215, 34);
            this.patientName.TabIndex = 3;
            // 
            // patientPicture
            // 
            this.patientPicture.BackColor = System.Drawing.Color.Silver;
            this.patientPicture.Location = new System.Drawing.Point(64, 52);
            this.patientPicture.Name = "patientPicture";
            this.patientPicture.Size = new System.Drawing.Size(631, 644);
            this.patientPicture.TabIndex = 2;
            this.patientPicture.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(790, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "Otwórz plik DICOM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 914);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Tomograf";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSinoFiltered)).EndInit();
            this.DICOM.ResumeLayout(false);
            this.DICOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox txtAlfa;
        private System.Windows.Forms.TextBox txtDetectors;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage DICOM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox patientComments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox patientName;
        private System.Windows.Forms.PictureBox patientPicture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox patientId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.PictureBox pictureBoxSinoFiltered;
        private System.Windows.Forms.CheckBox chkIsFiltered;
    }
}

