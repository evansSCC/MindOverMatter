﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MindOverMatter.Models.DbContexts;

namespace MindOverMatter.Migrations
{
    [DbContext(typeof(ChemicalDbContext))]
    partial class ChemicalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MindOverMatter.Models.Matter.Atom", b =>
                {
                    b.Property<int>("AtomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BondPotential");

                    b.Property<string>("Name");

                    b.HasKey("AtomId");

                    b.ToTable("Atoms");

                    b.HasData(
                        new { AtomId = 1, BondPotential = 4, Name = "Carbon" }
                    );
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Chain", b =>
                {
                    b.Property<int>("ChainId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MoleculeId");

                    b.Property<bool>("Parent");

                    b.Property<bool>("Side");

                    b.HasKey("ChainId");

                    b.HasIndex("MoleculeId");

                    b.ToTable("Chain");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Molecule", b =>
                {
                    b.Property<int>("MoleculeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("MoleculeId");

                    b.ToTable("Molecules");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Node", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AtomId");

                    b.Property<int>("BranchCount");

                    b.Property<int?>("ChainId");

                    b.Property<bool>("Divergent");

                    b.Property<bool>("Linear");

                    b.Property<string>("NodeTag");

                    b.Property<bool>("Outer");

                    b.HasKey("NodeId");

                    b.HasIndex("AtomId");

                    b.HasIndex("ChainId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.NodeChain", b =>
                {
                    b.Property<int>("ChainId");

                    b.Property<int>("NodeId");

                    b.HasKey("ChainId", "NodeId");

                    b.HasIndex("ChainId")
                        .IsUnique();

                    b.HasIndex("NodeId");

                    b.ToTable("NodeChains");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.NodeNeighbor", b =>
                {
                    b.Property<int>("NodeId");

                    b.Property<int>("NeighborId");

                    b.HasKey("NodeId", "NeighborId");

                    b.ToTable("NodeNeighbors");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Chain", b =>
                {
                    b.HasOne("MindOverMatter.Models.Matter.Molecule")
                        .WithMany("Chains")
                        .HasForeignKey("MoleculeId");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Node", b =>
                {
                    b.HasOne("MindOverMatter.Models.Matter.Atom", "Atom")
                        .WithMany()
                        .HasForeignKey("AtomId");

                    b.HasOne("MindOverMatter.Models.Matter.Chain")
                        .WithMany("NodeList")
                        .HasForeignKey("ChainId");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.NodeChain", b =>
                {
                    b.HasOne("MindOverMatter.Models.Matter.Chain")
                        .WithOne("NodeChain")
                        .HasForeignKey("MindOverMatter.Models.Matter.NodeChain", "ChainId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MindOverMatter.Models.Matter.Node")
                        .WithMany("nodeChains")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.NodeNeighbor", b =>
                {
                    b.HasOne("MindOverMatter.Models.Matter.Node")
                        .WithMany("nodeNeighbors")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
