using System;
using System.Collections.Generic;

namespace Blazor.API.Data.Entities;

public partial class UserLogin
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string PasswordSalt { get; set; }

    public int RoleType { get; set; }

    public bool IsVerified { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }

    public string ForgetPasswordLink { get; set; }

    public DateTime? ForgetPasswordExpirationDate { get; set; }

    public virtual ICollection<AdminDocuments> AdminDocuments { get; } = new List<AdminDocuments>();

    public virtual ICollection<AdminLeadComment> AdminLeadComment { get; } = new List<AdminLeadComment>();

    public virtual ICollection<AdminLeadConversation> AdminLeadConversation { get; } = new List<AdminLeadConversation>();

    public virtual ICollection<AdminLeadFile> AdminLeadFile { get; } = new List<AdminLeadFile>();

    public virtual ICollection<AdminLeadNote> AdminLeadNote { get; } = new List<AdminLeadNote>();

    public virtual ICollection<LeadComment> LeadComment { get; } = new List<LeadComment>();

    public virtual ICollection<LeadConversation> LeadConversation { get; } = new List<LeadConversation>();

    public virtual ICollection<LeadFile> LeadFile { get; } = new List<LeadFile>();

    public virtual ICollection<LeadLog> LeadLog { get; } = new List<LeadLog>();

    public virtual ICollection<LeadNote> LeadNote { get; } = new List<LeadNote>();

    public virtual ICollection<LeadStoreLog> LeadStoreLog { get; } = new List<LeadStoreLog>();

    public virtual Role RoleTypeNavigation { get; set; }

    public virtual ICollection<Users> UsersParent { get; } = new List<Users>();

    public virtual ICollection<Users> Users { get; } = new List<Users>();
}
