using MoneyBocket.Domain.Common;
using System;

namespace MoneyBocket.Domain.Models
{
    public class Transaction : Entity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Category Categotry { get; set; }
        public int CategotryId { get; set; }
    }
}
