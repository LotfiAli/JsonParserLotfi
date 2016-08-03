using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.EnumParser;

namespace JsonSerializ.JSonBase
{
    public class SimpleProperty : BaseProperty<string>
    {

        public SimpleProperty()
            : base()
        {
        }

        public override string ToString()
        {
            Value = Value.Trim();
            if (String.IsNullOrEmpty(Value.Trim()))
                return Name;
            if (String.IsNullOrEmpty(this.Name))
                return Value;
            return string.Format("\"{0}\":\"{1}\"", Name, Value);
        }

        public override int Count
        {
            get
            {
                return 0;
            }
        }
        //public override void GetTreeViewItemNode(HierarchicalList<IBaseProperty> list, HierarchicalItem<IBaseProperty> parent)
        //{
        //    var result = new HierarchicalItem<IBaseProperty>(this, parent);
        //    list.Add(result);
        //}
        public override void ChangeValue(string value)
        {
            this.Value = value;
        }
        public override object ValueProperty
        {
            get
            {
                return Value;
            }
        }
        public override string GetPathStyleName()
        {
            return "SimpleProperty";
        }
        public override IEnumerable<IBaseProperty> GetChilderItems()
        {
            return new List<IBaseProperty>();
        }
        //public override JsonTreeViewItem GetJsonTreeViewItem(JsonTreeView tree)
        //{
        //    return new JsonTreeViewItem(tree, this, this.ToString());
        //}
    }
}
