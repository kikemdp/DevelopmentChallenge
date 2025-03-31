using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Implementaciones
{
    public class Trapecio : FormaGeometricaBase
    {
        private readonly decimal _baseMayor, _baseMenor, _altura, _lado1, _lado2;
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2, ITraductor traductor)
            : base(traductor)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
        }
        public override decimal CalcularArea() => ((_baseMayor + _baseMenor) / 2) * _altura;
        public override decimal CalcularPerimetro() => _baseMayor + _baseMenor + _lado1 + _lado2;
        public override string ObtenerNombre(bool plural) => _traductor.Traducir("Trapecio", plural);
    }
}
