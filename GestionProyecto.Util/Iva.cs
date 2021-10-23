using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyecto.Util
{
    public class Iva
    {
        public static double GetIva(double precio)
        {
            double Iva = precio * 1.15;
            return Iva;
        }
    }
}
