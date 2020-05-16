using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingArray<T> : IEnumerable<T> {

    private T[] data;

    private int size;

    public RingArray(int size) {
        this.size = size;
        this.data = new T[size];
    }

    public override string ToString()
    {
        return "[" + string.Join(",", data.Select(x => x.ToString()).ToArray()) + "]";
    }

    public T this[int i]
    {
        get { 
            i = ((i % size) + size) % size;
            return data[i]; 
        }
        set {   
            i = ((i % size) + size) % size;
            data[i] = value; 
        }
    }
    public int Length {
        get {
            return size;
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)data).GetEnumerator();
    }

    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
}
