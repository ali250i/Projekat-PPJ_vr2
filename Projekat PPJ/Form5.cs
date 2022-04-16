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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        String kupID = Form1.kupacID;
        String konekStr = Form1.konekcioniString;
        String narID;

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            labelKorisnickoIme.Text = Form1.ImeKorisnika;
            
        }

        private void buttonKreirajNarudzbu_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                String query = "INSERT INTO narudzbenica(kupac_id, datum_narudzbe)" +
                    " VALUES('" + kupID + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "');";
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                cmd.ExecuteNonQuery();
                query = "SELECT max(narudzbenica_id) FROM narudzbenica;";
                cmd = new MySqlCommand(query, konekcija);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    narID = reader[0].ToString();
                }
                reader.Close();
                konekcija.Close();
                prikaziArtikle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void prikaziArtikle()
        {
            try
            {
                String query = "SELECT a.*, kolicina_stanje FROM artikal a, skladiste s" +
                        " WHERE a.artikal_id=s.artikal_id;";
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
                dataAdapter.Dispose();
                konekcija.Close();
                ModificirajGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void prikaziKorpu()
        {
            try
            {
                //popunjavanje korpe
                String query = "SELECT a.*, kolicina FROM artikal a, stavka_narudzbenice sn" +
                    " WHERE a.artikal_id=sn.artikal_id AND narudzbenica_id='"+narID+
                    "';";
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);
                dataGridView2.DataSource = tabela;
                dataAdapter.Dispose();

                //Query za dobijanje vrijednosti korpe
                query = "SELECT sum(cijena*kolicina) FROM artikal a, stavka_narudzbenice sn" +
                    " WHERE a.artikal_id=sn.artikal_id AND narudzbenica_id='" + narID +"';";
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                cmd = new MySqlCommand(query, konekcija);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBoxTotal.Text = reader[0].ToString();
                }
                reader.Close();
                konekcija.Close();
                ModificirajGridView(dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text == "" || textBoxKolicina.Text == "" || Convert.ToInt32(textBoxKolicina.Text) <= 0)
                {
                    MessageBox.Show("Nepravilan unos");
                }
                else
                {
                    //provjera da li zeli dodati u korpu vecu kolicinu od dostupne
                    int stanje=1<<30;
                    MySqlConnection konekcija = new MySqlConnection(konekStr);
                    konekcija.Open();
                    String query = "SELECT kolicina_stanje FROM skladiste s" +
                    " WHERE artikal_id='" + textBoxId.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, konekcija);
                    cmd = new MySqlCommand(query, konekcija);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        stanje = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                    if (Convert.ToInt32(textBoxKolicina.Text) > stanje)
                    {
                        MessageBox.Show("Nedovoljno na stanju");
                        return;
                    }

                    
                    query = "SELECT * FROM stavka_narudzbenice sn WHERE " +
                        "narudzbenica_id='" + narID + "' AND artikal_id='" + textBoxId.Text + "';";
                    
                    cmd = new MySqlCommand(query, konekcija);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (!reader.HasRows)
                    {
                        query = "INSERT INTO stavka_narudzbenice(narudzbenica_id, artikal_id, kolicina)" +
                        " VALUES('" + narID + "', '" + textBoxId.Text + "', '" + textBoxKolicina.Text + "');";
                        stanje -= Convert.ToInt32(textBoxKolicina.Text);
                    }
                    else
                    {
                        stanje += Convert.ToInt32(reader["kolicina"]) - Convert.ToInt32(textBoxKolicina.Text);
                        query = "UPDATE stavka_narudzbenice SET" +
                        " kolicina='" + textBoxKolicina.Text + "' WHERE" +
                        " narudzbenica_id='" + narID + "' AND artikal_id='" + textBoxId.Text + "';";
                    }
                    reader.Close();
                    cmd = new MySqlCommand(query, konekcija);
                    cmd.ExecuteNonQuery();

                    query = "UPDATE skladiste SET" +
                        " kolicina_stanje='" + stanje + "' WHERE" +
                        " artikal_id='" + textBoxId.Text + "';";
                    cmd = new MySqlCommand(query, konekcija);
                    cmd.ExecuteNonQuery();

                    konekcija.Close();

                    prikaziKorpu();
                    prikaziArtikle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text == "")
                {
                    MessageBox.Show("Nepravilan unos");
                }
                else
                {
                    int stanje = 0;
                    MySqlConnection konekcija = new MySqlConnection(konekStr);
                    konekcija.Open();
                    String query = "SELECT kolicina FROM stavka_narudzbenice sn" +
                    " WHERE artikal_id='" + textBoxId.Text + "' AND narudzbenica_id='"+narID+"';";
                    MySqlCommand cmd = new MySqlCommand(query, konekcija);
                    cmd = new MySqlCommand(query, konekcija);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        stanje = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();


                    query = "UPDATE skladiste SET" +
                        " kolicina_stanje=kolicina_stanje+" + stanje + " WHERE" +
                        " artikal_id='" + textBoxId.Text + "';";
                    cmd = new MySqlCommand(query, konekcija);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM stavka_narudzbenice" +
                    " WHERE artikal_id='" + textBoxId.Text + "' AND narudzbenica_id='" + narID + "';";
                    cmd = new MySqlCommand(query, konekcija);
                    cmd.ExecuteNonQuery();

                    konekcija.Close();

                    prikaziKorpu();
                    prikaziArtikle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void prikazNarudžbiIStavkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Hide();
            fr6.Show();
        }
        int artikalId;
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    artikalId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }

                textBoxId.Text = artikalId.ToString();
                textBoxKolicina.Clear();
            }
            catch
            {
                MessageBox.Show("Trebate odabrati polje u tabeli!");
            }
        }
        int stavkaID;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    stavkaID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    
                }
                textBoxId.Text = stavkaID.ToString();
                textBoxKolicina.Clear();
               
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
