using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using Refit;
using Talabat.${{values.component_id}}.External;
using Xunit;

namespace Talabat.${{values.component_id}}.Services
{
    public class ExternalServiceTestRefit
    {
        private readonly IExternalServiceClient externalService;

        public ExternalServiceTestRefit()
        {
            externalService = RestService.For<IExternalServiceClient>("https://api.adviceslip.com/");
        }

        [Fact]
        public async Task Get_Advice_From_External_Service()
        {
            const int adviceId = 1;
            var expected = new AdviceResponse
            {
                Slip = new AdviceSlip()
                {
                    Id = 1, Advice = "Remember that spiders are more afraid of you, than you are of them."
                }
            };

            AdviceResponse actual = await externalService.Advice(adviceId);

            actual.ShouldCompare(expected);
        }
    }
}
