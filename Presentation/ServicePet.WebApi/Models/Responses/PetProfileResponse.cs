﻿#pragma warning disable CS8618 
using System.ComponentModel.DataAnnotations;

namespace ServicePet.WebApi.Models.Responses
{
    public class PetProfileResponse
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Years { get; set; }
        public string? Description { get; set; }
        //фотография
    }
}
