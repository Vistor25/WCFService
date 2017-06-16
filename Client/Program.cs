using Client.RemoteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 1;
            while (n == 1)
            {
                CalculatorClient client = new CalculatorClient();

                try
                {
                    Console.WriteLine("Type first argument:");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Type the operation type(+, -, *, /)");
                    string b = Console.ReadLine();
                    Console.WriteLine("Type second argument:");
                    int c = int.Parse(Console.ReadLine());

                    switch (b)
                    {
                        case "+":

                            Console.WriteLine("Answer: {0}", client.Addition(a, c));
                            break;
                        case "-":

                            Console.WriteLine("Answer: {0}", client.Substraction(a, c));
                            break;
                        case "*":

                            Console.WriteLine("Answer: {0}", client.Multiplication(a, c));
                            break;
                        case "/":

                            Console.WriteLine("Answer: {0}", client.Division(a, c));
                            break;

                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Invalid argument!");
                    client.Close();

                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Invalid argument!");
                    client.Close();

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid argument!");
                    client.Close();

                }
                catch (TimeoutException e)
                {
                    Console.WriteLine("The service operation timed out. " + e.Message);
                    client.Close();
                }
                catch (FaultException<CalculatorService.OverflowFault> e)
                {
                    Console.WriteLine("Message: {0}, Description: {1}", e.Detail.Message, e.Detail.Description);
                    client.Close();
                }
                catch (FaultException<CalculatorService.ValidationFault> e)
                {
                    Console.WriteLine("Message: {0}, Description: {1}", e.Detail.Message, e.Detail.Description);
                    client.Close();
                }
                catch (FaultException<CalculatorService.DivideByZeroFault> e)
                {
                    Console.WriteLine("Message: {0}, Description: {1}", e.Detail.Message, e.Detail.Description);
                    client.Close();

                }
                catch (FaultException e)
                {
                    Console.WriteLine(e.Message);
                    client.Close();
                }

                Console.WriteLine("Continue? Y or N ");
                string d = Console.ReadLine();
                if (d == "N")
                    n = 0;
                client.Close();
            }
        }

    }








}
