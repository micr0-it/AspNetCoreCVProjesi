using System.ComponentModel.DataAnnotations;

namespace CoreProjeAPI.DAL.Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int Name { get; set; }
    }
}
