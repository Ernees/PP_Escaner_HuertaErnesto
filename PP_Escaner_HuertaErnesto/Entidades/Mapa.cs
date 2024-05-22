using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        int ancho;

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        public int Alto { get => alto; }
        public int Ancho { get => ancho; }
        public int Superficie { get => Alto * Ancho; }

        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            bool retorno;
            retorno = false;
            if (m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie))
            {
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendLine($"Cód. de barras: {this.Barcode}.");
            retorno.AppendLine($"Superficie: {this.Ancho} * {this.Alto} = {this.Superficie} cm2.\n");
            return retorno.ToString();
        }

    }
}
