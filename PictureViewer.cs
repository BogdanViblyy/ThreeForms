namespace ThreeForms
{
    public partial class PictureViewer : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn1, btn2, btn3, btn4, btn5;
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
            btn4.Text = "Set the background color";
            btn4.AutoSize = true;
            btn4.Click += backgroundButton_Click;

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
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the picture.
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Show the color dialog box. If the user clicks OK, change the
            // PictureBox control's background to the color the user chose.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects the Stretch check box, 
            // change the PictureBox's
            // SizeMode property to "Stretch". If the user clears 
            // the check box, change it to "Normal".
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
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
            flowLayoutPanel1.Controls.Add(btn5);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
        }
    }
}
