using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Reportes
{
    /// <summary>
    /// Clase que se encarga de imprimir el reporte de las formas geométricas,
    /// se basó en el código original de la clase FormaGeometrica pero usando el nuevo Traductor y FormaGeometricaBase
    /// </summary>
    public class ReporteFormas
    {
        private readonly ITraductor _traductor;

        public ReporteFormas(ITraductor traductor)
        {
            _traductor = traductor;
        }

        public string Imprimir(List<FormaGeometricaBase> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{_traductor.Traducir("Lista vacía de formas", false)}!</h1>");
                return sb.ToString();
            }

            sb.Append($"<h1>{_traductor.Traducir("Reporte de Formas", false)}</h1>");

            var resumen = formas
                .GroupBy(f => f.GetType())
                .Select(g => new
                {
                    Tipo = g.First().ObtenerNombre(g.Count() > 1),
                    Cantidad = g.Count(),
                    Area = g.Sum(f => f.CalcularArea()),
                    Perimetro = g.Sum(f => f.CalcularPerimetro())
                });

            foreach (var item in resumen)
            {
                sb.Append($"{item.Cantidad} {item.Tipo} | " +
                          $"{_traductor.Traducir("Area", false)} {item.Area:#.##} | " +
                          $"{_traductor.Traducir("Perimetro", false)} {item.Perimetro:#.##} <br/>");
            }

            sb.Append("TOTAL:<br/>");
            sb.Append($"{formas.Count} {_traductor.Traducir("formas", true)} " +
                      $"{_traductor.Traducir("Perimetro", false)} {resumen.Sum(r => r.Perimetro):#.##} " +
                      $"{_traductor.Traducir("Area", false)} {resumen.Sum(r => r.Area):#.##}");

            return sb.ToString();
        }
    }
}
