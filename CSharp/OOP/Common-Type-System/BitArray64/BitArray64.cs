using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BitArray64 : IEnumerable<int>
{
    private int length = 0;
    private ulong[] bitArr64;
    public ulong[] BitArr64
    {
        get { return this.bitArr64; }
        set { this.bitArr64 = value; }
    }
    public int Length
    {
        get { return this.length; }
    }
    public BitArray64(int length)
    {
        this.length = length;
        bitArr64 = new ulong[length];
    }
    public ulong this[int index] //indexer
    {
        get
        {
            if (index < 0 || index >= bitArr64.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return bitArr64[index];
        }
        set
        {
            if (index < 0 || index >= bitArr64.Length)
            {
                throw new IndexOutOfRangeException();
            }
            bitArr64[index] = value;
        }
    }
    public override bool Equals(object obj)
    {
        BitArray64 other = obj as BitArray64;
        if (other == null)
        {
            return false;
        }
        bool equal = true;
        if (this.Length == other.Length)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != other[i])
                {
                    equal = false;
                    break;
                }
            }
        }
        else
        {
            equal = false;
        }
        return equal;
    }
    public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
    {
        return arr1.Equals(arr2);
    }
    public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
    {
        return !(arr1.Equals(arr2));
    }
    public override int GetHashCode()
    {
        ulong hashCode = 0;
        if (this.Length < 1)
        {
            return (int)hashCode;
        }
        hashCode = this[0];
        for (int i = 1; i < this.Length; i++)
        {
            hashCode ^= this[i];
        }
        return (int)hashCode;
    }
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.Length; i++)
        {
            yield return (int)this[i];
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
