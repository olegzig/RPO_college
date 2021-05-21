using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPO_college
{
    public class ToDoFlyoutMenuItem
    {
        public ToDoFlyoutMenuItem()
        {
            TargetType = typeof(ToDoFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}