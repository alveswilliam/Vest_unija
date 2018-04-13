using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Final : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CarregarInformacoesProcesso();
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            spanMsg.InnerText = "Houve um erro ao carregar as página. Favor entrar em contato com o suporte. " + ex.Message;
        }

    }

    protected void CarregarInformacoesProcesso()
    {
        try
        {
            //Page.Header.Title = "Vestibular UNIJÁ 2018";
            divBanner.InnerHtml = "<img src=\"img/banner.jpg\" width=\"1140\" height=\"150\" border=\"0\" class=\"img-responsive\" />";
            linkNova.HRef = "http://webserver.faj.br/vestibularunijateste/Inscricao.aspx";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}