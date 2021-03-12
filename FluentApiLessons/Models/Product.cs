using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentApiLessons.Models
{
  
    public class Product : Entity
    {
        public string Name { get; set; }        
        //public Guid DishId { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
