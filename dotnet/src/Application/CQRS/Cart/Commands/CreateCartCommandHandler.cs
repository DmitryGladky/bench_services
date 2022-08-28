using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Talabat.${{values.component_id}}.CQRS.Cart.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ${{values.component_id}}.Cart>
    {
        public async Task<${{values.component_id}}.Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(50, cancellationToken);

            return new ${{values.component_id}}.Cart
            {
                Id = Guid.NewGuid().ToString(),
                VendorId = request.VendorId
            };
        }
    }
}
