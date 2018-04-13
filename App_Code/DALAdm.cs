using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALAdm
/// </summary>
public class DALAdm
{
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    public DALAdm()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CarregarIdProcSel(Usuario usuario)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"SELECT DISTINCT IDPROCSEL FROM SCURSOPROCSEL WHERE CODCOLIGADA = @CODCOLIGADA AND CODTIPOCURSO = @CODTIPOCURSO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", usuario.CodColigada);
            cmd.Parameters.AddWithValue("CODTIPOCURSO", usuario.CodTipoCurso);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                usuario.IdProcSel = Convert.ToInt32(reader["IDPROCSEL"]);
            }

            reader.Close();
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

        return usuario.IdProcSel;
    }

    public DataTable CarregarInscritos(Usuario usuario)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       PVC.CODIGOINSCRICAO,
                                       PVC.NOME,
                                       PVC.TELEFONE1,
                                       PVC.CPF,
                                       PVC.CIDADE,
                                       PVC.EMAIL,
                                       STC.NOME AS POLO

                                  FROM
                                       POLIS_VESTIBULAR_CANDIDATO PVC (NOLOCK)

                                       INNER JOIN SCURSOPROCSEL SCP (NOLOCK) ON
                                       PVC.CODCOLIGADA = SCP.CODCOLIGADA
                                       AND PVC.COD_VESTIBULAR = SCP.IDPROCSEL
                                       AND PVC.IDHABILITACAOFILIAL = SCP.IDHABILITACAOFILIAL

                                       INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK) ON
                                       SCP.CODCOLIGADA = SHF.CODCOLIGADA
                                       AND SCP.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL

                                       INNER JOIN STURNO STU (NOLOCK) ON
                                       SCP.CODCOLIGADA = STU.CODCOLIGADA
                                       AND SHF.CODTURNO = STU.CODTURNO

                                       INNER JOIN SPROCSEL SPR (NOLOCK) ON
                                       SCP.CODCOLIGADA = SPR.CODCOLIGADA
                                       AND SCP.IDPROCSEL = SPR.IDPROCSEL

                                       INNER JOIN STIPOCURSO STC (NOLOCK) ON
                                       SCP.CODCOLIGADA = STC.CODCOLIGADA
                                       AND SCP.CODTIPOCURSO = STC.CODTIPOCURSO

                                 WHERE
                                       PVC.CODCOLIGADA = @CODCOLIGADA
                                       AND PVC.COD_VESTIBULAR = @COD_VESTIBULAR
                                       AND PVC.CODTIPOCURSO = @CODTIPOCURSO
                                       AND PVC.CODFILIAL = @CODFILIAL

                              ORDER BY
                                       STC.NOME,
                                       PVC.NOME";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", usuario.CodColigada);
            cmd.Parameters.AddWithValue("COD_VESTIBULAR", usuario.IdProcSel);
            cmd.Parameters.AddWithValue("CODTIPOCURSO", usuario.CodTipoCurso);
            cmd.Parameters.AddWithValue("CODFILIAL", usuario.CodFilial);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            reader.Close();
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

        return dt;
    }

    public DataTable CarregarPolosComInscritos()
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT NOME AS POLO FROM STIPOCURSO (NOLOCK) WHERE CODCOLIGADA = 1 AND CODTIPOCURSO = 11";

            cmd.Parameters.Clear();

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            reader.Close();
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

        return dt;
    }

    public bool ValidaUsuario(Usuario usuario)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT 
                                       ZMDU.CODTIPOCURSO,
									   ZMDU.GRUPO,
									   STC.NOME AS POLO

                                  FROM
                                       ZMDLIBUSERAPP ZMDU (NOLOCK)

									   INNER JOIN STIPOCURSO STC (NOLOCK)
									   ON ZMDU.CODCOLIGADA = STC.CODCOLIGADA
									   AND ZMDU.CODTIPOCURSO = STC.CODTIPOCURSO

                                 WHERE
                                       ZMDU.CODCOLIGADA = @CODCOLIGADA
                                       AND ZMDU.CODAPLICACAO = @CODAPLICACAO
                                       AND ZMDU.CODFILIAL = @CODFILIAL
                                       AND ZMDU.USUARIO = @USUARIO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", usuario.CodColigada);
            cmd.Parameters.AddWithValue("CODAPLICACAO", "VE");
            cmd.Parameters.AddWithValue("CODFILIAL", usuario.CodFilial);
            cmd.Parameters.AddWithValue("USUARIO", usuario.Codigo);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario.CodTipoCurso = Convert.ToInt16(reader["CODTIPOCURSO"]);
                usuario.Permmissao = reader["GRUPO"].ToString();
                usuario.Polo = reader["POLO"].ToString();
            }

            reader.Close();
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

        return true;
    }

    public DataTable CarregarCandidatos(Usuario usuario)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       PVC.CODIGOINSCRICAO,
                                       PVC.NOME,
                                       PVC.NOTATOTAL,
									   PVC.STATUS

                                  FROM
                                       POLIS_VESTIBULAR_CANDIDATO PVC (NOLOCK)

                                       INNER JOIN SCURSOPROCSEL SCP (NOLOCK) ON
                                       PVC.CODCOLIGADA = SCP.CODCOLIGADA
                                       AND PVC.COD_VESTIBULAR = SCP.IDPROCSEL
                                       AND PVC.IDHABILITACAOFILIAL = SCP.IDHABILITACAOFILIAL

                                       INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK) ON
                                       SCP.CODCOLIGADA = SHF.CODCOLIGADA
                                       AND SCP.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL

                                       INNER JOIN STURNO STU (NOLOCK) ON
                                       SCP.CODCOLIGADA = STU.CODCOLIGADA
                                       AND SHF.CODTURNO = STU.CODTURNO

                                       INNER JOIN SPROCSEL SPR (NOLOCK) ON
                                       SCP.CODCOLIGADA = SPR.CODCOLIGADA
                                       AND SCP.IDPROCSEL = SPR.IDPROCSEL

                                       INNER JOIN STIPOCURSO STC (NOLOCK) ON
                                       SCP.CODCOLIGADA = STC.CODCOLIGADA
                                       AND SCP.CODTIPOCURSO = STC.CODTIPOCURSO

                                 WHERE
                                       PVC.CODCOLIGADA = @CODCOLIGADA
                                       AND PVC.COD_VESTIBULAR = @COD_VESTIBULAR
                                       AND PVC.CODTIPOCURSO = @CODTIPOCURSO
                                       AND PVC.CODFILIAL = @CODFILIAL

							  ORDER BY
									   PVC.NOME";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", usuario.CodColigada);
            cmd.Parameters.AddWithValue("COD_VESTIBULAR", usuario.IdProcSel);
            cmd.Parameters.AddWithValue("CODTIPOCURSO", usuario.CodTipoCurso);
            cmd.Parameters.AddWithValue("CODFILIAL", usuario.CodFilial);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            reader.Close();
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

        return dt;
    }

    public DataTable CarregarPolos()
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       SCP.CODTIPOCURSO,
                                       STC.NOME AS POLO,
                                       CONVERT(VARCHAR, PVC.CODCOLIGADA) + '|' + CONVERT(VARCHAR,PVC.COD_VESTIBULAR) + '|' + CONVERT(VARCHAR,PVC.CODTIPOCURSO) + '|' + CONVERT(VARCHAR,PVC.CODFILIAL) VALOR

                                  FROM
                                       POLIS_VESTIBULAR_CANDIDATO PVC (NOLOCK)

                                       INNER JOIN SCURSOPROCSEL SCP (NOLOCK)
                                       ON PVC.CODCOLIGADA = SCP.CODCOLIGADA
                                       AND PVC.CODTIPOCURSO = SCP.CODTIPOCURSO
									   AND PVC.IDHABILITACAOFILIAL = SCP.IDHABILITACAOFILIAL

									   INNER JOIN STIPOCURSO STC (NOLOCK)
									   ON PVC.CODCOLIGADA = STC.CODCOLIGADA
									   AND PVC.CODTIPOCURSO = STC.CODTIPOCURSO

                                 WHERE
									   STC.NOME LIKE 'Polo%'

                              GROUP BY
                                       SCP.CODTIPOCURSO,
                                       STC.NOME,
                                       PVC.CODCOLIGADA,
									   PVC.COD_VESTIBULAR,
									   PVC.CODTIPOCURSO,
									   PVC.CODFILIAL

                              ORDER BY
                                       STC.NOME";

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            reader.Close();
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

        return dt;
    }

    public bool InserirNota(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"UPDATE POLIS_VESTIBULAR_CANDIDATO
                                   SET
                                       NOTATOTAL = @NOTATOTAL,
                                       STATUS = @STATUS

                                 WHERE
                                       CODCOLIGADA = @CODCOLIGADA
                                       AND CODIGOINSCRICAO = @CODIGOINSCRICAO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("NOTATOTAL", candidato.Nota);
            cmd.Parameters.AddWithValue("STATUS", candidato.Nota >= 3 ? "A" : "R");
            cmd.Parameters.AddWithValue("CODCOLIGADA", candidato.CodColigada);
            cmd.Parameters.AddWithValue("CODIGOINSCRICAO", candidato.CodigoInscricao);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return true;
    }
}