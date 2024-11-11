using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeForms
{
    public partial class Menu : Form
    {
        private Button btn1, btn2, btn3;
      
        public Menu()
        {
            InitializeComponent();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn1.Location = new Point(100, 100);
            btn1.AutoSize = true;
            btn2.Location = new Point(200, 100);
            btn2.AutoSize = true;
            btn3.Location = new Point(300, 100);
            btn3.AutoSize = true;

            btn1.Text = "Picture Viewer";
            btn1.Click += Btn1_Click;


            btn2.Text = "Math Quiz";
            btn2.Click += Btn2_Click;


            btn3.Text = "Matching Game";
            btn3.Click += Btn3_Click;


            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            

        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            PictureViewer pictureViewer = new PictureViewer();
            pictureViewer.Show();
                   
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            MathQuiz mathQuiz = new MathQuiz();
            mathQuiz.Show();

        }
        private void Btn3_Click(object sender, EventArgs e)
        {
            MatchingGame matchingGame = new MatchingGame();
            matchingGame.Show();

        }



    }
}
