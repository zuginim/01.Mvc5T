using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class Product
    {
        private string name;

        //16.08.21 도메인선언.
        public int ProductID { get; set; }
        public string Name {
            get { return ProductID + " " + name; }
            set { name = value; }
        }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}