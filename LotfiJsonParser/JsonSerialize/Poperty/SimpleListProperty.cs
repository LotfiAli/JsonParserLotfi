using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.EnumParser;

namespace JsonSerializ.JSonBase
{
    public class SimpleListProperty : BaseListProperty<SimpleProperty>
    {

        //public override void GetTreeViewItemNode(HierarchicalList<IBaseProperty> list, Caspian.Infra.Interface.HierarchicalItem<IBaseProperty> parent)
        //{
        //    var result = new Caspian.Infra.Interface.HierarchicalItem<IBaseProperty>(this, parent);
        //    foreach (var item in Value)
        //    {
        //        var d = new Caspian.Infra.Interface.HierarchicalItem<IBaseProperty>(item, result);
        //        list.Add(d);
        //    }
        //}
        //public override Parser.EnumParser.TypeNodeJson JsonNodeType
        //{
        //    get
        //    {
        //      return TypeNodeJson.SimpleList;
        //    }
        //}
        //public override IBaseProperty this[int index]
        //{
        //    get
        //    {
        //        return this.Value.Where(c => c.Name == index.ToString()).SingleOrDefault();
        //    }
        //}
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (String.IsNullOrEmpty(Name))
                sb.Append("[");
            else
                sb.Append("\"" + Name + "\"").Append(":[");

            for (int i = 0; i < Value.Count; i++)
            {
                sb.Append(Value[i].Value);
                if (i < Value.Count - 1)
                    sb.Append(",");

            }
            sb.Append("]");
            return sb.ToString();
        }
      public override IBaseProperty GetPropertyWithName(string name)
        {
            foreach (var item in base.Value)
            {
                if (item.Name == name) return item;
            }
            throw new Exception("This Name Dose Not existing");
        }
        public override string GetPathStyleName()
        {
            return "ListProperty";
        }


    }
}