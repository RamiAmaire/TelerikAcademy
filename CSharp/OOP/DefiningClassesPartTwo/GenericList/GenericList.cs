using System;

class GenericList<T> where T : IComparable
{
    private int length = 0;
    private T[] arr;
    private static int arrIndex = 0;
    public int Length
    {
        get { return this.length; }
    }
    public GenericList()
    {
    }
    public GenericList(int length)
    {
        this.length = length;
        arr = new T[length];
    }
    public void Add(T element)
    {
        arr[arrIndex++] = element;
        if (arrIndex + 1 == arr.Length) //autogrow
        {
            T[] newArr = arr;
            arr = new T[newArr.Length * 2];
            for (int i = 0; i < newArr.Length; i++)
            {
                arr[i] = newArr[i];
            }
        }
    }
    public T GetElementByIndex(int index)
    {
        T element = arr[index];
        return element;
    }
    public void RemoveAt(int index)
    {
        for (int i = index + 1; i < arr.Length; i++)
        {
            arr[i - 1] = arr[i];
        }
        arrIndex--;
    }
    public void Insert(T element, int index)
    {
        T[] tempArr = new T[arr.Length];
        int k = 0;
        for (int i = index; i < arr.Length; i++)
        {
            tempArr[k++] = arr[i];
        }
        arr[index] = element;
        k = 0;
        for (int i = index + 1; i < arr.Length; i++)
        {
            arr[i] = tempArr[k++];
        }
        arrIndex++;
        if (arrIndex + 1 == arr.Length) //autogrow
        {
            T[] newArr = arr;
            arr = new T[newArr.Length * 2];
            for (int i = 0; i < newArr.Length; i++)
            {
                arr[i] = newArr[i];
            }
        }
    }
    public void ClearList()
    {
        int temp = arr.Length;
        arr = new T[temp];
        arrIndex = 0;
    }
    public int FindElementByValue(T element)
    {
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(element))
            {
                index = i;
                break;
            }
        }
        return index;
    }
    public override string ToString()
    {
        string pointToString = string.Format("Type= {0}" + "\n" + "Length= {1} " + "\n" + "IsFixedSize= {2}", "GenericList<T>", arr.Length, !arr.IsFixedSize);
        return pointToString;
    }
    public T Min()
    {
        T min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if ((arr[i].CompareTo(min)) < 0 && !arr[i].Equals(0))
            {
                min = arr[i];
            }
        }
        return min;
    }
    public T Max()
    {
        T max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if ((arr[i].CompareTo(max)) > 0)
            {
                max = arr[i];
            }
        }
        return max;
    }
}