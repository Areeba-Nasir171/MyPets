using System.Collections.Generic;

namespace MyPets.Models
{
    public class FeedbackVM
    {
        public FeedBack FormData { get; set; } = new FeedBack();

        public List<FeedBack> ListData { get; set; } = new List<FeedBack>();
    }
}
