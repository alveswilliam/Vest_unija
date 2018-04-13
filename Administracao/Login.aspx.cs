using CPConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracao_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["codusuario"] = string.Empty;
                CarregarInformacoesProcesso();
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Desculpe, ocorreu um erro ao carregar a página. Favor entrar em contato com o suporte. Erro: " + ex.Message;
        }
    }

    protected void CarregarInformacoesProcesso()
    {
        try
        {
            divBanner.InnerHtml = "<img src=\"../img/banner.jpg\" width=\"1140\" height=\"150\" border=\"0\" class=\"img-responsive\" />";

            Page.Header.Title = "Vestibular UNIJÁ 2018 - Controle Administrativo";
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Houve um erro ao carregar as informações do processo. Favor entrar em contato com o suporte. " + ex.Message;
        }
    }

    protected void btnAcessar_Click(object sender, EventArgs e)
    {
        try
        {
            //LoginClass login = new LoginClass();
            //object a, b, c;
            //int erro_i = 0;
            //string erro_s = null;

            //b = login.ErrorCode;
            //c = login.ErrorMessage;
            //a = null;

            ////método utilizado para conexão com RM através de ADO
            //login.GetConnectionParams(true, "CORPORERM", txtUsuario.Value.ToString(), txtSenha.Value.ToString(), "F", ref a, ref erro_i, ref erro_s);
            ////método utilizado para verificação do usuário dentro do RM
            //login.GetAccessParams(true, "CORPORERM", txtUsuario.Value.ToString(), txtSenha.Value.ToString(), "F", ref a, ref b, ref c);
            ////O código '0' indica que a conexão foi efetuada com sucesso.

            //if (b.ToString() == "0" || b.ToString() == "11" || b.ToString() == "10" || b.ToString() == "6")
            //{
                //Usuário existe e senha OK, mas sem permissão de acesso ao corpore.net

                DALAdm dal = new DALAdm();
                ProcSel procsel = new ProcSel();

                Usuario usuario = new Usuario()
                {
                    CodColigada = 1,
                    Codigo = txtUsuario.Value,
                    CodFilial = procsel.CodFilial
                };

                if (dal.ValidaUsuario(usuario))
                {
                    Session["usuario"] = usuario;

                    Response.Redirect("Painel.aspx", false);
                }
            //}
            //else
            //{
            //    divMsg.Visible = true;
            //    spanMsg.InnerText = "Usuário ou senha incorretos. Por favor, tente novamente.";
            //}
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Desculpe. Ocorreu um erro durante o processo. Favor entrar em contato com o suporte. Erro: " + ex.Message;
        }
    }
}