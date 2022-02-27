using Family.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.DAL.Entities
{
    public class Request : BaseEntity
    {
        public int SenderId { get; set; }
        public virtual Person Sender { get; set; }
        public int ReceiverId { get; set; }
        public virtual Person Receiver { get; set; }
        public RelationEnum Relation { get; set; }
        public DateTime RequestDate { get; set; }
        public ResponseEnum Response { get; set; }
    }
}
