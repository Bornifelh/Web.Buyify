namespace Web.Buyify.Models
{
    public class PanierItem
    {
        public int Id { get; set; }
        public string? NomProduit { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
    }
}
