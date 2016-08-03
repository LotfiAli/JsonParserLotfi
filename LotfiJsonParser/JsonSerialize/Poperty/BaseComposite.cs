using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase;


namespace JsonSerializ.Poperty
{
    public abstract class BaseComposite<T> : BaseProperty<T>, ICompositeProperty
    {
        public abstract void AddToList(object property);
    }
}
