using System;
using System.Collections.Generic;
using Blazor.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminCalendar> AdminCalendar { get; set; }

    public virtual DbSet<AdminCalendarUsers> AdminCalendarUsers { get; set; }

    public virtual DbSet<AdminDocuments> AdminDocuments { get; set; }

    public virtual DbSet<AdminLead> AdminLead { get; set; }

    public virtual DbSet<AdminLeadComment> AdminLeadComment { get; set; }

    public virtual DbSet<AdminLeadConversation> AdminLeadConversation { get; set; }

    public virtual DbSet<AdminLeadFile> AdminLeadFile { get; set; }

    public virtual DbSet<AdminLeadNote> AdminLeadNote { get; set; }

    public virtual DbSet<AdminNotes> AdminNotes { get; set; }

    public virtual DbSet<Agency> Agency { get; set; }

    public virtual DbSet<AgencyAppointment> AgencyAppointment { get; set; }

    public virtual DbSet<AgencyLicense> AgencyLicense { get; set; }

    public virtual DbSet<AgencyState> AgencyState { get; set; }

    public virtual DbSet<AgencyUserView> AgencyUserView { get; set; }

    public virtual DbSet<AlternateContactDetail> AlternateContactDetail { get; set; }

    public virtual DbSet<Carrier> Carrier { get; set; }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMaster { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }

    public virtual DbSet<Enquiry> Enquiry { get; set; }

    public virtual DbSet<FlagMaster> FlagMaster { get; set; }

    public virtual DbSet<Lead> Lead { get; set; }

    public virtual DbSet<LeadComment> LeadComment { get; set; }

    public virtual DbSet<LeadConversation> LeadConversation { get; set; }

    public virtual DbSet<LeadFile> LeadFile { get; set; }

    public virtual DbSet<LeadLog> LeadLog { get; set; }

    public virtual DbSet<LeadNote> LeadNote { get; set; }

    public virtual DbSet<LeadSourceMaster> LeadSourceMaster { get; set; }

    public virtual DbSet<LeadStoreCart> LeadStoreCart { get; set; }

    public virtual DbSet<LeadStoreFilter> LeadStoreFilter { get; set; }

    public virtual DbSet<LeadStoreLeadTypes> LeadStoreLeadTypes { get; set; }

    public virtual DbSet<LeadStoreLeads> LeadStoreLeads { get; set; }

    public virtual DbSet<LeadStoreLog> LeadStoreLog { get; set; }

    public virtual DbSet<LeadStoreOrderDetails> LeadStoreOrderDetails { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<Plan> Plan { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<State> State { get; set; }

    public virtual DbSet<StatePlan> StatePlan { get; set; }

    public virtual DbSet<UserCalendar> UserCalendar { get; set; }

    public virtual DbSet<UserCarrier> UserCarrier { get; set; }

    public virtual DbSet<UserLogin> UserLogin { get; set; }

    public virtual DbSet<UserOpportunity> UserOpportunity { get; set; }

    public virtual DbSet<UserProduct> UserProduct { get; set; }

    public virtual DbSet<UserTimeZones> UserTimeZones { get; set; }

    public virtual DbSet<Users> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminCal__3214EC07BA9CA427");

            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.Location).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(1000);
        });

        modelBuilder.Entity<AdminCalendarUsers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminCal__3214EC071BE00BA9");

            entity.HasOne(d => d.AdminCalendar).WithMany(p => p.AdminCalendarUsers)
                .HasForeignKey(d => d.AdminCalendarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminCalendarAgents_AdminCalendar_AdminCalendarId");

            entity.HasOne(d => d.User).WithMany(p => p.AdminCalendarUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminCalendarAgents_Agent_AgentId");
        });

        modelBuilder.Entity<AdminDocuments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminDoc__3214EC07184B8360");

            entity.Property(e => e.FileDescription).HasMaxLength(200);
            entity.Property(e => e.FileExt).HasMaxLength(50);
            entity.Property(e => e.FileType).HasMaxLength(200);

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.AdminDocuments)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AdminLead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLea__3214EC078FE49EDF");

            entity.Property(e => e.Address).HasMaxLength(2000);
            entity.Property(e => e.AgencyName).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Mobile).HasMaxLength(30);
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.State).WithMany(p => p.AdminLead)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Adminlead_State");
        });

        modelBuilder.Entity<AdminLeadComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLea__3214EC070D4955C3");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.AdminLeadComment)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AdminLead).WithMany(p => p.AdminLeadComment)
                .HasForeignKey(d => d.AdminLeadId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AdminLeadConversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLea__3214EC07C1183B7A");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.AdminLeadConversation)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AdminLead).WithMany(p => p.AdminLeadConversation)
                .HasForeignKey(d => d.AdminLeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminLeadConversation_AdminLead_LeadId");
        });

        modelBuilder.Entity<AdminLeadFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLea__3214EC0780B7927A");

            entity.Property(e => e.FileExt).HasMaxLength(50);
            entity.Property(e => e.FileType).HasMaxLength(200);

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.AdminLeadFile)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AdminLead).WithMany(p => p.AdminLeadFile)
                .HasForeignKey(d => d.AdminLeadId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AdminLeadNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLea__3214EC070E576B11");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.AdminLeadNote)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AdminLead).WithMany(p => p.AdminLeadNote)
                .HasForeignKey(d => d.AdminLeadId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AdminNotes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminNot__3214EC07C9886EB7");

            entity.HasOne(d => d.User).WithMany(p => p.AdminNotes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminNotes_Agent_AgentId");
        });

        modelBuilder.Entity<Agency>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(250);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Logo).HasMaxLength(500);
            entity.Property(e => e.ModifyDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Npn)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NPN");

            entity.HasOne(d => d.State).WithMany(p => p.Agency).HasForeignKey(d => d.StateId);
        });

        modelBuilder.Entity<AgencyAppointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgencyAp__3214EC07F1726F3E");

            entity.Property(e => e.Cocode)
                .HasMaxLength(250)
                .HasColumnName("COcode");
            entity.Property(e => e.CompanyName).HasMaxLength(250);
            entity.Property(e => e.Fein)
                .HasMaxLength(250)
                .HasColumnName("FEIN");
            entity.Property(e => e.LineOfAuthority).HasMaxLength(250);
            entity.Property(e => e.Loacode)
                .HasMaxLength(250)
                .HasColumnName("LOACode");
            entity.Property(e => e.ReasonDate).HasColumnType("datetime");
            entity.Property(e => e.RenewalDate).HasColumnType("datetime");
            entity.Property(e => e.TerminationReason).HasMaxLength(50);

            entity.HasOne(d => d.Agency).WithMany(p => p.AgencyAppointment)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.State).WithMany(p => p.AgencyAppointment)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgencyLicense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgencyLi__3214EC0704597115");

            entity.Property(e => e.Class).HasMaxLength(250);
            entity.Property(e => e.DateExpire).HasColumnType("datetime");
            entity.Property(e => e.DateIssue).HasColumnType("datetime");

            entity.HasOne(d => d.Agency).WithMany(p => p.AgencyLicense)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.State).WithMany(p => p.AgencyLicense)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgencyState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgencySt__3214EC07DF81EAA3");

            entity.Property(e => e.Class).HasMaxLength(250);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.DateExpire).HasColumnType("datetime");
            entity.Property(e => e.DateIssue).HasColumnType("datetime");
            entity.Property(e => e.LicenseNo).HasMaxLength(100);
            entity.Property(e => e.Modified).HasColumnType("datetime");

            entity.HasOne(d => d.Agency).WithMany(p => p.AgencyState)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.State).WithMany(p => p.AgencyState)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgencyUserView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Agency_User_View");

            entity.Property(e => e.Code).HasMaxLength(250);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Id).HasMaxLength(150);
            entity.Property(e => e.Logo).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(752);
            entity.Property(e => e.Npn)
                .HasMaxLength(50)
                .HasColumnName("NPN");
            entity.Property(e => e.ProfilePic).HasMaxLength(500);
            entity.Property(e => e.StateId).HasMaxLength(5);
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlternateContactDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alternat__3214EC07419EB5D0");

            entity.Property(e => e.ContactNumber)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);

            entity.HasOne(d => d.Lead).WithMany(p => p.AlternateContactDetail).HasForeignKey(d => d.LeadId);
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrier__3214EC0779CE1219");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsAca).HasColumnName("IsACA");
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<DesignationMaster>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmailTem__3214EC07F76C4063");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(250);
        });

        modelBuilder.Entity<Enquiry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enquiry__3214EC07A04CE267");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<FlagMaster>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FlagColor)
                .IsRequired()
                .HasMaxLength(250);
            entity.Property(e => e.FlagName)
                .IsRequired()
                .HasMaxLength(250);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentLea__3214EC076536DA7E");

            entity.Property(e => e.Address1).HasMaxLength(1500);
            entity.Property(e => e.Address2).HasMaxLength(1500);
            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.CompanyName).HasMaxLength(1000);
            entity.Property(e => e.DriverLicenseNumber).HasMaxLength(200);
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(400);
            entity.Property(e => e.Height).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.MainContactName).HasMaxLength(1000);
            entity.Property(e => e.MiddleName).HasMaxLength(200);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.MotherMaidenName).HasMaxLength(400);
            entity.Property(e => e.Occupation).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(2000);
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.State).WithMany(p => p.Lead)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_AgentLead_State_StateId");

            entity.HasOne(d => d.User).WithMany(p => p.Lead)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AgentLead_Agent_AgentId");
        });

        modelBuilder.Entity<LeadComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadComm__3214EC07D574C019");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.LeadComment)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadComment).HasForeignKey(d => d.LeadId);
        });

        modelBuilder.Entity<LeadConversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadConv__3214EC076824A4FA");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.LeadConversation)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadConversation).HasForeignKey(d => d.LeadId);
        });

        modelBuilder.Entity<LeadFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadFile__3214EC07F8284F53");

            entity.Property(e => e.FileExt).HasMaxLength(50);
            entity.Property(e => e.FileType).HasMaxLength(200);

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.LeadFile)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadFile).HasForeignKey(d => d.LeadId);
        });

        modelBuilder.Entity<LeadLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadLog__3214EC07A093C61C");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.LeadLog)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadLog).HasForeignKey(d => d.LeadId);
        });

        modelBuilder.Entity<LeadNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadNote__3214EC0781F49184");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.LeadNote)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadNote).HasForeignKey(d => d.LeadId);
        });

        modelBuilder.Entity<LeadSourceMaster>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(250);
        });

        modelBuilder.Entity<LeadStoreCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadStor__3214EC07782B12B3");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NumberOfLeads).HasColumnName("NumberOfLeads ");
        });

        modelBuilder.Entity<LeadStoreFilter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadStor__3214EC07DF6A314D");

            entity.HasOne(d => d.LeadType).WithMany(p => p.LeadStoreFilter).HasForeignKey(d => d.LeadTypeId);
        });

        modelBuilder.Entity<LeadStoreLeadTypes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadStor__3214EC07E34DFAB9");

            entity.Property(e => e.LeadDescription)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<LeadStoreLeads>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadStor__3214EC07BAAD59DD");

            entity.Property(e => e.Address1).HasMaxLength(1500);
            entity.Property(e => e.Address2).HasMaxLength(1500);
            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.DriverLicenseNumber).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(400);
            entity.Property(e => e.Height).HasMaxLength(50);
            entity.Property(e => e.IsSold).HasColumnName("isSold");
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.MiddleName).HasMaxLength(200);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.MotherMaidenName).HasMaxLength(400);
            entity.Property(e => e.Occupation).HasMaxLength(500);
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(2000);
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.LeadTypeNavigation).WithMany(p => p.LeadStoreLeads).HasForeignKey(d => d.LeadType);

            entity.HasOne(d => d.Log).WithMany(p => p.LeadStoreLeads).HasForeignKey(d => d.LogId);

            entity.HasOne(d => d.State).WithMany(p => p.LeadStoreLeads).HasForeignKey(d => d.StateId);

            entity.HasOne(d => d.User).WithMany(p => p.LeadStoreLeads)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_LeadStoreLeads_Agent");
        });

        modelBuilder.Entity<LeadStoreLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadStor__3214EC07841DB80E");

            entity.Property(e => e.FileName).HasMaxLength(100);

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.LeadStoreLog)
                .HasForeignKey(d => d.AddedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<LeadStoreOrderDetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadStor__3214EC0719F50B6E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OrderNumber).HasMaxLength(12);
            entity.Property(e => e.UserName).HasMaxLength(200);

            entity.HasOne(d => d.Cart).WithMany(p => p.LeadStoreOrderDetails).HasForeignKey(d => d.CartId);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3214EC07B3F86410");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url).HasMaxLength(150);
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plan__3214EC07531D2761");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Plan)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07769913E7");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Carrier).WithMany(p => p.Product)
                .HasForeignKey(d => d.CarrierId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.StateCode).HasMaxLength(5);

            entity.HasOne(d => d.Country).WithMany(p => p.State)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Country_State");
        });

        modelBuilder.Entity<StatePlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatePla__3214EC071C84F4FA");

            entity.HasOne(d => d.Plan).WithMany(p => p.StatePlan)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.State).WithMany(p => p.StatePlan)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentCal__3214EC079BE6D23D");

            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.Location).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(1000);

            entity.HasOne(d => d.User).WithMany(p => p.UserCalendar)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentCalendar_Agent_AgentId");
        });

        modelBuilder.Entity<UserCarrier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentCar__3214EC07A2C78AB2");

            entity.Property(e => e.CarrierUserId).HasMaxLength(100);

            entity.HasOne(d => d.Carrier).WithMany(p => p.UserCarrier)
                .HasForeignKey(d => d.CarrierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentCarrier_Carrier_CarrierId");

            entity.HasOne(d => d.User).WithMany(p => p.UserCarrier)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentCarrier_Agent_AgentId");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ForgetPasswordExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.ForgetPasswordLink).HasMaxLength(256);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(300);

            entity.HasOne(d => d.RoleTypeNavigation).WithMany(p => p.UserLogin)
                .HasForeignKey(d => d.RoleType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogin_Role");
        });

        modelBuilder.Entity<UserOpportunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentOpp__3214EC07C44A62BC");

            entity.Property(e => e.Address1).HasMaxLength(1500);
            entity.Property(e => e.Address2).HasMaxLength(1500);
            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.DriverLicenseNumber).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(400);
            entity.Property(e => e.Height).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.MiddleName).HasMaxLength(200);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.MotherMaidenName).HasMaxLength(400);
            entity.Property(e => e.Occupation).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(2000);
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.State).WithMany(p => p.UserOpportunity)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_AgentOpportunity_State_StateId");

            entity.HasOne(d => d.User).WithMany(p => p.UserOpportunity)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentOpportunity_Agent_AgentId");
        });

        modelBuilder.Entity<UserProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentPro__3214EC070E320F34");

            entity.HasOne(d => d.Carrier).WithMany(p => p.UserProduct)
                .HasForeignKey(d => d.CarrierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentProduct_Carrier_CarrierId");

            entity.HasOne(d => d.Product).WithMany(p => p.UserProduct)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentProduct_Product");

            entity.HasOne(d => d.User).WithMany(p => p.UserProduct)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentProduct_Agent_AgentId");
        });

        modelBuilder.Entity<UserTimeZones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimeZone__3214EC071A1AFF4D");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TimeZone)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agent__3214EC079F6CC205");

            entity.Property(e => e.BodyBackGroundColor).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.FacebookLink).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.FooterBackGroundColor).HasMaxLength(50);
            entity.Property(e => e.FooterTextColorH).HasMaxLength(50);
            entity.Property(e => e.FooterTitleColor).HasMaxLength(50);
            entity.Property(e => e.FooterTitleTextSize).HasMaxLength(50);
            entity.Property(e => e.GooglePlusLink).HasMaxLength(200);
            entity.Property(e => e.HeaderBackGroundColor).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.LinkedInLink).HasMaxLength(200);
            entity.Property(e => e.Logo).HasMaxLength(500);
            entity.Property(e => e.Mobile)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.NavigationBackGroundColor).HasMaxLength(50);
            entity.Property(e => e.NavigationtextColor).HasMaxLength(50);
            entity.Property(e => e.NavigationtextSize).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ProfilePic).HasMaxLength(500);
            entity.Property(e => e.ShortUrl)
                .HasMaxLength(300)
                .HasColumnName("Short_Url");
            entity.Property(e => e.SubNavigationBgcolor)
                .HasMaxLength(50)
                .HasColumnName("SubNavigationBGColor");
            entity.Property(e => e.TwitterLink).HasMaxLength(200);
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.Designation).WithMany(p => p.Users)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK_Users_DesignationMaster");

            entity.HasOne(d => d.Parent).WithMany(p => p.UsersParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Users_UserLogin");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Agent_State_StateId");

            entity.HasOne(d => d.UserLogin).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserLoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agent_UserLogin_UserLoginId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
