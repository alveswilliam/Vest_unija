using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    public Usuario()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CodColigada { get; set; }
    public int CodFilial { get; set; }
    public int CodTipoCurso { get; set; }
    public string Codigo { get; set; }
    public int IdProcSel { get; set; }
    public string Permmissao { get; set; }
    public string Polo { get; set; }
}