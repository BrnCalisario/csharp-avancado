using System;
using System.Collections.Generic;

namespace DesafioRPA.Model;

public partial class WatchDirectory
{
    public string Tag { get; set; }

    public string Dpath { get; set; }

    public virtual ICollection<GitDirectory> GitDirectories { get; set; } = new List<GitDirectory>();
}
