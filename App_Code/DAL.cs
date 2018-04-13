﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    public DAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /* Grava os dados da PÁGINA 1 */
    public bool SalvarPagina1(Candidato candidato, Curso curso)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"INSERT INTO POLIS_VESTIBULAR_CANDIDATO
                                           (CODIGOINSCRICAO,
                                            CODCOLIGADA,
                                            NOME,
                                            CIDADE,
                                            ESTADO,
                                            CPF,
                                            DTNASCIMENTO,
                                            EMAIL,
                                            TELEFONE1,
                                            DATAINSCRICAO,
                                            SEXO,
                                            NATURALIDADE,
                                            UFNATURALIDADE,
                                            CODCURSO,
                                            FORMAINGRESSO,
                                            COD_VESTIBULAR,
                                            CODTIPOCURSO,
                                            IDHABILITACAOFILIAL,
                                            CODFILIAL)
                                     VALUES
                                           (@CODIGOINSCRICAO,
                                            @CODCOLIGADA,
                                            @NOME,
                                            @CIDADE,
                                            @ESTADO,
                                            @CPF,
                                            @DTNASCIMENTO,
                                            @EMAIL,
                                            @TELEFONE1,
                                            @DATAINSCRICAO,
                                            @SEXO,
                                            @NATURALIDADE,
                                            @UFNATURALIDADE,
                                            @CODCURSO,
                                            @FORMAINGRESSO,
                                            @COD_VESTIBULAR,
                                            @CODTIPOCURSO,
                                            @IDHABILITACAOFILIAL,
                                            @CODFILIAL)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODIGOINSCRICAO", candidato.CodigoInscricao);
            cmd.Parameters.AddWithValue("CODCOLIGADA", candidato.CodColigada);
            cmd.Parameters.AddWithValue("NOME", candidato.Nome);
            cmd.Parameters.AddWithValue("CIDADE", candidato.Cidade);
            cmd.Parameters.AddWithValue("ESTADO", candidato.UF);
            cmd.Parameters.AddWithValue("CPF", candidato.CPF);
            cmd.Parameters.AddWithValue("DTNASCIMENTO", candidato.DataNascimento);
            cmd.Parameters.AddWithValue("EMAIL", candidato.Email);
            cmd.Parameters.AddWithValue("TELEFONE1", candidato.Telefone);
            cmd.Parameters.AddWithValue("DATAINSCRICAO", DateTime.Now);
            cmd.Parameters.AddWithValue("SEXO", candidato.Sexo);
            cmd.Parameters.AddWithValue("NATURALIDADE", candidato.Naturalidade);
            cmd.Parameters.AddWithValue("UFNATURALIDADE", candidato.UFNaturalidade);
            cmd.Parameters.AddWithValue("CODCURSO", curso.Codigo);
            cmd.Parameters.AddWithValue("FORMAINGRESSO", candidato.FormaIngresso);
            cmd.Parameters.AddWithValue("COD_VESTIBULAR", candidato.IdProcSel);
            cmd.Parameters.AddWithValue("CODTIPOCURSO", curso.CodTipoCurso);
            cmd.Parameters.AddWithValue("IDHABILITACAOFILIAL", curso.IdHabilitacaoFilial);
            cmd.Parameters.AddWithValue("CODFILIAL", curso.CodFilial);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();
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

    public int NovoCodigoInscricao(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"SELECT
                                       MAX(CODIGOINSCRICAO + 1) AS CODIGOINSCRICAO
                                      
                                  FROM
                                       POLIS_VESTIBULAR_CANDIDATO (NOLOCK)";

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                candidato.CodigoInscricao = Convert.ToInt32(reader["CODIGOINSCRICAO"]);

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

        return candidato.CodigoInscricao;
    }

    /* Grava os dados da PÁGINA 2 */
    public bool SalvarPagina2(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"UPDATE POLIS_VESTIBULAR_CANDIDATO
                                   SET
                                       CEP = @CEP,
                                       RUA = @RUA,
                                       NUMERO = @NUMERO,
                                       COMPLEMENTO = @COMPLEMENTO,
                                       BAIRRO = @BAIRRO,
                                       GRAUINSTRUCAO = @GRAUINSTRUCAO

                                 WHERE
                                       CODIGOINSCRICAO = @CODIGOINSCRICAO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CEP", candidato.CEP);
            cmd.Parameters.AddWithValue("RUA", candidato.Endereco);
            cmd.Parameters.AddWithValue("NUMERO", candidato.Numero);
            cmd.Parameters.AddWithValue("COMPLEMENTO", candidato.Complemento);
            cmd.Parameters.AddWithValue("BAIRRO", candidato.Bairro);
            cmd.Parameters.AddWithValue("GRAUINSTRUCAO", candidato.Escolaridade);
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
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        return true;
    }

    public DataTable CarregarPolos(int codColigada)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       CODTIPOCURSO,
                                       NOME POLO

                                  FROM
                                       STIPOCURSO (NOLOCK)

                                 WHERE
                                       CODCOLIGADA = @CODCOLIGADA
                                       AND CODTIPOCURSO IN (11,12,13)
                               
                              ORDER BY
                                       NOME";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", codColigada);

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

    public DataTable CarregarCursos(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                        CONVERT(VARCHAR, SHF.CODCURSO) + '-' + CONVERT(VARCHAR, SCP.IDHABILITACAOFILIAL) + '-' + SCP.CODCURSO + '-' + CONVERT(VARCHAR, SCP.IDPROCSEL) AS CODCURSOIDHAB,
                                        CASE
	                                         WHEN ST.TIPO = 'N' THEN SCP.DESCRICAO + ' - Noturno'
	                                         WHEN ST.TIPO = 'V' THEN SCP.DESCRICAO + ' - Vespertino'
	                                         WHEN ST.TIPO = 'M' THEN SCP.DESCRICAO + ' - Diurno'
	                                         WHEN ST.TIPO = 'I' THEN SCP.DESCRICAO
                                        END CURSO

                                   FROM
                                        SCURSOPROCSEL SCP (NOLOCK)

                                        INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                        ON SCP.CODCOLIGADA = SHF.CODCOLIGADA
                                        AND SCP.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL

                                        INNER JOIN STURNO ST (NOLOCK)
                                        ON SCP.CODCOLIGADA = ST.CODCOLIGADA
                                        AND SHF.CODTURNO = ST.CODTURNO

                                        INNER JOIN SPROCSEL SPS (NOLOCK)
                                        ON SCP.CODCOLIGADA = SPS.CODCOLIGADA
                                        AND SCP.IDPROCSEL = SPS.IDPROCSEL

                                  WHERE
										SCP.CODCOLIGADA = @CODCOLIGADA
										AND SCP.CODFILIAL = @CODFILIAL
                                        AND SCP.CODTIPOCURSO = @CODTIPOCURSO
                                        AND SCP.NUMVAGASTOTAL <> 0

                               ORDER BY
                                        CURSO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCOLIGADA", candidato.CodColigada);
            cmd.Parameters.AddWithValue("CODFILIAL", candidato.CodFilial);
            cmd.Parameters.AddWithValue("CODTIPOCURSO", candidato.CodTipoCurso);

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

    public Candidato RetornarEndereco(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"SELECT
                                       GLOG.TIPO,
                                       GLOG.NOME AS ENDERECO,
                                       GB_INICIO.NOME AS 'BAIRRO_INICIO',
                                       GB_FIM.NOME AS 'BAIRRO_FIM',
                                       GLOC.UF,
                                       GLOC.NOME AS 'CIDADE',
                                       GLOG.CEP

                                  FROM
                                       GLOGRADOURO GLOG (NOLOCK)

                                       LEFT OUTER JOIN GBAIRRO GB_INICIO (NOLOCK)
                                       ON GLOG.CODLOCALIDADE = GB_INICIO.CODLOCALIDADE
                                       AND GLOG.CODBAIRROINI = GB_INICIO.CODBAIRRO

                                       LEFT OUTER JOIN GBAIRRO GB_FIM (NOLOCK)
                                       ON GLOG.CODLOCALIDADE = GB_FIM.CODLOCALIDADE
                                       AND GLOG.CODBAIRROFIM = GB_FIM.CODBAIRRO,

                                       GLOCALIDADE GLOC (NOLOCK)

                                 WHERE
                                       GLOG.CODLOCALIDADE = GLOC.CODLOCALIDADE
                                       AND GLOG.CEP = @CEP

                                 UNION

                                SELECT
                                       '',
                                       '',
                                       '',
                                       '',
                                       GLOC2.UF,
                                       GLOC2.NOME,
                                       GLOC2.CEP

                                  FROM
                                       GLOCALIDADE GLOC2 (NOLOCK)

                                       LEFT JOIN GLOGRADOURO GLOG2 (NOLOCK)
                                       ON GLOC2.CODLOCALIDADE = GLOG2.CODLOCALIDADE

                                 WHERE
                                       GLOC2.CEP = @CEP";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CEP", candidato.CEP);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                candidato.Endereco = string.Format("{0} {1}", reader["TIPO"].ToString(), reader["ENDERECO"].ToString());
                candidato.Bairro = string.Format("{0} {1}", reader["BAIRRO_INICIO"].ToString(), reader["BAIRRO_FIM"].ToString());
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return candidato;
    }
}