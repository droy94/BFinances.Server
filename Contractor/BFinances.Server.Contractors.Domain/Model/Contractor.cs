using BFinances.Server.Common.Domain.Model;

namespace BFinances.Server.Contractors.Domain.Model
{
    public class Contractor : Entity
    {
        public string Name { get; set; }

        public string Nip { get; set; }
    }
}