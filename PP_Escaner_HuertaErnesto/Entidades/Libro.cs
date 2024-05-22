using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        public int NumPaginas { get => numPaginas; }
        private string ISBN { get => this.NumNormalizado; }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        public static bool operator ==(Libro l1, Libro l2)
        {
            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
           
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendLine($"ISBN: {this.ISBN}.");
            retorno.AppendLine($"Cód. de barras: {this.Barcode}.");
            retorno.AppendLine($"Número de paginas: {this.NumPaginas}.\n");
            return retorno.ToString();
        }

    }
}
