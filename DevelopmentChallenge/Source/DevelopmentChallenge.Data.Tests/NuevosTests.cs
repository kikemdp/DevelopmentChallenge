using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Implementaciones;
using DevelopmentChallenge.Data.Reportes;
using DevelopmentChallenge.Data.Traductor;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class NuevosTests
    {
        [Test]
        public void TestReporteConTrapecioEnCastellano()
        {
            // Se calcula el área: ((10 + 5) / 2) * 4 = 30
            // Y el perímetro: 10 + 5 + 3 + 3 = 21
            ITraductor traductor = new TraductorCastellano();
            List<FormaGeometricaBase> formas = new List<FormaGeometricaBase>
            {
                new Trapecio(10, 5, 4, 3, 3, traductor)
            };

            ReporteFormas reporte = new ReporteFormas(traductor);
            var resultado = reporte.Imprimir(formas);

            var esperado = "<h1>Reporte de Formas</h1>1 Trapecio | Area 30 | Perimetro 21 <br/>TOTAL:<br/>1 formas Perimetro 21 Area 30";
            Assert.AreEqual(esperado, resultado);
        }

        [Test]
        public void TestReporteConRectanguloEnIngles()
        {
            // Creamos un Rectangulo de 4 (base) x 3 (altura)
            // Área = 12, Perímetro = 14
            ITraductor traductor = new TraductorIngles();
            List<FormaGeometricaBase> formas = new List<FormaGeometricaBase>
            {
                new Rectangulo(4, 3, traductor)
            };

            ReporteFormas reporte = new ReporteFormas(traductor);
            var resultado = reporte.Imprimir(formas);

            var esperado = "<h1>Shapes report</h1>1 Rectangle | Area 12 | Perimeter 14 <br/>TOTAL:<br/>1 shapes Perimeter 14 Area 12";
            Assert.AreEqual(esperado, resultado);
        }

        [Test]
        public void TestReporteEnItaliano()
        {
            ITraductor traductor = new TraductorItaliano();
            List<FormaGeometricaBase> formas = new List<FormaGeometricaBase>
            {
                new Cuadrado(5, traductor),
                new Circulo(3, traductor),
                new TrianguloEquilatero(4, traductor)
            };

            ReporteFormas reporte = new ReporteFormas(traductor);
            var resultado = reporte.Imprimir(formas);

            // Verificar que el encabezado está en italiano
            StringAssert.Contains("Rapporto sulle forme", resultado);
            // Verificar que se use la forma singular/plural correctamente:
            // Solo se agregó 1 cuadrado => "Quadrato"
            StringAssert.Contains("1 Quadrato", resultado);
            // Para el círculo y el triángulo, se debe verificar también la traducción italiana
            StringAssert.Contains("Cerchio", resultado);
            StringAssert.Contains("Triangolo", resultado);
        }

        [Test]
        public void TestLegacyConstructorConTipoInvalido()
        {
            // Se espera que al pasar un tipo no soportado (por ejemplo, 99) se lance ArgumentOutOfRangeException
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var forma = new FormaGeometrica(99, 5);
            });
        }
    }
}
