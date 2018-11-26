using quaneu.datalayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using quaneu.datalayer.Models.Image;
using quaneu.datalayer.Models.Blog;
using System.Collections.Generic;
using quaneu.datalayer.Models.Work;

namespace quaneu.datalayer
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {

        }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageCategory> ImageCategories { get; set; }
        public DbSet<Category> CategoriesImage { get; set; }
        public DbSet<WordPressTemplate> WordPressTemplates { get; set; }
        public DbSet<WordPressCategory> WordPressCategories { get; set; }
        public DbSet<WordPressTemplateCategory> WordPressTemplateCategories { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordPressTemplateCategory>().HasKey(
                table => new { table.WordPressCategoryId, table.WordPressTemplateId });

            modelBuilder.Entity<ImageCategory>().HasKey(
              table => new { table.CategoryId, table.ImageId });

            modelBuilder.Entity<BlogPost>().HasKey(
              table => new { table.BlogId, table.PostId });

            modelBuilder.Entity<Comment>(entity => {
                entity.HasIndex(c => c.ParentCommentId);
            });


            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    Name = "Image Name alt",
                    ContentType = null,
                    Url = @"Images/Templates/avada.png"
                },
                new Image
                {
                    Id = 2,
                    Name = "Image Name alt",
                    ContentType = null,
                    Url = @"Images/Templates/x-theme.png"
                },
                new Image
                {
                    Id = 3,
                    Name = "Image Name alt",
                    ContentType = null,
                    Url = @"Images/Templates/The-7-Theme.jpg"
                },
                new Image
                {
                    Id = 4,
                    Name = "Image Name alt",
                    ContentType = null,
                    Url = @"Images/Templates/be.jpg"
                },
                new Image
                {
                    Id = 5,
                    Name = "Image Name alt",
                    ContentType = null,
                    Url = @"Images/Templates/enfold.jpg"
                }, new Image
                {
                    Id = 6,
                    Name = "Image Name alt",
                    ContentType = null,
                    Url = @"Images/Blog/test.jpg"
                });

            modelBuilder.Entity<WordPressCategory>().HasData(
               new WordPressCategory
               {
                   Id = 1,
                   Category = "Restaurant"
               },
               new WordPressCategory
               {
                   Id = 2,
                   Category = "Business"
               },
               new WordPressCategory
               {
                   Id = 3,
                   Category = "Entertainment"
               },
               new WordPressCategory
               {
                   Id = 4,
                   Category = "Creativiteit"
               },
               new WordPressCategory
               {
                   Id = 5,
                   Category = "Portfolio"
               },
               new WordPressCategory
               {
                   Id = 6,
                   Category = "Blog"
               },
               new WordPressCategory
               {
                   Id = 7,
                   Category = "Dieren"
               },
               new WordPressCategory
               {
                   Id = 8,
                   Category = "WebShop"
               },
               new WordPressCategory
               {
                   Id = 9,
                   Category = "Club"
               },
               new WordPressCategory
               {
                   Id = 10,
                   Category = "School"
               },
               new WordPressCategory
               {
                   Id = 11,
                   Category = "Tech"
               },
               new WordPressCategory
               {
                   Id = 12,
                   Category = "Nieuws Site"
               });

            modelBuilder.Entity<WordPressTemplate>().HasData(
                new WordPressTemplate
                {
                    Id = 1,
                    ImageId = 1,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 2,
                    ImageId = 2,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 3,
                    ImageId = 3,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 4,
                    ImageId = 4,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 5,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 6,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 7,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 8,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                }, new WordPressTemplate
                {
                    Id = 9,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 10,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 11,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 12,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 13,
                    ImageId = 1,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 14,
                    ImageId = 2,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 15,
                    ImageId = 3,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 16,
                    ImageId = 4,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                },
                new WordPressTemplate
                {
                    Id = 17,
                    ImageId = 5,
                    Title = "The7 WordPress template",
                    CreationDate = DateTime.Now,
                    Description = "The7 features full and seamless integration with Visual Composer and Ultimate Addons!",
                }
                );

            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Category = "BELANGRIJK",
                },
                new Blog
                {
                    Id = 2,
                    Category = "WordPress",
                },
                new Blog
                {
                    Id = 3,
                    Category = "Backuppen",
                },
                new Blog
                {
                    Id = 4,
                    Category = "Updaten",
                },
                new Blog
                {
                    Id = 5,
                    Category = "Paginabuilder",
                }
                );

            modelBuilder.Entity<Post>().HasData(
               new Post
               {
                   Id = 1,
                   ImageId = 6,
                   Title = "Post Title tester test",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 2,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 3,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 4,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 5,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 6,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 7,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 8,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 9,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 10,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 11,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 12,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 13,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 14,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 15,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 16,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               },
               new Post
               {
                   Id = 17,
                   ImageId = 6,
                   Title = "The7 WordPress template",
                   CreationDate = DateTime.Now,
                   Description = "This is a description to test that shit",
                   Content = "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>"
               }
               );

            modelBuilder.Entity<Work>().HasData(
               new Work
               {
                   Id = 1,
                   Title = "BuitensteBinnen salon",
                   Description = "BuitensteBinnen gloednieuwe website description",
                   ImageId = 6,
                   URL = "buitenstebinnen.nl"
               },
               new Work
               {
                   Id = 2,
                   Title = "BuitensteBinnen salon",
                   Description = "BuitensteBinnen gloednieuwe website description",
                   ImageId = 6,
                   URL = "diss-online.nl"
               },
               new Work
               {
                   Id = 3,
                   Title = "BuitensteBinnen salon",
                   Description = "BuitensteBinnen gloednieuwe website description",
                   ImageId = 6,
                   URL = "buitenstebinnen.nl"
               },
               new Work
               {
                   Id = 4,
                   Title = "BuitensteBinnen salon",
                   Description = "BuitensteBinnen gloednieuwe website description",
                   ImageId = 6,
                   URL = "buitenstebinnen.nl"
               });

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1,
                    PostId = 1,
                    AddDate = DateTime.Now,
                    CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    UpVotes = new Random().Next(1, 100),
                    DownVotes = new Random().Next(1, 100),
                    ParentCommentId = 0
                },
                new Comment
                {
                    CommentId = 2,
                    PostId = 1,
                    AddDate = DateTime.Now,
                    CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    UpVotes = new Random().Next(1, 100),
                    DownVotes = new Random().Next(1, 100),
                    ParentCommentId = 0
                },
                new Comment
                {
                    CommentId = 3,
                    PostId = 1,
                    AddDate = DateTime.Now,
                    CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    UpVotes = new Random().Next(1, 100),
                    DownVotes = new Random().Next(1, 100),
                    ParentCommentId = 2
                },
                new Comment
                {
                    CommentId = 4,
                    PostId = 1,
                    AddDate = DateTime.Now,
                    CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    UpVotes = new Random().Next(1, 100),
                    DownVotes = new Random().Next(1, 100),
                    ParentCommentId = 0
                },
                new Comment
                {
                    CommentId = 5,
                    PostId = 1,
                    AddDate = DateTime.Now,
                    CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    UpVotes = new Random().Next(1, 100),
                    DownVotes = new Random().Next(1, 100),
                    ParentCommentId = 0
                }
                );

            modelBuilder.Entity<WordPressTemplateCategory>().HasData(
                new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 1
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 2
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 3
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 4
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 5
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 6
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 7
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 8
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 9
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 10
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 11
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 12
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 13
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 14
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 15
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 16
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 1,
                    WordPressTemplateId = 17
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 2,
                    WordPressTemplateId = 3
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 3,
                    WordPressTemplateId = 6
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 3,
                    WordPressTemplateId = 9
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 3,
                    WordPressTemplateId = 12
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 3,
                    WordPressTemplateId = 15
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 4,
                    WordPressTemplateId = 15
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 4,
                    WordPressTemplateId = 16
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 4,
                    WordPressTemplateId = 17
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 5,
                    WordPressTemplateId = 8
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 5,
                    WordPressTemplateId = 9
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 5,
                    WordPressTemplateId = 10
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 5,
                    WordPressTemplateId = 11
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 6,
                    WordPressTemplateId = 5
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 7,
                    WordPressTemplateId = 13
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 8,
                    WordPressTemplateId = 4
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 9,
                    WordPressTemplateId = 11
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 9,
                    WordPressTemplateId = 13
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 9,
                    WordPressTemplateId = 14
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 3
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 4
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 5
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 7
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 8
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 15
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 16
                }, new WordPressTemplateCategory
                {
                    WordPressCategoryId = 12,
                    WordPressTemplateId = 17
                }
               );

            modelBuilder.Entity<BlogPost>().HasData(
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 1
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 2
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 3
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 4
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 5
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 6
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 7
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 8
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 9
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 10
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 11
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 12
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 13
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 14
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 15
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 16
               },
               new BlogPost
               {
                   BlogId = 1,
                   PostId = 17
               },
               new BlogPost
               {
                   BlogId = 2,
                   PostId = 1
               },
               new BlogPost
               {
                   BlogId = 2,
                   PostId = 8
               },
               new BlogPost
               {
                   BlogId = 2,
                   PostId = 7
               },
               new BlogPost
               {
                   BlogId = 2,
                   PostId = 6
               },
               new BlogPost
               {
                   BlogId = 3,
                   PostId = 4
               }, new BlogPost
               {
                   BlogId = 3,
                   PostId = 8
               }, new BlogPost
               {
                   BlogId = 3,
                   PostId = 12
               }, new BlogPost
               {
                   BlogId = 3,
                   PostId = 16
               }, new BlogPost
               {
                   BlogId = 4,
                   PostId = 7
               }, new BlogPost
               {
                   BlogId = 5,
                   PostId = 15
               });
        }
    }
}
