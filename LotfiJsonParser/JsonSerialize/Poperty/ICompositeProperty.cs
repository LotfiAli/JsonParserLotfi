using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase.Poperty;

namespace JsonSerializ.Poperty
{
    public interface ICompositeProperty : IBaseProperty
    {
        void AddToList(Object property);
    }
}
