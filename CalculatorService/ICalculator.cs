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
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [FaultContract(typeof(OverflowFault))]
        int Addition(int firstArgument, int secondArgument);

        [OperationContract]
        int Substraction(int firstArgument, int secondArgument);

        [OperationContract]
        [FaultContract(typeof(OverflowFault))]
        int Multiplication(int firstArgument, int secondArgument);

        [OperationContract]
        [FaultContract(typeof(DivideByZeroFault))]
        [FaultContract(typeof(ValidationFault))]
        int Division(int firstArgument, int secondArgument);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
