using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendVersenylovak.Models
{
    public class Istallo
    {
        public int Id { get; set; }
        public string Istallonev { get; set; }

        public static List<Istallo> LoadFromJson()
        {
            string jsonContent = File.ReadAllText(@"..\..\..\istallok.json");  //teljes text fájl beolvasása

            var options = new JsonSerializerOptions     //kis-nagybetű különbségek figyelmen kívül hagyása az osztály property-jei és a json változónevek között
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<Istallo>>(jsonContent, options);  //Versenylo objektum listává alakítja a json text-et
        }
    }
}
