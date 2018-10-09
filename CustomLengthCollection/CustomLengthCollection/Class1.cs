using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLengthCollection
{

    public class CustomLengthCollection<T> : IList, IStructuralComparable, IStructuralEquatable, ICloneable
    {

        private int start, end;
        public int Length;

        public CustomLengthCollection(int start, int end)
        {
            this.start = start;
            this.end = end;
            this.Length = end - start;
            collection = new T[Length];
        }

        private T[] collection;

        bool IList.IsReadOnly => collection.IsReadOnly;

        bool IList.IsFixedSize => collection.IsFixedSize;

        int ICollection.Count => Length;

        object ICollection.SyncRoot => throw new NotImplementedException();

        bool ICollection.IsSynchronized => collection.IsSynchronized;

        public bool InRange(int position)
        {
            return position >= start && position <= end;
        }

        object IList.this[int index] { get => this[index]; set => this[index] = (dynamic)value; }


        public T this[int i]
        {
            get
            {
                if (!InRange(i))
                    throw new IndexOutOfRangeException();
                var m = new int[3];
                return this.collection[i - start];
            }
            set
            {
                if (InRange(i))
                    this.collection[i - start] = value;
                else throw new IndexOutOfRangeException();
            }
        }



        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in collection)
                sb.Append(element + " ");
            return sb.ToString();

        }

        int IList.Add(object value)
        {
            throw new NotImplementedException();
        }

        bool IList.Contains(object value)
        {
            int total = collection.Count(x => (dynamic)x == value);
            if (total > 0)
                return true;
            return false;
        }

        void IList.Clear()
        {
            throw new NotImplementedException();
        }

        int IList.IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        void IList.Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        void IList.Remove(object value)
        {
            throw new NotImplementedException();
        }

        void IList.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            collection.CopyTo(array, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            throw new NotImplementedException();
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            return collection.Equals(other);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return collection.GetHashCode();
        }

        object ICloneable.Clone()
        {
            var newCollection = new CustomLengthCollection<T>(start, end);
            int i = start;
            foreach (var e in this)
            {
                newCollection[i] = (dynamic) e;
                i++;
            }
            return newCollection;
        }
    }
}
