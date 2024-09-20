using NZWalksAPI.Models.Domain;

using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddWalkRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters in length")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters in length")]
        public string Description { get; set; }

        [Required]
        [Range(0,50)]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }

    }
}
