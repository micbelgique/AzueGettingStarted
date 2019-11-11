using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureGettingStarted.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdultContent = table.Column<bool>(nullable: false),
                    IsRacyContent = table.Column<bool>(nullable: false),
                    AdultScore = table.Column<double>(nullable: false),
                    RacyScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DominantColorForeground = table.Column<string>(nullable: true),
                    DominantColorBackground = table.Column<string>(nullable: true),
                    AccentColor = table.Column<string>(nullable: true),
                    IsBwImg = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaceRectangle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Left = table.Column<double>(nullable: false),
                    Top = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceRectangle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClipArtType = table.Column<int>(nullable: false),
                    LineDrawingType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rectangle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    W = table.Column<int>(nullable: false),
                    H = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    DescriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caption_Description_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Description",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisionResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdultId = table.Column<int>(nullable: true),
                    ColorId = table.Column<int>(nullable: true),
                    ImageTypeId = table.Column<int>(nullable: true),
                    DescriptionId = table.Column<int>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    MetadataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisionResult_Adult_AdultId",
                        column: x => x.AdultId,
                        principalTable: "Adult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisionResult_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisionResult_Description_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Description",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisionResult_ImageType_ImageTypeId",
                        column: x => x.ImageTypeId,
                        principalTable: "ImageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisionResult_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalTable: "Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    RectangleId = table.Column<int>(nullable: true),
                    VisionResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Rectangle_RectangleId",
                        column: x => x.RectangleId,
                        principalTable: "Rectangle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brand_VisionResult_VisionResultId",
                        column: x => x.VisionResultId,
                        principalTable: "VisionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    VisionResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_VisionResult_VisionResultId",
                        column: x => x.VisionResultId,
                        principalTable: "VisionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Face",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    FaceRectangleId = table.Column<int>(nullable: true),
                    VisionResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Face", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Face_FaceRectangle_FaceRectangleId",
                        column: x => x.FaceRectangleId,
                        principalTable: "FaceRectangle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Face_VisionResult_VisionResultId",
                        column: x => x.VisionResultId,
                        principalTable: "VisionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    VisionResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_VisionResult_VisionResultId",
                        column: x => x.VisionResultId,
                        principalTable: "VisionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    VisionResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_VisionResult_VisionResultId",
                        column: x => x.VisionResultId,
                        principalTable: "VisionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Thing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RectangleId = table.Column<int>(nullable: true),
                    Object = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    VisionResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thing_Rectangle_RectangleId",
                        column: x => x.RectangleId,
                        principalTable: "Rectangle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Thing_VisionResult_VisionResultId",
                        column: x => x.VisionResultId,
                        principalTable: "VisionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_RectangleId",
                table: "Brand",
                column: "RectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_VisionResultId",
                table: "Brand",
                column: "VisionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Caption_DescriptionId",
                table: "Caption",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_VisionResultId",
                table: "Category",
                column: "VisionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Face_FaceRectangleId",
                table: "Face",
                column: "FaceRectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Face_VisionResultId",
                table: "Face",
                column: "VisionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_VisionResultId",
                table: "Images",
                column: "VisionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_VisionResultId",
                table: "Tag",
                column: "VisionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Thing_RectangleId",
                table: "Thing",
                column: "RectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Thing_VisionResultId",
                table: "Thing",
                column: "VisionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_VisionResult_AdultId",
                table: "VisionResult",
                column: "AdultId");

            migrationBuilder.CreateIndex(
                name: "IX_VisionResult_ColorId",
                table: "VisionResult",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisionResult_DescriptionId",
                table: "VisionResult",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_VisionResult_ImageTypeId",
                table: "VisionResult",
                column: "ImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VisionResult_MetadataId",
                table: "VisionResult",
                column: "MetadataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Caption");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Face");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Thing");

            migrationBuilder.DropTable(
                name: "FaceRectangle");

            migrationBuilder.DropTable(
                name: "Rectangle");

            migrationBuilder.DropTable(
                name: "VisionResult");

            migrationBuilder.DropTable(
                name: "Adult");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropTable(
                name: "Metadata");
        }
    }
}
