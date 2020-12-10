using System;
using System.Threading;
namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string k = "10";
            IPResolveClass addr = null;
            string ipAddress;
            string subnetMask;
            do
            {
                Console.WriteLine("Press to continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Create new pair (IP Address + Subnet Mask)");
                Console.WriteLine("2) Check Address");
                Console.WriteLine("3) Check Mask");
                Console.WriteLine("4) Show SubnetID");
                Console.WriteLine("5) Show HostID");
                Console.WriteLine("6) Show SubnetID & HostID");
                Console.WriteLine("0) Exit");
                Console.WriteLine("˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜");
                k = Console.ReadLine();

                switch (k)
                {
                    case "1":
                        addr = null;
                        Console.WriteLine("Enter IP: ");
                        ipAddress = Console.ReadLine();
                        Console.WriteLine("Enter subnet mask: ");
                        subnetMask = Console.ReadLine();
                        addr = new IPResolveClass(ipAddress, subnetMask);
                        break;
                    case "2":
                        Console.WriteLine("Address is: ");
                        Console.WriteLine(addr.CheckAddress());
                        break;
                    case "3":
                        Console.WriteLine("Subnet mask is: ");
                        Console.WriteLine(addr.CheckMask());
                        break;
                    case "4":
                        if (addr.CheckAddress() == false || addr.CheckMask() == false)
                        {
                            Console.WriteLine("Correct your data.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("SubnetID is: ");
                            Console.WriteLine(addr.ShowSubnetID());
                            break;
                        }
                    case "5":
                        if (addr.CheckAddress() == false || addr.CheckMask() == false)
                        {
                            Console.WriteLine("Correct your data.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("HostID is: ");
                            Console.WriteLine(addr.ShowHostID());
                            break;
                        }
                    case "6":
                        if (addr.CheckAddress() == false || addr.CheckMask() == false)
                        {
                            Console.WriteLine("Correct your data.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("SubnetID is: ");
                            Console.WriteLine(addr.ShowSubnetID());
                            Console.WriteLine("HostID is: ");
                            Console.WriteLine(addr.ShowHostID());
                            break;
                        }
                }
            } while (k != "0");
        }
    }
}
