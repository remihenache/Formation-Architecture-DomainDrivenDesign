namespace DDD.Samples.RealEstate;

internal class AddressService
{
    public static bool ValidateAddress(string address)
    {
        // call api to check if address exists and get GPS coordinates
        return !string.IsNullOrEmpty(address);
    }
}