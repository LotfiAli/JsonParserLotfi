using JsonSerializ.JSonBase;
using JsonSerializ.Parser.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string josnText = System.IO.File.ReadAllText("D:\\json.txt", System.Text.Encoding.UTF8);
            CompoiteProperty result = ParserController.DeserializeJson(josnText);

            //1 is index Array and id is name
            var selectPath = result.GetPathProperty(".0.id");

            //{[{"id":"1","employees":"1","requestDate":"1469280960233","totalAmount":"1200","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1200","transactionWorkBox":"null","requestStatus":"1000"},{"id":"8","employees":"1","requestDate":"1469285835858","totalAmount":"1250","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1250","transactionWorkBox":"null","requestStatus":"1000"}]}

            result.GetPathProperty(".0.id").ChangeValue("2000");
            
            var resultPath = result.GetPathProperty(".1").GetPathSelectedItem();
           //{[{"id":"2000","employees":"1","requestDate":"1469280960233","totalAmount":"1200","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1200","transactionWorkBox":"null","requestStatus":"1000"},{"id":"8","employees":"1","requestDate":"1469285835858","totalAmount":"1250","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1250","transactionWorkBox":"null","requestStatus":"1000"}]}
            var f = result.ToString();


        }
    }
}
