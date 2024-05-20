
using BackendVersenylovak.Models;
using MySqlConnector;

var lovak = Versenylo.LoadFromJson(); //meghívom
var istallok = Istallo.LoadFromJson();

// Az arab lovak kiírása fájlba
var fajlNev = @"..\..\..\only_arab.txt";    //változó létrehozása
var filteredLovak = GetLovakByFajta("Arab");    //változó létrehozása, itt adom meg, mit keresek
Console.WriteLine($"Arab lovak száma: {filteredLovak.Count}");
FajlbaKiir(fajlNev, filteredLovak);

// Lovak kiírása fájlba istálló név szerint
fajlNev = @"..\..\..\lovak_istallo_szerint.txt";
var istalloId = istallok.FirstOrDefault(i => i.Istallonev == "Stacio").Id;
filteredLovak = lovak.Where(lo => lo.IstalloId == istalloId).ToList();
Console.WriteLine($"Stacio istállóban lévő lovak száma: {filteredLovak.Count}");
FajlbaKiir(fajlNev, filteredLovak);

// 2017-ben született lovak kiírása fájlba
fajlNev = @"..\..\..\2017.txt";
filteredLovak = lovak.Where(lo => lo.SzuletesiDatum.Year == 2017).ToList();
Console.WriteLine($"2017-es lovak száma: {filteredLovak.Count}");
FajlbaKiir(fajlNev, filteredLovak);

DBbeMent();


Console.WriteLine($"Összes verseny: {OsszesVersenySzam()}");


List<Versenylo> GetLovakByFajta(string fajta)   //fajta szerint leválogat és visszaadja listába
{
    return lovak.Where(lo => lo.Fajta == fajta).ToList();
}

void FajlbaKiir(string fajlNev, List<Versenylo> lovak)  //ez a függvény egy általános, több mindenre lehet benne szűrni, lásd fent
{
    var fs = File.Create(fajlNev);
    
    using (StreamWriter sw = new StreamWriter(fs))
    {
        foreach (var lo in lovak)
        {
            sw.WriteLine(lo.ToString());
        }
    }

    fs.Close();
}

int OsszesVersenySzam()
{
    return lovak.Sum(lo => lo.VersenyekSzama);
}

bool DBbeMent()
{
    try
    {
        //figyelni, hogy melyik inserttel kezdjük, a FK miatt, most a másik tábla használja az itt lévő istallonev-et
        var connectionString = @"server=localhost;user=root;password=titok;database=versenylovak";
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        string istalloInsertSql = "INSERT INTO istallo (Id, Istallonev) VALUES (@Id, @Istallonev)";
        foreach (var istallo in istallok)
        {
            MySqlCommand istalloInsert = new MySqlCommand(istalloInsertSql, connection);
            istalloInsert.Parameters.AddWithValue("@Id", istallo.Id);
            istalloInsert.Parameters.AddWithValue("@Istallonev", istallo.Istallonev);
            istalloInsert.ExecuteNonQuery();
        }

        //SQL utasítás: az insert into-nál figyelni a db paraméterek egyezésekre
        string versenyloInsertSql = "INSERT INTO versenylo (Id, Nev, IstalloId, Fajta, SzuletesiDatum, VersenyekSzama) VALUES (@Id, @Nev, @IstalloId, @Fajta, @SzuletesiDatum, @VersenyekSzama)";
        foreach (var lo in lovak)
        {
            MySqlCommand versenyloInsert = new MySqlCommand(versenyloInsertSql, connection);
            versenyloInsert.Parameters.AddWithValue("@Id", lo.Id);
            versenyloInsert.Parameters.AddWithValue("@Nev", lo.Nev);
            versenyloInsert.Parameters.AddWithValue("@IstalloId", lo.IstalloId);
            versenyloInsert.Parameters.AddWithValue("@Fajta", lo.Fajta);
            versenyloInsert.Parameters.AddWithValue("@SzuletesiDatum", lo.SzuletesiDatum);
            versenyloInsert.Parameters.AddWithValue("@VersenyekSzama", lo.VersenyekSzama);
            versenyloInsert.ExecuteNonQuery();
        }

        connection.Close();

        Console.WriteLine($"Sikeres DB-be mentés !");

        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Hiba trörtént a DB-be szúrás során: {ex.Message}");
        return false;
    }
}
