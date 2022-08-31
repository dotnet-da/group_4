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
                Entries = new HashSet<Entry>();
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public virtual ICollection<Entry> Entries { get; set; }
        }

        public partial class Entry
        {
            public int Id { get; set; }
            public int TypeId { get; set; }
            public int PlayerId { get; set; }
            public int? Value { get; set; }

            public virtual Player PlayerNavigation { get; set; }
            public virtual Type TypeNavigation { get; set; }
        }

        public partial class Type
        {
            public Type()
            {
                Entries = new HashSet<Entry>();
            }

            public int Id { get; set; }
            public string Identifier { get; set; }

            public virtual ICollection<Entry> Entries { get; set; }
        }
    }
}