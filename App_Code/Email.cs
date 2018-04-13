using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

    public bool Enviar(string emailDestinatario, string instituicao, string assunto, string corpo)
    {
        if (emailDestinatario.Trim().Length > 0 && instituicao.Trim().Length > 0 && assunto.Trim().Length > 0 && corpo.Trim().Length > 0)
        {
            try
            {
                MailMessage mensagem;
                mensagem = new MailMessage();
                mensagem.To.Add(emailDestinatario);
                //mensagem.To.Add("ti.william@faj.br");
                mensagem.From = new MailAddress("noreply@faj.br", instituicao);
                mensagem.IsBodyHtml = true;
                mensagem.Subject = assunto;
                mensagem.Body = corpo;
                mensagem.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                mensagem.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                //SmtpClient smtpClient = new SmtpClient("smtp-relay.gmail.com", 465);
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