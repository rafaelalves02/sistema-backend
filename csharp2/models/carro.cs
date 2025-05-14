namespace csharp2.models
{
    public class carro : veiculo
    {
        public carro()
        {
            QuantidadeRodas = 4;
        }

        public int QuantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }

        private void InjetarCombustivel(int quntidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quntidadeCombustivel;
        }
    }
}
