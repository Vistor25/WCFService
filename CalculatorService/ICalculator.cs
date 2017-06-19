using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(CustomFaultExeption))]
        int Addition(int firstArgument, int secondArgument);

        [OperationContract]
        [FaultContract(typeof(CustomFaultExeption))]
        int Substraction(int firstArgument, int secondArgument);

        [OperationContract]
        [FaultContract(typeof(CustomFaultExeption))]
        int Multiplication(int firstArgument, int secondArgument);

        [OperationContract]
        [FaultContract(typeof(CustomFaultExeption))]
        int Division(int firstArgument, int secondArgument);


    }
    
}
