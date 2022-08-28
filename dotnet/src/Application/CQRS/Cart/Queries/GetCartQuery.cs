using MediatR;

namespace Talabat.${{values.component_id}}.CQRS.Cart.Queries
{
    public class GetCartQuery : IRequest<CartResponse>
    {
        public string Id { get; set; }

        public GetCartQuery()
        {
            Id = string.Empty;
        }
    }
}
