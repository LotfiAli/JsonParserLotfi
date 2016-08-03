using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using JsonSerializ.JSonBase.Poperty;


namespace JsonSerializ.JSonBase
{
    public abstract class BaseProperty<T> : IBaseProperty
    {
        protected bool _IsCreate;
        protected bool _isLazyLoad = false;
        private const string Fake_Header = "$$$###$$$Fake$$$###$$$";

        public BaseProperty()
        {
        }
        public BaseProperty(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public T Value { get; set; }
        public IBaseProperty Parent { get; set; }

        //public abstract void GetTreeViewItemNode(HierarchicalList<IBaseProperty> list, HierarchicalItem<IBaseProperty> parent);

        public bool IsFindInProperty(string path)
        {
            return (path == this.Name);
        }
        public virtual IBaseProperty GetPropertyWithName(string name)
        {
            if (this.Name == name) return this;
            return null;
        }

        public  string PathProperty()
        {
            if (!String.IsNullOrEmpty(Name))
                return Name;
            if (!String.IsNullOrEmpty(NameIndex))
                return NameIndex;
            return string.Empty;
        }
        public string GetPathSelectedItem()
        {
            if (Parent == null) return string.Empty;
            var value = PathProperty();
            if (value!= string.Empty)
                return Parent.GetPathSelectedItem() +"." + value;
            return Parent.GetPathSelectedItem();
        }

        public virtual int Count
        {
            get { return 0; }
        }

        public virtual void ChangeValue(string value)
        {

        }
        public virtual object ValueProperty
        {
            get { throw new NotImplementedException(); }
        }

        public abstract IEnumerable<IBaseProperty> GetChilderItems();

        //public virtual JsonTreeViewItem GetJsonTreeViewItem(JsonTreeView tree)
        //{
        //    var treeViewItem = new JsonTreeViewItem(tree, this, this.Name);
        //    var children = this.GetChilderItems();
        //    if (children != null && children.Any())
        //    {
        //      treeViewItem.Items.Add(new TreeViewItem() { Header = Fake_Header });
        //    }
        //    return treeViewItem;
        //}
        public virtual string GetPathStyleName()
        {
            return "SimpleProperty";
        }
        //private bool IsLazyLoaded(TreeViewItem treeViewItem)
        //{
        //    if (treeViewItem.Items != null)
        //    {
        //        if (treeViewItem.Items.Count == 1)
        //        {
        //            var item = treeViewItem.Items[0] as TreeViewItem;
        //            if (item != null && Fake_Header.Equals(item.Header))
        //                return false;
        //        }
        //    }
        //    return true;
        //}
        //public void LazyLoadChildren(JsonTreeViewItem treeViewItem, JsonTreeView tree)
        //{
        //    if (!this.IsLazyLoaded(treeViewItem))
        //    {
        //        treeViewItem.Items.Clear();
        //        var listJsonTreeView = this.GetChilderItems();
        //        foreach (var value in listJsonTreeView)
        //        {
        //            var node = value.GetJsonTreeViewItem(tree);
        //            if (node != null)
        //            {
        //                treeViewItem.Items.Add(node);

        //            }
        //        }
        //    }
        //}
        public string NameIndex { get; set; }
    }
}
