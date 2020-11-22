using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV.Structure;
using Emgu.CV;

namespace Métodos_de_binarización
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> img;
        Image<Gray, byte> GrayImage;
        Image<Gray, byte> binarImg;

        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    img = new Image<Bgr, byte>(ofd.FileName);
                    pictureBox1.Image = img.ToBitmap();
                }catch(Exception)
                {
                    MessageBox.Show("El formato del archivo no es válido", "Formato incorrecto", MessageBoxButtons.OK);
                }

            }
        }

        private void binarizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayImage = img.Convert<Gray, byte>();
            pictureBox1.Image = GrayImage.ToBitmap();

            //Binarización thresholding
            binarImg = new Image<Gray, byte>(GrayImage.Width,GrayImage.Height,new Gray(0));
            CvInvoke.Threshold(GrayImage,binarImg,100,255,Emgu.CV.CvEnum.ThresholdType.Binary);
            pictureBox2.Image = binarImg.ToBitmap();
        }
    }
}
