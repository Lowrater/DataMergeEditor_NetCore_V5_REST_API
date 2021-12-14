using System.ComponentModel.DataAnnotations;

namespace DataMergeEditor_Restfull_API.Models.EntityModels.Game
{
    public class Games
    {
        [Required]
        [Key]
        public int GameID { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string GameCompany { get; set; }
        [Required]
        public string GameType { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
