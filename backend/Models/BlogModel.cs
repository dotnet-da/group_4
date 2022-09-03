using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MySql.EntityFrameworkCore.DataAnnotations;

namespace backend.Models
{
    ///<summary>
    /// This class stores subclasses related to the Blog-section of the database
    ///</summary>
    public class BlogModel
    {
        ///<summary>
        /// This class represents a blog post on the database. 
        /// It consists of a title and a content, and is also linked to an author, which is a user
        ///</summary>
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
        
        ///<summary>
        /// This class represents a user on the database. 
        /// It consist of a name and every Post it created
        ///</summary>
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