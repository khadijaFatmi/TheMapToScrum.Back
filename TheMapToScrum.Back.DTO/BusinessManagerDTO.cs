﻿using System.ComponentModel.DataAnnotations;

namespace TheMapToScrum.Back.DTO
{
    public class BusinessManagerDTO : BaseEntityDTO
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string FullName { get; set; }
    }
}
