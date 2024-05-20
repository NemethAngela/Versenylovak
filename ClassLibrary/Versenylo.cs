using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendVersenylovak.Models
{
    public class Versenylo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int IstalloId { get; set; }
        public string Fajta { get; set; }
        public DateTime SzuletesiDatum { get;set; }
        public int VersenyekSzama { get; set; }

        public string? IstalloNev { get; set; }  //egy helyen legyen az összes adat, ez az istallo táblából (get-hez, stb)

        public static List<Versenylo> LoadFromJson()
        {
            string jsonContent = File.ReadAllText(@"..\..\..\lovak.json");  //teljes json fájl beolvasása
            
            var options = new JsonSerializerOptions     //kis-nagybetű különbségek figyelmen kívül hagyása az osztály property-jei és a json változónevek között
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<Versenylo>>(jsonContent, options);  //Versenylo objektum listává alakítja a json text-et
        }

        public override string ToString()   //fájlba kiírás
        {
            return $"{Id},{Nev},{IstalloId},{Fajta},{SzuletesiDatum},{VersenyekSzama}";
        }

        public string PrintInfo()
        {
            return @$"Istálló neve: {IstalloNev}
Fajta: {Fajta}
Születési dátum: {SzuletesiDatum.ToString("yyyy.MM.dd.")}
Versenyek száma: {VersenyekSzama}";
        }
    }


 }
