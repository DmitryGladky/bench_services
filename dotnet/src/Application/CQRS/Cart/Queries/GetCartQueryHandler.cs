using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Talabat.${{values.component_id}}.CQRS.Cart.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartResponse>
    {
        public async Task<CartResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(50, cancellationToken);

            return new CartResponse { Id = request.Id, VendorId = Guid.NewGuid().ToString() };
        }
    }
}
