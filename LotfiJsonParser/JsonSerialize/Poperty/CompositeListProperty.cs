using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.Parser.EnumParser;

namespace JsonSerializ.JSonBase.Poperty
{
    public class CompositeListProperty : BaseListProperty<CompoiteProperty>
    {
       //public override void GetTreeViewItemNode(HierarchicalList<IBaseProperty>list,HierarchicalItem<IBaseProperty> parent)
       // {
       //     var me = new HierarchicalItem<IBaseProperty>(this,parent);
       //     foreach (var item in Value)
       //     {
       //         item.GetTreeViewItemNode(list, me);
       //     }
       // }
       //public override Parser.EnumParser.TypeNodeJson JsonNodeType
       //{
       //    get
       //    {
       //     return TypeNodeJson.CompositeList;
       //    }
       //}
       //public override string PathProperty()
       //{
       //    return _Index.ToString();
       //}
        public override IBaseProperty GetPropertyWithName(string name)
        {
            return this.Value[int.Parse(name)]; 
        }
        //public override object CheckBeforAdd(object property)
        //{
        //    var compositeObject = property as CompoiteProperty;
        //  //  compositeObject.Name = (Value.Count + 1).ToString();
        //    return compositeObject;
        //}
        //public override IBaseProperty this[int index]
        //{
        //    get
        //    {
        //        return Value[index];
        //    }
        //}
    }
}
