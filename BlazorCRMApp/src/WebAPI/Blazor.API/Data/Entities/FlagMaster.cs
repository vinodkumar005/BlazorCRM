using System;
using System.Collections.Generic;

namespace Blazor.API.Data.Entities;

public partial class FlagMaster
{
    public long Id { get; set; }

    public string FlagName { get; set; }

    public string FlagColor { get; set; }

    public bool IsActive { get; set; }

    public bool IsDynamic { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
