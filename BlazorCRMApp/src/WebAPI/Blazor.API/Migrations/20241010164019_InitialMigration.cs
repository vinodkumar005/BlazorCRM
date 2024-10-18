using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminCalendar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsSelectAll = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminCal__3214EC07BA9CA427", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Logo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IsACA = table.Column<bool>(type: "bit", nullable: false),
                    ShowInAdminGraph = table.Column<bool>(type: "bit", nullable: true),
                    GraphSequenceNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carrier__3214EC0779CE1219", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignationMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailTem__3214EC07F76C4063", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enquiry__3214EC07A04CE267", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlagMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlagName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FlagColor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDynamic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadSourceMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSourceMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadStoreCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfLeads = table.Column<int>(name: "NumberOfLeads ", type: "int", nullable: true),
                    IsLeadUnder20Days = table.Column<byte>(type: "tinyint", nullable: true),
                    LeadTypeId = table.Column<int>(type: "int", nullable: true),
                    PerLeadPrice = table.Column<double>(type: "float", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    Tax = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    GrantTotal = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadStor__3214EC07782B12B3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadStoreLeadTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lead1To249 = table.Column<double>(type: "float", nullable: false),
                    Lead250To999 = table.Column<double>(type: "float", nullable: false),
                    Lead1000To4999 = table.Column<double>(type: "float", nullable: false),
                    Lead5000To9999 = table.Column<double>(type: "float", nullable: false),
                    Lead10000To24999 = table.Column<double>(type: "float", nullable: false),
                    Lead25000Plus = table.Column<double>(type: "float", nullable: false),
                    NewLeadsPrice = table.Column<double>(type: "float", nullable: false),
                    LeadTypeIdForExcel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadStor__3214EC07E34DFAB9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MainMenuId = table.Column<long>(type: "bigint", nullable: true),
                    SequenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Menu__3214EC07B3F86410", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTimeZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeZone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOnSite = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TimeZone__3214EC071A1AFF4D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MenuId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3214EC07769913E7", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Carrier_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carrier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_State",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadStoreOrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadStor__3214EC0719F50B6E", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadStoreOrderDetails_LeadStoreCart_CartId",
                        column: x => x.CartId,
                        principalTable: "LeadStoreCart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadStoreFilter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadTypeId = table.Column<int>(type: "int", nullable: true),
                    StateFilterId = table.Column<long>(type: "bigint", nullable: true),
                    ZipCodeFilterId = table.Column<long>(type: "bigint", nullable: true),
                    MinAge = table.Column<int>(type: "int", nullable: true),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    LeadAge = table.Column<int>(type: "int", nullable: true),
                    PhoneNumberPreference = table.Column<byte>(type: "tinyint", nullable: true),
                    States = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadStor__3214EC07DF6A314D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadStoreFilter_LeadStoreLeadTypes_LeadTypeId",
                        column: x => x.LeadTypeId,
                        principalTable: "LeadStoreLeadTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleType = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ForgetPasswordLink = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ForgetPasswordExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogin_Role",
                        column: x => x.RoleType,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Plan__3214EC07531D2761", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminLead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AgencyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsUser = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminLea__3214EC078FE49EDF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adminlead_State",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NPN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agency_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminDoc__3214EC07184B8360", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminDocuments_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadStoreLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcelPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadStor__3214EC07841DB80E", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadStoreLog_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLoginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Short_Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TimeZoneId = table.Column<byte>(type: "tinyint", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BodyBackGroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeaderBackGroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NavigationBackGroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NavigationtextColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubNavigationBGColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FooterBackGroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FooterTitleColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FooterTextColorH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NavigationtextSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FooterTitleTextSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GooglePlusLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProfilePic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LeadStoreFilterId = table.Column<long>(type: "bigint", nullable: true),
                    IsHealthNavigator = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agent__3214EC079F6CC205", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agent_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agent_UserLogin_UserLoginId",
                        column: x => x.UserLoginId,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_DesignationMaster",
                        column: x => x.DesignationId,
                        principalTable: "DesignationMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserLogin",
                        column: x => x.ParentId,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatePlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    PlanType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StatePla__3214EC071C84F4FA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatePlan_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatePlan_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminLeadComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminLeadId = table.Column<int>(type: "int", nullable: false),
                    StatusType = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminLea__3214EC070D4955C3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLeadComment_AdminLead_AdminLeadId",
                        column: x => x.AdminLeadId,
                        principalTable: "AdminLead",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminLeadComment_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminLeadConversation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminLeadId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminLea__3214EC07C1183B7A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLeadConversation_AdminLead_LeadId",
                        column: x => x.AdminLeadId,
                        principalTable: "AdminLead",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminLeadConversation_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminLeadFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminLeadId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminLea__3214EC0780B7927A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLeadFile_AdminLead_AdminLeadId",
                        column: x => x.AdminLeadId,
                        principalTable: "AdminLead",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminLeadFile_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminLeadNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminLeadId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminLea__3214EC070E576B11", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLeadNote_AdminLead_AdminLeadId",
                        column: x => x.AdminLeadId,
                        principalTable: "AdminLead",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminLeadNote_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgencyAppointment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FEIN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LineOfAuthority = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LOACode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    COcode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    TerminationReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReasonDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RenewalDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgencyAp__3214EC07F1726F3E", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyAppointment_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgencyAppointment_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgencyLicense",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    LicenseNo = table.Column<long>(type: "bigint", nullable: false),
                    DateIssue = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateExpire = table.Column<DateTime>(type: "datetime", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsResidency = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgencyLi__3214EC0704597115", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyLicense_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgencyLicense_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgencyState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    SaleStatusType = table.Column<byte>(type: "tinyint", nullable: false),
                    LicenseNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateIssue = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResidencyStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgencySt__3214EC07DF81EAA3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyState_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgencyState_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminCalendarUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminCalendarId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminCal__3214EC071BE00BA9", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminCalendarAgents_AdminCalendar_AdminCalendarId",
                        column: x => x.AdminCalendarId,
                        principalTable: "AdminCalendar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminCalendarAgents_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminNot__3214EC07C9886EB7", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminNotes_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GenderType = table.Column<byte>(type: "tinyint", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherMaidenName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeadType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OpportunityStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MainContactName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NumberOfEmployess = table.Column<int>(type: "int", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgentLea__3214EC076536DA7E", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentLead_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentLead_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadStoreLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GenderType = table.Column<byte>(type: "tinyint", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherMaidenName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSold = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    LeadAge = table.Column<int>(type: "int", nullable: true),
                    LogId = table.Column<long>(type: "bigint", nullable: true),
                    LeadType = table.Column<int>(type: "int", nullable: true),
                    WorkPhone = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    LeadsCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderNumber = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadStor__3214EC07BAAD59DD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadStoreLeads_Agent",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadStoreLeads_LeadStoreLeadTypes_LeadType",
                        column: x => x.LeadType,
                        principalTable: "LeadStoreLeadTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadStoreLeads_LeadStoreLog_LogId",
                        column: x => x.LogId,
                        principalTable: "LeadStoreLog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadStoreLeads_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCalendar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgentCal__3214EC079BE6D23D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentCalendar_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCarrier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CarrierId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CarrierUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgentCar__3214EC07A2C78AB2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentCarrier_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentCarrier_Carrier_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carrier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserOpportunity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GenderType = table.Column<byte>(type: "tinyint", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpportunityStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    LeadStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherMaidenName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgentOpp__3214EC07C44A62BC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentOpportunity_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentOpportunity_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CarrierId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgentPro__3214EC070E320F34", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentProduct_Agent_AgentId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentProduct_Carrier_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carrier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentProduct_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlternateContactDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Alternat__3214EC07419EB5D0", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternateContactDetail_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    StatusType = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadComm__3214EC07D574C019", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadComment_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadComment_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadConversation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadConv__3214EC076824A4FA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadConversation_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadConversation_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadFile__3214EC07F8284F53", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadFile_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadFile_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadLog__3214EC07A093C61C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadLog_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadLog_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LeadNote__3214EC0781F49184", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadNote_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadNote_UserLogin_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminCalendarUsers_AdminCalendarId",
                table: "AdminCalendarUsers",
                column: "AdminCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCalendarUsers_UserId",
                table: "AdminCalendarUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminDocuments_AddedBy",
                table: "AdminDocuments",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLead_StateId",
                table: "AdminLead",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadComment_AddedBy",
                table: "AdminLeadComment",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadComment_AdminLeadId",
                table: "AdminLeadComment",
                column: "AdminLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadConversation_AddedBy",
                table: "AdminLeadConversation",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadConversation_AdminLeadId",
                table: "AdminLeadConversation",
                column: "AdminLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadFile_AddedBy",
                table: "AdminLeadFile",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadFile_AdminLeadId",
                table: "AdminLeadFile",
                column: "AdminLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadNote_AddedBy",
                table: "AdminLeadNote",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLeadNote_AdminLeadId",
                table: "AdminLeadNote",
                column: "AdminLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminNotes_UserId",
                table: "AdminNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_StateId",
                table: "Agency",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyAppointment_AgencyId",
                table: "AgencyAppointment",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyAppointment_StateId",
                table: "AgencyAppointment",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyLicense_AgencyId",
                table: "AgencyLicense",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyLicense_StateId",
                table: "AgencyLicense",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyState_AgencyId",
                table: "AgencyState",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyState_StateId",
                table: "AgencyState",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternateContactDetail_LeadId",
                table: "AlternateContactDetail",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_StateId",
                table: "Lead",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_UserId",
                table: "Lead",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadComment_AddedBy",
                table: "LeadComment",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadComment_LeadId",
                table: "LeadComment",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadConversation_AddedBy",
                table: "LeadConversation",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadConversation_LeadId",
                table: "LeadConversation",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadFile_AddedBy",
                table: "LeadFile",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadFile_LeadId",
                table: "LeadFile",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadLog_AddedBy",
                table: "LeadLog",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadLog_LeadId",
                table: "LeadLog",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadNote_AddedBy",
                table: "LeadNote",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadNote_LeadId",
                table: "LeadNote",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreFilter_LeadTypeId",
                table: "LeadStoreFilter",
                column: "LeadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreLeads_LeadType",
                table: "LeadStoreLeads",
                column: "LeadType");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreLeads_LogId",
                table: "LeadStoreLeads",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreLeads_StateId",
                table: "LeadStoreLeads",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreLeads_UserId",
                table: "LeadStoreLeads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreLog_AddedBy",
                table: "LeadStoreLog",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStoreOrderDetails_CartId",
                table: "LeadStoreOrderDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_ProductId",
                table: "Plan",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CarrierId",
                table: "Product",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StatePlan_PlanId",
                table: "StatePlan",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StatePlan_StateId",
                table: "StatePlan",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendar_UserId",
                table: "UserCalendar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarrier_CarrierId",
                table: "UserCarrier",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarrier_UserId",
                table: "UserCarrier",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_RoleType",
                table: "UserLogin",
                column: "RoleType");

            migrationBuilder.CreateIndex(
                name: "IX_UserOpportunity_StateId",
                table: "UserOpportunity",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOpportunity_UserId",
                table: "UserOpportunity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_CarrierId",
                table: "UserProduct",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_ProductId",
                table: "UserProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_UserId",
                table: "UserProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DesignationId",
                table: "Users",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParentId",
                table: "Users",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                table: "Users",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLoginId",
                table: "Users",
                column: "UserLoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminCalendarUsers");

            migrationBuilder.DropTable(
                name: "AdminDocuments");

            migrationBuilder.DropTable(
                name: "AdminLeadComment");

            migrationBuilder.DropTable(
                name: "AdminLeadConversation");

            migrationBuilder.DropTable(
                name: "AdminLeadFile");

            migrationBuilder.DropTable(
                name: "AdminLeadNote");

            migrationBuilder.DropTable(
                name: "AdminNotes");

            migrationBuilder.DropTable(
                name: "AgencyAppointment");

            migrationBuilder.DropTable(
                name: "AgencyLicense");

            migrationBuilder.DropTable(
                name: "AgencyState");

            migrationBuilder.DropTable(
                name: "AlternateContactDetail");

            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "FlagMaster");

            migrationBuilder.DropTable(
                name: "LeadComment");

            migrationBuilder.DropTable(
                name: "LeadConversation");

            migrationBuilder.DropTable(
                name: "LeadFile");

            migrationBuilder.DropTable(
                name: "LeadLog");

            migrationBuilder.DropTable(
                name: "LeadNote");

            migrationBuilder.DropTable(
                name: "LeadSourceMaster");

            migrationBuilder.DropTable(
                name: "LeadStoreFilter");

            migrationBuilder.DropTable(
                name: "LeadStoreLeads");

            migrationBuilder.DropTable(
                name: "LeadStoreOrderDetails");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "StatePlan");

            migrationBuilder.DropTable(
                name: "UserCalendar");

            migrationBuilder.DropTable(
                name: "UserCarrier");

            migrationBuilder.DropTable(
                name: "UserOpportunity");

            migrationBuilder.DropTable(
                name: "UserProduct");

            migrationBuilder.DropTable(
                name: "UserTimeZones");

            migrationBuilder.DropTable(
                name: "AdminCalendar");

            migrationBuilder.DropTable(
                name: "AdminLead");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "LeadStoreLeadTypes");

            migrationBuilder.DropTable(
                name: "LeadStoreLog");

            migrationBuilder.DropTable(
                name: "LeadStoreCart");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "DesignationMaster");

            migrationBuilder.DropTable(
                name: "Carrier");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
