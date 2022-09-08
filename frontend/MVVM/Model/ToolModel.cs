using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WpfApp4.Core;

namespace frontend.MVVM.Model;

public class ToolModel
{
    public partial class Player : ObservableObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public partial class Entry
    {
        [JsonPropertyName("collection_id")]
        public int CollectionId { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        [JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public partial class Type
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("identfier")]
        public string Identifier { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }


    }

    public partial class Collection
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("player_id")]
        public int PlayerId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}