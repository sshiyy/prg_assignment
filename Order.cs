namespace prg_assignment
{
    class Order
    {
        // private attributes
        private int id;
        private DateTime timeReceived;
        private DateTime? timeFulfilled;
        private List<IceCream> iceCreamList;

        // public attributes
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime TimeReceived
        {
            get { return timeReceived; }
            set { timeReceived = value; }
        }

        public DateTime? TimeFulfilled
        {
            get { return timeFulfilled; }
            set { timeFulfilled = value; }
        }

        public List<IceCream> IceCreamList
        {
            get { return iceCreamList; }
            set { iceCreamList = value; }
        }

        // constructors
        public Order() { }

        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
        }

        public void ModifyIceCream(int Id)
        {

        }

        public void AddIceCream(IceCream)
        {

        }

        public void DeleteIceCream(int Id)
        {

        }

        public void double CalculateTotal()
        {

        }

        public override string ToString()
        {
            return "ID: " + Id +
                "\tTime Received: " + TimeReceived +
                "\tTime Fulfilled: " + TimeFulfilled;
        }
    }
}
