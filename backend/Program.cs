using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            CreateHostBuilder(args).Build().Run();
        }
        
        private static void InsertData()
        {
            using(var context = new BlogContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var publisher = new BlogModel.User()
                {
                    Name = "Oktay"
                };
                context.Users.Add(publisher);

                // Adds some books
                context.Posts.Add(new BlogModel.Post()
                {
                    Title = "Titel",
                    Content = "Inhalt",
                    Author = publisher
                });
                context.Posts.Add(new BlogModel.Post()
                {
                    Title = "Titel 2",
                    Content = "Inhalt 2",
                    Author = publisher
                });

                // Saves changes
                context.SaveChanges();
            }
        }
        
        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new BlogContext())
            {
                try
                {
                    var users = context.Users.Include(u => u.Posts);
                    var posts = context.Posts;

                    foreach (var user in users)
                    {
                        var data = new StringBuilder();
                        data.AppendLine($"ID: {user.ID}");
                        data.AppendLine($"Name: {user.Name}");
                        data.AppendLine($"PostCount: {user.Posts.Count}");
                        Console.WriteLine(data.ToString());
                    }
                    
                    foreach (var post in posts)
                    {
                        var data = new StringBuilder();
                        data.AppendLine($"ID: {post.ID}");
                        data.AppendLine($"Title: {post.Title}");
                        data.AppendLine($"Content: {post.Content}");
                        data.AppendLine($"Author.Name: {post.Author.Name}");
                        Console.WriteLine(data.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                /*foreach(var book in books)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ISBN: {book.ID}");
                    data.AppendLine($"Title: {book.Title}");
                    data.AppendLine($"Content: {book.Content}");
                    data.AppendLine($"Publisher: {book.Author.Name}");
                    Console.WriteLine(data.ToString());
                }*/
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}