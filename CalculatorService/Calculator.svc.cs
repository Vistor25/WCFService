using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;



namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Calculator: ICalculator
    {
        public int Addition(int firstArgument, int secondArgument)
        {
            int result;
            try
            {
                result = checked(firstArgument + secondArgument);
            }
            catch (OverflowException e)
            {
                CustomFaultExeption fault = new CustomFaultExeption();
                fault.TypeOfExeption = "OverflowException";
                fault.Result = false;
                fault.Description = "Overflow detected!";
                fault.Message = e.Message;
                throw new FaultException<CustomFaultExeption>(fault);
            }
            return result;
        }

        public int Division(int firstArgument, int secondArgument)
        {
            try
            {
                if (firstArgument == 0 && secondArgument == 0)
                {
                    CustomFaultExeption fault = new CustomFaultExeption();
                    fault.TypeOfExeption = "ValidationFault";
                    fault.Description = "Invalid arguments";
                    fault.Message = "Both arguments can't be zero! ";
                    fault.Result = false;
                    throw  new FaultException<CustomFaultExeption>(fault);
                }
                return firstArgument / secondArgument;
            }
            catch (DivideByZeroException exception)
            {
                CustomFaultExeption fault = new CustomFaultExeption();
                fault.TypeOfExeption = "DivideByZeroException";
                fault.Result = false;
                fault.Description = "Divizion by zero";
                fault.Message = exception.Message;

                throw new FaultException<CustomFaultExeption>(fault);
            }
        }

       public int Multiplication(int firstArgument, int secondArgument)
        {
            int result;
            try
            {
                result = checked(firstArgument * secondArgument);
            }
            catch (OverflowException e)
            {
                CustomFaultExeption fault = new CustomFaultExeption();
                fault.TypeOfExeption = "OverflowException";
                fault.Result = false;
                fault.Description = "Overflow detected!";
                fault.Message = e.Message;
                throw new FaultException<CustomFaultExeption>(fault);
            }
            return result;
        }

        public int Substraction(int firstArgument, int secondArgument)
        {
            int result;
            try
            {
                result = checked(firstArgument - secondArgument);
            }
            catch (OverflowException e)
            {
                CustomFaultExeption fault = new CustomFaultExeption();
                fault.TypeOfExeption = "OverflowException";
                fault.Result = false;
                fault.Description = "Overflow detected!";
                fault.Message = e.Message;
                throw new FaultException<CustomFaultExeption>(fault);
            }
            return result;
        }
    }
    

}
