using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Application.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MeasuringUnit
    {
        [EnumMember(Value = "Kilometre")]
        Kilometre = 1,

        [EnumMember(Value = "Metres")]
        Metres = 2,

        [EnumMember(Value = "Miles")]
        Miles = 3,       

        [EnumMember(Value = "Feets")]
        Feets = 4
    }
}
