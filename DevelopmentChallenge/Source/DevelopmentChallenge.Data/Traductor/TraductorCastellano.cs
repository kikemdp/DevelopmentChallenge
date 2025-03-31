namespace DevelopmentChallenge.Data.Traductor
{
    public class TraductorCastellano : ITraductor
    {
        public string Traducir(string clave, bool plural)
        {
            switch (clave)
            {
                case "Cuadrado":
                    return plural ? "Cuadrados" : "Cuadrado";
                case "Circulo":
                    return plural ? "Círculos" : "Círculo";
                case "Rectangulo":
                    return plural ? "Rectángulos" : "Rectángulo";
                case "Triangulo":
                    return plural ? "Triángulos" : "Triángulo";
                case "Trapecio":
                    return plural ? "Trapecios" : "Trapecio";
                case "Lista vacía de formas":
                    return "Lista vacía de formas";
                case "Reporte de Formas":
                    return "Reporte de Formas";
                case "Area":
                    return "Area";
                case "Perimetro":
                    return "Perimetro";
                case "formas":
                    return "formas";
                default:
                    return clave;
            }
        }
    }
}
