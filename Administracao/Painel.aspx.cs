using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracao_Painel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario.CodTipoCurso == 0)
                    Response.Redirect("Login.aspx", false);
                else
                    CarregarInformacoesProcesso();

            }
        }
        catch (Exception ex)
        {
            Show(string.Format("Desculpe. Ocorreu um erro ao carregar os inscritos. Favor entrar em contato com o suporte. Erro: {0}", ex.Message));
        }
    }

    public void Show(string message)
    {
        ClientScriptManager cs = Page.ClientScript;
        String redirect = String.Format(
            "alert('{0}');", message);
        cs.RegisterStartupScript(this.GetType(), "redirecionamento", redirect, true);
    }

    protected void CarregarInformacoesProcesso()
    {
        try
        {
            divBanner.InnerHtml = "<img src=\"/img/banner.jpg\" width=\"1140\" height=\"150\" border=\"0\" class=\"img-responsive\" />";

            Page.Header.Title = "Vestibular UniJÁ 2018 - Controle de Administrativo";

            DALAdm dal = new DALAdm();

            Usuario usuario = (Usuario)Session["usuario"];
            usuario.IdProcSel = dal.CarregarIdProcSel(usuario);
            Session["usuario"] = usuario;

            spanPolo.InnerText = usuario.Polo;
            spanUsuario.InnerText = usuario.Codigo;
        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }
    }

    protected void btnVisualizar_Click(object sender, EventArgs e)
    {
        try
        {
            DALAdm dal = new DALAdm();
            Usuario usuario = (Usuario)Session["usuario"];

            DataTable dt = dal.CarregarInscritos(usuario);

            gvInscritos.DataSource = dt;
            gvInscritos.DataBind();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe. Ocorreu um erro ao carregar os inscritos. Favor entrar em contato com o suporte. {0} ", ex.Message);
        }
    }
}