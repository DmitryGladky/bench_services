using MediatR;

namespace Talabat.ServiceBench.CQRS.Cart.Commands
{
    public class CreateCartCommand : IRequest<ServiceBench.Cart>
    {
        public string VendorId { get; set; }

        public CreateCartCommand()
        {
            VendorId = string.Empty;
        }
    }
}
