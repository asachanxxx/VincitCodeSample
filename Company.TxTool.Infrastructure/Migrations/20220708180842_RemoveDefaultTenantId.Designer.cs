﻿// <auto-generated />
using System;
using Cushwake.TreasuryTool.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220708180842_RemoveDefaultTenantId")]
    partial class RemoveDefaultTenantId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AppConfig", b =>
                {
                    b.Property<int>("AppConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AppConfigID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppConfigId"), 1L, 1);

                    b.Property<string>("AppConfigCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("AppConfigName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AppConfigText")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedbyId")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedbyID");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("AppConfigId");

                    b.HasIndex(new[] { "AppConfigName" }, "IX_AppConfigName")
                        .IsUnique();

                    b.HasIndex(new[] { "ModifiedbyId" }, "IX_ModifiedByID");

                    b.ToTable("AppConfig", "app");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.ErrorMessage", b =>
                {
                    b.Property<int>("ErrorMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ErrorMessageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErrorMessageId"), 1L, 1);

                    b.Property<string>("ErrorMessageCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ErrorMessageName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ErrorMessageText")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedbyId")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedbyID");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("ErrorMessageId");

                    b.HasIndex(new[] { "ErrorMessageName" }, "IX_ErrorMessageName")
                        .IsUnique();

                    b.HasIndex(new[] { "ModifiedbyId" }, "IX_ModifiedByID")
                        .HasDatabaseName("IX_ModifiedByID1");

                    b.ToTable("ErrorMessage", "app");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Lookups.Currency", b =>
                {
                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nchar(3)")
                        .IsFixedLength();

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedByID");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<string>("Symbol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CurrencyCode");

                    b.HasIndex(new[] { "CurrencyName" }, "IX_CurrencyName")
                        .IsUnique();

                    b.HasIndex(new[] { "ModifiedById" }, "IX_ModifiedByID")
                        .HasDatabaseName("IX_ModifiedByID2");

                    b.ToTable("Currency", "lkp");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Lookups.CurrencyConversion", b =>
                {
                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyCodeTo")
                        .HasMaxLength(3)
                        .HasColumnType("nchar(3)")
                        .IsFixedLength();

                    b.Property<string>("CurrencyCodeFrom")
                        .HasMaxLength(3)
                        .HasColumnType("nchar(3)")
                        .IsFixedLength();

                    b.Property<string>("CurrencyCodeFromTo")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasComputedColumnSql("(([CurrencyCodeFrom]+'|')+[CurrencyCodeTo])", true);

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedByID");

                    b.Property<decimal>("RateDivide")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,4)")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("Year", "CurrencyCodeTo", "CurrencyCodeFrom");

                    b.HasIndex(new[] { "CurrencyCodeFrom" }, "IX_CurrencyCodeFrom");

                    b.HasIndex(new[] { "CurrencyCodeTo" }, "IX_CurrencyCodeTo");

                    b.HasIndex(new[] { "ModifiedById" }, "IX_ModifiedByID")
                        .HasDatabaseName("IX_ModifiedByID3");

                    b.ToTable("CurrencyConversion", "lkp");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ApplicationRoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationRoleCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ApplicationRoleName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("CopiedFromApplicationRoleID")
                        .HasColumnType("int")
                        .HasColumnName("CopiedFromApplicationRoleID");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStandardRole")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedByID");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("Id");

                    b.HasIndex("CopiedFromApplicationRoleID");

                    b.HasIndex("ModifiedByID");

                    b.ToTable("ApplicationRole", "usr");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRoleBPermission", b =>
                {
                    b.Property<int>("ApplicationRoleId")
                        .HasColumnType("int")
                        .HasColumnName("ApplicationRoleID");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int")
                        .HasColumnName("PermissionID");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedByID");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("ApplicationRoleId", "PermissionId");

                    b.HasIndex(new[] { "ModifiedById" }, "IX_ModifiedByID")
                        .HasDatabaseName("IX_ModifiedByID4");

                    b.HasIndex(new[] { "PermissionId" }, "IX_PermissionID");

                    b.ToTable("ApplicationRole_b_Permission", "usr");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PermissionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int");

                    b.Property<string>("PermissionCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PermissionName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ModifiedByID" }, "IX_ModifiedByID")
                        .HasDatabaseName("IX_ModifiedByID5");

                    b.HasIndex(new[] { "PermissionCode" }, "UIX_PermissionCode")
                        .IsUnique();

                    b.ToTable("Permission", "usr");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApplicationRoleID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedByID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<int>("TenantId")
                        .HasColumnType("int")
                        .HasColumnName("TenantID");

                    b.Property<Guid>("UserGraphId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserGraphID");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex(new[] { "ApplicationRoleID" }, "IX_ApplicationRoleID")
                        .IsUnique();

                    b.HasIndex(new[] { "ModifiedByID" }, "IX_ModifiedByID")
                        .HasDatabaseName("IX_ModifiedByID6");

                    b.HasIndex(new[] { "UserGraphId" }, "IX_UserGraphID")
                        .IsUnique();

                    b.HasIndex(new[] { "WorkEmail" }, "IX_WorkEmail")
                        .IsUnique();

                    b.ToTable("User", "usr");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("TenantID");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AdminEmail" }, "IX_AdminEmail")
                        .IsUnique();

                    b.ToTable("Tenant", "app");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Reminder")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AppConfig", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "Modifiedby")
                        .WithMany()
                        .HasForeignKey("ModifiedbyId")
                        .HasConstraintName("FK_AppConfig_User");

                    b.Navigation("Modifiedby");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.ErrorMessage", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "Modifiedby")
                        .WithMany()
                        .HasForeignKey("ModifiedbyId")
                        .HasConstraintName("FK_ErrorMessage_ModifiedBy");

                    b.Navigation("Modifiedby");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Lookups.Currency", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .HasConstraintName("FK_Currency_ModifiedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Lookups.CurrencyConversion", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Lookups.Currency", "CurrencyCodeFromNavigation")
                        .WithMany("CurrencyConversionCurrencyCodeFromNavigation")
                        .HasForeignKey("CurrencyCodeFrom")
                        .IsRequired()
                        .HasConstraintName("FK_CurrencyConversion_CurrencyCodeFrom");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Lookups.Currency", "CurrencyCodeToNavigation")
                        .WithMany("CurrencyConversionCurrencyCodeToNavigation")
                        .HasForeignKey("CurrencyCodeTo")
                        .IsRequired()
                        .HasConstraintName("FK_CurrencyConversion_CurrencyCodeTo");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .HasConstraintName("FK_CurrencyConversion_ModifiedBy");

                    b.Navigation("CurrencyCodeFromNavigation");

                    b.Navigation("CurrencyCodeToNavigation");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", "CopiedFromApplicationRole")
                        .WithMany()
                        .HasForeignKey("CopiedFromApplicationRoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_ApplicationRole_CopiedFromApplicationRoleID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_ApplicationRole_ModifiedBy");

                    b.Navigation("CopiedFromApplicationRole");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRoleBPermission", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationRoleBPermissions")
                        .HasForeignKey("ApplicationRoleId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRole_b_Permission_ApplicationRole");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .HasConstraintName("FK_ApplicationRole_b_Permission_ModifiedBy");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", "Permission")
                        .WithMany("ApplicationRoleBPermissions")
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRole_b_Permission_Permission");

                    b.Navigation("ApplicationRole");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_Permission_ModifiedBy");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.User", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", "Role")
                        .WithOne()
                        .HasForeignKey("Cushwake.TreasuryTool.Domain.Entities.Security.User", "ApplicationRoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_User_ApplicationRoleID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_User_ModifiedBy");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_TenantID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.TodoList", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.TodoList", b =>
                {
                    b.OwnsOne("Cushwake.TreasuryTool.Domain.ValueObjects.Colour", "Colour", b1 =>
                        {
                            b1.Property<int>("TodoListId")
                                .HasColumnType("int");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TodoListId");

                            b1.ToTable("TodoLists");

                            b1.WithOwner()
                                .HasForeignKey("TodoListId");
                        });

                    b.Navigation("Colour")
                        .IsRequired();
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Lookups.Currency", b =>
                {
                    b.Navigation("CurrencyConversionCurrencyCodeFromNavigation");

                    b.Navigation("CurrencyConversionCurrencyCodeToNavigation");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationRoleBPermissions");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", b =>
                {
                    b.Navigation("ApplicationRoleBPermissions");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.TodoList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
