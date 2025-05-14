using csharp2.models;
using Microsoft.AspNetCore.Mvc;

namespace csharp2.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public veiculo obterVeiculo()
        {
            var meuVeiculo = new veiculo();

            meuVeiculo.Cor = "amarelo";
            meuVeiculo.Marca = "honda";
            meuVeiculo.Modelo = "civic";
            meuVeiculo.Placa = "REX-9078";

            meuVeiculo.Acelerar();
            
            return meuVeiculo;
        }


        [Route("obterCarro")]
        [HttpGet]
        public carro obterCarro()
        {
            var meuCarro = new carro();

            meuCarro.Cor = "verde";
            meuCarro.Marca = "ford";
            meuCarro.Modelo = "ka";
            meuCarro.Placa = "EWS-7543";

            meuCarro.Acelerar();

            return meuCarro;
        }


        [Route("obterMoto")]
        [HttpGet]
        public moto obterMoto()
        {
            var minhaMoto = new moto();

            minhaMoto.Cor = "verde";
            minhaMoto.Marca = "ford";
            minhaMoto.Modelo = "ka";
            minhaMoto.Placa = "EWS-7543";

            minhaMoto.Acelerar();

            return minhaMoto;
        }

    }
}
