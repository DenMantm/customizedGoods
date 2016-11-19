using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CustomizedGoods.Entites;

namespace CustomizedGoods.Migrations
{
    [DbContext(typeof(ITemsProjectDbContext))]
    partial class ITemsProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PluralApp.Entites.CountersModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cup");

                    b.Property<int>("hat");

                    b.Property<int>("tshirt");

                    b.HasKey("id");

                    b.ToTable("ItemCounters");
                });

            modelBuilder.Entity("PluralApp.Entites.ItemModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("id_in_category");

                    b.Property<string>("item_color");

                    b.Property<string>("item_description");

                    b.Property<string>("item_model_json");

                    b.Property<string>("item_owner");

                    b.Property<double>("item_price");

                    b.Property<string>("item_type");

                    b.Property<bool>("item_view_allowed");

                    b.HasKey("id");

                    b.ToTable("ItemModels");
                });
        }
    }
}
