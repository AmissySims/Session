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
        public static PracticaEntities db = new PracticaEntities();

        public DBConnect()
        {
            db.Product.Load();
        }
    }
}
