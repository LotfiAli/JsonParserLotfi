using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonSerializ.Parser.EnumParser
{
    public enum StatusParsers
    {
        Composite,
        Terminate,
        NoneTeminate
    }
    public enum CurrentState
    {
        Start,
        StartComposite,
        End,
    }
    public enum TypeNodeJson
    {
        SimpleProperty,
        CompositeProperty,
        SimpleList,
        CompositeList
    }

    public enum TypeDtoMessage
    {
        Inbound,
        OutBound
    }

}

