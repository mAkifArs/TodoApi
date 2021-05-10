using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Hangfire.PostgreSql.Properties;

namespace TodoApi.DATA.DTO
{
    public class UserInfoDTO
    {
        [JsonIgnore]
        public int UserId { get; set; }
        
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        
        [Required]
        [NotNull]
        public string Name { get; set; }
    }
}