using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcSel
/// </summary>
public class ProcSel
{
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    public ProcSel()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CodColigada = 1;
    public int CodFilial = 8;
    public int Codigo = 20181;
}