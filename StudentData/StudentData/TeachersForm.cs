using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentData
{
    public partial class TeachersForm : Form
    {
        public TeachersForm()
        {
            InitializeComponent();
        }

        private void btnClub_Click(object sender, EventArgs e)
        {
            ClubsForm frm = new ClubsForm();
            this.Hide();
            frm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void TeachersForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLesson_Click(object sender, EventArgs e)
        {
            LesseonsForm frm = new LesseonsForm();
            frm.Show();
            this.Hide();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            StudentsForm2 frm = new StudentsForm2();
            frm.Show();
            this.Hide();
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            ExamsScoresForm frm = new ExamsScoresForm();
            frm.Show();
            this.Hide();
        }
    }
}
