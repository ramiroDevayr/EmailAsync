using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimeKit;
using MailKit.Net.Smtp;
using Xamarin.Forms;
using PruebaAsync.Droid;
using System.Threading.Tasks;

[assembly : Dependency(typeof (EnviarMail))]

namespace PruebaAsync.Droid
{
	public class EnviarMail : IEmail
    {
		#region IEmail implementation

		public void EnviarEmail (string remitente, string destinatario, string asunto, string cuerpo)
		{
			var message = new MimeMessage ();
			message.From.Add(new MailboxAddress("Mundo Arkano", "mundoarkano@arkanosoft.com"));
			message.To.Add(new MailboxAddress("Ramiro Sala", "ramiro.sala85@gmail.com"));
			message.Subject = "Prueba Mundo Arkano";

			message.Body = new TextPart("plain")
			{
				Text = @"Hola, estamos realizando pruebas de Mundo Arkano"
            };

			using (var client = new SmtpClient())
			{
				client.Connect("smtp.office365.com", 587, false);

				// Note: since we don't have an OAuth2 token, disable
				// the XOAUTH2 authentication mechanism.
				client.AuthenticationMechanisms.Remove("XOAUTH2");

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate("mundoarkano@arkanosoft.com", "Passw0rd!");

				client.Send(message);
				client.Disconnect(true);
			}
		}

		#endregion




    }
}