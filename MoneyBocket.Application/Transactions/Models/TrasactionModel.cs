using MoneyBocket.Domain.Models;
using System;

namespace MoneyBocket.Application.Transactions.Models
{
    public class TrasactionModel
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public DateTime Date { get; internal set; }
        public Category Category { get; internal set; }
    }
}