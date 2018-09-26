﻿namespace Domain.Entities
{
    // Assume this class was autogenerated from DB
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClaimed { get; set; } //Flag to check if pet has already been claimed
    }
}
