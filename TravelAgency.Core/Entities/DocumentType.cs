using System.Collections.Generic;

#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class DocumentType    {
        public DocumentType()
        {
            Guest = new HashSet<Guest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Guest> Guest { get; set; }
    }
}
