using System;
using System.Collections.Generic;


namespace MasterData.Msv.Models
{

    public partial class MstCustomer
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Telp { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}