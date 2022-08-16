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
    [Migration("20220723145241_MakeBaseAccountNullable")]
    partial class MakeBaseAccountNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AccountOpenRequest.BaseAccountOpenRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountOpenRequestID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("CreatedByID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int");

                    b.Property<int>("RequestedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestedOn")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ReviewedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewedOn")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<byte>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("ModifiedByID");

                    b.HasIndex("RequestedBy");

                    b.HasIndex("ReviewedBy");

                    b.HasIndex("TenantID");

                    b.HasIndex(new[] { "Status" }, "IX_AccountOpenRequest_Status");

                    b.HasIndex(new[] { "Type" }, "IX_AccountOpenRequest_Type");

                    b.ToTable("AccountOpenRequest", "app");

                    b.HasDiscriminator<byte>("Type");
                });

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
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedbyId")
                        .HasColumnType("int");

                    b.HasKey("AppConfigId");

                    b.HasIndex("ModifiedbyId");

                    b.HasIndex(new[] { "AppConfigName" }, "IX_AppConfigName")
                        .IsUnique();

                    b.ToTable("AppConfig", "app");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Audit.UserAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserAuditID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ActionedByEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ActionedById")
                        .HasColumnType("int")
                        .HasColumnName("ActionedByID");

                    b.Property<DateTime>("ActionedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetailsAsJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("ActionedById");

                    b.HasIndex("TenantID");

                    b.HasIndex(new[] { "UserId" }, "IX_UserAudit_UserID");

                    b.ToTable("UserAudit", "audit");
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
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedbyId")
                        .HasColumnType("int");

                    b.HasKey("ErrorMessageId");

                    b.HasIndex(new[] { "ErrorMessageName" }, "IX_ErrorMessageName")
                        .IsUnique();

                    b.HasIndex(new[] { "ModifiedbyId" }, "IX_ModifiedByID");

                    b.ToTable("ErrorMessage", "app");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("CreatedByID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int");

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
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("ModifiedByID");

                    b.HasIndex("TenantID", "Type", "Name")
                        .IsUnique()
                        .HasDatabaseName("UIX_PicklistItem_TenantID_Type_Name");

                    b.HasIndex(new[] { "Type" }, "IX_PicklistItem_Type");

                    b.ToTable("PicklistItem", "lkp");

                    b.HasDiscriminator<string>("Type").HasValue("BasePicklistItem");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.Picklist", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberOrderKey")
                        .HasColumnType("int");

                    b.HasKey("Code", "TenantID");

                    b.HasIndex("TenantID");

                    b.ToTable("Picklist", "lkp");
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

                    b.Property<DateTime?>("Created")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("CreatedByID")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    b.Property<DateTime>("RowModified")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("RowModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("Id");

                    b.HasIndex("CopiedFromApplicationRoleID");

                    b.HasIndex("CreatedByID");

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
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.HasKey("ApplicationRoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("ApplicationRole_b_Permission", "usr");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PermissionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("CreatedByID")
                        .HasColumnType("int");

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
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("ModifiedByID");

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

                    b.Property<DateTime?>("Created")
                        .HasPrecision(2)
                        .HasColumnType("datetime2(2)");

                    b.Property<int?>("CreatedByID")
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
                        .HasColumnType("int");

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
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<Guid>("UserGraphId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserGraphID");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("ModifiedByID");

                    b.HasIndex("TenantID");

                    b.HasIndex(new[] { "ApplicationRoleID" }, "IX_ApplicationRoleID")
                        .IsUnique();

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

                    b.HasIndex(new[] { "AdminEmail" }, "UIX_AdminEmail")
                        .IsUnique();

                    b.HasIndex(new[] { "Code" }, "UIX_Code")
                        .IsUnique();

                    b.ToTable("Tenant", "app");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AccountOpenRequest.PhysicalAccountOpenRequest", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.AccountOpenRequest.BaseAccountOpenRequest");

                    b.HasDiscriminator().HasValue((byte)1);
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AccountOpenRequest.VirtualAccountOpenRequest", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.AccountOpenRequest.BaseAccountOpenRequest");

                    b.HasDiscriminator().HasValue((byte)2);
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.AccountType", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem");

                    b.Property<string>("ReconciliationFrequency")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("AccountType");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.Currency", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem");

                    b.HasDiscriminator().HasValue("Currency");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.DatabaseType", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem");

                    b.HasDiscriminator().HasValue("DatabaseType");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.DocumentType", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem");

                    b.HasDiscriminator().HasValue("DocumentType");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.PhysicalAccountType", b =>
                {
                    b.HasBaseType("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem");

                    b.HasDiscriminator().HasValue("PhysicalAccountType");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AccountOpenRequest.BaseAccountOpenRequest", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedByID")
                        .HasConstraintName("FK_BaseAccountOpenRequest_CreatedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_BaseAccountOpenRequest_ModifiedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "RequestedUser")
                        .WithMany()
                        .HasForeignKey("RequestedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_AccountOpenRequest_RequestedBy");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "ReviewedUser")
                        .WithMany()
                        .HasForeignKey("ReviewedBy")
                        .HasConstraintName("FK_AccountOpenRequest_ReviewedBy");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_BaseAccountOpenRequest_TenantID");

                    b.Navigation("RequestedUser");

                    b.Navigation("ReviewedUser");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.AppConfig", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "Modifiedby")
                        .WithMany()
                        .HasForeignKey("ModifiedbyId");

                    b.Navigation("Modifiedby");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Audit.UserAudit", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ActionedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_UserAudit_ActionedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_UserAudit_TenantID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_UserAudit_UserID");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.ErrorMessage", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", "Modifiedby")
                        .WithMany()
                        .HasForeignKey("ModifiedbyId");

                    b.Navigation("Modifiedby");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.BasePicklistItem", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedByID")
                        .HasConstraintName("FK_BasePicklistItem_CreatedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_BasePicklistItem_ModifiedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_BasePicklistItem_TenantID");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Picklists.Picklist", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Picklist_TenantID");
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
                        .HasForeignKey("CreatedByID")
                        .HasConstraintName("FK_ApplicationRole_CreatedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_ApplicationRole_ModifiedByID");

                    b.Navigation("CopiedFromApplicationRole");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRoleBPermission", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationRoleBPermissions")
                        .HasForeignKey("ApplicationRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRole_b_Permission_ApplicationRole");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", "Permission")
                        .WithMany("ApplicationRoleBPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRole_b_Permission_Permission");

                    b.Navigation("ApplicationRole");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", b =>
                {
                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedByID")
                        .HasConstraintName("FK_Permission_CreatedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_Permission_ModifiedByID");
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
                        .HasForeignKey("CreatedByID")
                        .HasConstraintName("FK_User_CreatedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Security.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedByID")
                        .HasConstraintName("FK_User_ModifiedByID");

                    b.HasOne("Cushwake.TreasuryTool.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_User_TenantID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationRoleBPermissions");
                });

            modelBuilder.Entity("Cushwake.TreasuryTool.Domain.Entities.Security.Permission", b =>
                {
                    b.Navigation("ApplicationRoleBPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
