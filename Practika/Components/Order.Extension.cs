using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Practika.Components
{
    public partial class Order
    {
        public ObservableCollection<ProductOrder> ProductOrders
        {
            get
            {
               return new ObservableCollection<ProductOrder>(ProductOrder);
                
            }
        }
        public int? Quanity
        {
            get
            {
                return this.ProductOrder.Sum(x => x.Quanity);

            }
        }
        public decimal? TotalSum
        {
            get
            {
                return this.ProductOrder.Sum(x => x.Quanity * x.PurchasePrice);
            }
        }
       
    }
}
  