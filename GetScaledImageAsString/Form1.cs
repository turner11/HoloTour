using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetScaledImageAsString
{
    public partial class Form1 : Form
    {
        readonly DataTable dt;
        const string COL_NAME_MAX_WIDTH = "Max Width";
        const string COL_NAME_MAX_HEIGHT = "Max Heigth";

        public Form1()
        {
            InitializeComponent();
            this.dt = new DataTable();
            this.dt.Columns.Add(COL_NAME_MAX_WIDTH, typeof(int));
            this.dt.Columns.Add(COL_NAME_MAX_HEIGHT, typeof(int));
            this.gvSize.DataSource = dt;

            var r =dt.NewRow();
            r[COL_NAME_MAX_WIDTH] = 280;
            r[COL_NAME_MAX_HEIGHT] = 187;
            dt.Rows.Add(r);

        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            var imageFilePath = this.txbImage.Text;
            if (!File.Exists(imageFilePath))
            {
                MessageBox.Show($"File {imageFilePath } does not exist.");
                return;
            }
            try
            {
                var origFile = new FileInfo(imageFilePath);
                foreach (var row in this.dt.Rows.OfType<DataRow>().ToList())
                {
                    int maxWidth =(int)(row[COL_NAME_MAX_WIDTH] ?? int.MaxValue);
                    int maxHeight = (int)(row[COL_NAME_MAX_HEIGHT] ?? int.MaxValue);

                   
                    using (var image = Image.FromFile(imageFilePath))
                    using (var newImage = ScaleImage(image, maxWidth, maxHeight))
                    {
                        var suffix = $"_{maxWidth}_{maxHeight}";
                        string newFileName = GetFileNameWithSuffix(imageFilePath, suffix);

                        var imgFormt = ImageFormat.Png;
                        Path.ChangeExtension(newFileName, imgFormt.ToString());
                        newImage.Save(newFileName, imgFormt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }

        private static string GetFileNameWithSuffix(string path, string suffix)
        {
            
            return Path.Combine(
                Path.GetDirectoryName(path)
                , Path.GetFileNameWithoutExtension(path) + suffix
               + Path.GetExtension(path)
               );
        }


        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.txbImage.Text = fd.FileName;
            }
        }

        private void btnGetImageAsString_Click(object sender, EventArgs e)
        {
            var imageFilePath = this.txbImage.Text;
            if (!File.Exists(imageFilePath))
            {
                MessageBox.Show($"File {imageFilePath } does not exist.");
                return;
            }

            var bytes = File.ReadAllBytes(imageFilePath);
            var asString = Convert.ToBase64String(bytes);

            var textFileName = GetFileNameWithSuffix(imageFilePath, "_AS_STRING");
            textFileName = Path.ChangeExtension(textFileName, "txt");
            File.WriteAllText(textFileName,asString);

            Process.Start("Explorer.exe", textFileName);
            //var frm = new TextForm(asString);
            //frm.Show(this);
        }
    }
}
