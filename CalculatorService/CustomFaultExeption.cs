using System.Runtime.Serialization;

namespace CalculatorService
{
    [DataContract]
    public class CustomFaultExeption
    {
        [DataMember]
        public string TypeOfExeption { get; set; }
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}