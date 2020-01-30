using System;
using System.Net;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

namespace ContaCorrente.Extrato.TestesDeIntegracao.Cenarios.Steps
{
    [Binding]
    public class DadoQueOuUmClienteSuperditalSteps
    {
        [Given(@"que a url da API é  '(.*)'")]
        public void DadoQueAUrlDaAPIE(string url)
        {
            ScenarioContext.Current["Endpoint"] = url;
        }
        
        [When(@"chamar o serviço")]
        public void QuandoChamarOServico()
        {
            ScenarioContext.Current["Reponse"] = ExceutarRequest();
        }

        [Then(@"o statuscode da resposta dever ser OK")]
        public void EntaoOStatusCodeDaRespostaDeverSer()
        {
            var response = (IRestResponse)ScenarioContext.Current["Reponse"];
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        private static IRestResponse ExceutarRequest()
        {
            var endpoint = ScenarioContext.Current["Endpoint"].ToString();

            var request = new RestRequest(Method.GET);
            var restClient = new RestClient(endpoint);
            var response = restClient.Execute(request);
            
            return response;
        }
    }
}
