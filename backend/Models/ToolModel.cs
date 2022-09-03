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
    ///<summary>
    ///Model (in MVC desgin pattern) for the stat Tool
    ///This class has subclasses for every table related to the stat tracking tool in the database
    ///</summary>
    public class ToolModel
    {
        ///<summary>
        /// The player of which an entry was made.
        ///</summary>
        public partial class Player
        {
            public Player()
            {
                Collections = new HashSet<Collection>();
            }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }

            [JsonIgnore]
            public virtual ICollection<Collection> Collections { get; set; }
        }

        ///<summary>
        /// A entry is a specific statistical data, related to a player, a entry-type and a entry-collection.
        /// This structure allows for easy adding and removing statistical data categorys, by just adding a new entry type.
        ///</summary>
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

        ///<summary>
        /// A Type is mandatory for an entry, because is specifies what data an entry is recording. 
        /// In a more traditional database structure this would be the column of a table which stores collections of entrys.
        /// Which this database structure, it allows us to more easily add entry-types or don't use existing ones while the system is already up and running.
        ///</summary>
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
        
        ///<summary>
        /// A collection is a set of entries all made by a specific player at a specific moment. 
        /// Every entry should be of a different EntryType (overlapping would be irrational) 
        ///</summary>
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