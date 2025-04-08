using System.Drawing;
using System.Windows.Forms;
namespace TestGI
{
    public class TimerForTest:Label
    {
        Timer timer;
        int timeTotal;
        int timeCurrent;

        public TimerForTest(int time,int x, int y)
        {
            this.timeTotal = time;
            this.Text = timeTotal.ToString();
            this.Font = new System.Drawing.Font("Arial", 20);
            this.BackColor = SystemColors.ActiveCaption;
            this.Width = timeTotal.ToString().Length *30;
            this.Height = 50;
            this.Top = y;
            this.Left = x;
            this.TextAlign = ContentAlignment.MiddleCenter;
            timer = new Timer();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (timeCurrent == 0)
            {
                timer.Enabled = false;
                return;
            }
            Tick();
        }
        public void Start()
        {
            timeCurrent = timeTotal;
            timer.Enabled = true;
        }
        private void Tick()
        {
            timeCurrent--;
            this.Text = timeCurrent.ToString();
        }
    }
}
