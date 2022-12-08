using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Components
{
    internal class DBConnect
    {
        public static ProductsBaseEntities db = new ProductsBaseEntities();

        public DBConnect()
        {
            db.Product.Load();
        }
    }
}
