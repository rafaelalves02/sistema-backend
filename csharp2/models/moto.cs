namespace csharp2.models
{
    public class moto : veiculo
    {
        public moto()
        {
            QuantidadeRodas = 2;
            TanqueCombustivel = 16;
        }

        public int QuantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(1);
        }

        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            TanqueCombustivel = TanqueCombustivel - quantidadeCombustivel;
        }
    }
}
