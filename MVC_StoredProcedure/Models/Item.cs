using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_StoredProcedure.Models
{
    public class Item : BaseModel.BaseModel
    {
        [Required(ErrorMessage="Please broooo, Fill this name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please broooo, Fill this stock")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Please broooo, Fill this price")]
        public int Price { get; set; }
    }
}