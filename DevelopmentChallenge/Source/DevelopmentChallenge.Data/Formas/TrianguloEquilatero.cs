using System;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Implementaciones
{
    public class TrianguloEquilatero : FormaGeometricaBase
    {
        private readonly decimal _lado;
        public TrianguloEquilatero(decimal lado, ITraductor traductor) : base(traductor)
        {
            _lado = lado;
        }
        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        public override decimal CalcularPerimetro() => _lado * 3;
        public override string ObtenerNombre(bool plural) => _traductor.Traducir("Triangulo", plural);
    }
}
