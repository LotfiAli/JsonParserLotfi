using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonSerializ.Parser.Prasers
{
    public class TerminateComplexListParser : BaseParser
    {
        private const char SPEICAL_CHARCTER = ']';
      
        public override BaseParser CanParse(Context.IContextParser context)
        {
            if (context.GetNextSpecificCharacters() == SPEICAL_CHARCTER)
                return this;
             if (successor != null)
                return successor.CanParse(context);
            return null;
        }
        public override void Parse(Context.IContextParser context)
        {
            context.RemoveComposite();
        }
    }
}
