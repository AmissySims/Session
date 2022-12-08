using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Components
{
    public partial class User
    {
        public string FullName
        {
            get
            {
                return $"{LastName[0]}.{Patronymic[0]}. {FirstName}" ;
            }
        }
    }
}
