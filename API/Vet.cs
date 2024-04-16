
using System.Text.Json.Serialization;
using API;

public class Vet
{
    public DateTime date { get; set; }
    public Animal animal { get; set; }
    public string opisWizyty { get; set; }
    public double cena { get; set; }

    // Atrybut [JsonIgnore] oznacza, że te właściwości nie będą serializowane
    [JsonIgnore]
    public int id { get; set; }
    [JsonIgnore]
    public string imie { get; set; }
    [JsonIgnore]
    public string kategoria { get; set; }
    [JsonIgnore]
    public double masa { get; set; }
    [JsonIgnore]
    public string kolorSiersci { get; set; }
}