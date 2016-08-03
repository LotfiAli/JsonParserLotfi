# JsonParserLotfi
JsonParserLotfi

hello . This code is part of a project.you can parse json text to tree and do many operation.

       string josnText = System.IO.File.ReadAllText("D:\\json.txt", System.Text.Encoding.UTF8);
        //{[{"id":"1","employees":"1","requestDate":"1469280960233","totalAmount":"1200","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1200","transactionWorkBox":"null","requestStatus":"1000"},{"id":"8","employees":"1","requestDate":"1469285835858","totalAmount":"1250","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1250","transactionWorkBox":"null","requestStatus":"1000"}]}
        CompoiteProperty result = ParserController.DeserializeJson(josnText);

        //1 is index Array and id is name
        var selectPath = result.GetPathProperty(".0.id");

        //{[{"id":"1","employees":"1","requestDate":"1469280960233","totalAmount":"1200","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1200","transactionWorkBox":"null","requestStatus":"1000"},{"id":"8","employees":"1","requestDate":"1469285835858","totalAmount":"1250","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1250","transactionWorkBox":"null","requestStatus":"1000"}]}

        result.GetPathProperty(".0.id").ChangeValue("2000");

        var resultPath = result.GetPathProperty(".1").GetPathSelectedItem();
       //{[{"id":"2000","employees":"1","requestDate":"1469280960233","totalAmount":"1200","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1200","transactionWorkBox":"null","requestStatus":"1000"},{"id":"8","employees":"1","requestDate":"1469285835858","totalAmount":"1250","requestPaymentCode":"null","sourceAccountNumber":"1512154511","transactionCountSuccess":"0","transactionAmountSuccess":"0","transactionCountUnSuccess":"1","transactionAmountUnSuccess":"1250","transactionWorkBox":"null","requestStatus":"1000"}]}
        var f = result.ToString();
you can find node and change vaue and other operation.

    public interface IBaseProperty
    {
        string Name { get; set; }
        bool IsFindInProperty(string path);
        IBaseProperty GetPropertyWithName(string name);
        IBaseProperty Parent { get; set; }
        string GetPathSelectedItem();
        int Count { get; }
        void ChangeValue(string value);
        object ValueProperty { get; }
        string GetPathStyleName();
        //JsonTreeViewItem GetJsonTreeViewItem(JsonTreeView tree);
        IEnumerable<IBaseProperty> GetChilderItems();
        //void LazyLoadChildren(JsonTreeViewItem treeViewItem, JsonTreeView tree);
        string NameIndex { get; set; }
       }
