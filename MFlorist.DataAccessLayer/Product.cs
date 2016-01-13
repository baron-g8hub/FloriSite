using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFlorist.DataAccessLayer
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }
       
    
        public int Id { get; set; }


      
        public int TypeId { get; set; }

 

        public string Name { get; set; }
        
    
        public Nullable<decimal> Price { get; set; }

   
        public string Description { get; set; }



        public string Image { get; set; }



        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
