using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class ShouldNotContainBugAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (valueAsString.ToLower().Contains("bug"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
