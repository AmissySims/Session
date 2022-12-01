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
        public static ProductsSessionEntities2 db = new ProductsSessionEntities2();

        public DBConnect()
        {
            db.Product.Load();
            db.User.Load();
        }
    }
}
