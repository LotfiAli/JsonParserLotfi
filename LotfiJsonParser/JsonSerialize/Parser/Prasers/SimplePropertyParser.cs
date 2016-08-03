using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase;

namespace JsonSerializ.Parser.Prasers
{
    public class SimplePropertyParser : BaseParser
    {
        #region IParser Members

        public string GetStringAndGoAhead(Context.IContextParser context)
        {
            string key = string.Empty;
            while (true)
            {
                char nextCharceter = context.GetNextSpecificCharacters();
                switch (nextCharceter)
                {
                    case '\\':
                    case '\n':
                    case '\r':
                    //case ' ':
                        context.GoAhead();
                        break;
                    case '\"':
                    case '\'':
                        context.GoAhead();
                        break;
                    case ',':
                        key=key.Trim();
                        return key;
                    case '}':
                        key = key.Trim();
                        return key;
                    default:
                        context.GoAhead();
                        key += nextCharceter;
                        break;
                }
            }
        }

        public override BaseParser CanParse(Context.IContextParser context)
        {
            return this;
        }
      
        public override void Parse(Context.IContextParser context)
        {
            SimpleProperty simpleProperty = new SimpleProperty();
            simpleProperty.Name = context.GetKey();
            simpleProperty.Value = GetStringAndGoAhead(context);
            context.AddProperty(simpleProperty);
        }
        #endregion
    }
}
