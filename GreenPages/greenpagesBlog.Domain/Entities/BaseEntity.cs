using System.ComponentModel.DataAnnotations;

namespace GreenPagesBlog.Domain.Entities
{
    public class BaseEntity
    {
        [Key] 
        public int Id { get; set; }
    }
}
