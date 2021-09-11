using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentData
{
    public partial class StudentsForm : Form
    {
        public StudentsForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;");

        public string numara;
        private void StudentsForm_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select LessName, exam1, exam2, exam3, projectScore, average, scoreStatus  from dbo.Scores inner join Lessons on Scores.lessId = Lessons.lessId where stuId = @p1", con);
            komut.Parameters.AddWithValue("@p1", numara);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            // Açılan formda öğrenci ismini çekme
            con.Open();
            SqlCommand komut2 = new SqlCommand("select stuName, stuSurname from Students", con);
            SqlDataReader dataReader = komut2.ExecuteReader();
            
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    this.Text = dataReader[0].ToString() + " " + dataReader[1].ToString();
                }
            }
            con.Close();


        }
    }
}
