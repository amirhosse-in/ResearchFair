using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace People
{
    public class Persons : IList
    {
        ArrayList InnerList = new ArrayList();
        public int Add(object value)
        {
            return this.InnerList.Add(value);
        }
        public void Clear()
        {
            InnerList.Clear();
        }
        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }
        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, object value)
        {
            InnerList.Insert(index, value);
        }
        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public void Remove(object value)
        {
            InnerList.Remove(value);
        }
        public void RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }
        public object this[int index]
        {
            get { return InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public void CopyTo(Array array, int index)
        {
            InnerList.CopyTo(array, index);
        }
        public int Count
        {
            get { return InnerList.Count; }
        }
        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }

        }
        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
        public IEnumerator GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

    }
}
