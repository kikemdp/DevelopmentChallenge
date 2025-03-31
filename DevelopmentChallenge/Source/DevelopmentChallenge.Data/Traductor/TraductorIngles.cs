namespace DevelopmentChallenge.Data.Traductor
{
    public class TraductorIngles : ITraductor
    {
        public string Traducir(string clave, bool plural)
        {
            switch (clave)
            {
                case "Cuadrado":
                    return plural ? "Squares" : "Square";
                case "Circulo":
                    return plural ? "Circles" : "Circle";
                case "Rectangulo":
                    return plural ? "Rectangles" : "Rectangle";
                case "Triangulo":
                    return plural ? "Triangles" : "Triangle";
                case "Trapecio":
                    return plural ? "Trapezoids" : "Trapezoid";
                case "Lista vacía de formas":
                    return "Empty list of shapes";
                case "Reporte de Formas":
                    return "Shapes report";
                case "Area":
                    return "Area";
                case "Perimetro":
                    return "Perimeter";
                case "formas":
                    return "shapes";
                default:
                    return clave;
            }
        }
    }

}
