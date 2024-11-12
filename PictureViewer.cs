namespace ThreeForms
{
    public partial class PictureViewer : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn1, btn2, btn3, btn4, btn5, btn6; 
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;

        public PictureViewer()
        {
            InitializeComponent();
            this.Text = "Picture Viewer";

            
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            checkBox1 = new CheckBox();
            checkBox1.Text = "Stretch";
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;

            btn1 = new Button();
            btn1.Text = "Show a picture";
            btn1.AutoSize = true;
            btn1.Click += showButton_Click;

            btn2 = new Button();
            btn2.Text = "Clear the picture";
            btn2.AutoSize = true;
            btn2.Click += clearButton_Click;

            btn3 = new Button();
            btn3.Text = "Set the background color";
            btn3.AutoSize = true;
            btn3.Click += backgroundButton_Click;
          

            btn4 = new Button();
            btn4.Text = "Convert to Black & White";
            btn4.AutoSize = true;
            btn4.Click += convertToGrayscaleButton_Click;

            btn5 = new Button();
            btn5.Text = "Close";
            btn5.AutoSize = true;
            btn5.Click += closeButton_Click;

          

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a picture file";

            colorDialog1 = new ColorDialog();

            InitializeControls();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void convertToGrayscaleButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap grayscaleBitmap = ConvertToGrayscale(originalBitmap);
                pictureBox1.Image = grayscaleBitmap;
            }
        }

        
        private Bitmap ConvertToGrayscale(Bitmap originalBitmap)
        {
            Bitmap grayscaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    Color pixelColor = originalBitmap.GetPixel(x, y);
                    int grayValue = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayscaleBitmap.SetPixel(x, y, grayColor);
                }
            }
            return grayscaleBitmap;
        }

        private void InitializeControls()
        {
            Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 1);
            flowLayoutPanel1.Controls.Add(btn1);
            flowLayoutPanel1.Controls.Add(btn2);
            flowLayoutPanel1.Controls.Add(btn3);
            flowLayoutPanel1.Controls.Add(btn4);
            flowLayoutPanel1.Controls.Add(btn5);  
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
        }
    }
}
