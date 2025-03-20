﻿#pragma warning disable CS8618 
using System.ComponentModel.DataAnnotations;

namespace ServicePet.WebApi.Models.Requests
{
    public class UpdatePetProfileRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ProfileId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        public string? Description { get; set; }
    }
}
