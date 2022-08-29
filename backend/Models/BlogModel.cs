using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MySql.EntityFrameworkCore.DataAnnotations;

namespace backend.Models
{
    public class BlogModel
    {
        [Table("blog_posts")]
        public class Post
        {
            [Column("id"), Key]
            public int ID { get; set; }
            
            [Column("title")]
            public string Title { get; set; }
            
            [Column("content")]
            public string Content { get; set; }
 
            [Column("author"), JsonPropertyName("author")]
            public int AuthorID { get; set; }
            
            [NotMapped, JsonIgnore]
            public virtual User Author { get; set; }
        }
        
        [Table("blog_users")]
        public class User
        {
            [Column("id")]
            public int ID { get; set; }
            
            [Column("name")]
            public string Name { get; set; }

            [NotMapped, JsonIgnore]
            public virtual ICollection<Post> Posts { get; set; }
        }
    }
}