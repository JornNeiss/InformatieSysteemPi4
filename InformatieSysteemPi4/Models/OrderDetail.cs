﻿namespace InformatieSysteemPi4.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }     
        public int OrderID { get; set; }           
        public int ProductID { get; set; }           
        public int Quantity { get; set; }         
        public decimal UnitPrice { get; set; }     

      
        public Order Order { get; set; }             
        public Product Product { get; set; }         
    }
}