using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PruebaAsync
{
    public partial class MainPage : ContentPage
    {
        private TrabajandoViewModel estado;

        public MainPage()
        {
            InitializeComponent();
            this.estado = new TrabajandoViewModel();
        }

		public async void EnviarMail(object sender, EventArgs e)
        {
			string a = "a";
            var email = DependencyService.Get<IEmail>();
            if (email != null)
            {
				estado.estaTrabajando = true;
				estado.btnHabilitado = false;
				reloj.IsRunning = estado.estaTrabajando;
				enviarMail.IsEnabled = estado.btnHabilitado;

				await Task.Delay (2000);
				email.EnviarEmail (a, a, a, a);
            }
            await DisplayAlert("OK", "La compra fue realizada exitosamente", "OK");
			estado.estaTrabajando = false;
			estado.btnHabilitado = true;
			reloj.IsRunning = estado.estaTrabajando;
			enviarMail.IsEnabled = estado.btnHabilitado;
        }
    }
}
