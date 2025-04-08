using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGI
{
    public partial class FormTest : Form
    {

        TestGeniusIdiot test;
        TimerForTest timer;
        public FormTest()
        {
            InitializeComponent();
            timer = new TimerForTest(20,50,100);
            this.Controls.Add(timer);
            startTest();
            timer.Start();
        }
        void startTest()
        {
            test = new TestGeniusIdiot();
            textBoxQuestion.Text = test.NextQuestion();
            labelNumberOfQuestion.Text = "Вопрос №" + test.NumberQuestion();
        }
        private void buttonNextQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                int userAnswer = Convert.ToInt32(textBoxUserAnswer.Text);
                test.CheckAnswer(userAnswer);
                if (test.EndOfTest())
                {
                    MessageBox.Show(test.Diagnose());
                    buttonNewStart.Visible = true;
                }
                else
                {
                    textBoxQuestion.Text = test.NextQuestion();
                    labelNumberOfQuestion.Text = "Вопрос №" + test.NumberQuestion();
                    timer.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("В ответе может быть только число");
            }

            

        }

        private void buttonNewStart_Click(object sender, EventArgs e)
        {
            startTest();
        }

        
    }
}
