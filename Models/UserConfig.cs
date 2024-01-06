﻿namespace CarCareTracker.Models
{
    public class UserConfig
    {
        public bool UseDarkMode { get; set; }
        public bool UsekWh { get; set; }
        public bool EnableCsvImports { get; set; }
        public bool UseMPG { get; set; }
        public bool UseDescending { get; set; }
        public bool EnableAuth { get; set; }
        public string UserNameHash { get; set; }
        public string UserPasswordHash { get; set;}
    }
}