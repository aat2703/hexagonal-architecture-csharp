using System.ComponentModel.DataAnnotations;

namespace HexagonalArchitecture.Infrastructure.Http
{
    public class RegisterShopRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}