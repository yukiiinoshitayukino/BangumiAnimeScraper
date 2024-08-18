namespace BangumiAnimeScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
            textBox1.Focus();

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string UserInput=textBox1.Text;
            textBox1.Clear();
            
        }
        public string GetUserInput()
        {

            return textBox1.Text;
        }
    }
}
