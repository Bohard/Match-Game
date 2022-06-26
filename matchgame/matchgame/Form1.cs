

namespace matchgame
{
    public partial class Form1 : Form
    {
        public static Form1 SelfRef
        {
            get; set;
        }
        Random r = new Random();
        List<string> icons = new List<string>();
        Label first = null;
        Label second = null;
        public Form1()
        {

            InitializeComponent();
         
            AssignIconsToSquares();
            SelfRef = this;
        }
        string chars = "01234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        void CreateRandomString()
        {
            for (int i = 0; i<tableLayoutPanel1.Controls.Count/2; i++)
            {
               m1: var randomIndex = r.Next(chars.Length);
                if (!icons.Contains(chars[randomIndex].ToString()))
                {
                    icons.Add(chars[randomIndex].ToString());
                    icons.Add(chars[randomIndex].ToString());
                }
                else
                {
                    goto m1;
                }
            }
        }
        public void res()
        {
            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            CreateRandomString();
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                try
                {
                    if (iconLabel != null)
                    {
                        int randomNumber = r.Next(icons.Count);
                        iconLabel.Text = icons[randomNumber];
                        iconLabel.ForeColor = iconLabel.BackColor;
                        icons.RemoveAt(randomNumber);
                    }
                }
                catch { }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
    if (timer1.Enabled == true)
        return;

    Label clickedLabel = sender as Label;

    if (clickedLabel != null)
    {
        if (clickedLabel.ForeColor == Color.Black)
            return;
        if (first == null)
        {
            first = clickedLabel;
            first.ForeColor = Color.Black;
            return;
        }
        second = clickedLabel;
        second.ForeColor = Color.Black;
                CheckForWinner();
                if (first.Text == second.Text)
                {
                    first = null;
                    second = null;
                    return;
                }
                timer1.Start();
    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            new Form2().Show();
        }
    }
}