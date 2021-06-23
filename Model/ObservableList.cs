using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ObservableList<Value> : List<Value>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public ObservableList(List<Value> dictionary) : base(dictionary)
        {
        }

        public ObservableList()
        {
        }
        public new void Add(Value value)
        {
            base.Add(value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
        }
    }
}
