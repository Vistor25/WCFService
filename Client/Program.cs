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
            CalculatorClient client = new CalculatorClient();
            int n = 1;
            while (n == 1)
            {


                try
                {
                    Console.WriteLine("Type first argument:");
                    int inputFirstArgument = int.Parse(Console.ReadLine());
                    Console.WriteLine("Type the operation type(+, -, *, /)");
                    string typeOfOperation = Console.ReadLine();
                    Console.WriteLine("Type second argument:");
                    int inputSecondArgument = int.Parse(Console.ReadLine());

                    switch (typeOfOperation)
                    {
                        case "+":

                            Console.WriteLine("Answer: {0}", client.Addition(inputFirstArgument, inputSecondArgument));
                            break;
                        case "-":

                            Console.WriteLine("Answer: {0}",
                                client.Substraction(inputFirstArgument, inputSecondArgument));
                            break;
                        case "*":

                            Console.WriteLine("Answer: {0}",
                                client.Multiplication(inputFirstArgument, inputSecondArgument));
                            break;
                        case "/":

                            Console.WriteLine("Answer: {0}", client.Division(inputFirstArgument, inputSecondArgument));
                            break;

                    }
                }
                
                catch (TimeoutException e)
                {
                    Console.WriteLine("The service operation timed out. " + e.Message);

                }
             
                catch (FaultException<CalculatorService.CustomFaultExeption> e)
                {
                    Console.WriteLine("Message: {0}, Description: {1}", e.Detail.Message, e.Detail.Description);


                }
                catch (FaultException e)
                {
                    Console.WriteLine(e.Message);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Continue? Y or N ");
                string d = Console.ReadLine();
                if (d == "N")
                {
                    n = 0;
                    client.Close();
                }
            }
        }

    }








}
