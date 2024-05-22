using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {

            extension = 0;
            cantidad = 0;
            resumen = "";
            foreach (Documento d in e.listaDocumentos)
            {
                if (d.Estado == estado)
                {
                    switch (e.tipo)
                    {
                        case Escaner.TipoDoc.mapa:
                            if (d is Mapa mapa)
                            {
                                extension += mapa.Superficie;
                                cantidad += 1;
                                resumen += mapa.ToString();
                            }
                            break;
                        case Escaner.TipoDoc.libro:
                            if (d is Libro libro)
                            {
                                extension += libro.NumPaginas;
                                cantidad += 1;
                                resumen += libro.ToString();
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            Console.WriteLine($"Extensión: {extension}\nCantidad: {cantidad}\nResumen: \n{resumen}\n");
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }


    }
}
