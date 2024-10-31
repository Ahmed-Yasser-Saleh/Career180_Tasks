using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using Task_14.Models;
namespace Task_14
{
    public partial class Form1 : Form
    {
        public ItiProjectContext db = new ItiProjectContext();
        public int? id;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            displaydata();
            comboBox1.DataSource = db.Departments.ToList();
        }
        private void displaydata()
        {
            var x = db.Trainees
            .Include(d => d.Dept)
            .Include(d => d.TraineeCourses)
            .ThenInclude(tc => tc.Course)  // Ensure Course is loaded within TraineeCourses
            .Select(d => new
            {
                d.Id,
                d.Name,
                d.Address,
                d.Grade,
                d.Age,
                DeptName = d.Dept.Name,
                Courses = string.Join(", ", d.TraineeCourses.Select(tc => tc.Course.Name))
            })
            .ToList();

            DVG1.DataSource = x;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var name = TextBoxName.Text;
                var id = int.Parse(TextBoxId.Text);
                var age = int.Parse(textBoxAge.Text);
                var address = textBoxAddress.Text;
                var deptid = int.Parse(textBoxDeptid.Text);
                var grade = textBoxGrade.Text;
                db.Trainees.Add(new Trainee { Name = name, Id = id, Age = age, Address = address, Deptid = deptid, Grade = grade });
                db.SaveChanges();
                displaydata();
                TextBoxName.Text = TextBoxId.Text = textBoxAge.Text = textBoxAddress.Text = textBoxDeptid.Text = textBoxGrade.Text = "";
                MessageBox.Show($"Trainee with id: {id} Added Successful");
            }
            catch (Exception ex)
            {
                TextBoxName.Text = TextBoxId.Text = textBoxAge.Text = textBoxAddress.Text = textBoxDeptid.Text = textBoxGrade.Text = "";
                MessageBox.Show($"Failed Adding because of {ex.Message}");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var req = db.Trainees.FirstOrDefault(t => t.Id == id);
            try
            {
                if (int.Parse(TextBoxId.Text) != id)
                {
                    db.Remove(req);
                    var name = TextBoxName.Text;
                    var id = int.Parse(TextBoxId.Text);
                    var age = int.Parse(textBoxAge.Text);
                    var address = textBoxAddress.Text;
                    var deptid = int.Parse(textBoxDeptid.Text);
                    var grade = textBoxGrade.Text;
                    db.Trainees.Add(new Trainee { Name = name, Id = id, Age = age, Address = address, Deptid = deptid, Grade = grade });
                }
                else
                {
                    req.Name = TextBoxName.Text;
                    req.Id = int.Parse(TextBoxId.Text);
                    req.Age = int.Parse(textBoxAge.Text);
                    req.Address = textBoxAddress.Text;
                    req.Deptid = int.Parse(textBoxDeptid.Text);
                    req.Grade = textBoxGrade.Text;
                }
                db.SaveChanges();
                displaydata();
                TextBoxName.Text = TextBoxId.Text = textBoxAge.Text = textBoxAddress.Text = textBoxDeptid.Text = textBoxGrade.Text = "";
                MessageBox.Show($"Trainee with id: {id} Edited Successful");
            }
            catch(Exception ex) {
                TextBoxName.Text = TextBoxId.Text = textBoxAge.Text = textBoxAddress.Text = textBoxDeptid.Text = textBoxGrade.Text = "";
                MessageBox.Show($"Failed Editing because of {ex.Message}");
            } 
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var req = db.Trainees.FirstOrDefault(t => t.Id == id);
            db.Remove(req);
            db.SaveChanges();
            displaydata();
            TextBoxName.Text = TextBoxId.Text = textBoxAge.Text = textBoxAddress.Text = textBoxDeptid.Text = textBoxGrade.Text = "";
            MessageBox.Show($"Trainee with id: {id} Removed Successful");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void Address_Click(object sender, EventArgs e)
        {

        }

        private void DVG1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = (int)DVG1.SelectedRows[0].Cells["Id"].Value;
            var trainee_req = db.Trainees.FirstOrDefault(t => t.Id == id);
            TextBoxName.Text = trainee_req?.Name;
            TextBoxId.Text = trainee_req?.Id.ToString();
            textBoxAge.Text = trainee_req?.Age.ToString();
            textBoxAddress.Text = trainee_req?.Address;
            textBoxDeptid.Text = trainee_req?.Deptid.ToString();
            textBoxGrade.Text = trainee_req?.Grade;
        }

        private void TextBoxId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
