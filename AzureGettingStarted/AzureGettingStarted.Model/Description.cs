using System.Collections.Generic;

namespace AzureGettingStarted.Model
{
    public class Description : Entity
    {
        public List<Caption> Captions { get; set; }
    }
}
