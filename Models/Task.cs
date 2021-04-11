using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoList.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDetails { get; set; }
    }
}
