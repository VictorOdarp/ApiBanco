using System.Text.Json.Serialization;

namespace ApiBanco.Enums
{
    public enum AccountType
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        Corrente,
        Poupança
    }
}
