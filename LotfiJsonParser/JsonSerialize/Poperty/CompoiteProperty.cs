using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Poperty;
using JsonSerializ.Parser.EnumParser;

namespace JsonSerializ.JSonBase
{
    public class CompoiteProperty : BaseComposite<List<IBaseProperty>>
    {
        //private TreeView treeView;
        //private JsonTreeViewItem perentItem = null;
        public CompoiteProperty()
        {
            this.Value = new List<IBaseProperty>();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty(this.Name))
            {
                sb.Append("\"" + this.Name + "\"");
                sb.Append(":");
            }
            sb.Append("{");
            for (int i = 0; i < this.Value.Count; i++)
            {
                sb.Append(this.Value[i].ToString());
                if (i < this.Value.Count - 1)
                    sb.Append(",");
            }
            sb.Append("}");
            return sb.ToString();
        }
       public override int Count
        {
            get
            {
                return this.Value.Count();
            }
        }
        public override void AddToList(object property)
        {
            this.Value.Add(property as IBaseProperty);
        }
        public IBaseProperty GetPathProperty(string path)
        {
            IBaseProperty resultProperty = this;
            string[] listPath = path.Split('.');
            foreach (string item in listPath)
                if (item!=null)
                    resultProperty = resultProperty.GetPropertyWithName(item);
            return resultProperty;
        }
        public void ChangeValueNode(string path, string value)
        {
            var resultValue = this.GetPathProperty(path);
            resultValue.ChangeValue(value);
        }
        public override IBaseProperty GetPropertyWithName(string name)
        {
            foreach (var item in base.Value)
            {
                if (item.Name == name) return item;
            }
            throw new Exception("This Name Dose Not existing");
        }
        public override IEnumerable<IBaseProperty> GetChilderItems()
        {
            return this.Value;
        }
        //public override void GetTreeViewItemNode(HierarchicalList<IBaseProperty> list, HierarchicalItem<IBaseProperty> parent)
        //{
        //    throw new NotImplementedException();
        //}
        public override string GetPathStyleName()
        {
            return "CompositeProperty";
        }
    }
}
