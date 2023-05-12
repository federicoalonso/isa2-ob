using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.Domain;
using Newtonsoft.Json;

namespace SpecFlowArenaGestor.StepDefinitions
{
    [Binding]
    internal class BajaDeSnackSteps
    {

        private readonly ScenarioContext context;
        private readonly SnackDto snackDto = new SnackDto();
        //private readonly List<SnackDto> snacksDto = new List<SnackDto>();
        //private int snackIdToDelete;
        private readonly Assistant assistant = new Assistant();
        private string role;

        public BajaDeSnackSteps(ScenarioContext context)
        {
            this.context = context;
            role = "";
        }

        //[Given(@"existe un snack con los valores ""(.*)"" de precio ""(.*)"" y cantidad ""(.*)""")]
        //public void GivenTheDescription(string description, float price, int quantity)
        //{
        //    snackDto.Name = description;
        //    snackDto.Quantity = quantity;
        //    snackDto.Price = price;
        //}

        [Given(@"un usuario con rol ""(.*)""")]
        public void GivenTheRole(string role)
        {
            this.role = role;
        }

        [When(@"solicito la baja de ""([^""]*)"" de id existente")]
        public async Task WhenSolicitoLaBajaDeDeIdExistente(string operation)
        {
            int idToDelete = await GetIdToDelete(operation).ConfigureAwait(false);
            HttpResponseMessage responseDelete = await assistant.SendRequest($"{operation}/{idToDelete}", null, role, "Delete");
            context.Set(responseDelete.StatusCode, "ResponseStatusCode");
        }

        private async Task<int> GetIdToDelete(string operation)
        {
            try
            {
                Thread.Sleep(5000);
                HttpResponseMessage response = await assistant.SendRequest(operation, snackDto, role, "Get").ConfigureAwait(false);
                string responseContent = await response.Content.ReadAsStringAsync();
                List<SnackDto> responseObject = JsonConvert.DeserializeObject<List<SnackDto>>(responseContent);
                int idToDelete = responseObject.ElementAt(responseObject.Count - 1).SnackId;
                return idToDelete;
            }
            catch (JsonReaderException e)
            {      
                return await GetIdToDelete(operation);
            }
        }

        [When(@"solicito la baja de ""([^""]*)"" de id que no existe ""([^""]*)""")]
        public async Task WhenSolicitoLaBajaDeDeIdQueNoExiste(string operation, string idUnknown)
        {
            HttpResponseMessage responseDelete = await assistant.SendRequest($"{operation}/{idUnknown}", null, role, "Delete");
            context.Set(responseDelete.StatusCode, "ResponseStatusCode");
        }


    }
}