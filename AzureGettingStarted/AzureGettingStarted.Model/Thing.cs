namespace AzureGettingStarted.Model
{
    public class Thing : Entity
    {
        public Rectangle Rectangle { get; set; }
        public string Object { get; set; }
        public double Confidence { get; set; }
    }
}
