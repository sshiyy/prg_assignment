namespace prg_assignment
{
    // Customer 
    class Customer
    {
        // private attributes
        private string name;
        private int memberid;
        private DateTime dob;
        private Order currentOrder;
        private List<Order> orderHistory;
        private PointCard rewards;

        // public attributes
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Memberid
        {
            get { return memberid; }
            set { memberid = value; }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; }
        }

        public List<Order> OrderHistory
        {
            get { return orderHistory; }
            set { orderHistory = value; }
        }

        public PointCard Rewards
        {
            get { return rewards; }
            set { rewards = value; }
        }

        // constructors
        public Customer() { }

        public Customer(string name, int memberid, DateTime dob)
        {
            Name = name;
            Memberid = memberid;
            Dob = dob;
        }
    }

    class Order
    {

    }

    class PointCard
    {

    }
}
