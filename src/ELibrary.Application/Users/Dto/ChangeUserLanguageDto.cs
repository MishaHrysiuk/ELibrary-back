using System.ComponentModel.DataAnnotations;

namespace ELibrary.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}