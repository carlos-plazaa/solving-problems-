using System;

namespace Data
{
     public interface InterfaceEvent
     {
         int EventID { get; set; }
         int UserID { get; set; }
         int ProductID { get; set; }
         DateTime PurchaseDate { get; set; }
    }
}
