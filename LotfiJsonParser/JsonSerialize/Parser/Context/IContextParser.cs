using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Poperty;

namespace JsonSerializ.Parser.Context
{
    public interface IContextParser
    {
        char GetCharInIndex(int index);
        char GetNextSpecificCharacters();
        string GetKey();
        void AddComposite(ICompositeProperty compositeProperty);
        void AddProperty(IBaseProperty baseProperty);
        void RemoveComposite();
        void GoAhead(int count=1);
        int GetIndex();
        IBaseProperty GetParent();
        
    }
}
