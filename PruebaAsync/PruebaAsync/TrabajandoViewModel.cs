using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAsync
{
    public class TrabajandoViewModel:NotifyPropertyChangedBase
    {
        private Boolean trab;
        private Boolean btn;

        public Boolean estaTrabajando
        {
            get { return trab; }

            set
            {
                if(trab!=value)
                {
                    trab = value;
                    OnPropertyChanged();
                }
            }
        }

        public Boolean btnHabilitado
        {
            get { return btn; }

            set
            {
                if(btn!=value)
                {
                    btn = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
