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
    public partial class StudentsForm2 : Form
    {
        public StudentsForm2()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;");
        private void StudentsForm2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();

            // Kulüp isimlerini combobox'a çekme
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Clubs", con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbKulup.DisplayMember = "clubName";
            cmbKulup.ValueMember = "clubId";
            cmbKulup.DataSource = dataTable;
            con.Close();
            //--
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TeachersForm frm = new TeachersForm();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {


            if (!checkBox1.Checked && !checkBox2.Checked || string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text))
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz doldurun!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Lütfen cinsiyet alanında tek seçim yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ss = GetSex(); ; // cinsiyet için

                ds.InsertStudent(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), ss);
                MessageBox.Show("İşlem Başarılı.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtId.Text = cmbKulup.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DeleteStudent(Convert.ToInt32(txtId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //Tıklanıldığında cinsiyeti çekme
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kadin")
            {
                checkBox2.Checked = true;
                checkBox1.Checked = false;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Erkek")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ss = GetSex();
            ds.UpdateStudent(txtAd.Text, txtSoyad.Text, Convert.ToByte(cmbKulup.SelectedValue.ToString()), ss, Convert.ToInt32(txtId.Text));

        }

        // cinsiyet methodu
        public string GetSex()
        {
            string s;
            if (checkBox1.Checked == true)
            {
                s = "Erkek";
                return s;
            }
            else if (checkBox2.Checked)
            {
                s = "Kadın";
                return s;
            }
            else
                return "";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.GetStudentInfo(txtAra.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
