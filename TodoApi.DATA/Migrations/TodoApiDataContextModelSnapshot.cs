// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.DATA;

namespace TodoApi.DATA.Migrations
{
    [DbContext(typeof(TodoApiDataContext))]
    partial class TodoApiDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TodoApi.DATA.Entities.TodoList", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateofJob")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserInfoUserId")
                        .HasColumnType("integer");

                    b.HasKey("TodoId");

                    b.HasIndex("UserInfoUserId");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("TodoApi.DATA.Entities.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("TodoApi.DATA.Entities.TodoList", b =>
                {
                    b.HasOne("TodoApi.DATA.Entities.UserInfo", "UserInfo")
                        .WithMany("TodoLists")
                        .HasForeignKey("UserInfoUserId");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("TodoApi.DATA.Entities.UserInfo", b =>
                {
                    b.Navigation("TodoLists");
                });
#pragma warning restore 612, 618
        }
    }
}
