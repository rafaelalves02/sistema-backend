namespace csharp2.models
{
    public class veiculo
    {
        //constutor
        public veiculo()
        {
            TanqueCombustivel = 40;
        }

        //atributos ou propriedades
        public string Cor { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }

        public int TanqueCombustivel { get; set; } 

        //metodos
        public virtual void Acelerar()
        {
            InjetarCombustivel(2);
     
        }

        public void Frear()
        {

        }

        private void InjetarCombustivel(int QuntidadeInjetada)
        {
            TanqueCombustivel = TanqueCombustivel - QuntidadeInjetada;
        }
    }
}
