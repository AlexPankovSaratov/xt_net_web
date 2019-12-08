using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //IList<int> Array = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //Console.WriteLine("Колличество элементов: " + Array.Count);
            //Lost(Array);
            //Console.WriteLine("Значение оставшенося элемента: " + Array[0]);
            //Console.ReadLine();

            //WordFrequency("Hellow HELLOW Hellow may happy friend, may friend");

            DynamicArray<int> DynamicArray2 = new DynamicArray<int>();
            DynamicArray2.AddElement(0);
            DynamicArray2.AddElement(1);
            DynamicArray2.AddElement(2);
            DynamicArray2.AddElement(3);
            DynamicArray2.AddElement(4);
            DynamicArray2.AddElement(5);
            DynamicArray2.AddElement(6);
            DynamicArray2.AddElement(7);
            DynamicArray2.InitDynamicEnumer();
            DynamicArray2.Enumirator.Index = 5;
            DynamicArray2.Remove(4);
            DynamicArray2.Remove(0);

            Console.ReadLine();
        }
        static void Lost<T>(IList<T> Array)
        {
            bool removeElement = false;
            Stack<int> RemoveStack = new Stack<int>();
            int index = 0;
            while (Array.Count > 1)
            {
                if (removeElement) RemoveStack.Push(index);
                index++;
                removeElement = !removeElement;
                if (index > Array.Count-1)
                {
                    index = 0;
                    while(RemoveStack.Count > 0)
                    {
                        Array.RemoveAt(RemoveStack.Pop());
                    }
                }
            }
        }
        static void WordFrequency(string str)
        {
            IList<string> ListStrUnique = new List<string> { };
            IList<string> ListStrAll = new List<string> { };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string item in str.ToUpper().Split(' ', ','))
            {
                if (!(ListStrUnique.Contains(item))) ListStrUnique.Add(item);
            }
            foreach (string item in str.ToUpper().Split(' ', ','))
            {
                ListStrAll.Add(item);
            }
            foreach (string item in ListStrUnique)
            {
                if (item != "")
                {
                    int count = 0;
                    foreach (string itemAll in ListStrAll)
                    {
                        if (itemAll.Equals(item)) count++;
                    }
                    dictionary.Add(item, count);
                }  
            }
            PrintDictionary<string, int>(dictionary);
            Console.ReadLine();
        }
        private static void PrintDictionary<T1, T2>(Dictionary<T1, T2> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }  
        }
    }
    class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _count;
        public int Count { get { return _count; } }
        private int _capacity;
        public int Capacity { get { return _capacity; } }
        public DynamicEnumetator Enumirator;
        public DynamicArray()
        {
            _array = new T[8];
            _capacity = 8;
        }
        public DynamicArray(int CountElem)
        {
            _array = new T[CountElem];
            _capacity = CountElem;
        }
        public DynamicArray(IEnumerable <T> Enumer)
        {
            int countelem = Enumer.Count();
            _array = new T[countelem];
            _capacity = countelem;
            _count = 0;
            foreach (T item in Enumer)
            {
                AddElement(item);
            }

        }
        public void AddElement(T element)
        {
            if(_capacity == _count) IncreaseCapacity(_capacity);
            _array[_count] = element;
            _count++;
        }
        public void AddRange(IEnumerable<T> Enumer){
            if((Enumer.Count() + _count) > _capacity)
            {
                IncreaseCapacity(Enumer.Count());
            }
            foreach (T item in Enumer)
            {
                AddElement(item);
            }
        }
        public bool Remove(T Element)
        {
            if (!(_array.Contains(Element))) return false;
            bool Removed = false;
            int IndexRemoved = 0;
            for (int i = _count-1; i > -1 && !Removed; i--)
            {
                if (_array[i].Equals(Element))
                {
                    _array[i] = default;
                    Removed = true;
                    IndexRemoved = i;
                }
            }
            for (int i = IndexRemoved; i < _capacity-1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _array[_capacity - 1] = default;
            _count--;
            return true;
        }
        public bool Insert(int NumElement, T element)
        {
            if (_count + 1 < NumElement) throw new ArgumentOutOfRangeException();
            if (NumElement == _count + 1) IncreaseCapacity(_capacity);
            for (int i = _count; i > NumElement; i--)
            {
                _array[i] = _array[i-1];
            }
            _array[NumElement] = element;
            _count++;
            return true;
        }
        public bool IncreaseCapacity(int count)
        {
            if (count < 0) return false;
            T[] TempArray = new T[_capacity + count];
            for (int i = 0; i < _count; i++)
            {
                TempArray[i] = _array[i];
            }
            _array = TempArray;
            _capacity += count;
            return true;
        }   

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrEnumirator<T>(_array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrEnumirator<T>(_array);
        }
        public void InitDynamicEnumer()
        {
            Enumirator = new DynamicEnumetator();
        }
        public class DynamicEnumetator : DynamicArray<T>
        {
            private int _index;
            public int Index {
                get
                {
                    return _index;
                }
                set
                {
                    if (value < 0 || value > _capacity - 1) throw new ArgumentOutOfRangeException();
                    _index = value;
                }
            }
            public T GetItem()
            {
                return _array[_index];
            }
            public void GetItem(T NewItem)
            {
                _array[_index] = NewItem;
            }
        }
    }
    class DynamicArrEnumirator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int _index = 0;
        public T Current { get { return _array[_index]; } }

        object IEnumerator.Current => Current;
        public DynamicArrEnumirator(T[] array)
        {
            _array = array;
        }
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (_index + 1 > _array.Length-1) return false;
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
