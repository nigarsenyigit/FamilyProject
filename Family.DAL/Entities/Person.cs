using Family.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.DAL.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Mothers = new List<Parent>();
            Fathers = new List<Parent>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthOfDay { get; set; }
        public GenderEnum Gender { get; set; }
        public bool IsLife { get; set; }
        public int? ParentId { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual ICollection<Parent> Mothers { get; set; }
        public virtual ICollection<Parent> Fathers { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Request> Receivers { get; set; }

    }
}
