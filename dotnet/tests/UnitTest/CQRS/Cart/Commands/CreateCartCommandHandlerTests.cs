using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Talabat.${{values.component_id}}.CQRS.Cart.Commands
{
    public class CreateCartCommandHandlerTests
    {
        private readonly Fixture fixture;
        private readonly CreateCartCommandHandler createCartCommandHandler;

        public CreateCartCommandHandlerTests()
        {
            fixture = new Fixture();
            fixture
                .Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            createCartCommandHandler = new CreateCartCommandHandler();
        }

        [Fact]
        public async Task CreateCartCommandHandler_WhenRequestProvided_ShouldReturnCorrectResponse()
        {
            var command = fixture.Build<CreateCartCommand>().Create();
            var expected = new ${{values.component_id}}.Cart { VendorId = command.VendorId };


            var actual = await createCartCommandHandler.Handle(command, default);


            actual.Should().BeEquivalentTo(expected, opts => opts.Excluding(ex => ex.Id));
        }
    }
}
