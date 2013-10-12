using System;
using System.ComponentModel;

namespace TicketingSystem.Models
{
    public enum Priority
    {
        [Description("Low")]
        Low,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High
    }
}
