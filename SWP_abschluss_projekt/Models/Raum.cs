﻿namespace SWP_abschluss_projekt.Models
{
    public class Raum
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public Raum(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
        }
    }
}
