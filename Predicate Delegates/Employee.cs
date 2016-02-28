namespace Predicate_Delegates
{
    public class Employee
    {
        private string _firstName;
        private string _lastName;
        private string _designation;

        public Employee(string firstName, string lastName, string designation)
        {
            _firstName = firstName;
            _lastName = lastName;
            _designation = designation;
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
            }
        }
    }
}