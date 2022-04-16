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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        String kupID = Form1.kupacID;
        String konekStr = Form1.konekcioniString;

        private void buttonKreiranjeKupca_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "INSERT INTO kupac(ime,prezime,grad,adresa,telefon,user,pass)" +
                    " VALUES('";
                if (textBoxIme.Text == "" || textBoxPrezime.Text == "" || textBoxGrad.Text == "" ||
                    textBoxAdresa.Text == "" || textBoxTelefon.Text == "" || textBoxKorisničkoIme.Text=="" || textBoxSifra.Text == "")
                {
                    MessageBox.Show("Nisu popunjena sva polja");
                }
                else
                {
                    query += textBoxIme.Text + "', '" + textBoxPrezime.Text + "', '" + textBoxGrad.Text + "', '" +
                        textBoxAdresa.Text + "', '" + textBoxTelefon.Text + "', '" +
                        textBoxKorisničkoIme.Text + "', '" + textBoxSifra.Text + "'); ";
                    MessageBox.Show(query);
                    MySqlConnection konekcija = new MySqlConnection(konekStr);
                    konekcija.Open();
                    MySqlCommand cmd = new MySqlCommand(query, konekcija);
                    cmd.ExecuteNonQuery();
                    buttonTrazi.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonTrazi_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "SELECT *" +
                    " FROM kupac " +
                    " WHERE kupac_id IS NOT NULL";
                if (textBoxPretragaIme.Text != "")
                {
                    query += " AND ime LIKE '%" + textBoxPretragaIme.Text + "%' ";
                }
                if (textBoxPretragaPrezime.Text != "")
                {
                    query += " AND prezime LIKE '%" + textBoxPretragaPrezime.Text + "%' ";
                }
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
                dataAdapter.Dispose();
                ModificirajGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonTrazi.PerformClick();
        }

        private void buttonAzuriranjeKupca_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "UPDATE kupac SET ";
                if (textBoxIme.Text != "")
                {
                    query += "ime='"+textBoxIme.Text + "',";
                }
                if (textBoxPrezime.Text != "")
                {
                    query += "prezime='" + textBoxPrezime.Text + "',";
                }
                if(textBoxGrad.Text != "")
                {
                    query += "grad='" + textBoxGrad.Text + "',";
                }
                if(textBoxAdresa.Text != "")
                {
                    query += "adresa='" + textBoxAdresa.Text + "',";
                }
                if(textBoxTelefon.Text != "")
                {
                    query += "telefon='" + textBoxTelefon.Text + "',";
                }
                if(textBoxKorisničkoIme.Text != "")
                {
                    query += "user='" + textBoxKorisničkoIme.Text + "',";
                }
                if(textBoxSifra.Text != "")
                {
                    query += "pass='" + textBoxSifra.Text + "',";
                }
                if(query[query.Length-1]==',') query=query.Substring(0,query.Length-1);
                query += " WHERE kupac_id='" + id.ToString() + "';";
                MessageBox.Show(query);
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                cmd.ExecuteNonQuery();
                buttonTrazi.PerformClick();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dodavanjeAžuriranjeArtiklaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Hide();
            fr3.Show();
        }

        private void prikazBrisanjeNarudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Hide();
            fr4.Show();
        }
        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Odaberite polje unutar tabele!");
            }

            string upit = "SELECT ime, prezime, grad, adresa, telefon, user, pass FROM kupac WHERE kupac_ID='" + id + "'";

            try
            {
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(upit, konekcija);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                reader.Read();

                String ime = reader[0].ToString();
                String prezime = reader[1].ToString();
                String grad = reader[2].ToString();
                String adresa = reader[3].ToString();
                String telefon = reader[4].ToString();
                String username = reader[5].ToString();
                String password = reader[6].ToString();


                textBoxIme.Text = ime;
                textBoxPrezime.Text = prezime;
                textBoxGrad.Text = grad;
                textBoxTelefon.Text = telefon;
                textBoxAdresa.Text = adresa;
                textBoxKorisničkoIme.Text = username;
                textBoxSifra.Text = password;

                reader.Close();
                konekcija.Close();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message);
            }
        }

        private void buttonObrisiKupca_Click(object sender, EventArgs e)
        {
            try
            {

                String upit = "DELETE FROM kupac WHERE kupac_id='" + id + "';";

                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(upit, konekcija);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Uspješno ste obrisali kupca!!!");
                konekcija.Close();


                buttonTrazi.PerformClick();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message);
            }
        }

        private void buttonOsvjezi_Click(object sender, EventArgs e)
        {
            textBoxIme.Clear();
            textBoxPrezime.Clear();
            textBoxGrad.Clear();
            textBoxTelefon.Clear();
            textBoxAdresa.Clear();
            textBoxKorisničkoIme.Clear();
            textBoxSifra.Clear();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr1=new Form1();
            this.Hide();
            fr1.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void label10_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
