using System;
using System.Windows.Forms;

namespace Simon_Says
{
    class Game
    {
        public int[] TheArray = new int[1000];

        private int m_Turn;
        public int Turn
        {
            set { m_Turn = value; }
            get { return m_Turn; }
        }

        private int m_Count;
        public int Count
        {
            set { m_Count = value; }
            get { return m_Count; }
        }

        private bool m_Play;
        public bool Play
        {
            set { m_Play = value; }
            get { return m_Play; }
        }

        public Game()
        {
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                TheArray[i] = rnd.Next(0, 4); // between 0 and 3
            }

            m_Play = false;
            m_Turn = 0;
            m_Count = 0;
        }

        public void GameOver()
        {
            m_timer.Enabled = false;

            String str = String.Format("Game Over\nYou Scored {0}", m_Turn);
            MessageBox.Show(str, "Simon");

            m_Play = false;
            m_Turn = 0;
            m_Count = 0;
        }

        #region Timer
        public void Start()
        {
            m_timer = new Timer();
            m_timer.Interval = 500;
            m_timer.Tick += new EventHandler(TimerTick);
            m_timer.Enabled = true;
        }

        public void Restart()
        {
            m_timer.Enabled = true;
            m_Count = 0;
        }

        public void Stop()
        {
            m_timer.Enabled = false;
            m_Play = true;
            m_Count = 0;
        }

        private Timer m_timer;
        public event EventHandler Tick;

        private void TimerTick(object sender, EventArgs e)
        {
            if (Tick != null)
            {
                Tick(this, new EventArgs());
            }
        }
        #endregion
    }
}
