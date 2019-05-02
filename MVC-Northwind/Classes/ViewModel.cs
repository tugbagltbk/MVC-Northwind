using MVC_Northwind.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Northwind.Classes
{

    public class ViewModel
    {
        public List<Product> prodList { get; set; }
        public List<Category> catList { get; set; }
        public List<Supplier> supList { get; set; }
    }
}