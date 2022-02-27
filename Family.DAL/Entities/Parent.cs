using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.DAL.Entities
{
    public class Parent : BaseEntity
    {
        public Parent()
        {
            Childs = new List<Person>();
        }
        public int MotherId { get; set; }
        public virtual Person Mother { get; set; }
        public int FatherId { get; set; }
        public virtual Person Father { get; set; }
        public DateTime MarriedDate { get; set; }
        public DateTime? DivorceDate { get; set; }
        public bool IsMaried { get; set; }
        public virtual ICollection<Person> Childs { get; set; }
    }
}
