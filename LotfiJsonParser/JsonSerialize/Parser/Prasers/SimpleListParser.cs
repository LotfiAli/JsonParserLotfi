using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase;

namespace JsonSerializ.Parser.Prasers
{
    public class SimpleListParser : BaseParser
    {
        #region IParser Members
        private const char SPEICAL_CHARCTER = '[';
        private const char SPEICAL_END_CHARCTER = ']';

        private SimpleProperty CreateNewSimpleProperty(string key, int index) 
        {
            return new SimpleProperty() { Name = index.ToString(), Value = key };
        }
        private IEnumerable<SimpleProperty> GetStringAndGoAheadArray(Context.IContextParser context, char arrayEndChar)
        {
            string key = string.Empty;
            List<SimpleProperty> listString = new List<SimpleProperty>();
            while (context.GetNextSpecificCharacters() != SPEICAL_END_CHARCTER)
            {

                while (true)
                {
                    char nextCharceter = context.GetNextSpecificCharacters();
                    switch (nextCharceter)
                    {
                        case ' ':
                            context.GoAhead();
                            break;
                        case '\"':
                        case '\'':
                            context.GoAhead();
                            break;
                        case ',':
                            listString.Add(CreateNewSimpleProperty(key,listString.Count+1));
                            key = string.Empty;
                            context.GoAhead();
                            break;
                        default:
                            if (nextCharceter == SPEICAL_END_CHARCTER)
                            {
                                listString.Add(CreateNewSimpleProperty(key, listString.Count + 1));
                                key = string.Empty;
                                return listString;
                            };
                            context.GoAhead();
                            key += nextCharceter;
                            break;
                    }
                }
            }
            return listString;
        }
    
        public override BaseParser CanParse(Context.IContextParser context)
        {
            if (context.GetNextSpecificCharacters() == SPEICAL_CHARCTER && !StartWithThisChatecter(context,'{'))
                return this;
            else if (successor != null)
                return successor.CanParse(context);
            return null;
        }
        public override void Parse(Context.IContextParser context)
        {
            context.GoAhead();
            SimpleListProperty simpleListProperty = new SimpleListProperty();
            simpleListProperty.Name = context.GetKey();
            simpleListProperty.Value = new List<SimpleProperty>();
            simpleListProperty.Value.AddRange(GetStringAndGoAheadArray(context, SPEICAL_END_CHARCTER));
            context.GoAhead();
            if (context.GetNextSpecificCharacters()=='\"')
             context.GoAhead();
            simpleListProperty.Value.ForEach(c => c.Parent = simpleListProperty);
            context.AddProperty(simpleListProperty);
        }
        #endregion

    }
}
