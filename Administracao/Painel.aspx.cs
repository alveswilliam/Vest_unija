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
                CarregarInformacoesProcesso();

                if (Session["codusuario"].ToString() == "controlegeral")
                {
                    PolosInscritos(0);
                    divPolo.Visible = true;
                }
                else
                    VisualizarInscritos(Convert.ToInt32(Session["codpolo"]));
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

            Page.Header.Title = "Vestibular UNIJÁ 2018 - Controle de Administrativo";

            spanUsuario.InnerText = Session["codusuario"].ToString();
            linkSair.HRef = "Login.aspx";
        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }
    }

    protected void VisualizarInscritos(int codPolo)
    {
        try
        {
            if (codPolo == 0)
            {
                DAL dal = new DAL();
                DataTable dt = dal.CarregarInscritos();

                gvInscritos.DataSource = dt;
                gvInscritos.DataBind();
            }
            else
            {
                Polo polo = new Polo
                {
                    CodPolo = codPolo
                };

                DAL dal = new DAL();
                DataTable dt = dal.CarregarInscritos(polo);

                gvInscritos.DataSource = dt;
                gvInscritos.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void PolosInscritos(int codPolo)
    {
        try
        {
            DAL dal = new DAL();
            DataTable dt = dal.CarregarPolosComInscritos();

            ddlPolo.DataSource = dt;
            ddlPolo.DataTextField = "POLO";
            ddlPolo.DataValueField = "CODPOLO";
            ddlPolo.DataBind();
            ddlPolo.Items.Insert(0, new ListItem("Selecione um polo", ""));
            ddlPolo.Items.Insert(1, new ListItem("Todos inscritos", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlPolo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Polo polo = new Polo
            {
                CodPolo = Convert.ToInt32(ddlPolo.SelectedValue)
            };

            DAL dal = new DAL();
            DataTable dt = new DataTable();

            if (polo.CodPolo == 0)
                dt = dal.CarregarInscritos();
            else
                dt = dal.CarregarInscritos(polo);

            gvInscritos.DataSource = dt;
            gvInscritos.DataBind();
        }
        catch (Exception ex)
        {
            Show(string.Format("Desculpe. Ocorreu um erro ao carregar os inscritos. Favor entrar em contato com o suporte. Erro: {0}", ex.Message));
        }
    }
}