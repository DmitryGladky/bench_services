using MediatR;

namespace Talabat.${{values.component_id}}.CQRS.Cart.Commands
{
    public class CreateCartCommand : IRequest<${{values.component_id}}.Cart>
    {
        public string VendorId { get; set; }

        public CreateCartCommand()
        {
            VendorId = string.Empty;
        }
    }
}
