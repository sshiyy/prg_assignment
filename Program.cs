using prg_assignment;

List<Customer> customers = new List<Customer>();

// Menu
while (true)
{
    Console.WriteLine("-----------Menu------------");
    Console.WriteLine("[1] List all customers");
    Console.WriteLine("[2] List all current orders");
    Console.WriteLine("[3] Register a new customer");
    Console.WriteLine("[4] Create a customer's order");
    Console.WriteLine("[5] Display order details of a customer");
    Console.WriteLine("[6] Modify order details");
    Console.WriteLine("[0] Exit");
    Console.WriteLine("---------------------------");
    Console.Write("Enter your option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if (option == 0)
    {
        break;
    }
    else if (option == 1)
    {
        Option1(customers);
    }
    else if (option == 2)
    {
        Option2(customers);
    }
    else if (option == 3)
    {
        Option3();
    }
    else if (option == 4)
    {
        Option4();
    }
    else if (option == 5)
    {
    }
    else if (option == 6)
    {
    }
}


// part 1 - List all customers
void Option1(List<Customer> customers)
{
    using (StreamReader sr = new StreamReader("customers.csv"))
    {
        sr.ReadLine();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] fields = line.Split(',');

            if (fields.Length == 3)
            {
                string name = fields[0];
                string idStr = fields[1];
                string dobStr = fields[2];

                if (int.TryParse(idStr, out int id))
                {
                    try
                    {
                        DateTime dob = DateTime.Parse(dobStr);
                        Customer customer = new Customer(name, id, dob);
                        customers.Add(customer);
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            else
            {
                continue;
            }
        }
    }
    Console.WriteLine("All Customers:");
    foreach (Customer customer in customers)
    {
        Console.WriteLine(customer);
    }
    Console.WriteLine();
}

// part 2 - List all current orders
void Option2(List<Customer> customers)
{
    int goldmember = 100;
    Console.WriteLine("All Current Orders:");

    // Regular Queue
    Console.WriteLine("Regular Members Queue:");
    foreach (Customer customer in customers)
    {
        if (customer.CurrentOrder != null && (customer.Rewards.Points < goldmember))
        {
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine($"Order ID: {customer.CurrentOrder.Id}");
            Console.WriteLine($"Time Received: {customer.CurrentOrder.TimeReceived}");

            foreach (IceCream iceCream in customer.CurrentOrder.IceCreamList)
            {
                Console.WriteLine(iceCream);
            }

            Console.WriteLine();
        }
    }

    // Gold Queue
    Console.WriteLine("Gold Members Queue:");
    foreach (Customer customer in customers)
    {
        if (customer.CurrentOrder != null && (customer.Rewards.Points >= goldmember))
        {
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine($"Order ID: {customer.CurrentOrder.Id}");
            Console.WriteLine($"Time Received: {customer.CurrentOrder.TimeReceived}");

            foreach (IceCream iceCream in customer.CurrentOrder.IceCreamList)
            {
                Console.WriteLine(iceCream);
            }

            Console.WriteLine();
        }
    }

}

// part 3 - Register a new customer
void Option3()
{
    Console.WriteLine("Enter name: ");
    Console.WriteLine("Enter ID number: ");
    Console.WriteLine("Enter DOB: ");

}

// part 4 - Create a customer's order
void Option4()
{
    Option1(customers);
    Console.WriteLine("Enter name of customer: ");
}

// part 5 - Display order details of a customer
// part 6 - Modify order details
