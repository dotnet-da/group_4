using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class ToolModel
    {
        public partial class Player
        {
            public Player()
            {
                Collections = new HashSet<Collection>();
            }

            public int Id { get; set; }
            public string Name { get; set; }

            [JsonIgnore]
            public virtual ICollection<Collection> Collections { get; set; }
        }

        public partial class Entry
        {
            [JsonPropertyName("collection_id")]
            public int CollectionId { get; set; }
            
            [JsonPropertyName("type_id")]
            public int TypeId { get; set; }

            public int? Value { get; set; }

            [JsonIgnore]
            public virtual Type TypeNavigation { get; set; }
            [JsonIgnore]
            public virtual Collection CollectionNavigation { get; set; }
        }

        public partial class Type
        {
            public Type()
            {
                Entries = new HashSet<Entry>();
            }

            public int Id { get; set; }
            public string Identifier { get; set; }
            public string Description { get; set; }

            [JsonIgnore]
            public virtual ICollection<Entry> Entries { get; set; }
        }
        
        public partial class Collection
        {
            public Collection()
            {
                Entries = new HashSet<Entry>();
            }

            public int Id { get; set; }
            
            [JsonPropertyName("player_id")]
            public int PlayerId { get; set; }
            [JsonPropertyName("created_at")]
            public DateTime CreatedAt { get; set; }
            
            [JsonIgnore]
            public virtual Player PlayerNavigation { get; set; }
            
            [JsonIgnore]
            public virtual ICollection<Entry> Entries { get; set; }
        }
    }
}