using System.Text;

namespace Bank
{
    public abstract class Customer
    {
        //Fields
        private int customerID;
        private string name;
        private string address;
        private string phone;

        //Properties
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Address
        {
            get { return address; }
            set { address = value; }
        } 

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        //Constructors
        protected Customer(int customerID, string name, string address) : this(customerID, name, address, null) { }

        protected Customer(int customerID, string name, string address, string phone)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Address = address;
            this.phone = phone;
        }

        public override string ToString()
        {
            StringBuilder customerPrint = new StringBuilder();
            customerPrint.AppendLine();
            customerPrint.AppendFormat("Customer ID: {0}", this.CustomerID);
            customerPrint.AppendLine();
            customerPrint.AppendFormat("Customer type: {0}", this.GetType().Name);
            customerPrint.AppendLine();
            customerPrint.AppendFormat("Name: {0}", this.Name);
            customerPrint.AppendLine();
            customerPrint.AppendFormat("Address: {0}", this.Address);
            customerPrint.AppendLine();
            customerPrint.AppendFormat("Phone: {0}", this.Phone);
            customerPrint.AppendLine();

            return customerPrint.ToString();
        }
    }
}
