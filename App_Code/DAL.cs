using System;
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
    public string SalvarPagina1(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"INSERT INTO POLIS_VESTIBULAR_UNIJA_CANDIDATO
                                           (CODCOLIGADA,
                                            NOME,
                                            CIDADE,
                                            ESTADO,
                                            CPF,
                                            DTNASCIMENTO,
                                            EMAIL,
                                            TELEFONE1,
                                            DATAINSCRICAO)
                                     VALUES
                                           (@CODCOLIGADA,
                                            @NOME,
                                            @CIDADE,
                                            @ESTADO,
                                            @CPF,
                                            @DTNASCIMENTO,
                                            @EMAIL,
                                            @TELEFONE1,
                                            @DATAINSCRICAO); SELECT SCOPE_IDENTITY()";

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

    /* Grava os dados da PÁGINA 2 */
    public string SalvarPagina2(Candidato candidato, Curso curso)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"UPDATE POLIS_VESTIBULAR_UNIJA_CANDIDATO
                                   SET
                                       CODCURSO = @CODCURSO,
                                       FORMAINGRESSO = @FORMAINGRESSO,
                                       IDPROCSEL = @IDPROCSEL,
                                       CODTIPOCURSO = @CODTIPOCURSO,
                                       IDHABILITACAOFILIAL = @IDHABILITACAOFILIAL,
                                       CODFILIAL = @CODFILIAL

                                 WHERE
                                       CODIGOINSCRICAO = @CODIGOINSCRICAO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODCURSO", curso.Codigo);
            cmd.Parameters.AddWithValue("FORMAINGRESSO", candidato.FormaIngresso);
            cmd.Parameters.AddWithValue("IDPROCSEL", candidato.IdProcSel);
            cmd.Parameters.AddWithValue("CODTIPOCURSO", curso.CodTipoCurso);
            cmd.Parameters.AddWithValue("IDHABILITACAOFILIAL", curso.IdHabilitacaoFilial);
            cmd.Parameters.AddWithValue("CODFILIAL", curso.CodFilial);
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

        return candidato.CodigoInscricao;
    }

    /* Grava os dados da PÁGINA 3 */
    public string SalvarPagina3(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"UPDATE POLIS_VESTIBULAR_UNIJA_CANDIDATO
                                   SET
                                       CEP = @CEP,
                                       RUA = @RUA,
                                       NUMERO = @NUMERO,
                                       COMPLEMENTO = @COMPLEMENTO,
                                       BAIRRO = @BAIRRO

                                 WHERE
                                       CODIGOINSCRICAO = @CODIGOINSCRICAO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CEP", candidato.CEP);
            cmd.Parameters.AddWithValue("RUA", candidato.Endereco);
            cmd.Parameters.AddWithValue("NUMERO", candidato.Numero);
            cmd.Parameters.AddWithValue("COMPLEMENTO", candidato.Complemento);
            cmd.Parameters.AddWithValue("BAIRRO", candidato.Bairro);
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

        return candidato.CodigoInscricao;
    }

    /* Grava os dados da PÁGINA 4 */
    public string SalvarPagina4(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"UPDATE POLIS_VESTIBULAR_UNIJA_CANDIDATO
                                   SET
                                       CORRACA = @CORRACA,
                                       ESTADOCIVIL = @ESTADOCIVIL,
                                       NACIONALIDADE = @NACIONALIDADE,
                                       SEXO = @SEXO,
                                       CANHOTO = @CANHOTO

                                 WHERE
                                       CODIGOINSCRICAO = @CODIGOINSCRICAO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CORRACA", candidato.CorRaca == string.Empty ? SqlString.Null : candidato.CorRaca);
            cmd.Parameters.AddWithValue("ESTADOCIVIL", candidato.EstadoCivil == string.Empty ? SqlString.Null : candidato.EstadoCivil);
            cmd.Parameters.AddWithValue("NACIONALIDADE", candidato.Nacionalidade == string.Empty ? SqlString.Null : candidato.Nacionalidade);
            cmd.Parameters.AddWithValue("SEXO", candidato.Sexo == string.Empty ? SqlString.Null : candidato.Sexo);
            cmd.Parameters.AddWithValue("CANHOTO", candidato.Canhoto == string.Empty ? SqlString.Null : candidato.Canhoto);
            cmd.Parameters.AddWithValue("DEFICIENTEFISICO", candidato.NecessidadeFisica == 1 ? candidato.NecessidadeFisica : SqlInt32.Null);
            cmd.Parameters.AddWithValue("DEFICIENTEAUDITIVO", candidato.NecessidadeAuditiva == 1 ? candidato.NecessidadeAuditiva : SqlInt32.Null);
            cmd.Parameters.AddWithValue("DEFICIENTEVISUAL", candidato.NecessidadeVisual == 1 ? candidato.NecessidadeVisual : SqlInt32.Null);
            cmd.Parameters.AddWithValue("DEFICIENTEMENTAL", candidato.NecessidadeMental == 1 ? candidato.NecessidadeMental : SqlInt32.Null);
            cmd.Parameters.AddWithValue("RECURSOACESSIBILIDADE", candidato.NecessidadeRecursos != string.Empty ? candidato.NecessidadeRecursos : SqlString.Null);
            cmd.Parameters.AddWithValue("ESPECIFICADEFICIENCIA", candidato.EspecificacaoNecessidade != string.Empty ? candidato.EspecificacaoNecessidade : SqlString.Null);
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

        return candidato.CodigoInscricao;
    }

    /* Grava os dados da PÁGINA 5 */
    public string SalvarPagina5(Candidato candidato)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"UPDATE POLIS_VESTIBULAR_UNIJA_CANDIDATO
                                   SET
                                       GRAUINSTRUCAO = @GRAUINSTRUCAO,
                                       ANOCONCLUSAOEM = @ANOCONCLUSAOEM,
                                       FORMACAO = @FORMACAO,
                                       NOMECOLEGIOEM = @NOMECOLEGIOEM,
                                       ENSINOSUPERIOR = @ENSINOSUPERIOR

                                 WHERE
                                       CODIGOINSCRICAO = @CODIGOINSCRICAO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("GRAUINSTRUCAO", candidato.Escolaridade == string.Empty ? SqlString.Null : candidato.Escolaridade);
            cmd.Parameters.AddWithValue("ANOCONCLUSAOEM", candidato.AnoConclusao == string.Empty ? SqlString.Null : candidato.AnoConclusao);
            cmd.Parameters.AddWithValue("FORMACAO", candidato.Formacao == string.Empty ? SqlString.Null : candidato.Formacao);
            cmd.Parameters.AddWithValue("NOMECOLEGIOEM", candidato.Escola == string.Empty ? SqlString.Null : candidato.Escola);
            cmd.Parameters.AddWithValue("ENSINOSUPERIOR", candidato.EnsinoSuperior == string.Empty ? SqlString.Null : candidato.EnsinoSuperior);
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

        return candidato.CodigoInscricao;
    }

    public bool GravarDisponibilidade(string codigoInscricao, int dia, string periodo)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"INSERT INTO POLIS_VESTIBULAR_UNIJA_DISPONIBILIDADE
                                           (CODIGOINSCRICAO,
                                           DIA,
                                           PERIODO)
                                     VALUES
                                           (@CODIGOINSCRICAO,
                                           @DIA,
                                           @PERIODO)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODIGOINSCRICAO", codigoInscricao);
            cmd.Parameters.AddWithValue("DIA", dia);
            cmd.Parameters.AddWithValue("PERIODO", periodo);

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

    public Polo CarregarEnderecoPolo(Polo polo)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

        try
        {
            cmd.CommandText = @"SELECT CIDADE, LOGRADOURO, NUMERO, BAIRRO, CEP, TELEFONE FROM POLIS_VESTIBULAR_UNIJA_POLO (NOLOCK) WHERE CODPOLO = @CODPOLO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODPOLO", polo.CodPolo);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                polo.Cidade = reader["CIDADE"].ToString();
                polo.Logradouro = reader["LOGRADOURO"].ToString();
                polo.Numero = reader["NUMERO"].ToString();
                polo.Bairro = reader["BAIRRO"].ToString();
                polo.CEP = reader["CEP"].ToString();
                polo.Telefone = reader["TELEFONE"].ToString();
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

        return polo;
    }

    public DataTable CarregarInscritos(Polo polo)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       PUC.CODIGOINSCRICAO,
                                       PUC.NOME,
                                       PUC.TELEFONE1,
                                       PUC.TELEFONE2,
                                       PUC.CPF,
                                       PUC.CIDADE,
                                       PUC.EMAIL,
                                       PUP.NOME AS POLO

                                  FROM
                                       POLIS_VESTIBULAR_UNIJA_CANDIDATO PUC (NOLOCK)

                                       INNER JOIN POLIS_VESTIBULAR_UNIJA_POLO PUP (NOLOCK)
                                       ON PUC.CODCOLIGADA = PUP.CODCOLIGADA
                                       AND PUC.CODPOLO = PUP.CODPOLO

                                 WHERE
                                       PUC.CODPOLO = @CODPOLO

                              ORDER BY
                                       PUP.NOME,
                                       PUC.NOME";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("CODPOLO", polo.CodPolo);

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

    public DataTable CarregarInscritos()
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       PUC.CODIGOINSCRICAO,
                                       PUC.NOME,
                                       PUC.TELEFONE1,
                                       PUC.TELEFONE2,
                                       PUC.CPF,
                                       PUC.CIDADE,
                                       PUC.EMAIL,
                                       PUP.NOME AS POLO

                                  FROM
                                       POLIS_VESTIBULAR_UNIJA_CANDIDATO PUC (NOLOCK)

                                       INNER JOIN POLIS_VESTIBULAR_UNIJA_POLO PUP (NOLOCK)
                                       ON PUC.CODCOLIGADA = PUP.CODCOLIGADA
                                       AND PUC.CODPOLO = PUP.CODPOLO

                              ORDER BY
                                       PUP.NOME,
                                       PUC.NOME";

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

    public DataTable CarregarPolosComInscritos()
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT
                                       PUP.CODPOLO,
                                       PUP.NOME AS POLO

                                  FROM
                                       POLIS_VESTIBULAR_UNIJA_CANDIDATO PUC (NOLOCK)

                                       INNER JOIN POLIS_VESTIBULAR_UNIJA_POLO PUP (NOLOCK)
                                       ON PUC.CODCOLIGADA = PUP.CODCOLIGADA
                                       AND PUC.CODPOLO = PUP.CODPOLO

                              GROUP BY
                                       PUP.CODPOLO,
                                       PUP.NOME

                              ORDER BY
                                       PUP.NOME";

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

    public bool ValidaUsuario(Polo polo)
    {
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            cmd.CommandText = @"SELECT CODPOLO, SENHA FROM POLIS_VESTIBULAR_UNIJA_USUARIOS (NOLOCK) WHERE USUARIO = @USUARIO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("USUARIO", polo.Usuario);

            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                polo.CodPolo = Convert.ToInt32(reader["CODPOLO"]);
                polo.Senha = reader["SENHA"].ToString();
            }

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

        return true;
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