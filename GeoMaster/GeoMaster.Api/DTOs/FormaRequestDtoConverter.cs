using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using GeoMaster.Domain.Entities;

namespace GeoMaster.Api.DTOs
{
    public class FormaRequestDtoConverter : JsonConverter<FormaRequestDto>
    {
        public override FormaRequestDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonDoc = JsonDocument.ParseValue(ref reader);
            var root = jsonDoc.RootElement;
            var dto = new FormaRequestDto();
            if (root.TryGetProperty("tipo", out var tipoProp))
                dto.Tipo = tipoProp.GetString() ?? string.Empty;
            if (root.TryGetProperty("raio", out var raioProp))
                dto.Raio = raioProp.GetDouble();
            if (root.TryGetProperty("largura", out var larguraProp))
                dto.Largura = larguraProp.GetDouble();
            if (root.TryGetProperty("altura", out var alturaProp))
                dto.Altura = alturaProp.GetDouble();
            return dto;
        }

        public override void Write(Utf8JsonWriter writer, FormaRequestDto value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("tipo", value.Tipo);
            if (value.Raio.HasValue)
                writer.WriteNumber("raio", value.Raio.Value);
            if (value.Largura.HasValue)
                writer.WriteNumber("largura", value.Largura.Value);
            if (value.Altura.HasValue)
                writer.WriteNumber("altura", value.Altura.Value);
            writer.WriteEndObject();
        }

        
    }
}
