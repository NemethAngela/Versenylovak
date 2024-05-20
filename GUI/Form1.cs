using BackendVersenylovak.Models;
using EzaBackendVersenylovak.Controllers;
using MySqlConnector;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        string connectionString = "database=localhost;user=root;password=titok;database=versenylovak";
        List<Versenylo> lovak = new List<Versenylo>();  //Versenylo=modell oszt�llyal, t�bla n�vvel
        List<Istallo> istallok = new List<Istallo>();

        public Form1()
        {
            InitializeComponent();
            LovakBetoltese();
            IstallokBetoltese();
        }

        private void LovakBetoltese()   // felt�lti a lovak list�t
        {
            lovak.Clear();

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT lo.id, lo.istalloid, lo.nev, lo.fajta, lo.szuletesidatum, lo.versenyekszama, i.istallonev FROM versenylo lo 
                            INNER JOIN istallo i ON i.id = lo.istalloId ORDER BY lo.nev";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!

            while (reader.Read())   // Am�g vannak sorok a resultban
            {
                Versenylo lo = new Versenylo()
                {
                    Id = reader.GetInt32(0),
                    IstalloId = reader.GetInt32(1),
                    Nev = reader.GetString(2),
                    Fajta = reader.GetString(3),
                    SzuletesiDatum = reader.GetDateTime(4),
                    VersenyekSzama = reader.GetInt32(5),
                    IstalloNev = reader.GetString(6)
                };

                lovak.Add(lo);
            }

            listBoxLovakLista.Items.Clear();
            listBoxLovakLista.Items.AddRange(lovak.ToArray()); //felt�ltj�k a listBoxot a lovak list�val
            listBoxLovakLista.ValueMember = "Id";
            listBoxLovakLista.DisplayMember = "Nev";    //ezt jelen�ti meg a listBoxban

            connection.Close();
        }


        private void IstallokBetoltese()
        {
            istallok.Clear();

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT id, istallonev FROM istallo ORDER BY istallonev";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!

            while (reader.Read())   // Am�g vannak sorok a resultban
            {
                Istallo istallo = new Istallo()
                {
                    Id = reader.GetInt32(0),
                    Istallonev = reader.GetString(1)
                };

                istallok.Add(istallo);
            }

            comboBoxIstallok.Items.Clear();
            comboBoxIstallok.Items.AddRange(istallok.ToArray()); //felt�ltj�k a listBoxot a lovak list�val
            comboBoxIstallok.ValueMember = "Id";
            comboBoxIstallok.DisplayMember = "Istallonev";    //ezt jelen�ti meg a listBoxban

            connection.Close();
        }

        //lovak adatinak ki�r�sa a textbox-ba
        private void listBoxLovakLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Versenylo selectedLo = listBoxLovakLista.SelectedItem as Versenylo;
            textBoxInfo.Text = selectedLo.PrintInfo();
        }

        private void buttonTorles_Click(object sender, EventArgs e)
        {
            // van-e kiv�lasztott l� �s ha igen, akkor melyik
            Versenylo selectedLo = listBoxLovakLista.SelectedItem as Versenylo;
            if (selectedLo == null)
            {
                MessageBox.Show("Nincs kiv�lasztott l�");
                return;
            }

            // l� db-b�l t�rl�s
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = @"DELETE FROM versenylo WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("id", selectedLo.Id);

            cmd.ExecuteNonQuery();

            connection.Close();

            // controlok �s l� lista update
            LovakBetoltese();
            textBoxInfo.Clear();    //textbox-b�l t�rl�s
        }

        private void buttonBezar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMent_Click(object sender, EventArgs e)
        {
            // valid�ci�
            var selectedIstallo = comboBoxIstallok.SelectedItem as Istallo;
            if (selectedIstallo == null)
            {
                MessageBox.Show("Nem adt�l meg ist�ll�t!");
                return;
            }
            else if (textBoxNev.Text == "")
            {
                MessageBox.Show("Nem adt�l meg nevet!");
                return;
            }
            else if (textBoxFajta.Text == "")
            {
                MessageBox.Show("Nem adt�l meg fajt�t!");
                return;
            }
            else if (dateTimePickerSzuletett.Text == "")
            {
                MessageBox.Show("Nem adt�l meg sz�let�si d�tumot!");
                return;
            }
           
            int versenyszam;
            if (int.TryParse(textBoxVersen�szam.Text, out versenyszam) == false)
            {
                MessageBox.Show("Nem adt�l meg versenysz�mot!");
                return;
            }

            // ment�s
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = @"INSERT INTO versenylo (istalloid, nev, fajta, szuletesidatum, versenyekszama) VALUES (@istalloid, @nev, @fajta, @szuletesidatum, @versenyekszama)";
            using MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("istalloid", selectedIstallo.Id);
            cmd.Parameters.AddWithValue("nev", textBoxNev.Text);
            cmd.Parameters.AddWithValue("fajta", textBoxFajta.Text);
            cmd.Parameters.AddWithValue("szuletesidatum", dateTimePickerSzuletett.Value);
            cmd.Parameters.AddWithValue("versenyekszama", versenyszam);

            cmd.ExecuteNonQuery();

            connection.Close();

            // controlok update-je ,textboxok t�rl�se, lovak list�j�nak friss�t�se
            comboBoxIstallok.SelectedIndex = -1;
            textBoxNev.Clear();
            textBoxFajta.Clear();
            textBoxVersen�szam.Clear();
            textBoxInfo.Clear();

            LovakBetoltese();
        }
    }
}