namespace AzureGettingStarted.Model
{
    public class Image : Entity
    {
        public string Url { get; set; }
        public VisionResult VisionResult { get; set; }
    }
}
