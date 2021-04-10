using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpDate { get; set; }
        public string Cvv { get; set; }
    }
}
