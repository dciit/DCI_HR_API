using System;
using System.Collections.Generic;

namespace DCI_HR_API.Models;

public partial class DciwebCounterVisitorLog
{
    public int Id { get; set; }

    public string? Ip { get; set; }

    public DateTime? DtStamp { get; set; }
}
