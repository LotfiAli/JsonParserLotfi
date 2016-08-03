using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase.Poperty;

namespace JsonSerializ.Parser.Prasers
{
    public class ComplexListParser : BaseParser
    {
        private const char SPEICAL_CHARCTER = '[';
        private const char SPEICAL_END_CHARCTER = ']';

      
        public override BaseParser CanParse(Context.IContextParser context)
        {
            if (context.GetNextSpecificCharacters() == SPEICAL_CHARCTER && StartWithThisChatecter(context,'{'))
                return this;
            else if (successor != null)
                return successor.CanParse(context);
            return null;
        }
        public override void Parse(Context.IContextParser context)
        {
            CompositeListProperty compositeListParser = new CompositeListProperty() { Name = context.GetKey() };
            context.AddComposite(compositeListParser);
        }
    }
}
