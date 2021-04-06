﻿using System.ComponentModel.DataAnnotations;

namespace Mvc1VaccinDemo.Data
{
    public class VaccineringsFas
    {
        public int Id { get; set; }
        
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Myndighet AnsvarigMyndighet { get; set; }
    }
}