using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentData
{
    public partial class ClubsForm : Form
    {
        public ClubsForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;");

        private void btnBack_Click(object sender, EventArgs e)
        {
            TeachersForm frm = new TeachersForm();
            frm.Show();
            this.Hide();
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {
            listMethod();
        }

        // listele butonu
        private void button1_Click(object sender, EventArgs e)
        {
            listMethod();
        }

        public void listMethod()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Clubs", con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("insert into Clubs (clubName) values (@p1)", con);
            komut.Parameters.AddWithValue("p1", txtAd.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kulüp listeye eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Silme işleminde emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con.Open();
                SqlCommand komut = new SqlCommand("delete from Clubs where clubId=@p1", con);
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Silme işlemi başarılı.");
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Silme işlemi iptal edildi.");
            }
            else
            {
                MessageBox.Show("Silme işlemi sırasında bir hata gerçekleşti!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Güncelleme işleminde emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con.Open();
                SqlCommand komut = new SqlCommand("update Clubs set clubName=@p1 where clubId=@p2", con);
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", txtId.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Güncelleme işlemi başarılı.");
                listMethod();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Günceleme işlemi iptal edildi.");
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi sırasında bir hata gerçekleşti!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
