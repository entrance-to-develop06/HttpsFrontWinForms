using System.Text.Json.Serialization;

namespace HttpsFrontWinForms.Model.AppService.Dto
{
    /// <summary>JSONデータ格納クラス</summary>
    /// <remarks></remarks>
    public class ShohinDto
    {
        [JsonPropertyName("uniqueId")]
        public string UniqueId { get; set; }

        [JsonPropertyName("shohinCode")]
        public short ShohinCode { get; set; }

        [JsonPropertyName("shohinName")]
        public string? ShohinName { get; set; }

        [JsonPropertyName("editDate")]
        public decimal EditDate { get; set; }

        [JsonPropertyName("editTime")]
        public decimal EditTime { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }
    }
}