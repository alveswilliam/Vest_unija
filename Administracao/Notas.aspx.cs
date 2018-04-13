using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracao_Notas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                VerificaPerfil();
                CarregarInformacoesProcesso();
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe. Ocorreu um erro ao carregar a página. Favor entrar em contato com o suporte. {0} ", ex.Message);
        }
    }

    protected void VerificaPerfil()
    {
        try
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario.Permmissao == string.Empty || usuario.Permmissao == null)
                Response.Redirect("Login.aspx", false);
        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }
    }

    protected void CarregarInformacoesProcesso()
    {
        try
        {
            divBanner.InnerHtml = "<img src=\"../img/banner.jpg\" width=\"1140\" height=\"150\" border=\"0\" class=\"img-responsive\" />";

            Usuario usuario = (Usuario)Session["usuario"];
            spanUsuario.InnerText = usuario.Codigo;
            spanPolo.InnerText = usuario.Polo;

            Candidatos();
        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }
    }

    protected void Candidatos()
    {
        try
        {
            Usuario usuario = (Usuario)Session["usuario"];

            DALAdm dal = new DALAdm();
            DataTable dt = dal.CarregarCandidatos(usuario);

            gvNotaCandidatos.DataSource = dt;
            gvNotaCandidatos.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvNotaCandidatos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow linha = gvNotaCandidatos.Rows[e.RowIndex];

            TextBox nota = (TextBox)linha.FindControl("txtNota");

            Usuario usuario = (Usuario)Session["usuario"];

            Candidato candidato = new Candidato()
            {
                CodColigada = usuario.CodColigada,
                Nota = Convert.ToDouble(nota.Text),                
                CodigoInscricao = Convert.ToInt32(linha.Cells[0].Text)
            };

            DALAdm dal = new DALAdm();
            dal.InserirNota(candidato);

            gvNotaCandidatos.EditIndex = -1;
            Candidatos();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe. Ocorreu um erro ao inserir a nota. Favor entrar em contato com o suporte. {0} ", ex.Message);
        }
    }

    protected void gvNotaCandidatos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvNotaCandidatos.EditIndex = e.NewEditIndex;
            Candidatos();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe. Ocorreu um erro ao editar o candidato. Favor entrar em contato com o suporte. {0} ", ex.Message);
        }
    }

    protected void gvNotaCandidatos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvNotaCandidatos.EditIndex = -1;
            Candidatos();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = string.Format("Desculpe. Ocorreu um erro ao cancelar o lançamento da nota. Favor entrar em contato com o suporte. {0} ", ex.Message);
        }
    }
}