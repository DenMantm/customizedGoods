using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CustomizedGoods.Entites;

namespace CustomizedGoods.Migrations
{
    [DbContext(typeof(ITemsProjectDbContext))]
    [Migration("20161103163443_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PluralApp.Entites.ItemModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("item_color");

                    b.Property<string>("item_model_json");

                    b.Property<string>("item_owner");

                    b.Property<string>("item_type");

                    b.Property<bool>("item_view_allowed");

                    b.HasKey("id");

                    b.ToTable("ItemModels");
                });
        }
    }
}
