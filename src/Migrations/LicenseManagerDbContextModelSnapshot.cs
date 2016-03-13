using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using LicenseManager.Database;

namespace src.Migrations
{
    [DbContext(typeof(LicenseManagerDbContext))]
    partial class LicenseManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LicenseManager.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Clients");
                });

            modelBuilder.Entity("LicenseManager.Models.License", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<Guid>("LicenseTemplateId");

                    b.Property<int>("Number");

                    b.Property<Guid>("ProductId");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime?>("ValidTo");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Licenses");
                });

            modelBuilder.Entity("LicenseManager.Models.LicenseElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<Guid?>("LicenseId");

                    b.Property<Guid>("LicenseTemplateElementId");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "LicenseElements");
                });

            modelBuilder.Entity("LicenseManager.Models.LicenseTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("SystemVersionId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "LicenseTemplates");
                });

            modelBuilder.Entity("LicenseManager.Models.LicenseTemplateElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<int>("Level");

                    b.Property<Guid>("LicenseTemplateId");

                    b.Property<string>("Mnemonic")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "LicenseTemplateElements");
                });

            modelBuilder.Entity("LicenseManager.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<Guid>("SystemVersionId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Products");
                });

            modelBuilder.Entity("LicenseManager.Models.System", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Systems");
                });

            modelBuilder.Entity("LicenseManager.Models.SystemVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<int>("Major");

                    b.Property<int>("Minor");

                    b.Property<Guid>("SystemId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "SystemVersions");
                });

            modelBuilder.Entity("LicenseManager.Models.License", b =>
                {
                    b.HasOne("LicenseManager.Models.LicenseTemplate")
                        .WithMany()
                        .HasForeignKey("LicenseTemplateId");

                    b.HasOne("LicenseManager.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("LicenseManager.Models.LicenseElement", b =>
                {
                    b.HasOne("LicenseManager.Models.License")
                        .WithMany()
                        .HasForeignKey("LicenseId");

                    b.HasOne("LicenseManager.Models.LicenseTemplateElement")
                        .WithMany()
                        .HasForeignKey("LicenseTemplateElementId");

                    b.HasOne("LicenseManager.Models.LicenseElement")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("LicenseManager.Models.LicenseTemplate", b =>
                {
                    b.HasOne("LicenseManager.Models.SystemVersion")
                        .WithMany()
                        .HasForeignKey("SystemVersionId");
                });

            modelBuilder.Entity("LicenseManager.Models.LicenseTemplateElement", b =>
                {
                    b.HasOne("LicenseManager.Models.LicenseTemplate")
                        .WithMany()
                        .HasForeignKey("LicenseTemplateId");

                    b.HasOne("LicenseManager.Models.LicenseTemplateElement")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("LicenseManager.Models.Product", b =>
                {
                    b.HasOne("LicenseManager.Models.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("LicenseManager.Models.SystemVersion")
                        .WithMany()
                        .HasForeignKey("SystemVersionId");
                });

            modelBuilder.Entity("LicenseManager.Models.SystemVersion", b =>
                {
                    b.HasOne("LicenseManager.Models.System")
                        .WithMany()
                        .HasForeignKey("SystemId");
                });
        }
    }
}
