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

    public string SalvarPagina1(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", candidato.CodColigada);
            cmd.Parameters.AddWithValue("NOME", candidato.Nome);
            cmd.Parameters.AddWithValue("CIDADE", candidato.Cidade);
            cmd.Parameters.AddWithValue("ESTADO", candidato.UF);
            cmd.Parameters.AddWithValue("CPF", candidato.CPF);
            cmd.Parameters.AddWithValue("DTNASCIMENTO", candidato.DataNascimento);
            cmd.Parameters.AddWithValue("EMAIL", candidato.Email);
            cmd.Parameters.AddWithValue("TELEFONE1", candidato.Telefone);
            cmd.Parameters.AddWithValue("DATAINSCRICAO", DateTime.Now);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            candidato.CodigoInscricao = Convert.ToString(cmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        return candidato.CodigoInscricao;
    }
}