using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase;
using JsonSerializ.Parser.Context;
using JsonSerializ.Parser.EnumParser;

namespace JsonSerializ.Parser.Prasers
{
    public class TerminateCompositeParser : BaseParser
    {
        private const char SPEICAL_CHARCTER = '}';
        #region IParser Members

        public override BaseParser CanParse(IContextParser context)
        {
            if (context.GetNextSpecificCharacters() == SPEICAL_CHARCTER) return this;
            if (successor != null)
                return successor.CanParse(context);
            return null;
        }

        public override void Parse(IContextParser context)
        {
            context.RemoveComposite();
        }

        #endregion
    }
}
