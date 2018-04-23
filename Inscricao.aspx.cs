using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inscricao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("https://selecao.nead.com.br/inscricao_sp.php", false);

            if (!IsPostBack)
            {
                Session["codigoinscricao"] = string.Empty;

                CarregarInformacoesProcesso();
                CarregarFormatadores();
                Polos();
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Houve um erro ao carregar a página. Favor entrar em contato com o suporte. {0}", ex.Message);
        }
    }

    public void Show(string message)
    {
        ClientScriptManager cs = Page.ClientScript;
        String redirect = String.Format(
            "alert('{0}');", message);
        cs.RegisterStartupScript(this.GetType(), "redirecionamento", redirect, true);
    }

    protected void CarregarFormatadores()
    {
        txtDataNascimento.Attributes["onkeyup"] = "formataData(txtDataNascimento, event);";
        txtCPF.Attributes["onkeyup"] = "formataCPF(txtCPF, event)";
        txtCPF.Attributes["onblur"] = "validarCPF(this.value, 'txtCPF')";
        txtTelefone.Attributes["onkeyup"] = "formataTelefone(txtTelefone, event)";
        txtCEP.Attributes["onkeyup"] = "formataInteiro(txtCEP, event)";
    }

    protected void CarregarInformacoesProcesso()
    {
        try
        {
            lblAnoVestibular.Text = "2018";
            divBanner.InnerHtml = "<img src=\"img/banner.jpg\" width=\"1140\" height=\"150\" border=\"0\" class=\"img-responsive\" />";
            spanPagina.InnerText = "Página 1/2";
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Houve um erro ao carregar as informações do processo seletivo. Favor entrar em contato com o suporte. {0}", ex.Message);
        }
    }

    protected void Polos()
    {
        try
        {
            ProcSel procsel = new ProcSel();

            DAL dal = new DAL();

            DataTable dt = dal.CarregarPolos(procsel.CodColigada);

            ddlPolo.DataSource = dt;
            ddlPolo.DataTextField = "POLO";
            ddlPolo.DataValueField = "CODTIPOCURSO";
            ddlPolo.DataBind();
            ddlPolo.Items.Insert(0, "Selecione um polo");
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Houve um erro ao carregar os pólos. Favor entrar em contato com o suporte. {0}", ex.Message);
        }
    }

    protected void ddlPolo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Cursos();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Houve um erro ao carregar os cursos. Favor entrar em contato com o suporte. {0}", ex.Message);
        }
    }

    private void Cursos()
    {
        try
        {
            ProcSel procsel = new ProcSel();

            Candidato candidato = new Candidato()
            {
                CodFilial = procsel.CodFilial,
                CodColigada = procsel.CodColigada,
                CodTipoCurso = Convert.ToInt16(ddlPolo.SelectedValue)
            };

            DAL dal = new DAL();

            DataTable dt = dal.CarregarCursos(candidato);

            ddlCurso.DataSource = dt;
            ddlCurso.DataTextField = "CURSO";
            ddlCurso.DataValueField = "CODCURSOIDHAB";
            ddlCurso.DataBind();
            ddlCurso.Items.Insert(0, "Selecione um curso");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtCEP_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Candidato candidato = new Candidato()
            {
                CEP = txtCEP.Text
            };

            DAL dal = new DAL();
            dal.RetornarEndereco(candidato);

            if (candidato.Endereco != string.Empty)
            {
                txtEndereco.Text = candidato.Endereco;
                txtBairro.Text = candidato.Bairro;

                BloqueiaCamposEndereco();
                linkCepInvalido.Visible = false;
            }
            else
            {
                linkCepInvalido.Visible = true;
                HabilitaCamposEndereco();
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe-nos, houve um erro ao encontrar as informações do CEP. Favor informar o seguinte erro ao suporte: {0}", ex.Message);
        }
    }

    public void BloqueiaCamposEndereco()
    {
        if (txtEndereco.Text == " ")
            txtEndereco.Text = string.Empty;
        if (txtBairro.Text == " ")
            txtBairro.Text = string.Empty;

        if (txtEndereco.Text != string.Empty)
            txtEndereco.Enabled = false;
        else
            txtEndereco.Enabled = true;

        if (txtBairro.Text != string.Empty)
            txtBairro.Enabled = false;
        else
            txtBairro.Enabled = true;
    }

    public void HabilitaCamposEndereco()
    {
        txtEndereco.Text = string.Empty;
        txtNumero.Text = string.Empty;
        txtComplemento.Text = string.Empty;
        txtBairro.Text = string.Empty;

        txtEndereco.Enabled = true;
        txtNumero.Enabled = true;
        txtComplemento.Enabled = true;
        txtBairro.Enabled = true;
    }

    /* Dispara os javascripts responsáveis por habilitar as divs escondidas (divNecessidadeEspecial) */
    protected void DisparaJavaScripts()
    {

        /*---javascript para habilitar a div Necessidade Especial---*/
        string scriptNecessidadeEspecial = "<script>var valor = document.querySelector('input[name=rblPortador]:checked').value; if (valor == 'S') { document.getElementById('divNecessidadeEspecial').style.display = 'block'; } else { document.getElementById('divNecessidadeEspecial').style.display = 'none'; }</script>";
        ClientScript.RegisterStartupScript(GetType(), "nec", scriptNecessidadeEspecial);
    }

    public void LimparMensagem()
    {
        divMsg.Visible = false;
        spanMsg.InnerText = string.Empty;
    }

    protected bool ValidaCamposPagina1()
    {
        if (txtNome.Text == string.Empty) { throw new Exception("O campo Nome completo é de preenchimento obrigatório."); }
        if (txtCidade.Text == string.Empty) { throw new Exception("O campo Cidade é de preenchimento obrigatório."); }
        if (txtUF.Text == string.Empty) { throw new Exception("O campo Estado é de preenchimento obrigatório."); }
        if (txtCPF.Text == string.Empty) { throw new Exception("O campo CPF é de preenchimento obrigatório."); }
        if (txtDataNascimento.Text == string.Empty) { throw new Exception("O campo Data de nascimento é de preenchimento obrigatório."); }
        if (txtEmail.Text == string.Empty) { throw new Exception("O campo E-mail é de preenchimento obrigatório."); }
        if (txtTelefone.Text == string.Empty) { throw new Exception("O campo telefone residencial é de preenchimento obrigatório."); }
        if (rblSexo.SelectedValue == string.Empty) { throw new Exception("O campo Sexo é de preenchimento obrigatório."); }
        if (txtNaturalidade.Text == string.Empty) { throw new Exception("O campo Sexo é de preenchimento obrigatório."); }
        if (txtUFNaturalidade.Text == string.Empty) { throw new Exception("O campo Sexo é de preenchimento obrigatório."); }
        if (ddlPolo.SelectedValue == string.Empty) { throw new Exception("O campo Pólo é de preenchimento obrigatório."); }
        if (ddlCurso.SelectedValue == string.Empty) { throw new Exception("O campo Curso é de preenchimento obrigatório."); }
        if (ddlFormaIngresso.SelectedValue == string.Empty) { throw new Exception("O campo Forma de ingresso é de preenchimento obrigatório."); }

        return true;
    }

    protected bool ValidaCamposPagina2()
    {
        if (txtCEP.Text == string.Empty) { throw new Exception("O campo CEP é de preenchimento obrigatório."); }
        if (txtEndereco.Text == string.Empty) { throw new Exception("O campo Endereço é de preenchimento obrigatório."); }
        if (txtNumero.Text == string.Empty) { throw new Exception("O campo Número do endereço é de preenchimento obrigatório."); }
        if (txtBairro.Text == string.Empty) { throw new Exception("O campo Bairro é de preenchimento obrigatório."); }
        if (ddlEscolaridade.SelectedValue == string.Empty) { throw new Exception("O campo Ensino médio é de preenchimento obrigatório."); }

        return true;
    }

    protected void btnAvancar1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidaCamposPagina1())
            {
                LimparMensagem();
                spanPagina.InnerText = "Página 2/2";

                DAL dal = new DAL();
                ProcSel procsel = new ProcSel();

                Candidato candidato = new Candidato()
                {
                    CodColigada = 1,
                    Nome = txtNome.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUF.Text,
                    CPF = txtCPF.Text.Replace(".", "").Replace("-", ""),
                    DataNascimento = Convert.ToDateTime(txtDataNascimento.Text),
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,
                    Sexo = rblSexo.SelectedValue,
                    Naturalidade = txtNaturalidade.Text,
                    UFNaturalidade = txtUFNaturalidade.Text,
                    FormaIngresso = ddlFormaIngresso.SelectedItem.Text,
                    IdProcSel = Convert.ToInt32(ddlCurso.SelectedValue.Split('-')[3])
                };

                candidato.CodigoInscricao = dal.NovoCodigoInscricao(candidato);

                /* Armazena o código de inscrição em sessão para utilização nas páginas seguintes */
                Session["codigoinscricao"] = candidato.CodigoInscricao;

                Curso curso = new Curso()
                {
                    Codigo = Convert.ToInt32(ddlCurso.SelectedValue.Split('-')[0]),
                    IdHabilitacaoFilial = Convert.ToInt32(ddlCurso.SelectedValue.Split('-')[1]),
                    CodFilial = Convert.ToInt16(procsel.CodFilial),
                    CodTipoCurso = Convert.ToInt16(ddlPolo.SelectedValue)
                };

                /*---- Insert das informações da PÁGINA 1 ----*/
                if (dal.SalvarPagina1(candidato, curso))
                {
                    divPagina1.Visible = false;
                    divPagina2.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe, ocorreu um erro ao avançar para próxima página. Favor entrar em contato com o suporte. {0}", ex.Message);
        }
    }

    protected void btnInscrever_Click(object sender, EventArgs e)
    {
        try
        {
            DAL dal = new DAL();

            Candidato candidato = new Candidato()
            {
                CEP = txtCEP.Text,
                Endereco = txtEndereco.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Bairro = txtBairro.Text,
                Escolaridade = ddlEscolaridade.SelectedValue,
                CodigoInscricao = Convert.ToInt32(Session["codigoinscricao"])
            };

            /*---- Insert das informações da PÁGINA 2 ----*/
            if (dal.SalvarPagina2(candidato))
            {
                EnviarEmail();

                Response.Redirect("Final.aspx", false);
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe, ocorreu um erro ao concluir a inscrição. Favor entrar em contato com o suporte. {0}", ex.Message);
        }
    }

    protected bool EnviarEmail()
    {
        try
        {
            Email email = new Email();
            email.Link = "http://unija.edu.br/polos-unija/";
            email.NomeDestinatario = txtNome.Text;
            email.EnderecoDestinatario = txtEmail.Text;
            email.Instituicao = "UniJÁ";
            email.Assunto = "Bem-vindo à UniJÁ";
            email.Imagem = Server.MapPath("img") + "/email.jpg";            

            if (email.Enviar(email))
                return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return false;
    }
}