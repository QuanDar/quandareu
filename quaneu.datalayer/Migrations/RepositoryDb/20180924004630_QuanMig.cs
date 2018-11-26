using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace quaneu.datalayer.Migrations.RepositoryDb
{
    public partial class QuanMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordPressCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordPressCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageCategories",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCategories", x => new { x.CategoryId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ImageCategories_CategoriesImage_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageCategories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Content = table.Column<string>(maxLength: 2147483647, nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 255, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsCommented = table.Column<bool>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    NumberOfViews = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    NumberOfLikes = table.Column<int>(nullable: false),
                    NumberOfComments = table.Column<int>(nullable: false),
                    NumberOfDislikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordPressTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordPressTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordPressTemplates_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => new { x.BlogId, x.PostId });
                    table.ForeignKey(
                        name: "FK_BlogPost_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    CommentText = table.Column<string>(nullable: false),
                    UpVotes = table.Column<int>(nullable: false),
                    DownVotes = table.Column<int>(nullable: false),
                    ParentCommentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WordPressTemplateCategories",
                columns: table => new
                {
                    WordPressCategoryId = table.Column<int>(nullable: false),
                    WordPressTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordPressTemplateCategories", x => new { x.WordPressCategoryId, x.WordPressTemplateId });
                    table.ForeignKey(
                        name: "FK_WordPressTemplateCategories_WordPressCategories_WordPressCategoryId",
                        column: x => x.WordPressCategoryId,
                        principalTable: "WordPressCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordPressTemplateCategories_WordPressTemplates_WordPressTemplateId",
                        column: x => x.WordPressTemplateId,
                        principalTable: "WordPressTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "BELANGRIJK" },
                    { 2, "WordPress" },
                    { 3, "Backuppen" },
                    { 4, "Updaten" },
                    { 5, "Paginabuilder" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ContentType", "Height", "Name", "Url", "Width" },
                values: new object[,]
                {
                    { 1, null, 0, "Image Name alt", "Images/Templates/avada.png", 0 },
                    { 2, null, 0, "Image Name alt", "Images/Templates/x-theme.png", 0 },
                    { 3, null, 0, "Image Name alt", "Images/Templates/The-7-Theme.jpg", 0 },
                    { 4, null, 0, "Image Name alt", "Images/Templates/be.jpg", 0 },
                    { 5, null, 0, "Image Name alt", "Images/Templates/enfold.jpg", 0 },
                    { 6, null, 0, "Image Name alt", "Images/Blog/test.jpg", 0 }
                });

            migrationBuilder.InsertData(
                table: "WordPressCategories",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 10, "School" },
                    { 9, "Club" },
                    { 8, "WebShop" },
                    { 7, "Dieren" },
                    { 6, "Blog" },
                    { 1, "Restaurant" },
                    { 4, "Creativiteit" },
                    { 3, "Entertainment" },
                    { 2, "Business" },
                    { 11, "Tech" },
                    { 5, "Portfolio" },
                    { 12, "Nieuws Site" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Action", "Content", "Controller", "CreationDate", "Description", "ImageId", "IsCommented", "IsPrivate", "IsShared", "MetaDescription", "MetaKeywords", "NumberOfComments", "NumberOfDislikes", "NumberOfLikes", "NumberOfViews", "Title", "UpdateDate", "Url" },
                values: new object[,]
                {
                    { 2, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4580), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 4, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4613), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 5, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4619), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 6, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4625), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 7, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4628), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 8, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4634), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 9, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4640), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 3, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4607), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 10, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4643), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 12, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4655), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 13, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4658), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 14, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4664), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 15, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4670), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 16, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4673), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 17, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4679), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 11, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(4649), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "The7 WordPress template", null, null },
                    { 1, null, "<div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>  </div></div><div class='row'>  <div class='row d-flex align-items-center'>    <div class='col-md-8'>      <p style='font-size: 1.5rem;'>        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis        aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.      </p>    </div>    <div class='col-md-4'>      <img class='img-fluid' src='../../../../../assets/images/P1030094.JPG'>    </div>  </div></div>", null, new DateTime(2018, 9, 24, 2, 46, 29, 823, DateTimeKind.Local).AddTicks(2404), "This is a description to test that shit", 6, false, false, false, null, null, 0, 0, 0, 0, "Post Title tester test", null, null }
                });

            migrationBuilder.InsertData(
                table: "WordPressTemplates",
                columns: new[] { "Id", "CreationDate", "Description", "ImageId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 24, 2, 46, 29, 814, DateTimeKind.Local).AddTicks(587), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 1, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5750), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 4, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5657), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 2, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5741), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 2, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5684), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 3, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5744), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 3, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5690), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 4, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5757), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5735), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 1, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5693), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5705), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5711), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5714), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5720), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5726), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5729), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2018, 9, 24, 2, 46, 29, 822, DateTimeKind.Local).AddTicks(5699), "The7 features full and seamless integration with Visual Composer and Ultimate Addons!", 5, "The7 WordPress template", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Description", "ImageId", "PostId", "Title", "URL" },
                values: new object[,]
                {
                    { 2, "BuitensteBinnen gloednieuwe website description", 6, null, "BuitensteBinnen salon", "diss-online.nl" },
                    { 3, "BuitensteBinnen gloednieuwe website description", 6, null, "BuitensteBinnen salon", "buitenstebinnen.nl" },
                    { 1, "BuitensteBinnen gloednieuwe website description", 6, null, "BuitensteBinnen salon", "buitenstebinnen.nl" },
                    { 4, "BuitensteBinnen gloednieuwe website description", 6, null, "BuitensteBinnen salon", "buitenstebinnen.nl" }
                });

            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "BlogId", "PostId" },
                values: new object[,]
                {
                    { 1, 17 },
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 4, 7 },
                    { 1, 8 },
                    { 1, 6 },
                    { 3, 8 },
                    { 1, 16 },
                    { 5, 15 },
                    { 2, 8 },
                    { 1, 15 },
                    { 1, 14 },
                    { 1, 13 },
                    { 3, 16 },
                    { 1, 12 },
                    { 1, 11 },
                    { 1, 10 },
                    { 1, 9 },
                    { 3, 12 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AddDate", "CommentText", "DownVotes", "ParentCommentId", "PostId", "UpVotes", "UserName" },
                values: new object[,]
                {
                    { 5, new DateTime(2018, 9, 24, 2, 46, 29, 824, DateTimeKind.Local).AddTicks(6058), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 58, 0, 1, 21, null },
                    { 3, new DateTime(2018, 9, 24, 2, 46, 29, 824, DateTimeKind.Local).AddTicks(5919), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 56, 2, 1, 62, null },
                    { 2, new DateTime(2018, 9, 24, 2, 46, 29, 824, DateTimeKind.Local).AddTicks(5814), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 43, 0, 1, 66, null },
                    { 1, new DateTime(2018, 9, 24, 2, 46, 29, 824, DateTimeKind.Local).AddTicks(2211), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, 0, 1, 21, null },
                    { 4, new DateTime(2018, 9, 24, 2, 46, 29, 824, DateTimeKind.Local).AddTicks(5989), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 65, 0, 1, 22, null }
                });

            migrationBuilder.InsertData(
                table: "WordPressTemplateCategories",
                columns: new[] { "WordPressCategoryId", "WordPressTemplateId" },
                values: new object[,]
                {
                    { 1, 12 },
                    { 12, 17 },
                    { 4, 17 },
                    { 1, 17 },
                    { 3, 12 },
                    { 9, 11 },
                    { 1, 11 },
                    { 8, 4 },
                    { 1, 4 },
                    { 12, 15 },
                    { 4, 15 },
                    { 3, 15 },
                    { 1, 15 },
                    { 12, 3 },
                    { 2, 3 },
                    { 1, 3 },
                    { 9, 14 },
                    { 1, 14 },
                    { 1, 2 },
                    { 9, 13 },
                    { 7, 13 },
                    { 1, 13 },
                    { 12, 4 },
                    { 5, 11 },
                    { 1, 16 },
                    { 12, 16 },
                    { 5, 10 },
                    { 1, 10 },
                    { 5, 9 },
                    { 3, 9 },
                    { 1, 9 },
                    { 12, 8 },
                    { 5, 8 },
                    { 1, 8 },
                    { 12, 7 },
                    { 1, 7 },
                    { 3, 6 },
                    { 1, 6 },
                    { 12, 5 },
                    { 6, 5 },
                    { 1, 5 },
                    { 4, 16 },
                    { 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_PostId",
                table: "BlogPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCategories_ImageId",
                table: "ImageCategories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImageId",
                table: "Posts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WordPressTemplateCategories_WordPressTemplateId",
                table: "WordPressTemplateCategories",
                column: "WordPressTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WordPressTemplates_ImageId",
                table: "WordPressTemplates",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ImageId",
                table: "Works",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_PostId",
                table: "Works",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ImageCategories");

            migrationBuilder.DropTable(
                name: "WordPressTemplateCategories");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CategoriesImage");

            migrationBuilder.DropTable(
                name: "WordPressCategories");

            migrationBuilder.DropTable(
                name: "WordPressTemplates");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
