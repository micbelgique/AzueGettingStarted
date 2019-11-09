namespace AzureGettingStarted.Model
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public double Confidence { get; set; }
        public Rectangle Rectangle { get; set; }
    }
}
