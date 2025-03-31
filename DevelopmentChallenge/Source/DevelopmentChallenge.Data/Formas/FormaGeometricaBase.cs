using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Formas
{
    /// <summary>
    /// Nueva clase abstracta común a todas las formas, cada forma nueva que se agregue deberá heredar de esta clase
    /// </summary>
    public abstract class FormaGeometricaBase
    {
        protected readonly ITraductor _traductor;

        protected FormaGeometricaBase(ITraductor traductor)
        {
            _traductor = traductor;
        }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string ObtenerNombre(bool plural);
    }
}
