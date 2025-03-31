using DevelopmentChallenge.Data.Traductor;

namespace DevelopmentChallenge.Data.Formas
{
    public class Rectangulo : FormaGeometricaBase
    {
        private readonly decimal _base, _altura;
        public Rectangulo(decimal _base, decimal altura, ITraductor traductor) : base(traductor)
        {
            this._base = _base;
            _altura = altura;
        }
        public override decimal  CalcularArea() => _base * _altura;
        public override decimal CalcularPerimetro() => 2 * (_base + _altura);

        public override string ObtenerNombre(bool plural) => _traductor.Traducir("Rectangulo", plural);


    }
}
