using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must not be less than 3 characters in length")]
        [MaxLength(3, ErrorMessage = "Code must not exceed 3 characters in length")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters in length")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }

    }
}
