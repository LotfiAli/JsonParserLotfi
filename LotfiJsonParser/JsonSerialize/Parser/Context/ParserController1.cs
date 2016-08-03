using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using JsonSerializ.JSonBase;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.Context;
using JsonSerializ.Parser.EnumParser;
using JsonSerializ.Parser.Prasers;
using JsonSerializ.Poperty;


namespace JsonSerializ.Parser.Controller
{
    public class ParserController
    {
        private static readonly CompositeParser _RootParser;
        private IBaseProperty _CurrentBaseProperty;
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

        public static ParserController DeserializeJson(byte[] jsonString, string idMessage, TypeDtoMessage typeDtoMessage)
        {
            return DeserializeJson(Encoding.UTF8.GetString(jsonString), idMessage, typeDtoMessage);
        }
        public static ParserController DeserializeJson(string jsonString, string idMessage, TypeDtoMessage typeDtoMessage)
        {
            //   string keyMessage = String.Concat(idMessage, typeDtoMessage);
            //if (_CatcheParseTreeView.ContainsKey(keyMessage))
            //return _CatcheParseTreeView[keyMessage];


            //   _CatcheParseTreeView.Add(keyMessage, controlParser);
            //   return controlParser;
            return new ParserController(jsonString);
        }
        public ParserController(string jsonString)
        {
            var parser = new ContextParser(jsonString, _RootParser);
            _CurrentBaseProperty = parser.ParseJosn();
        }

      
        public IBaseProperty GetPathProperty(IBaseProperty baseProperty,string path)
        {
            IBaseProperty resultProperty = baseProperty;
            var listPath = path.Split('.');
            foreach (string item in listPath)
                if (!string.IsNullOrEmpty(item))
                    resultProperty = resultProperty.GetPropertyWithName(item);
            return resultProperty;
        }
       
    }
}