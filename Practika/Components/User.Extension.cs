namespace Practika.Components
{
    public partial class User
    {
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName[0]}. {Patronymic[0]}." ;
            }
        }
    }
}
