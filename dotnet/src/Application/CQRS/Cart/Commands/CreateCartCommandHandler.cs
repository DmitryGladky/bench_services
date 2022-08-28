using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Talabat.ServiceBench.CQRS.Cart.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ServiceBench.Cart>
    {
        public async Task<ServiceBench.Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(50, cancellationToken);

            return new ServiceBench.Cart
            {
                Id = Guid.NewGuid().ToString(),
                VendorId = request.VendorId
            };
        }
    }
}
