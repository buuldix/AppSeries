﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeries.Models
{
    public class Serie
    {
        [Key]
        [Column("serieid")]
        public int Serieid { get; set; }

        [Column("titre")]
        [StringLength(100)]
        public string Titre { get; set; } = null!;

        [Column("resume")]
        public string? Resume { get; set; }

        [Column("nbsaisons")]
        public int? Nbsaisons { get; set; }

        [Column("nbepisodes")]
        public int? Nbepisodes { get; set; }

        [Column("anneecreation")]
        public int? Anneecreation { get; set; }

        [Column("network")]
        [StringLength(50)]
        public string? Network { get; set; }

        public Serie(int serieid, string titre, string? resume, int? nbsaisons, int? nbepisodes, int? anneecreation, string? network)
        {
            Serieid = serieid;
            Titre = titre;
            Resume = resume;
            Nbsaisons = nbsaisons;
            Nbepisodes = nbepisodes; 
            Anneecreation = anneecreation;
            Network = network;
        }

        public override string ToString()
        {
            return $"{Serieid} {Titre} {Resume} {Nbsaisons} {Nbepisodes} {Anneecreation} {Network}";
        }
    }
}
