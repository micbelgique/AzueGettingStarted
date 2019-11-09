namespace AzureGettingStarted.Model
{
    public class Face : Entity
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public FaceRectangle FaceRectangle { get; set; }
    }
}
