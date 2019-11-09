namespace AzureGettingStarted.Model
{
    public class Adult : Entity
    {
        public bool IsAdultContent { get; set; }
        public bool IsRacyContent { get; set; }
        public double AdultScore { get; set; }
        public double RacyScore { get; set; }
    }
}
