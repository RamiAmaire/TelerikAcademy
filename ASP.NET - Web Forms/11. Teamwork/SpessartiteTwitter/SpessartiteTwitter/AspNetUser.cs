//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpessartiteTwitter
{
    using SpessartiteTwitter.Data;
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.Comments = new HashSet<Comment>();
            this.Tweets = new HashSet<Tweet>();
        }
    
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> Age { get; set; }
        public byte[] Picture { get; set; }
        public string MobilePhone { get; set; }
        public string AboutMe { get; set; }
        public string WebSite { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}