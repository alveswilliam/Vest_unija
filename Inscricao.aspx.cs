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
            Response.Redirect("https://selecao.nead.com.br/inscricao_sp.php", false);

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
            spanMsg.InnerText = "Houve um erro ao carregar a página. Favor entrar em contato com o suporte. " + ex.Message;
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
        rblPortador.Attributes["onchange"] = "habilitaCamposNecessidadeEspecial()";
        txtEspecificacao.Attributes["onkeyup"] = "checkMaxLen(this,121)";
        txtRecursos.Attributes["onkeyup"] = "checkMaxLen(this,121)";
    }

    protected void CarregarInformacoesProcesso()
    {
        try
        {
            lblAnoVestibular.Text = "2018";
            //Page.Header.Title = "Vestibular UNIJÁ " + lblAnoVestibular.Text;
            divBanner.InnerHtml = "<img src=\"img/banner.jpg\" width=\"1140\" height=\"150\" border=\"0\" class=\"img-responsive\" />";
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Houve um erro ao carregar as informações do processo seletivo. Favor entrar em contato com o suporte. " + ex.Message;
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
            spanMsg.InnerText = "Houve um erro ao carregar os pólos. Favor entrar em contato com o suporte. " + ex.Message;
        }
    }

    protected void ddlPolo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Cursos();
            //EnderecoPolo();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Houve um erro ao carregar os cursos. Favor entrar em contato com o suporte. " + ex.Message;
        }
    }

    private void EnderecoPolo()
    {
        try
        {
            Polo polo = new Polo
            {
                CodPolo = Convert.ToInt32(ddlPolo.SelectedValue)
            };

            DAL dal = new DAL();
            dal.CarregarEnderecoPolo(polo);

            if (polo.Cidade != string.Empty)
            {
                divInformacoesPolo.Visible = true;

                spanCidade.InnerText = polo.Cidade;
                spanLogradouro.InnerText = polo.Logradouro;
                spanNumero.InnerText = polo.Numero;
                spanBairro.InnerText = polo.Bairro;
                spanCEP.InnerText = polo.CEP;
                //spanTelefone.InnerText = polo.Telefone;
            }
            else
                divInformacoesPolo.Visible = false;
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Houve um erro ao carregar o endereço do pólo. Favor entrar em contato com o suporte. " + ex.Message;
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

    protected void ddlEscolaridade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEscolaridade.SelectedValue == "7")
        {
            lblAnoConclusao.Text = "Mês e ano de conclusão";
            ddlAnoConclusao.Items.Clear();
            ddlAnoConclusao.Items.Add("Selecione");
            ddlAnoConclusao.Items.Add("Dezembro/2017");
            ddlAnoConclusao.Items.Add("Julho/2017");
            ddlAnoConclusao.Items.Add("Antes de 2017");
        }
        else if (ddlEscolaridade.SelectedValue == "6")
        {
            lblAnoConclusao.Text = "Mês e ano que irá concluir";
            ddlAnoConclusao.Items.Clear();
            ddlAnoConclusao.Items.Add("Selecione");
            ddlAnoConclusao.Items.Add("Dezembro/2018");
            ddlAnoConclusao.Items.Add("Julho/2018");
            ddlAnoConclusao.Items.Add("A partir de 2019");
        }
        else
        {
            ddlAnoConclusao.Items.Clear();
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
            spanMsg.InnerText = "Desculpe-nos, houve um erro ao encontrar as informações do CEP. Favor informar o seguinte erro ao suporte: " + ex.Message;
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
        if (txtNome.Text == String.Empty) { throw new Exception("O campo Nome completo é de preenchimento obrigatório."); }
        if (txtCidade.Text == String.Empty) { throw new Exception("O campo Cidade é de preenchimento obrigatório."); }
        if (txtUF.Text == String.Empty) { throw new Exception("O campo Estado é de preenchimento obrigatório."); }
        if (txtCPF.Text == String.Empty) { throw new Exception("O campo CPF é de preenchimento obrigatório."); }
        if (txtDataNascimento.Text == String.Empty) { throw new Exception("O campo Data de nascimento é de preenchimento obrigatório."); }
        if (txtEmail.Text == String.Empty) { throw new Exception("O campo E-mail é de preenchimento obrigatório."); }
        if (txtTelefone.Text == String.Empty) { throw new Exception("O campo telefone residencial é de preenchimento obrigatório."); }

        return true;
    }

    protected bool ValidaCamposPagina2()
    {
        if (ddlPolo.SelectedValue == string.Empty) { throw new Exception("O campo Pólo é de preenchimento obrigatório."); }
        if (ddlCurso.SelectedValue == String.Empty) { throw new Exception("O campo Curso é de preenchimento obrigatório."); }
        if (ddlFormaIngresso.SelectedValue == string.Empty) { throw new Exception("O campo Forma de ingresso é de preenchimento obrigatório."); }

        return true;
    }

    protected bool ValidaCamposPagina3()
    {
        if (txtCEP.Text == String.Empty) { throw new Exception("O campo CEP é de preenchimento obrigatório."); }
        if (txtEndereco.Text == String.Empty) { throw new Exception("O campo Endereço é de preenchimento obrigatório."); }
        if (txtNumero.Text == String.Empty) { throw new Exception("O campo Número do endereço é de preenchimento obrigatório."); }
        if (txtBairro.Text == String.Empty) { throw new Exception("O campo Bairro é de preenchimento obrigatório."); }

        return true;
    }

    protected bool ValidaCamposPagina4()
    {
        if (ddlCorRaca.SelectedValue == String.Empty) { throw new Exception("O campo Cor/Raça é de preenchimento obrigatório."); }
        if (ddlEstadoCivil.SelectedValue == String.Empty) { throw new Exception("O campo Estado civil é de preenchimento obrigatório."); }
        if (ddlNacionalidade.SelectedValue == String.Empty) { throw new Exception("O campo Nacionalidade é de preenchimento obrigatório."); }
        if (rblSexo.SelectedValue == String.Empty) { throw new Exception("O campo Sexo é de preenchimento obrigatório."); }
        if (rblCanhoto.SelectedValue == String.Empty) { throw new Exception("O campo Canhoto é de preenchimento obrigatório."); }

        if (rblPortador.SelectedValue == "S")
        {
            int necessidade = 0;
            for (int i = 0; i < 5; i++)
            {
                if (cblNecessidade.Items[i].Selected) { necessidade = 1; }
            }
            if (necessidade == 0) { throw new Exception("É necessário indicar ao menos um tipo de Necessidade especial."); }

            if (txtEspecificacao.Text == String.Empty) { throw new Exception("É necessário especificar o tipo de necessidade especial."); }
            if (txtRecursos.Text == String.Empty) { throw new Exception("É necessário indicar a necessidade de recursos adicionais para realização da prova."); }
        }

        return true;
    }

    protected bool ValidaCamposPagina5()
    {
        if (ddlEscolaridade.SelectedValue == String.Empty) { throw new Exception("O campo Ensino médio é de preenchimento obrigatório."); }
        if (ddlAnoConclusao.SelectedValue == String.Empty) { throw new Exception("O campo Ano de conclusão é de preenchimento obrigatório."); }
        if (ddlFormacao.SelectedValue == String.Empty) { throw new Exception("O campo Formação é de preenchimento obrigatório."); }
        if (txtEscola.Text == String.Empty) { throw new Exception("O campo Escola é de preenchimento obrigatório."); }
        if (ddlEnsinoSuperior.SelectedValue == string.Empty) { throw new Exception("O campo Ensino Superior é de preenchimento obrigatório."); }

        return true;
    }

    protected bool ValidaCamposDisponibilidade()
    {
        bool diaSelecionado = false;

        foreach (ListItem item in cbSegunda.Items)
        {
            if (item.Selected)
                diaSelecionado = true;
        }

        foreach (ListItem item in cbTerca.Items)
        {
            if (item.Selected)
                diaSelecionado = true;
        }

        foreach (ListItem item in cbQuarta.Items)
        {
            if (item.Selected)
                diaSelecionado = true;
        }

        foreach (ListItem item in cbQuinta.Items)
        {
            if (item.Selected)
                diaSelecionado = true;
        }

        foreach (ListItem item in cbSexta.Items)
        {
            if (item.Selected)
                diaSelecionado = true;
        }

        foreach (ListItem item in cbSabado.Items)
        {
            if (item.Selected)
                diaSelecionado = true;
        }

        return diaSelecionado;
    }

    protected void btnAvancar1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidaCamposPagina1())
            {
                LimparMensagem();

                Candidato candidato = new Candidato()
                {
                    CodColigada = 1,
                    Nome = txtNome.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUF.Text,
                    CPF = txtCPF.Text.Replace(".", "").Replace("-", ""),
                    DataNascimento = Convert.ToDateTime(txtDataNascimento.Text),
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text
                };

                /*---- Insert das informações da PÁGINA 1 ----*/
                DAL dal = new DAL();
                candidato.CodigoInscricao = dal.SalvarPagina1(candidato);

                /* Armazena o código de inscrição em sessão para utilização nas páginas seguintes */
                Session["codigoinscricao"] = candidato.CodigoInscricao;

                divPagina1.Visible = false;
                divPagina2.Visible = true;
            }

        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = ex.Message;
        }
    }

    protected void btnAvancar2_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidaCamposPagina2())
            {
                LimparMensagem();

                ProcSel procsel = new ProcSel();

                Candidato candidato = new Candidato()
                {
                    CodPolo = Convert.ToInt32(ddlPolo.SelectedValue),
                    FormaIngresso = ddlFormaIngresso.SelectedItem.Text,
                    IdProcSel = Convert.ToInt32(ddlCurso.SelectedValue.Split('-')[3]),
                    CodigoInscricao = Session["codigoinscricao"].ToString()
                };

                Curso curso = new Curso()
                {
                    Codigo = Convert.ToInt32(ddlCurso.SelectedValue.Split('-')[0]),
                    IdHabilitacaoFilial = Convert.ToInt32(ddlCurso.SelectedValue.Split('-')[1]),
                    CodFilial = Convert.ToInt16(procsel.CodFilial),
                    CodTipoCurso = Convert.ToInt16(ddlPolo.SelectedValue)
                };

                /*---- Insert das informações da PÁGINA 2 ----*/
                DAL dal = new DAL();
                dal.SalvarPagina2(candidato, curso);

                divPagina1.Visible = false;
                divPagina2.Visible = false;
                divPagina3.Visible = true;
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = ex.Message;
        }
    }

    protected void btnAvancar3_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidaCamposPagina3())
            {
                LimparMensagem();

                Candidato candidato = new Candidato()
                {
                    CEP = txtCEP.Text,
                    Endereco = txtEndereco.Text,
                    Numero = txtNumero.Text,
                    Complemento = txtComplemento.Text,
                    Bairro = txtBairro.Text,
                    CodigoInscricao = Session["codigoinscricao"].ToString()
                };

                /*---- Insert das informações da PÁGINA 3 ----*/
                DAL dal = new DAL();
                dal.SalvarPagina3(candidato);

                divPagina1.Visible = false;
                divPagina2.Visible = false;
                divPagina3.Visible = false;
                divPagina4.Visible = true;
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = ex.Message;
        }
    }

    protected void btnAvancar4_Click(object sender, EventArgs e)
    {
        try
        {
            //if (ValidaCamposPagina4())
            //{
            Candidato candidato = new Candidato()
            {
                CorRaca = ddlCorRaca.SelectedValue,
                EstadoCivil = ddlEstadoCivil.SelectedValue,
                Nacionalidade = ddlNacionalidade.SelectedValue,
                Sexo = rblSexo.SelectedValue,
                Canhoto = rblCanhoto.SelectedValue,
                NecessidadeAuditiva = cblNecessidade.Items[0].Selected ? 1 : 0,
                NecessidadeFisica = cblNecessidade.Items[1].Selected ? 1 : 0,
                NecessidadeVisual = cblNecessidade.Items[2].Selected ? 1 : 0,
                NecessidadeMental = cblNecessidade.Items[3].Selected ? 1 : 0,
                EspecificacaoNecessidade = txtEspecificacao.Text,
                NecessidadeRecursos = txtRecursos.Text,
                CodigoInscricao = Session["codigoinscricao"].ToString()
            };

            /*---- Insert das informações da PÁGINA 4 ----*/
            DAL dal = new DAL();
            dal.SalvarPagina4(candidato);

            divPagina1.Visible = false;
            divPagina2.Visible = false;
            divPagina3.Visible = false;
            divPagina4.Visible = false;
            divPagina5.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = ex.Message;
        }
    }

    protected void btnAvancar5_Click(object sender, EventArgs e)
    {
        try
        {
            //if (ValidaCamposPagina5())
            //{
            Candidato candidato = new Candidato()
            {
                Escolaridade = ddlEscolaridade.SelectedValue,
                AnoConclusao = ddlAnoConclusao.SelectedValue,
                Formacao = ddlFormacao.SelectedValue,
                Escola = txtEscola.Text,
                EnsinoSuperior = ddlEnsinoSuperior.SelectedValue,
                CodigoInscricao = Session["codigoinscricao"].ToString()
            };

            /*---- Insert das informações da PÁGINA 4 ----*/
            DAL dal = new DAL();
            dal.SalvarPagina5(candidato);

            divPagina1.Visible = false;
            divPagina2.Visible = false;
            divPagina3.Visible = false;
            divPagina4.Visible = false;
            divPagina5.Visible = false;
            divPagina6.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = ex.Message;
        }
    }

    protected void btnInscrever_Click(object sender, EventArgs e)
    {
        try
        {
            DAL dal = new DAL();
            Candidato candidato = new Candidato()
            {
                CodigoInscricao = Session["codigoinscricao"].ToString()
            };

            /* Salva as informações indicadas nos campos de disponibilidade de dias e períodos */

            //if (ValidaCamposDisponibilidade())
            //{
            foreach (ListItem item in cbSegunda.Items)
            {
                if (item.Selected)
                {
                    dal.GravarDisponibilidade(candidato.CodigoInscricao, 2, item.Value);
                }
            }

            foreach (ListItem item in cbTerca.Items)
            {
                if (item.Selected)
                {
                    dal.GravarDisponibilidade(candidato.CodigoInscricao, 3, item.Value);
                }
            }

            foreach (ListItem item in cbQuarta.Items)
            {
                if (item.Selected)
                {
                    dal.GravarDisponibilidade(candidato.CodigoInscricao, 4, item.Value);
                }
            }

            foreach (ListItem item in cbQuinta.Items)
            {
                if (item.Selected)
                {
                    dal.GravarDisponibilidade(candidato.CodigoInscricao, 5, item.Value);
                }
            }

            foreach (ListItem item in cbSexta.Items)
            {
                if (item.Selected)
                {
                    dal.GravarDisponibilidade(candidato.CodigoInscricao, 6, item.Value);
                }
            }

            foreach (ListItem item in cbSabado.Items)
            {
                if (item.Selected)
                {
                    dal.GravarDisponibilidade(candidato.CodigoInscricao, 7, item.Value);
                }
            }
            //}
            //else
            //{
            //    Show("Favor selecionar ao menos um dia e período de disponibilidade");
            //}

            Response.Redirect("Final.aspx", false);
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = ex.Message;
        }
    }
}