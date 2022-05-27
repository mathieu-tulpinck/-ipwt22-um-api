using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UuidMasterApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EntityType
    {
        ATTENDEE,
        ORGANISER,
        SESSION,
        SESSIONATTENDEE
    }
}