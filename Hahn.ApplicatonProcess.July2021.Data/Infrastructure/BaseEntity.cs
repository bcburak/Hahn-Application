using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Infrastructure
{
    public abstract class BaseEntity 
    {
        public virtual int Id { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual string UserCreated { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string UserModified { get; set; }
        public virtual bool? SoftDeleted { get; set; }
        //public virtual int Id { get; set; }
    }
}
