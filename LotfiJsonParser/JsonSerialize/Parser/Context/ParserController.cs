using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.Context;
using JsonSerializ.Parser.EnumParser;
using JsonSerializ.Parser.Prasers;
using JsonSerializ.Poperty;

namespace JsonSerializ.Parser.Controller
{
    public static class ParserController
    {
        private static readonly CompositeParser _RootParser;
        //  private static Dictionary<string, CompoiteProperty> _CatcheParseTreeView;

        //private ICompositeProperty _Root= new CompoiteProperty() { Name = "OutBound" };
        static ParserController()
        {
            _RootParser = new CompositeParser();
            var simpleParser = new SimplePropertyParser();
            var terminateParser = new TerminateCompositeParser();
            var parseList = new SimpleListParser();
            var compositeListParser = new ComplexListParser();
            var terminateCompoxiteListParser = new TerminateComplexListParser();

            _RootParser.SetSuccessor(terminateParser);
            terminateParser.SetSuccessor(compositeListParser);
            compositeListParser.SetSuccessor(terminateCompoxiteListParser);
            terminateCompoxiteListParser.SetSuccessor(parseList);
            parseList.SetSuccessor(simpleParser);

            // _CatcheParseTreeView = new Dictionary<string, CompoiteProperty>();
        }

        public static CompoiteProperty DeserializeJson(byte[] jsonString, string idMessage=null, TypeDtoMessage typeDtoMessage=TypeDtoMessage.OutBound)
        {
            if (jsonString==null) return new CompoiteProperty(){Name = "Empty"};
            return DeserializeJson(Encoding.UTF8.GetString(jsonString));
        }
        public static CompoiteProperty DeserializeJson(string jsonString)
        {
         //   string keyMessage = String.Concat(idMessage, typeDtoMessage);
            //if (_CatcheParseTreeView.ContainsKey(keyMessage))
            //return _CatcheParseTreeView[keyMessage];

            return  ParseMessage(jsonString); ;
            //   _CatcheParseTreeView.Add(keyMessage, controlParser);
         //   return controlParser;
        }

        private static CompoiteProperty ParseMessage(string jsonString)
        {
            var parser = new ContextParser(jsonString, _RootParser);
            return parser.ParseJosn();

        }


        //public static JsonTreeViewItem GetJsonTreeViewItem(JsonTreeView treeView)
        //{
        //    return null;
        //    // return _CompositeProperty.CreateNewJsonTreeViewItem(treeView);

        //}
    }
}