namespace DevelopmentChallenge.Data.Traductor
{
    /// <summary>
    /// Interfaz para traducir claves a distintos idiomas, cada implementación de esta interfaz deberá tener su propio diccionario de traducciones
    /// </summary>
    public interface ITraductor
    {
        string Traducir(string clave, bool plural);
    }
}
