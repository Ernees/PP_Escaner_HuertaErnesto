using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        internal List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        internal TipoDoc tipo;

        public Escaner(string marca, TipoDoc tipo)
        {
            this.tipo = tipo;
            this.marca = marca;
            listaDocumentos = new List<Documento>();
            if (tipo == TipoDoc.mapa)
            {
                locacion = Departamento.mapoteca;
            }
            else
            {
                locacion = Departamento.procesosTecnicos;
            }

        }

        enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            bool retorno;
            retorno = false;
            if (this.listaDocumentos.Contains(d))
            {
                d.AvanzarEstado();
                retorno = true;
            }
            return retorno;
        }

        public static bool operator +(Escaner e, Documento d)
        {
            bool r;
            r = false;

            if (!(e == d) && d.Estado == Documento.Paso.Inicio)
            {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                r = true;
            }
            else
            {
                Console.WriteLine("El Documento ya fue agregado anteriormente. ");
            }
            return r;
        }
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno;
            retorno = false;

            if (e.tipo == TipoDoc.libro)
            {
                try
                {
                    foreach (Libro doc in e.listaDocumentos)
                    {
                        if (doc == (Libro)d)
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
                catch (InvalidCastException excep)
                {
                    Console.WriteLine(excep.Message);
                }
            }
            else
            {
                try
                {
                    foreach (Mapa doc in e.listaDocumentos)
                    {
                        if (doc == (Mapa)d)
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
                catch (InvalidCastException excep)
                {
                    Console.WriteLine(excep.Message);
                }
            }
            return retorno;
        }
    }


}
