using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CardDetailDto:IDto
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpDate { get; set; }
        public string Cvv { get; set; }
        public string UserName { get; set; }
    }
}
