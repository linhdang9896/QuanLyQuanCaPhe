using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductCategory(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
    }
}
