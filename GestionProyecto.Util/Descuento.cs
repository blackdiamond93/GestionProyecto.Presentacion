using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyecto.Util
{
    public class Descuento
    {
        public static double GetDescuento(int precio)
        {
            double des = precio * 0.10;
            return des;
        }
    }
}
