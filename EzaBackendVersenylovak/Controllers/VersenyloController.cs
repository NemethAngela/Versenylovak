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

        //összes versenyló lekérdezése
        [HttpGet]
        public IActionResult GetVersenylovak() 
        {
            List<Versenylo> listVersenylovak = new List<Versenylo>();   //lista létrehozása modell osztály alapján listVersenylovak néven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lekérdezés db-bõl:
            string query = "SELECT v.id, v.nev, v.istalloId, v.fajta, v.szuletesiDatum, v.versenyekSzama, i.istalloNev FROM versenylo v INNER JOIN istallo i ON v.istalloId = i.id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);
                int istalloId = reader.GetInt32(2);
                string fajta = reader.GetString(3);
                DateTime szuletesiDatum = reader.GetDateTime(4);
                int versenyekSzama = reader.GetInt32(5);
                string istalloNev = reader.GetString(6);    //istallo táblából
                //osztály neve:
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

        //új ló felvétele
        [HttpPost]
        public IActionResult CreateVersenylo([FromBody] Versenylo versenylo)
        {
            // Ellenõrizzük a modell érvényességét
            if (versenylo == null ||
                versenylo.Nev == null ||
                versenylo.IstalloId <= 0 ||
                string.IsNullOrEmpty(versenylo.Fajta) ||
                versenylo.SzuletesiDatum == null ||
                versenylo.VersenyekSzama <= 0)
            {
                return BadRequest("Hiányos adatok");
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

        // ló módosítása
        [HttpPut]
        public IActionResult UpdateVersenylo([FromBody] Versenylo versenylo)
        {
            // Ellenõrizzük a modell érvényességét
            if (versenylo == null ||
                versenylo.Nev == null ||
                versenylo.IstalloId <= 0 ||
                string.IsNullOrEmpty(versenylo.Fajta) ||
                versenylo.SzuletesiDatum == null ||
                versenylo.VersenyekSzama <= 0)
            {
                return BadRequest("Hiányos adatok");
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

        //ló törlése
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
