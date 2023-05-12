using ArenaGestor.APIContracts.Snack;
using System.Net;

namespace SpecFlowArenaGestor.StepDefinitions
{
    [Binding]
    internal class GetSnacksStepsDefinition
    {
        private readonly ScenarioContext context;
        private readonly SnackDto snackDto = new SnackDto();
        private readonly SnackDto snackDto2 = new SnackDto();
        private readonly List<SnackDto> snacksDto = new List<SnackDto>();
        private readonly Assistant assistant = new Assistant();
        private string role;

        //private string token;

        public GetSnacksStepsDefinition(ScenarioContext context)
        {
            this.context = context;
            role = "Artista";
        }

        [Given(@"un usuario ""(.*)""")]
        public void GivenTheRole(string role)
        {
            this.role = role;
        }

        [When(@"solicito la lista disponible de ""(.*)""")]
        public async Task WhenIPostThisRequestToTheOperation(string operation)
        {
            snacksDto.Add(snackDto);
            HttpResponseMessage response = await assistant.SendRequest(operation, snackDto, role, "Get").ConfigureAwait(false);
            //try
            //{
            context.Set(response.StatusCode, "ResponseStatusCode");
            //}
            //finally
            //{
            //    // move along, move along
            //}
        }

        [When(@"solicito el ""(.*)"" de id ""(.*)""")]
        public async Task WhenIPostThisRequestToTheOperationGetById(string operation, string id)
        {
            snacksDto.Add(snackDto);
            HttpResponseMessage response = await assistant.SendRequest($"{operation}/{id}", snackDto, role, "Get").ConfigureAwait(false);
            //try
            //{
            context.Set(response.StatusCode, "ResponseStatusCode");
            //}
            //finally
            //{
            //    // move along, move along
            //}
        }

        [Then(@"veo el mensaje de la obtencion con el codigo ""(.*)""")]
        public void ThenISeeTheMessageWitStatusCode(int statusCode)
        {
            Assert.Equal(statusCode, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }
    }
}
