namespace DDD.Samples.RealEstate;

public class Property
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    private decimal askingPrice;
    public decimal AskingPrice
    {
        get { return askingPrice; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Le prix doit être supérieur à 0.");
            askingPrice = value;
        }
    }
    public List<Offer> Offers { get; private set; }

    public Property()
    {
        Offers = new List<Offer>();
    }

    public void AddOffer(Offer offer)
    {
        if (offer.Amount <= 0)
        {
            throw new ArgumentException("Le montant de l'offre doit être supérieur à 0.");
        }
        Offers.Add(offer);
    }

    public void FinalizeTransaction()
    {
        if (!Offers.Any())
        {
            throw new InvalidOperationException("Une transaction ne peut pas être finalisée sans au moins une offre.");
        }
            
        // Simuler la sélection de l'offre la plus élevée comme acceptée
        var highestOffer = Offers.OrderByDescending(o => o.Amount).First();
        highestOffer.Status = "Accepted";
        Console.WriteLine($"Transaction finalisée pour {Address} avec l'offre {highestOffer.Amount}.");
    }
}