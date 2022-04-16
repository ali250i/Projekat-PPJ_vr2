using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projekat_PPJ
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        String kupID = Form1.kupacID;
        String konekStr = Form1.konekcioniString;

        public void prikaziNarudzbe()
        {
            try
            {
                String query = "SELECT narudzbenica_id,datum_narudzbe" +
                        " FROM narudzbenica n WHERE kupac_id='" + kupID + "';";
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
                dataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPrikaz_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "SELECT stavka_id, naziv_artikla, cijena, kolicina" +
                        " FROM stavka_narudzbenice sn,artikal a" +
                        " WHERE sn.artikal_id=a.artikal_id" +
                        " AND narudzbenica_id='" + textBoxId.Text + "';";
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);
                dataGridView2.DataSource = tabela;
                dataAdapter.Dispose();
                query = "SELECT sum(cijena*kolicina)" +
                        " FROM stavka_narudzbenice sn,artikal a" +
                        " WHERE sn.artikal_id=a.artikal_id" +
                        " AND narudzbenica_id='" + textBoxId.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                textBoxTotal.Text = reader[0].ToString();
                ModificirajGridView(dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            prikaziNarudzbe();
            ModificirajGridView(dataGridView1);
            labelKorisnickoIme.Text = Form1.ImeKorisnika;
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kreiranjeNarudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Hide();
            fr5.Show();
        }
        int narudzbenicaID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    narudzbenicaID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                textBoxId.Text = narudzbenicaID.ToString();
                buttonPrikaz.PerformClick();
            }
            catch
            {
                MessageBox.Show("Trebate odabrati polje u tabeli!");
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            this.Hide();
            fr1.Show();
        }
        private void ModificirajGridView(DataGridView dgv)
        {
            // Funckija postavlja parne redove datagridview kontrole u sivu, 
            // a neparne u bijelu boju
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows.IndexOf(dgv.Rows[i]) % 2 == 0)
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                else
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }
    }
}
