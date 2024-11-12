using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ThreeForms
{
    public partial class MatchingGame : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "bmw.jpg", "bmw.jpg", "mercedes.jpg", "mercedes.jpg", "toyota.jpg", "toyota.jpg", "bentley.jpg", "bentley.jpg",
            "rollsRoyce.jpg", "rollsRoyce.jpg", "porsche.jpg", "porsche.jpg", "bugatt.jpg", "bugatt.jpg", "koeningsegg.jpg", "koeningsegg.jpg"
        };

        Label firstClicked = null;
        Label secondClicked = null;

        private Timer timer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;

        private Timer timer2;
        private Label labelTimer;
        private int timerInt;

       
        private int matchedPairs = 0;

        public MatchingGame()
        {
            this.Width = 600;
            this.Height = 600;           
            this.Text = "Matching Game";

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            label1 = CreateLabel();
            label2 = CreateLabel();
            label3 = CreateLabel();
            label4 = CreateLabel();
            label5 = CreateLabel();
            label6 = CreateLabel();
            label7 = CreateLabel();
            label8 = CreateLabel();
            label9 = CreateLabel();
            label10 = CreateLabel();
            label11 = CreateLabel();
            label12 = CreateLabel();
            label13 = CreateLabel();
            label14 = CreateLabel();
            label15 = CreateLabel();
            label16 = CreateLabel();

            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            timer2 = new Timer();
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            timer2.Start();

            labelTimer = new Label();
            labelTimer.AutoSize = true;
            labelTimer.Font = new Font(labelTimer.Font.FontFamily, 18f);
            labelTimer.TextAlign = ContentAlignment.MiddleLeft;
            labelTimer.Anchor = AnchorStyles.Left;

            InitializeControls();
            AssignIconsToSquares();
        }

        private Label CreateLabel()
        {
            Label label = new Label
            {
                BackColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            label.Click += label1_Click;
            return label;
        }

        private void AssignIconsToSquares()
        {
            List<string> availableIcons = new List<string>(icons); 

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(availableIcons.Count);
                    string imagePath = availableIcons[randomNumber];

                    
                    iconLabel.Image = null;
                    iconLabel.Tag = imagePath; 
                    availableIcons.RemoveAt(randomNumber);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) 
                return;

            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                string imagePath = clickedLabel.Tag as string;
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    Image originalImage = Image.FromFile(imagePath);
                    Image resizedImage = new Bitmap(originalImage, new Size(clickedLabel.Width, clickedLabel.Height));
                    clickedLabel.Image = resizedImage;
                }

                clickedLabel.ForeColor = Color.Black;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    return;
                }

                secondClicked = clickedLabel;

                
                if (firstClicked.Tag == secondClicked.Tag)
                {
                    matchedPairs++;
                    firstClicked = null;
                    secondClicked = null;
                    CheckForWinner();
                }
                else
                {
                    timer1.Start(); 
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            
            if (firstClicked.Image != secondClicked.Image)
            {
                firstClicked.Image = null;
                secondClicked.Image = null;
            }

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            
            if (matchedPairs == icons.Count / 2)
            {
                timer2.Stop();
                MessageBox.Show($"You matched all the icons in {timerInt} seconds!", "Congratulations");
                Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timerInt++;
            if (timerInt == 1)
            {
                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    Label iconLabel = control as Label;
                    if (iconLabel != null)
                    {
                        iconLabel.ForeColor = iconLabel.BackColor;
                    }
                }
            }
            labelTimer.Text = $"Elapsed: {timerInt} seconds";
        }

        private void InitializeControls()
        {
            Controls.Add(labelTimer);
            Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.Controls.AddRange(new Control[] {
                label1, label2, label3, label4,
                label5, label6, label7, label8,
                label9, label10, label11, label12,
                label13, label14, label15, label16
            });
        }
    }
}
