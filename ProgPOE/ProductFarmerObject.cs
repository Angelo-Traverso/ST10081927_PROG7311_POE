using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgPOE
{
    
    public class ProductFarmerObject
    {
        private string name;
        private string surname;
        private string prodCode;
        private string prodName;
        private double price;
        private int prodQuantity;
        private DateTime prodDateAdded;

        public ProductFarmerObject(string name, string surname, string code, string pName,double price, int quant, DateTime dateAdded)
        { 
            this.Name = name;
            this.Surname = surname;
            this.ProdCode = code;
            this.ProdName = pName;
            this.Price = price;
            this.ProdQuantity = quant;
            this.ProdDateAdded = dateAdded;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string ProdCode { get => prodCode; set => prodCode = value; }
        public string ProdName { get => prodName; set => prodName = value; }
        public int ProdQuantity { get => prodQuantity; set => prodQuantity = value; }
        public DateTime ProdDateAdded { get => prodDateAdded; set => prodDateAdded = value; }
        public double Price { get => price; set => price = value; }
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //