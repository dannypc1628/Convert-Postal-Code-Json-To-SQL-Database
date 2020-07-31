using System;
using System.Collections.Generic;

namespace Convert_Postal_Code_Json_To_SQL_Database.Models
{
    public partial class Postal
    {
        public Postal()
        {
            InverseParent = new HashSet<Postal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
        public int ParentId { get; set; }

        public virtual Postal Parent { get; set; }
        public virtual ICollection<Postal> InverseParent { get; set; }
    }
}
