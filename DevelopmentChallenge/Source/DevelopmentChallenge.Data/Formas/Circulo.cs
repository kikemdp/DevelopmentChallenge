using System;
using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Formas
{
    public class Circulo : FormaGeometricaBase
    {
        private readonly decimal _radio;
        public Circulo(decimal radio, ITraductor traductor) : base(traductor)
        {
            _radio = radio;
        }
        public override decimal CalcularArea() => (decimal)Math.PI * _radio * _radio;
        public override decimal CalcularPerimetro() => 2 * (decimal)Math.PI * _radio;
        public override string ObtenerNombre(bool plural) => _traductor.Traducir("Circulo", plural);
    }
}
