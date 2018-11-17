using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Supplier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Supplier(string id, string name, string address) {
            this.Id = id;
            this.Name = name;
            this.Address = address;
          
        }

        public Supplier(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
