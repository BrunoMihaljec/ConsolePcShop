using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop
{
    class Program
    {
        static void Main()
        {
            string userinput;
            int addtocart;
            bool incorrect = true;

            List<PcComponent> ComponentList = new List<PcComponent>();
            List<PcComponent> Cart = new List<PcComponent>();

            ComponentList.Add(new PcComponent(1, "CPU", "AMD Ryzen 8 5800x", "AMD", 449.00));
            ComponentList.Add(new PcComponent(2, "CPU", "Intel Core i7.10700k", "Intel", 412.64));
            ComponentList.Add(new PcComponent(3, "CPU", "Intel Core i0-9900K", "Intel", 349.99));
            ComponentList.Add(new PcComponent(4, "Memory", "G.Skill Trident", "G.skill", 174.99));
            ComponentList.Add(new PcComponent(5, "Memory", "Team T-Force XTREEM ARGB", "Team", 154.60));
            ComponentList.Add(new PcComponent(6, "Memory", "Corsair Vengeance LPX", "Corsair", 143.99));
            ComponentList.Add(new PcComponent(7, "Motherboard", "Gigabyte X570 Aourus", "Gigabyte", 177.00));
            ComponentList.Add(new PcComponent(8, "Motherboard", "Asus ROG MAXIMUS X11", "Asus", 513.66));
            ComponentList.Add(new PcComponent(9, "Motherboard", "Gigabyte Z390 AORUS", "Gigabyte", 179.99));
            ComponentList.Add(new PcComponent(10, "Storage", "Crucial MX500 1 TB", "Crucial", 170.59));
            ComponentList.Add(new PcComponent(11, "Storage", "Samsung 970 Evo 1 TB", "Samsung", 129.99));
            ComponentList.Add(new PcComponent(12, "Storage", "Western Digital SN750 1 TB", "Western Digital", 129.99));
            ComponentList.Add(new PcComponent(13, "Video Card", "EVGA GeForce RTX 3080", "EVGA", 1000.00));
            ComponentList.Add(new PcComponent(14, "Video Card", "PNY GeForce RTX 3090", "PNY", 1705.99));
            ComponentList.Add(new PcComponent(15, "Video Card", "MSI GeForce RTX 3070", "MSI", 979.00));

            while (incorrect)
            {


                Console.WriteLine("Type 'Add' to add components to your cart.\nType 'Price' to view your total price.\nType 'Exit' to exit program");
                userinput = Console.ReadLine().ToUpper();

                if (userinput == "ADD")
                {
                    Console.WriteLine("PC Components:");

                    foreach (var PcComponent in ComponentList)
                    {
                        Console.WriteLine(" ID = {0}, Type = {1}, Name = {2}, Manufacturer = {3}, Price = {4}", PcComponent.ID, PcComponent.Type, PcComponent.Name, PcComponent.Manufacturer, PcComponent.Price);
                    }
                    Console.WriteLine("Write item ID to add that item to your cart list.");
                    string inputAdd = Console.ReadLine();

                    if (int.TryParse(inputAdd, out addtocart))
                    {

                        if (ComponentList.Exists(x => x.ID == addtocart))
                        {
                            Cart.AddRange(ComponentList.Where(x => x.ID == addtocart));
                            Console.Clear();

                            Console.WriteLine("Item with ID = {0} has been added to your cart.", addtocart);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("{0} is not valid input please enter a number ID that is in the list.", addtocart);

                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("{0} is not a number, please enter a number that exists in the list.\n", inputAdd);
                    }
                    incorrect = true;
                }

                else if (userinput == "EXIT")
                {
                    break;
                }
                else if (userinput == "PRICE")
                {
                    var price = Cart.Sum(x => x.Price);
                    Console.WriteLine("Total price: {0}\n", price);
                    incorrect = true;

                }

                else
                {
                    Console.WriteLine("Your choice {0} is invalid please write something of the following:", userinput);
                    incorrect = true;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
