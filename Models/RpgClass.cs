using System.Text.Json.Serialization;

namespace asp_net_course_udemy.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,
        Cleric,
    }
}
