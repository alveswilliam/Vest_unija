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
            if (txtUsuario.Value == "controlegeral" && txtSenha.Value == "controlegeral")
            {
                Session["codusuario"] = txtUsuario.Value;

                Response.Redirect("Painel.aspx", false);
            }
            else
            {
                Polo polo = new Polo
                {
                    Usuario = txtUsuario.Value
                };

                DAL dal = new DAL();
                dal.ValidaUsuario(polo);

                if (txtSenha.Value == polo.Senha)
                {
                    Session["codpolo"] = polo.CodPolo;
                    Session["codusuario"] = txtUsuario.Value;

                    Response.Redirect("Painel.aspx", false);
                }
                else
                {
                    divMsg.Visible = true;
                    spanMsg.InnerText = "Usuário ou senha inválidos.";
                }
            }

        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Desculpe. Ocorreu um erro durante o processo. Favor entrar em contato com o suporte. Erro: " + ex.Message;
        }
    }
}