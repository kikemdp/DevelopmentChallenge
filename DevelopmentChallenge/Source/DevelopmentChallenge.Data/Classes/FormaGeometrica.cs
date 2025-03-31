/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Implementaciones;
using DevelopmentChallenge.Data.Reportes;
using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Classes
{
    // ====================================================  
    // Fachada para compatibilidad con los tests originales  
    // ====================================================
    /// <summary>
    /// Esta clase se dejó para poder cumplir con los tests originales (sin reescribirlos),
    /// pero ahora usa una forma interna que es la que realmente implementa la lógica
    /// </summary>
    public class FormaGeometrica : FormaGeometricaBase
    {
        // Constantes para tipos y para idiomas
        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        // Campos para recordar el tipo y el ancho (o lado) (los tests solo pasan un valor para el lado)
        private readonly int _tipo;
        private readonly decimal _lado;

        // Instancia interna que representa la forma concreta
        private FormaGeometricaBase _formaInterna;

        // Constructor legacy que usan los tests
        public FormaGeometrica(int tipo, decimal lado) : base(null)
        {
            _tipo = tipo;
            _lado = lado;
            // Se crea la forma interna usando un traductor por defecto (Ingles)
            _formaInterna = CrearForma(tipo, lado, new TraductorIngles());
        }

        // fábrica para crear la forma concreta según el tipo
        private static FormaGeometricaBase CrearForma(int tipo, decimal lado, ITraductor traductor)
        {
            switch (tipo)
            {
                case Cuadrado:
                    return new Cuadrado(lado, traductor);
                case Circulo:
                    return new Circulo(lado/2, traductor);
                case TrianguloEquilatero:
                    return new TrianguloEquilatero(lado, traductor);
                default:
                    throw new ArgumentOutOfRangeException("Tipo de forma desconocido o parámetros insuficientes");
            }
        }

        // Los métodos se delegan a la forma interna
        public override decimal CalcularArea() => _formaInterna.CalcularArea();
        public override decimal CalcularPerimetro() => _formaInterna.CalcularPerimetro();
        public override string ObtenerNombre(bool plural) => _formaInterna.ObtenerNombre(plural);

        // Método estático legacy para imprimir el reporte
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
                ITraductor traductor;
                switch (idioma)
                {
                    case Castellano:
                        traductor = new TraductorCastellano();
                        break;
                    case Italiano:
                        traductor = new TraductorItaliano();
                        break;
                    default:
                        traductor = new TraductorIngles();
                        break;
                }

                // Reconstruir cada forma usando el traductor adecuado (esto permite que los nombres se traduzcan según el idioma solicitado)
                List<FormaGeometricaBase> nuevasFormas = formas
                .Select(f => CrearForma(f._tipo, f._lado, traductor))
                .ToList();

            ReporteFormas reporte = new ReporteFormas(traductor);
            return reporte.Imprimir(nuevasFormas);
        }
    }
    }
