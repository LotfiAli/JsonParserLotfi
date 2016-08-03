using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.Context;

namespace JsonSerializ.Parser.Prasers
{
    public interface IParser
    {
        BaseParser CanParse(IContextParser context);
        void Parse(IContextParser context);

    }
}
