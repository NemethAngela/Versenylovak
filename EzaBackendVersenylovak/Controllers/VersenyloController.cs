using BackendVersenylovak.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace EzaBackendVersenylovak.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersenyloController : ControllerBase
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=versenylovak";

        //�sszes versenyl� lek�rdez�se
        [HttpGet]
        public IActionResult GetVersenylovak() 
        {
            List<Versenylo> listVersenylovak = new List<Versenylo>();   //lista l�trehoz�sa modell oszt�ly alapj�n listVersenylovak n�ven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lek�rdez�s db-b�l:
            string query = "SELECT v.id, v.nev, v.istalloId, v.fajta, v.szuletesiDatum, v.versenyekSzama, i.istalloNev FROM versenylo v INNER JOIN istallo i ON v.istalloId = i.id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Am�g vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);
                int istalloId = reader.GetInt32(2);
                string fajta = reader.GetString(3);
                DateTime szuletesiDatum = reader.GetDateTime(4);
                int versenyekSzama = reader.GetInt32(5);
                string istalloNev = reader.GetString(6);    //istallo t�bl�b�l
                //oszt�ly neve:
                Versenylo versenylo = new Versenylo()
                {
                    Id = id,
                    Nev = nev,
                    IstalloId = istalloId,
                    Fajta = fajta,
                    SzuletesiDatum = szuletesiDatum,
                    VersenyekSzama = versenyekSzama,
                    IstalloNev = istalloNev
                };
                listVersenylovak.Add(versenylo);
            }

            connection.Close();

            return Ok(listVersenylovak);
        }

        //�j l� felv�tele
        [HttpPost]
        public IActionResult CreateVersenylo([FromBody] Versenylo versenylo)
        {
            // Ellen�rizz�k a modell �rv�nyess�g�t
            if (versenylo == null ||
                versenylo.Nev == null ||
                versenylo.IstalloId <= 0 ||
                string.IsNullOrEmpty(versenylo.Fajta) ||
                versenylo.SzuletesiDatum == null ||
                versenylo.VersenyekSzama <= 0)
            {
                return BadRequest("Hi�nyos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO versenylo (nev, istalloId, fajta, szuletesiDatum, versenyekSzama) VALUES (@nev, @istalloId, @fajta, @szuletesiDatum, @versenyekSzama)";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@nev", versenylo.Nev);
            cmd.Parameters.AddWithValue("@istalloId", versenylo.IstalloId);
            cmd.Parameters.AddWithValue("@fajta", versenylo.Fajta);
            cmd.Parameters.AddWithValue("@szuletesiDatum", versenylo.SzuletesiDatum);
            cmd.Parameters.AddWithValue("@versenyekSzama", versenylo.VersenyekSzama);

            cmd.ExecuteNonQuery();
            long insertedVersenyloId = cmd.LastInsertedId;

            connection.Close();

            return Created("id", insertedVersenyloId);
        }

        // l� m�dos�t�sa
        [HttpPut]
        public IActionResult UpdateVersenylo([FromBody] Versenylo versenylo)
        {
            // Ellen�rizz�k a modell �rv�nyess�g�t
            if (versenylo == null ||
                versenylo.Nev == null ||
                versenylo.IstalloId <= 0 ||
                string.IsNullOrEmpty(versenylo.Fajta) ||
                versenylo.SzuletesiDatum == null ||
                versenylo.VersenyekSzama <= 0)
            {
                return BadRequest("Hi�nyos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "UPDATE versenylo SET nev = @nev, istalloId = @istalloId, fajta = @fajta, szuletesiDatum = @szuletesiDatum, versenyekSzama = @versenyekSzama WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@nev", versenylo.Nev);
            cmd.Parameters.AddWithValue("@istalloId", versenylo.IstalloId);
            cmd.Parameters.AddWithValue("@fajta", versenylo.Fajta);
            cmd.Parameters.AddWithValue("@szuletesiDatum", versenylo.SzuletesiDatum);
            cmd.Parameters.AddWithValue("@versenyekSzama", versenylo.VersenyekSzama);
            cmd.Parameters.AddWithValue("@id", versenylo.Id);

            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        //l� t�rl�se
        [HttpDelete]
        public IActionResult DeleteVersenylo(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM versenylo WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 0)
                return NotFound(result);

            return Ok();
        }
    }
}
