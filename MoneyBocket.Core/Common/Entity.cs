using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBocket.Domain.Common
{
    public class Entity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }
}