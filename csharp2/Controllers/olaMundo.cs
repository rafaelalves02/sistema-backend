using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace csharp2.controllers
{
    [Route("api/aula")]
    [ApiController]
    public class olaMundo : ControllerBase
    {
        [HttpGet("olaMundo")]
        
        public string olaMundoo()
        {
            var mensagem = "olá mundo via API";
            return mensagem;
        }


        [HttpGet("olaMundoPersonalizado")]

        public string olaMundoPersonalizadoo(string nome)
        {
            var mensagem = "olá mundo via API " + nome;
            return mensagem;
        }


        [HttpGet("soma")]

        public string somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var mensagem = "o soma é " + soma;
            return mensagem;
        }


        [HttpGet("media")]

        public string mediaa(int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var media = soma / 2;
            var mensagem = "a media é " + media;
            return mensagem;
        }


        [HttpGet("terreno")]

        public string terrenoo(decimal largura, decimal comprimento, decimal preco)
        {
            var area = largura * comprimento;
            var precoTotal = area * preco;
            var mensagem = "O preço total do terreno com o valor do metro quadrado a " + preco + "R$ e com a área de " + area + "m² é " + precoTotal + "R$";
            return mensagem;
        }


        [HttpGet("troco")]

        public string trocoo(decimal preco, decimal valorPago, int quantidade)
        {
            var valorDevido = preco * quantidade;
            if(valorDevido > valorPago){
                var mensagem = "ainda está faltando valor a ser pago";
                return mensagem;
            }
            else{
                var troco = valorDevido - valorPago;
                var mensagem = "o troco é " + troco + "R$";
                return mensagem;
            }

        }


        [HttpGet("salario")]

        public string salarioFuncionario(string nome, int salarioPorHora, int horasTrabalhadas)
        {
            var salario = salarioPorHora * horasTrabalhadas;
            var mensagem = "o funcionario " + nome + " deve receber o valor de " + salario + "R$";
            return mensagem;
        }


        [HttpGet("consumo")]

        public string calcularConsumo(int distancia, int combustivelGasto)
        {
            var consumoMedio = distancia / combustivelGasto;
            var mensagem = "o consumo médio do seu carro é " + consumoMedio;
            return mensagem;
        }
    }
}
