public static class StringExtension
{
    public static int CharCount(this string surname, char lowercaseLetter = 'm', char uppercaseLetter = 'M')
    {
        int counter = 0;
        for (int i = 0; i < surname.Length; i++)
        {
            if (surname[i] == lowercaseLetter || surname[i] == uppercaseLetter)
                counter++;
        }
        return counter;
    }
}

abstract class Person<T>
{
    private T _age;
    abstract public string Name { get; set; }
    abstract public string Surname { get; set; }
    virtual public T Age { get; set; }
    abstract public void DisplayInfo();
}

class Counter
{
    public int Value { get; set; }

    public static bool operator >(Counter counter1, Counter counter2)
    {
        return counter1.Value > counter2.Value;
    }
    public static bool operator <(Counter counter1, Counter counter2)
    {
        return counter1.Value > counter2.Value;
    }
}
class User : Person<int>
{
    protected int _age;
    public override string Name { get; set; }
    public override string Surname { get; set; }
    public override int Age
    {
        get
        {
            return _age;
        }
        set
        {
            bool result = CheckAge(value);
            if (result)
                _age = value;
            else
                Console.WriteLine("Sorry, but in order to buy in our Shop online, you should have at least 18 years old. ");
        }
    }
    public bool CheckAge(int value)
    {
        Counter counter2 = new Counter { Value = 17 };
        Counter counter1 = new Counter { Value = value };
        bool result = counter1.Value > counter2.Value;
        return result;
    }


    public override void DisplayInfo()
    {
        Console.WriteLine("Dear {0} {1}, we are glad to see you at our Shop!", Name, Surname);
    }
}

class Courier : Person<int>
{
    public override string Name { get; set; }
    public override string Surname { get; set; }
    public override int Age { get; set; }
    public string Telephone { get; set; }
    public override void DisplayInfo()
    {
        Console.WriteLine("Your courier will be {0} {1}. You can call the courier from 09:00 till 18:00 on the phone: {2}", Name, Surname, Telephone);
    }
    public void ChooseCourier()
    {
        int control = 0;
        while (control == 0)
        {
            Console.WriteLine("\nThe delivery is within a week starting from next day from the order day. " +
                "\nPlease choose the day of week that will suit you for the delivery, enter the number: " +
                "\n1 - Monday \n2 - Tuesday \n3 - Wednesday \n4 - Thursday \n5 - Friday \n6 - Saturday \n7 - Sunday");
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                case 3:
                case 5:
                    Name = "Nikolas";
                    Surname = "Cage";
                    Telephone = "555-774-951";
                    Age = 55;
                    control = -1;
                    break;

                case 2:
                case 4:
                    Name = "Antonio";
                    Surname = "Banderas";
                    Telephone = "654-744-111";
                    Age = 45;
                    control = -1;
                    break;

                case 6:
                case 7:
                    Name = "Greg";
                    Surname = "House";
                    Telephone = "333-777-014";
                    Age = 38;
                    control = -1;
                    break;

                default:
                    Console.WriteLine("You have choosen wrong number! Please follow the instructions!\n");
                    control = 0;
                    break;
            }
        }
    }

    static void ShowProductList()
    {
        Console.WriteLine("Choose a product that you want to buy: ");
        Console.WriteLine("1: printer - 501.09$");
        Console.WriteLine("2: keyboard - 385$");
        Console.WriteLine("3: mouse - 222.55$");
        Console.WriteLine("4: monitor - 463.11$");
        Console.WriteLine("5: the shopping is finished");
    }

    class Product
    {
        private string? _productName;
        private int _productPrice;

        public string? ProductName
        {
            get
            {
                return _productName;
            }
            private set
            {
                _productName = value;
            }
        }
        public int ProductPrice
        {
            get
            {
                return _productPrice;
            }
            private set
            {
                _productPrice = value;
            }
        }
        public string ChooseProduct(int productNumber)
        {
            switch (productNumber)
            {
                case 1:
                    _productName = "printer";
                    ShowPrice(_productName);
                    break;

                case 2:
                    _productName = "keyboard";
                    ShowPrice(_productName);
                    break;

                case 3:
                    _productName = "mouse";
                    ShowPrice(_productName);
                    break;

                case 4:
                    _productName = "monitor";
                    ShowPrice(_productName);
                    break;

                default:
                    Console.WriteLine("Wrong number!");
                    break;
            }
            return _productName;
        }

        public int ShowPrice(string productName)
        {
            switch (productName)
            {
                case "printer":
                    _productPrice = 501;
                    break;

                case "keyboard":
                    _productPrice = 385;
                    break;

                case "mouse":
                    _productPrice = 222;
                    break;

                case "monitor":
                    _productPrice = 463;
                    break;

                default:
                    Console.WriteLine("Wrong data!");
                    break;
            }
            return _productPrice;
        }
    }

    class Basket
    {
        private Product[] _productItems = new Product[10];
        public int TotalSum;

        public Product this[int index]
        {
            get => _productItems[index];
            set => _productItems[index] = value;
        }
        public void FullBasket()
        {
            int index = 0;
            int answer = 1;
            while (answer > 0 && answer < 6)
            {
                ShowProductList();
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1 || answer == 2 || answer == 3 || answer == 4)
                {
                    Product product = new Product();
                    product.ChooseProduct(answer);
                    _productItems[index] = product;
                    TotalSum += product.ProductPrice;
                    if (index == 9)
                    {
                        Console.WriteLine("You have taken into the basket 10 items already! It is a limit. Please go to delivery option step.");
                        break;
                    }
                    index++;
                }
                else if (answer == 5)
                    break;
                else
                {
                    Console.WriteLine("You are not following the instructions! Please follow the instructions!\n");
                    answer = 1;
                }
            }
        }
        public void DisplayProductItems()
        {
            foreach (var item in _productItems)
            {
                if (item != null)
                {
                    Console.WriteLine("{0} - {1}$", item.ProductName, item.ProductPrice);
                }
            }
            Console.WriteLine("Total sum is {0}$\n", TotalSum);
        }
    }
    public static int ShowDeliveryList()
    {
        Console.WriteLine("Choose the delivery, enter the number: ");
        Console.WriteLine("1: Home Delivery");
        Console.WriteLine("2: Pick Point Delivery");
        Console.WriteLine("3: Shop Delivery");
        Console.WriteLine("If you do not choose any of options, the delivery of the order will be at the address of our main shop");
        int deliveryAnswer = Convert.ToInt32(Console.ReadLine());
        return deliveryAnswer;
    }
    abstract class Delivery
    {
        private string _description;
        private string _address;
        public Courier CourierDelivery;

        abstract public void ShowDeliveryInfo();
    }

    class HomeDelivery : Delivery
    {
        protected string _description;
        protected string _address;

        public HomeDelivery(string address, Courier courierDelivery)
        {
            _description = "Home Delivery";
            _address = address;
            CourierDelivery = courierDelivery;
        }
        public override void ShowDeliveryInfo()
        {
            Console.WriteLine("You have chosen {0}. Your order will be delivered to the address {1}." +
                "\nThe purchases can be paid both by cash or by card to the courier.",
                _description, _address);
            CourierDelivery.DisplayInfo();
            Console.WriteLine();
        }
    }

    class PickPointDelivery : Delivery
    {
        protected string _description;
        protected string _address;
        public PickPointDelivery()
        {
            _description = "Pick Point Delivery";
            _address = "Wall Street, 7";
        }
        public override void ShowDeliveryInfo()
        {
            Console.WriteLine("You have chosen {0}. Your order will be delivered to the address {1}. " +
                "\nThe purchases can be paid both by cash or by card at Pick Point Delivery.\n", _description, _address);
        }
    }

    class ShopDelivery : Delivery
    {
        protected string _description;
        protected string _address;
        public ShopDelivery()
        {
            _description = "Shop Delivery";
            _address = "Main Street, 5";
        }
        public override void ShowDeliveryInfo()
        {
            Console.WriteLine("You have chosen {0}. Your order will be delivered to the address {1}. " +
                "\nThe purchases can be paid both by cash or by card at the shop.\n", _description, _address);
        }
    }
    class Order<TDelivery> where TDelivery : Delivery
    {
        private User _user;
        private int _number;
        private Basket _basket;
        public TDelivery Delivery;
        public Order(User user)
        {
            _user = user;
            _basket = new Basket();
        }
        public Basket Basket { get { return _basket; } }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value % 3 == 0)
                {
                    Console.WriteLine("As our regular customer, we give you a 20$ discount on the total amount of this order!" +
                        "\nThis amount will be automatically deducted from the total amount of purchases. \n");
                    _basket.TotalSum -= 20;
                }
                _number = value;
            }
        }
        public int IsBonusValid()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Let's check the bonus! \nTo get a bonus today, you need to have purchases that will cost at least 777$ and you should have one letter m in your last name.");
            int identifier = _user.Surname.CharCount();
            if (_basket.TotalSum >= 777 && identifier >= 1)
            {
                _basket.TotalSum -= 50;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("We congratulate you! You get a bonus - an additional 50$ discount!" +
                    "\nNow total sum is {0}$\n", _basket.TotalSum);
                Console.BackgroundColor = ConsoleColor.Black;
                return _basket.TotalSum;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("No, unfortunately, you don't get a bonus! " +
                    "\nTomorrow the conditions will change! " +
                    "\nWe are sure that you will be lucky next time!\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;

            return _basket.TotalSum;
        }

        public void ChooseDelivery(Order<Delivery> order, int deliveryAnswer)
        {
            if (deliveryAnswer == 1)
            {
                string userAddress = "";
                int control = 1;
                while (control == 1)
                {
                    Console.WriteLine("Please enter your address: ");
                    userAddress = Console.ReadLine();
                    if (userAddress == "")
                    {
                        Console.WriteLine("You cannot leave this field empty!");
                        control = 1;
                    }
                    else
                    {
                        control = 0;
                    }
                }
                Courier courier = new Courier();
                courier.ChooseCourier();
                order.Delivery = new HomeDelivery(userAddress, courier);
            }
            else if (deliveryAnswer == 2)
            {
                order.Delivery = new PickPointDelivery();
            }
            else
            {
                order.Delivery = new ShopDelivery();
            }
            order.Delivery.ShowDeliveryInfo();
        }
    }

    static void CreateOrder(User user, ref int orderNumber)
    {
        Order<Delivery> order = new Order<Delivery>(user);
        order.Number = CreateOrderNumber(ref orderNumber);
        Console.WriteLine("Let's create your order № {0}. You can order maximum 10 items. Let's shopping!", order.Number);

        order.Basket.FullBasket();
        Console.WriteLine("\nHere is your basket: ");
        order.Basket.DisplayProductItems();
        order.IsBonusValid();

        int deliveryAnswer = ShowDeliveryList();
        order.ChooseDelivery(order, deliveryAnswer);

        if (order.Number % 2 == 0)
            PlayGame();

        Console.WriteLine("Thank you for choosing us!\n");
    }
    public static int CreateOrderNumber(ref int orderNumber)
    {
        return ++orderNumber;
    }

    public static void PlayGame()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Let's play the game! \nIf you guess the answer, you will get a certificate at 50$ that you can use at our Main shop at Main Street, 5!" +
            "\nIn order to win, you should enter a sign (one number or one letter) and if it will be the same as our Random-bot has chosen, you will win!\n");

        Console.BackgroundColor = ConsoleColor.Black;

        Console.WriteLine("Are you going to guess a letter (option 1) or a number(option 2)? Please enter 1 or 2. " +
                "\nIf you enter another answer, the game will be over!");
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == 1)
        {
            Console.Write("Please enter one letter in lowercase: ");
            string? gameSign = Console.ReadLine();
            string? rightSign = "m";
            CheckGameResult(gameSign, rightSign);
        }
        else if (answer == 2)
        {
            Console.Write("Please enter one number (it should be integer): ");
            int gameSign = Convert.ToInt32(Console.ReadLine());
            int rightSign = 9;
            CheckGameResult(gameSign, rightSign);
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You have entered wrong number! The game is over! \n");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    public static void CheckGameResult<T>(T gameSign, T rightSign)
    {
        if (gameSign.Equals(rightSign))
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Congratulations! You've won! The certificate will be given to you along with your purchases!");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You didn't guess right! We are sure that next time you will be lucky!\n");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int orderNumber = 0;
            int control = 1;

            User user = new User();
            Console.Write("Enter your name: ");
            user.Name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            user.Surname = Console.ReadLine();

            Console.Write("Enter your age: ");
            user.Age = Convert.ToInt32(Console.ReadLine());
            if (user.Age == 0)
                control = 0;

            while (control == 1)
            {
                user.DisplayInfo();
                Console.WriteLine("{0}, do you want to make an order? Please, answer yes / no ", user.Name);
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "yes":
                        CreateOrder(user, ref orderNumber);
                        break;

                    case "no":
                        Console.WriteLine("We are waiting for you next time! Have a good day!");
                        control = 0;
                        break;

                    default:
                        Console.WriteLine("The wrong answer has been entered!");
                        break;
                }
            }
        }
    }
}