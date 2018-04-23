using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    public Email()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string EnderecoDestinatario { get; set; }
    public string NomeDestinatario { get; set; }
    public string Instituicao { get; set; }
    public string Assunto { get; set; }
    public string Corpo { get; set; }
    public string Link { get; set; }
    public string Imagem { get; set; }

    public bool Enviar(Email email)
    {
        if (email.EnderecoDestinatario.Trim().Length > 0 && email.Instituicao.Trim().Length > 0 && email.Assunto.Trim().Length > 0)
        {
            try
            {
                MailMessage mensagem;
                mensagem = new MailMessage();
                mensagem.To.Add(email.EnderecoDestinatario);
                mensagem.From = new MailAddress("noreply@faj.br", email.Instituicao);
                mensagem.IsBodyHtml = true;
                mensagem.Subject = email.Assunto;
                mensagem.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                mensagem.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                /* Inclui a imagem no corpo do e-mail. */
                var idConteudo = "Image";
                var imagem = new Attachment(email.Imagem);
                imagem.ContentId = idConteudo;
                imagem.ContentDisposition.Inline = true;
                imagem.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                mensagem.Attachments.Add(imagem);
                mensagem.Body += "<br /><br /><a href='http://unija.edu.br/polos-unija/' target='_blank'><img src=\"cid:" + idConteudo + "\" height=\"1460\" width=\"600\"></a><br />";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                using (smtpClient)
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("noreply@faj.br", "5mtp-r3l4y@F@J");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mensagem);
                }
            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
            return true;
        }
        return false;
    }
}