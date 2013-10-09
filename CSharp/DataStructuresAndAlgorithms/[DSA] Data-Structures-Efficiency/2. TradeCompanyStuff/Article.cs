namespace TradeCompanyStuff
{
    using System;

    public class Article: IComparable
    {
        public Article(string title, int price, string vendor, int barcode)
        {
            this.Title = title;
            this.Price = price;
            this.Vendor = vendor;
            this.Barcode = barcode;
        }

        public string Title { get; set; }
        public int Price { get; set; }
        public string Vendor { get; set; }
        public int Barcode { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null || obj.GetType().Name != "Article")
            {
                throw new ArgumentException("Invalid object.");
            }
            else
            {
                Article other = obj as Article;
                if (this.Price == other.Price)
                {
                    if (this.Title == other.Title)
                    {
                        if (this.Vendor == other.Vendor)
                        {
                            if (this.Barcode == other.Barcode)
                            {
                                return 0;
                            }
                            else
                            {
                                return this.Barcode.CompareTo(other.Barcode);
                            }
                        }
                        else
                        {
                            return string.Compare(this.Vendor, other.Vendor);
                        }
                    }
                    else
                    {
                        return string.Compare(this.Title, other.Title);
                    }
                }
                else
                {
                    return this.Price.CompareTo(other.Price);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "Article")
	        {
		        throw new ArgumentException("Invalid object.");
	        }
            else
	        {
                Article other = obj as Article;
                if (this.Title == other.Title)
                {
                    if (this.Price == other.Price)
                    {
                        if (this.Vendor == other.Vendor)
                        {
                            if (this.Barcode == other.Barcode)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
	        }
        }

        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;

            unchecked
            {
                result = result * prime + this.Title.GetHashCode();
                result = result * prime + this.Price.GetHashCode();
                result = result * prime + this.Vendor.GetHashCode();
                result = result * prime + this.Barcode.GetHashCode();
            }

            return result;
        }

        public override string ToString()
        {
            string result = string.Format("Title: {0}; Price: {1}; Vendor: {2}; Barcode: {3}", this.Title, this.Price, this.Vendor, this.Barcode);
            return result;
        }
    }
}
