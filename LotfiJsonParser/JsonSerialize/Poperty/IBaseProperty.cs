using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.Parser.EnumParser;

namespace JsonSerializ.JSonBase.Poperty
{
    public interface IBaseProperty
    {
        string Name { get; set; }
        bool IsFindInProperty(string path);
        IBaseProperty GetPropertyWithName(string name);
        IBaseProperty Parent { get; set; }
        string GetPathSelectedItem();
        int Count { get; }
        void ChangeValue(string value);
        object ValueProperty { get; }
        string GetPathStyleName();
        //JsonTreeViewItem GetJsonTreeViewItem(JsonTreeView tree);
        IEnumerable<IBaseProperty> GetChilderItems();
        //void LazyLoadChildren(JsonTreeViewItem treeViewItem, JsonTreeView tree);
        string NameIndex { get; set; }
       }
}
