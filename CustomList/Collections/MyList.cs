using System.Collections;
using System.Windows.Markup;

namespace CustomList.Collections;

public class MyList<T>:IEnumerable<T>
{
    public int Count { get; private set; }
    private int _capacity;
    public int Capacity 
    {
        get => _capacity;
        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException("capacity was less than the current size.");
            }
            _capacity = value;
            Array.Resize(ref array, _capacity);
        }
    }
    private T[] array;
    private IEnumerable<T> values;

    public MyList()
    {
        Count = 0;
        _capacity = 0;
        array = new T[_capacity];
    }
    public T this[int index] { 
        get
        {
            if (index >= Count) 
            { 
                throw new ArgumentOutOfRangeException(); 
            }
            return array[index];
        } 
        set
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            array[index] = value;
        } 
    }

    public void Add(T obj)
    {
        if (_capacity == 0)
        {
            _capacity = 4;
            Array.Resize(ref array, _capacity);
        }
        if (_capacity == Count)
        {
            _capacity *= 2;
            Array.Resize(ref array, _capacity);
        }
        array[Count]=obj;
        Count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Contains(T obj)
    {
        for (int i = 0; i < Count; i++)
        {
            if (obj.Equals(array[i]))
            {
                return true;
            }
        }
        return false;
    }

    public T? Find(Predicate<T> predicate)
    {
        for (int i = 0; i < Count; i++)
        {
            if (predicate(array[i]))
            {
                return array[i];
            }
        }
        return default;
    }
    //Remove()
    public bool Remove(T obj)
    {
        for (int i = 0; i< Count; i++)
        { 
            if (obj.Equals(array[i]))
            {
                array[i] = default;break;
            }
        }
        return false;
    }
    //reverse()
    public class reverse
    {
        public static void Main()
        {
            List<int> list = new List<int>{1, 2, 3, 4, 5 };
            
            List<int> reverse = Enumerable.Reverse(list).ToList();

            Console.WriteLine(string.Join(',',reverse)); 
        }
    }
    //clear()
    public void clear()
    {
        Capacity= 0;
        Count= 0;
        array = default;
    }
    //Addrange()
    public void AddRange(IEnumerable<T> list)
    {
        foreach(T item in values)
        {
            Add(item);
        }
    }
}
