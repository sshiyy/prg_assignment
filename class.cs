namespace prg_assignment
{
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
        public Customer() 
        {
            orderHistory = new List<Order>();
            rewards = new PointCard();
        }

        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        public Order MakeOrder()
        {
            Order newOrder = new Order();
            currentOrder = newOrder;
            return newOrder;
        }

        public bool IsBirthday()
        {
            return DateTime.Now.Date == Dob.Date;
        }

        public override string ToString()
        {
            return "Name: " + Name +
                "\tMember ID: " + MemberId +
                "\tDOB: " + Dob +
                "\tCurent Order: " + CurrentOrder +
                "\tOrder History: " + OrderHistory +
                "\tRewards: " + Rewards;
        }
    }

    class PointCard
    {
        // private attributes
        private int points;
        private int punchCard;
        private string tier;

        // public attributes
        public int Points
        { 
            get { return points; }
            set { points = value; }
        }

        public int PunchCard
        {
            get { return punchCard; }
            set { punchCard = value; }
        }

        public string Tier
        {
            get { return tier; }
            set { tier = value; }
        }

        // constructors
        public PointCard() { }

        public PointCard(int points, int punchCard)
        {
            Points = points;
            PunchCard = punchCard;
        }

        public void AddPoints(int totalAmount)
        {
            int earnedPoints = (int)Math.Floor(totalAmount * 0.72);
            Points += earnedPoints;
        }

        public void RedeemPoint(int redeemedPoints)
        {
            if (Points >= 50)
            {
                redeemedPoints = (int)(Points * 0.02);
                Points -= redeemedPoints;
            }
        }

        public void Punch()
        {
            PunchCard++;
            if (PunchCard == 10)
            {
                PunchCard = 0;
            }
        }

        public override string ToString()
        {
            return "Points: " + Points +
                "\tPunch Card: " + PunchCard +
                "\tTier: " + Tier;
        }
    }

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
        public Order() 
        { 
            iceCreamList = new List<IceCream>(); 
        }
        
        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
        }

        public void ModifyIceCream(int index, IceCream modifiedIceCream)
        {
            if (index >= 0 && index < iceCreamList.Count)
            {
                iceCreamList[index] = modifiedIceCream;
            }
        }

        public void AddIceCream(IceCream newIceCream)
        {
            iceCreamList.Add(newIceCream);
        }

        public override string ToString()
        {
            return "ID: " + Id +
                "\tTime Received: " + TimeReceived +
                "\tTime Fulfilled: " + TimeFulfilled;
        }
    }

    abstract class IceCream
    {
        // private attributes
        private string option;
        private int scoops;
        private List<Flavour> flavours;
        private List<Topping> toppings;

        // public attributes
        public string Option
        {
            get { return option; }
            set { option = value; }
        }

        public int Scoops
        {
            get { return scoops; }
            set { scoops = value; }
        }

        public List<Flavour> Flavours
        {
            get { return flavours; }
            set { flavours = value; }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        // consturctors
        public IceCream() { }

        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }

        public abstract double CalculatePrice();

        public override string ToString()
        {
            return "Option: " + Option +
                "\tScoops: " + Scoops +
                "\tFlavours: " + Flavours +
                "\tToppings: " + Toppings;
        }
    }

    class Cup : IceCream
    {
        // constuctors
        public Cup() { }

        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
            : base(option, scoops, flavours, toppings) { }

        public override double CalculatePrice()
        {
            double basePrice;
            double premiumScoopPrice = 2.0; 

            switch (Scoops)
            {
                case 1:
                    basePrice = 4.0;
                    break;
                case 2:
                    basePrice = 5.5;
                    break;
                case 3:
                    basePrice = 6.5;
                    break;
                default:
                    basePrice = 0.0; 
                    break;
            }

            double totalPrice = basePrice + (premiumScoopPrice * Flavours.Count);

            totalPrice += Toppings.Count;

            return totalPrice;
        }

        public override string ToString()
        {
            return base.ToString() +
                "\tPrice: " + CalculatePrice();
        }
    }

    class Cone : IceCream
    {
        // private attributes
        private bool dipped;

        // public attributes
        public bool Dipped
        {
            get { return dipped; }
            set { dipped = value; }
        }

        // consturctors
        public Cone() { }

        public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped)
            : base(option, scoops, flavours, toppings)
        { 
            Dipped = dipped;
        }

        public override double CalculatePrice()
        {
            double basePrice;
            double premiumScoopPrice = 2.0; 
            double dippedConePrice = 2.0; 

            switch (Scoops)
            {
                case 1:
                    basePrice = 4.0;
                    break;
                case 2:
                    basePrice = 5.5;
                    break;
                case 3:
                    basePrice = 6.5;
                    break;
                default:
                    basePrice = 0.0;
                    break;
            }

            if (Dipped)
            {
                basePrice += dippedConePrice;
            }

            double totalPrice = basePrice + (premiumScoopPrice * Flavours.Count);

            totalPrice += Toppings.Count;

            return totalPrice;
        }
        public override string ToString()
        {
            return base.ToString() + "\tDipped: " + Dipped +
                "\tPrice: " + CalculatePrice();
        }
    }

    class Waffle : IceCream
    {
        // private attributes
        private string waffleFlavour;

        // public attributes
        public string WaffleFlavour
        {
            get { return waffleFlavour; }
            set { waffleFlavour = value; }
        }

        // constructors
        public Waffle() { }

        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, string waffleFlavour)
            :base(option, scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }

        public override double CalculatePrice()
        {
            double basePrice;
            double premiumScoopPrice = 2.0; 
            double waffleFlavorPrice = 3.0; 

            switch (Scoops)
            {
                case 1:
                    basePrice = 7.0;
                    break;
                case 2:
                    basePrice = 8.5;
                    break;
                case 3:
                    basePrice = 9.5;
                    break;
                default:
                    basePrice = 0.0;
                    break;
            }

            if (!string.IsNullOrEmpty(WaffleFlavour))
            {
                basePrice += waffleFlavorPrice;
            }

            double totalPrice = basePrice + (premiumScoopPrice * Flavours.Count);

            totalPrice += Toppings.Count;

            return totalPrice;
        }
        public override string ToString()
        {
            return base.ToString() + "\tWaffle Flavour: " + WaffleFlavour +
                "\tPrice: " + CalculatePrice();
        }
    }

    class Flavour
    {
        // private attributes
        private string type;
        private bool premium;
        private int quantity;

        // public attributes
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool Premium
        {
            get { return premium; }
            set { premium = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        // constructors
        public Flavour() { }

        public Flavour(string type, bool premium, int quantity)
        {
            Type = type;
            Premium = premium;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return "Type: " + Type +
                "\tPremium: " + Premium +
                "\tQuantity: " + Quantity;
        }

    }

    class Topping
    {
        // private attributes
        private string type;

        // public attributes
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // constructors
        public Topping() { }

        public Topping(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return "Type: " + Type;
        }
    }
}
