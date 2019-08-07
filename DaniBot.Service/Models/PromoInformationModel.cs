using System;

namespace Avanade.HackathonAzul.DaniBot.Models
{
    public class PromoInformationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string HyperLinkUrl { get; set; }
        public DateTime EndDate { get; set; }
    }
}