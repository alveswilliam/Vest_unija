using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Curso
/// </summary>
public class Curso
{
    public Curso()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Nome { get; set; }
    public int Codigo { get; set; }
    public string Turno { get; set; }
    public int IdHabilitacaoFilial { get; set; }
    public int CodTipoCurso { get; set; }
    public string CodColigada { get; set; }
    public int CodFilial { get; set; }
}