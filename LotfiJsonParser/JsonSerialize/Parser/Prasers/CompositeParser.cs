using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.Context;

namespace JsonSerializ.Parser.Prasers
{
    public class CompositeParser : BaseParser
    {
        #region IParser Members

        private const char SPEICAL_CHARCTER = '{';
        public override BaseParser CanParse(IContextParser context)
        {
            if (context.GetNextSpecificCharacters() == SPEICAL_CHARCTER)
                return this;
            else if (successor != null)
                return successor.CanParse(context);
            return null;
        }

        public override void Parse(IContextParser context)
        {
            var nameComposite = context.GetKey();
            var compositeParser = new CompoiteProperty() { Name = nameComposite };
            context.AddComposite(compositeParser);
        }

        #endregion
    }
}
