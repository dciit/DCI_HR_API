using System;
using System.Collections.Generic;

namespace DCI_HR_API.Models;

public partial class DciPrivilege
{
    public int PrivId { get; set; }

    public string PrivModule { get; set; } = null!;

    public string? PrivComponent { get; set; }

    /// <summary>
    /// CREATE INSERT EDIT DELETE MODIFY
    /// </summary>
    public string PrivAction { get; set; } = null!;

    /// <summary>
    /// BY DEPT  SECT  GRP USER
    /// </summary>
    public string PrivRef { get; set; } = null!;

    public string? PrivVal { get; set; }

    public string? PrivStatus { get; set; }

    public DateTime? PrivCreateDate { get; set; }

    public DateTime? PrivUpdateDate { get; set; }
}
