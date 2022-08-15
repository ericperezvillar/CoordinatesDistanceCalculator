using System.Text.Json.Serialization;

namespace DataModel.Measures
{
    public class Measure
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [JsonIgnore]
        public string Description { get; set; }
    }
}
