using MediatR;

namespace Talabat.ServiceBench.CQRS.Cart.Queries
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
