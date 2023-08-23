using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Mensagem
{
    public int Id { get; set; }

    public string Texto { get; set; }

    public DateTime Horario { get; set; }
}
