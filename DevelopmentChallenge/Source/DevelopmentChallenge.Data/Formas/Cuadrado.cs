using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Implementaciones
{
    public class Cuadrado : FormaGeometricaBase
    {
        private readonly decimal _lado;
        public Cuadrado(decimal lado, ITraductor traductor) : base(traductor)
        {
            _lado = lado;
        }
        public override decimal CalcularArea() => _lado * _lado;
        public override decimal CalcularPerimetro() => _lado * 4;
        public override string ObtenerNombre(bool plural) => _traductor.Traducir("Cuadrado", plural);
    }
}
