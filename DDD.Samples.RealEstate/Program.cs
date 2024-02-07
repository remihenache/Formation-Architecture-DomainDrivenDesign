namespace DDD.Samples.RealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            var adresse = "123 Main St, Anytown";
            if(!AddressService.ValidateAddress(adresse))
            {
                Console.WriteLine("Adresse invalide");
                return;
            }
            
            Property property = new Property
            {
                Id = Guid.NewGuid(),
                Address = adresse,
                Description = "Beautiful 3-bedroom house",
                AskingPrice = 300000
            };

            try
            {
                Offer offer = new Offer(290000);
                property.AddOffer(offer);

                // Tentative d'ajout d'une offre invalide
                Offer invalidOffer = new Offer(-100);
                property.AddOffer(invalidOffer);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // Finaliser la transaction
                property.FinalizeTransaction();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
