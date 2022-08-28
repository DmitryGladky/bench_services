using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Talabat.${{values.component_id}}.CQRS.Cart.Queries
{
    public class GetCartQueryTests
    {
        private readonly Fixture fixture;
        private readonly GetCartQueryHandler getCartQueryHandler;

        public GetCartQueryTests()
        {
            fixture = new Fixture();
            fixture
                .Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            getCartQueryHandler = new GetCartQueryHandler();
        }

        [Fact]
        public async Task GetCartQuery_WhenRequestProvided_ShouldGenerateCorrectResponse()
        {
            var getQuery = fixture.Build<GetCartQuery>().Create();
            var expected = new CartResponse { Id = getQuery.Id };


            var actual = await getCartQueryHandler.Handle(getQuery, default);


            actual.Should().BeEquivalentTo(expected, opt => opt.Excluding(ex=>ex.VendorId));
        }
    }
}
