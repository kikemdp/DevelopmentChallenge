namespace DevelopmentChallenge.Data.Traductor
{
    public class TraductorItaliano : ITraductor
    {
        public string Traducir(string clave, bool plural)
        {
            switch (clave)
            {
                case "Cuadrado":
                    return plural ? "Quadrati" : "Quadrato";
                case "Circulo":
                    return plural ? "Cerchi" : "Cerchio";
                case "Rectangulo":
                    return plural ? "Rettangoli" : "Rettangolo";
                case "Triangulo":
                    return plural ? "Triangoli" : "Triangolo";
                case "Trapecio":
                    return plural ? "Trapezi" : "Trapezio";
                case "Lista vacía de formas":
                    return "Elenco vuoto di forme";
                case "Reporte de Formas":
                    return "Rapporto sulle forme";
                case "Area":
                    return "Area";
                case "Perimetro":
                    return "Perimetro";
                case "formas":
                    return "forme";
                default:
                    return clave;
            }
        }
    }
}
