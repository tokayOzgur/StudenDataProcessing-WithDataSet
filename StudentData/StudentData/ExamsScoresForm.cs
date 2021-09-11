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
    public partial class ExamsScoresForm : Form
    {
        public ExamsScoresForm()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.ScoresTableAdapter ds = new DataSet1TableAdapters.ScoresTableAdapter();
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;");

        private void ExamsScoresForm_Load(object sender, EventArgs e)
        {
            // Ders isimlerini combobox'a çekme
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Lessons", con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbDers.DisplayMember = "lessName";
            cmbDers.ValueMember = "lessId";
            cmbDers.DataSource = dataTable;
            con.Close();
            //--
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TeachersForm frm = new TeachersForm();
            frm.Show();
            this.Hide();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.GetScoreList(Convert.ToInt32(txtId.Text));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtSinav1.Text = "";
            txtSinav2.Text = "";
            txtSinav3.Text = "";
            txtProje.Text = "";
            txtOrtalama.Text = "";
            txtDurum.Text = "";
        }

        int notId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            cmbDers.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            string gelenDeger = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

            txtDurum.Text = gelenDeger == "True" ? "Geçti" : "Kaldı";
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;

            sinav1 = Convert.ToInt32(txtSinav1.Text);
            sinav2 = Convert.ToInt32(txtSinav2.Text);
            sinav3 = Convert.ToInt32(txtSinav3.Text);
            proje = Convert.ToInt32(txtProje.Text);
            ortalama = (double)(sinav1 + sinav2 + sinav3 + proje) / 4;
            txtOrtalama.Text = ortalama.ToString();

            txtDurum.Text = ortalama > 49 ? "Geçti" : "Kaldı";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProje.Text) && string.IsNullOrEmpty(txtDurum.Text) && string.IsNullOrEmpty(txtOrtalama.Text) && string.IsNullOrEmpty(txtSinav1.Text) && string.IsNullOrEmpty(txtSinav2.Text) && string.IsNullOrEmpty(txtSinav3.Text))
            {
                MessageBox.Show("Ortalamayı etkiliyen değerleri eksiksikz giriniz ve öncelikle Hesaplama işlemini gerçekleştiriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool durum = txtDurum.Text == "Geçti" ? true : false;

                ds.UpdateScore(byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), durum, int.Parse(txtId.Text), notId);

                dataGridView1.DataSource = ds.GetScoreList(Convert.ToInt32(txtId.Text));
            }

        }
    }
}
