﻿using System.ComponentModel.DataAnnotations;

namespace StudioManager.Models
{
    public abstract class Entitet
    {

        [Key]
        public int Sifra { get; set; }

    }
}
