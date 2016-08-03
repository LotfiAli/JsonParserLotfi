using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.Poperty;


namespace JsonSerializ.JSonBase.Poperty
{
    public abstract class BaseListProperty<T> : BaseComposite<List<T>>
    {

        protected int _Index = 1;
        //private JsonTreeViewItem perentItem = null;
        public BaseListProperty()
        {
            this.Value = new List<T>();
        }
        public void AddToList(T property)
        {
            Value.Add(property);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (String.IsNullOrEmpty(Name))
                sb.Append("[");
            else
                sb.Append("\"" + Name + "\"").Append(":[");
            for (int i = 0; i < Value.Count; i++)
            {
                sb.Append(((Value[i] as IBaseProperty).ToString()));
                if (i < Value.Count - 1)
                    sb.Append(",");
            }
            sb.Append("]");
            return sb.ToString();
        }
        //public override string PathProperty()
        //{
        //    return NameIndex;
        //}
        public override void AddToList(object property)
        {
            (property as IBaseProperty).NameIndex = Value.Count.ToString();
             Value.Add((T)property);
             //NameIndex = Value.Count.ToString();
        }
        public override int Count
        {
            get
            {
                return Value.Count();
            }
        }

        public override IEnumerable<IBaseProperty> GetChilderItems()
        {
            return this.Value.Cast<IBaseProperty>();
        }


        //public  override IEnumerable<JsonTreeViewItem> GeTreeViewItem(JsonTreeView tree)
        //{
        //    if (!_isLazyLoad)
        //    {
        //         perentItem = CreateNewJsonTreeViewItem(tree,this.Name);
        //        _isLazyLoad = true;
        //    }else
        //     foreach (var value in this.Value)
        //      {
        //         var jsonValue = (value as IBaseProperty).GeTreeViewItem(tree);
        //         if (jsonValue != null)
        //             perentItem.Items.Add(jsonValue);
        //      }
        //    return perentItem;
        //}
    }
}
