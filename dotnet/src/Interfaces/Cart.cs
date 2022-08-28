namespace Talabat.ServiceBench;
//TODO The following example was created by Talabat.DotNet.Templates and should be removed.

public class Cart
{
    public string Id { get; set; }

    public string VendorId { get; set; }
}

public class CartCreateRequest
{
    public string VendorId { get; set; }
}

public class CartResponse
{
    public string Id { get; set; }

    public string VendorId { get; set; }
}

public class CartCreateResponse : CartResponse
{

}
