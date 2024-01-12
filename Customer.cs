namespace prg_assignment
{
    // Customer 
    class Customer
    {
        // private attributes
        private string name;
        private int memberId;
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

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public Order CurrentOrder { get; set; }

        public List<Order> OrderHistory { get; } = new List<Order>();
        public PointCard Rewards
        {
            get { return rewards; }
            set { rewards = value; }
        }

        // constructors
        public Customer() { }

        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        public Order MakeOrder()
        {
            Order newOrder = new Order();
            orderHistory.Add(newOrder);
            CurrentOrder = newOrder;
            return newOrder;
        }

        public bool IsBirthday()
        {
            return dob.Month == DateTime.Now.Month && dob.Day == DateTime.Now.Day;
        }

        public override string ToString()
        {
            return "Name: " + Name +
                "\tMember ID: " + MemberId +
                "\tDOB: " + Dob +
                "\tCurrent Order: " + currentOrder +
                "\tOrder History: " + OrderHistory +
                "\tRewards: " + Rewards;
        }
    }
}
