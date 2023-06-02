using System;
using System.Collections.Generic;

namespace DesafioRPA.Model;

public partial class GitDirectory
{
    public int Id { get; set; }

    public string Dpath { get; set; }

    public DateTime? LastPull { get; set; }

    public DateTime? RegisterDate { get; set; }

    public string ParentDirectory { get; set; }

    public virtual WatchDirectory ParentDirectoryNavigation { get; set; }
}
