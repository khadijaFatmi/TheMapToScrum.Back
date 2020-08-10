using System;
using System.Collections.Generic;
using System.Text;

namespace TheMapToScrum.Back.DTO
{
    public class TechnicalManagerDTO : BaseEntityDTO
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
