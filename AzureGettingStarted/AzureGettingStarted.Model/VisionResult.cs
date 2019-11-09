using System.Collections.Generic;

namespace AzureGettingStarted.Model
{
    public class VisionResult : Entity
    {
        public List<Category> Categories { get; set; }
        public Adult Adult { get; set; }
        public Color Color { get; set; }
        public ImageType ImageType { get; set; }
        public List<Tag> Tags { get; set; }
        public Description Description { get; set; }
        public List<Face> Faces { get; set; }
        public List<Thing> Objects { get; set; }
        public List<Brand> Brands { get; set; }
        public string RequestId { get; set; }
        public Metadata Metadata { get; set; }
    }
}
