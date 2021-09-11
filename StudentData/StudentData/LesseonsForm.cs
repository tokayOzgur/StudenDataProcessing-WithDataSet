using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentData
{
    public partial class LesseonsForm : Form
    {
        public LesseonsForm()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.LessonsTableAdapter ds = new DataSet1TableAdapters.LessonsTableAdapter();
        private void LesseonsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.LessonList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.AddLesson(txtAd.Text);
            MessageBox.Show("Ders Eklendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.LessonList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TeachersForm frm = new TeachersForm();
            frm.Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DeleteLesson(Byte.Parse(txtId.Text));
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.UpdateLesson(txtAd.Text, Byte.Parse(txtId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
