namespace DDD.Samples.RealEstate;

public class Offer
{
    public Guid Id { get; set; }
    private decimal amount;
    public decimal Amount
    {
        get { return amount; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Le montant de l'offre doit être supérieur à 0.");
            amount = value;
        }
    }
    public DateTime OfferDate { get; set; }
    public string Status { get; set; } // Exemple: "Pending", "Accepted", "Rejected"

    public Offer(decimal amount)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        OfferDate = DateTime.Now;
        Status = "Pending";
    }
}