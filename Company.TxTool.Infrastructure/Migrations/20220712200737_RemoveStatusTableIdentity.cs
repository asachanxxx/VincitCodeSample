using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveStatusTableIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
                BEGIN TRANSACTION
                SET QUOTED_IDENTIFIER ON
                SET ARITHABORT ON
                SET NUMERIC_ROUNDABORT OFF
                SET CONCAT_NULL_YIELDS_NULL ON
                SET ANSI_NULLS ON
                SET ANSI_PADDING ON
                SET ANSI_WARNINGS ON
                COMMIT
                BEGIN TRANSACTION
                GO
                CREATE TABLE app.Tmp_Status
	                (
	                StatusID int NOT NULL,
	                Code nvarchar(255) NOT NULL,
	                RowModifiedBy nvarchar(255) NOT NULL,
	                RowModifiedOn datetime2(2) NOT NULL
	                )  ON [PRIMARY]
                GO
                ALTER TABLE app.Tmp_Status SET (LOCK_ESCALATION = TABLE)
                GO
                ALTER TABLE app.Tmp_Status ADD CONSTRAINT
	                DF_Status_RowModifiedBy DEFAULT (user_name()) FOR RowModifiedBy
                GO
                ALTER TABLE app.Tmp_Status ADD CONSTRAINT
	                DF_Status_RowModifiedOn DEFAULT (getdate()) FOR RowModifiedOn
                GO
                IF EXISTS(SELECT * FROM app.Status)
	                 EXEC('INSERT INTO app.Tmp_Status (StatusID, Code, RowModifiedBy, RowModifiedOn)
		                SELECT StatusID, Code, RowModifiedBy, RowModifiedOn FROM app.Status WITH (HOLDLOCK TABLOCKX)')
                GO
                ALTER TABLE app.AccountOpenRequest
	                DROP CONSTRAINT FK_AccountOpenRequest_StatusID
                GO
                DROP TABLE app.Status
                GO
                EXECUTE sp_rename N'app.Tmp_Status', N'Status', 'OBJECT'
                GO
                ALTER TABLE app.Status ADD CONSTRAINT
	                PK_Status PRIMARY KEY CLUSTERED
	                (
	                StatusID
	                ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

                GO
                CREATE UNIQUE NONCLUSTERED INDEX UIX_StatusCode ON app.Status
	                (
	                Code
	                ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                GO
                COMMIT
                BEGIN TRANSACTION
                GO
                ALTER TABLE app.AccountOpenRequest ADD CONSTRAINT
	                FK_AccountOpenRequest_StatusID FOREIGN KEY
	                (
	                StatusID
	                ) REFERENCES app.Status
	                (
	                StatusID
	                ) ON UPDATE  NO ACTION
	                 ON DELETE  CASCADE

                GO
                ALTER TABLE app.AccountOpenRequest SET (LOCK_ESCALATION = TABLE)
                GO
                COMMIT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}