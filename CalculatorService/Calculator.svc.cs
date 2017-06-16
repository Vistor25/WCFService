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
            int a;
            try
            {
                a = checked(firstArgument + secondArgument);
            }
            catch (OverflowException e)
            {
                OverflowFault fault = new OverflowFault();
                fault.Result = false;
                fault.Description = "Overflow detected!";
                fault.Message = e.Message;
                throw new FaultException<OverflowFault>(fault);
            }
            return a;
        }

        public int Division(int firstArgument, int secondArgument)
        {
            try
            {
                if (firstArgument == 0 && secondArgument == 0)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Description = "Invalid arguments";
                    fault.Message = "Both arguments can't be zero! ";
                    fault.Result = false;
                    throw  new FaultException<ValidationFault>(fault);
                }
                return firstArgument / secondArgument;
            }
            catch (DivideByZeroException exception)
            {
                DivideByZeroFault fault = new DivideByZeroFault();
                fault.Result = false;
                fault.Description = "Divizion by zero";
                fault.Message = exception.Message;

                throw new FaultException<DivideByZeroFault>(fault);
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int Multiplication(int firstArgument, int secondArgument)
        {
            int a;
            try
            {
                a = checked(firstArgument * secondArgument);
            }
            catch (OverflowException e)
            {
                OverflowFault fault = new OverflowFault();
                fault.Result = false;
                fault.Description = "Overflow detected!";
                fault.Message = e.Message;
                throw new FaultException<OverflowFault>(fault);
            }
            return a;
        }

        public int Substraction(int firstArgument, int secondArgument)
        {
            return firstArgument - secondArgument;
        }
    }
    [DataContract]
    public class DivideByZeroFault
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class ValidationFault
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class OverflowFault
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

}
