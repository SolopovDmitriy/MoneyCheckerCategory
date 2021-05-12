using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Models
{
   public class Category
    {
        public int Id { get; set; }
        public string Categ { get; set; }
        //public int? Parent_Id { get; set; } //возможен null
        public int Parent_Id { get; set; } 
        public List<Category> SubCategories { get; set; } // список для хранения подкатегорий

        public override string ToString()
        {
            return $"{Categ}";
        }
    }
}
