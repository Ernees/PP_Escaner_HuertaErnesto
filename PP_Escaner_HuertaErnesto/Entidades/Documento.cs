using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        string titulo;
        string autor;
        int anio;
        string numNormalizado;
        string barcode;
        Paso estado;

        protected Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            estado = Paso.Inicio;
        }

        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string Barcode { get => barcode; }
        public Paso Estado { get => estado; }
        protected string NumNormalizado { get => numNormalizado; }
        public string Titulo { get => titulo; }

        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        public bool AvanzarEstado()
        {
            bool retorno;
            if (this.Estado == Paso.Terminado)
            {
                retorno = false;
            }
            else
            {
                int estadoActual = (int)this.estado;
                this.estado = (Paso)(estadoActual + 1);
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine($"Título: {this.Titulo}.");
            retorno.AppendLine($"Autor: {this.Autor}.");
            retorno.AppendLine($"Año: {this.Anio}.");
            return retorno.ToString();
        }

    }
}
