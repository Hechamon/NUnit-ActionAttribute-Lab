using Newtonsoft.Json;

namespace Repository
{
    public class Rocket
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
        [JsonProperty(PropertyName = "stages")]
        public int Stages { get; private set; }

        public Rocket(string name, string description, int stages)
        {
            Name = name;
            Description = description;
            Stages = stages;
        }
    }
}
