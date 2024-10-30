using Task_15.MyContex;

namespace Task_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new NewsContext();
            var newsList = db.News.Where(s => s.Id != 0).ToList();

            dataGridView1.DataSource = newsList;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
