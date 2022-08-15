using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Application.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MeasuringUnit
    {
        [EnumMember(Value = "Kilometres")]
        Kilometres,

        [EnumMember(Value = "Metres")]
        Metres,

        [EnumMember(Value = "Miles")]
        Miles,       

        [EnumMember(Value = "Feets")]
        Feets
    }
}
