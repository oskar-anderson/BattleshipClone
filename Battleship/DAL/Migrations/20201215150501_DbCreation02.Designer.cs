// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201215150501_DbCreation02")]
    partial class DbCreation02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.DbGameData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("ActivePlayerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("AllowedPlacementType")
                        .HasColumnType("int");

                    b.Property<string>("BoardDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrameCount")
                        .HasColumnType("int");

                    b.Property<string>("InactivePlayerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipSizesDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpritesDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ActivePlayerID");

                    b.HasIndex("InactivePlayerID");

                    b.ToTable("GameData");
                });

            modelBuilder.Entity("DAL.DbPlayer", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("BoardBoundsDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHorizontalPlacement")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerType")
                        .HasColumnType("int");

                    b.Property<int>("ShipBeingPlacedIdx")
                        .HasColumnType("int");

                    b.Property<string>("ShipsDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShootingHistoryDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpriteDbFriendly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("fCameraPixelPosX")
                        .HasColumnType("real");

                    b.Property<float>("fCameraPixelPosY")
                        .HasColumnType("real");

                    b.Property<float>("fCameraScaleX")
                        .HasColumnType("real");

                    b.Property<float>("fCameraScaleY")
                        .HasColumnType("real");

                    b.Property<float>("fMouseSelectedTileX")
                        .HasColumnType("real");

                    b.Property<float>("fMouseSelectedTileY")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("DAL.DbGameData", b =>
                {
                    b.HasOne("DAL.DbPlayer", "ActivePlayer")
                        .WithMany()
                        .HasForeignKey("ActivePlayerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.DbPlayer", "InactivePlayer")
                        .WithMany()
                        .HasForeignKey("InactivePlayerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
