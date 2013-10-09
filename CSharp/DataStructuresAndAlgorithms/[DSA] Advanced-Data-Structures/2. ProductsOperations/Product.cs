namespace ProductsOperations
{
    using System;

    public class Product: IComparable
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "Product")
            {
                throw new ArgumentException("Invalid object.");
            }
            else
            {
                Product other = obj as Product;
                if (this.Name != other.Name)
                {
                    return false;
                }

                if (this.Price != other.Price)
                {
                     return false;
                }

                return true;
            }
        } 

        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;

            unchecked
            {
                result = result * prime + this.Name.GetHashCode();
                result = result * prime + this.Price.GetHashCode();
            }

            return result;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || obj.GetType().Name != "Product")
            {
                throw new ArgumentException("Invalid object.");
            }
            else
            {
                Product other = obj as Product;
                if (this.Price == other.Price)
                {
                    if (this.Name == other.Name)
                    {
                        return 0;
                    }
                    else
                    {
                        return string.Compare(this.Name, other.Name);
                    }
                }
                else
                {
                    return this.Price.CompareTo(other.Price);
                }
            }
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}; Price: {1}", this.Name, this.Price);
            return result;
        }
    }
}
