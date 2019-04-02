namespace MVC_StoredProcedure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
            CreateStoredProcedure(
                "dbo.Item_Insert",
                p => new
                    {
                        Name = p.String(),
                        Stock = p.Int(),
                        Price = p.Int(),
                        CreateDate = p.DateTimeOffset(),
                        UpdateDate = p.DateTimeOffset(),
                        DeleteDate = p.DateTimeOffset(),
                        IsDelete = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[Items]([Name], [Stock], [Price], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete])
                      VALUES (@Name, @Stock, @Price, @CreateDate, @UpdateDate, @DeleteDate, @IsDelete)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Items]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Items] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Item_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Stock = p.Int(),
                        Price = p.Int(),
                        CreateDate = p.DateTimeOffset(),
                        UpdateDate = p.DateTimeOffset(),
                        DeleteDate = p.DateTimeOffset(),
                        IsDelete = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[Items]
                      SET [Name] = @Name, [Stock] = @Stock, [Price] = @Price, [CreateDate] = @CreateDate, [UpdateDate] = @UpdateDate, [DeleteDate] = @DeleteDate, [IsDelete] = @IsDelete
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Item_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Items]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Supplier_Insert",
                p => new
                    {
                        Name = p.String(),
                        CreateDate = p.DateTimeOffset(),
                        UpdateDate = p.DateTimeOffset(),
                        DeleteDate = p.DateTimeOffset(),
                        IsDelete = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[Suppliers]([Name], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete])
                      VALUES (@Name, @CreateDate, @UpdateDate, @DeleteDate, @IsDelete)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Suppliers]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Suppliers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Supplier_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        CreateDate = p.DateTimeOffset(),
                        UpdateDate = p.DateTimeOffset(),
                        DeleteDate = p.DateTimeOffset(),
                        IsDelete = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[Suppliers]
                      SET [Name] = @Name, [CreateDate] = @CreateDate, [UpdateDate] = @UpdateDate, [DeleteDate] = @DeleteDate, [IsDelete] = @IsDelete
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Supplier_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Suppliers]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Supplier_Delete");
            DropStoredProcedure("dbo.Supplier_Update");
            DropStoredProcedure("dbo.Supplier_Insert");
            DropStoredProcedure("dbo.Item_Delete");
            DropStoredProcedure("dbo.Item_Update");
            DropStoredProcedure("dbo.Item_Insert");
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
