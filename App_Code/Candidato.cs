using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Candidato
/// </summary>
public class Candidato
{
    public Candidato()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DateTime DataProva { get; set; }
    public string CodigoInscricao { get; set; }
    public string FormaIngresso { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Celular { get; set; }
    public string EstadoCivil { get; set; }
    public string Sexo { get; set; }
    public string Nacionalidade { get; set; }
    public string NomePai { get; set; }
    public string NomeMae { get; set; }
    public string NomeResponsavel { get; set; }
    public string CPFResponsavel { get; set; }
    public string Canhoto { get; set; }
    public string CorRaca { get; set; }
    public string CEP { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string UF { get; set; }
    public string Cidade { get; set; }
    public string TipoInscricao { get; set; }
    public string Curso { get; set; }
    public string ENEM { get; set; }
    public string NotaENEM { get; set; }
    public int NecessidadeAuditiva { get; set; }
    public int NecessidadeFisica { get; set; }
    public int NecessidadeVisual { get; set; }
    public int NecessidadeMental { get; set; }
    public string EspecificacaoNecessidade { get; set; }
    public string NecessidadeRecursos { get; set; }
    public string Escolaridade { get; set; }
    public string EnsinoSuperior { get; set; }
    public string AnoConclusao { get; set; }
    public string Formacao { get; set; }
    public string Escola { get; set; }
    public string Ingles { get; set; }
    public string Espanhol { get; set; }
    public string OutraLingua { get; set; }
    public string DisponibilidadeCursoExtra { get; set; }
    public string EmpresaTrabalho { get; set; }
    public string EnqueteMarketing { get; set; }
    public string EnqueteMarketingQual { get; set; }
    public string RAAmigo { get; set; }
    public int CodColigada { get; set; }
    public int CodFilial { get; set; }
    public int CodTipoCurso { get; set; }
    public int CodCupomPromocional { get; set; }
    public int CodPolo { get; set; }
    public int IdProcSel { get; set; }
}