using Kinoteatr_Web_2027.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Kinoteatr_Web_2027.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kinoteatr_Web_2027.Model.Ticket", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Title")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Viewer")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Date")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Summa")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Tickets");
            });

            modelBuilder.Entity("Kinoteatr_Web_2027.Model.Visitor", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("LastName")
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("BirthDate")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Visitors");
            });
#pragma warning restore 612, 618
        }
    }
}
