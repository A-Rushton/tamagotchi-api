using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domain.Enums;

/// <summary>
/// Enumeration representing the happiness status of a pet.
/// Each value has a display name for use in UI or AI prompts.
/// </summary>
public enum HappinessLevel
{
    [Display(Name = "Ecstatic")]
    Ecstatic = 0,
    [Display(Name = "Happy")]
    Happy = 1,
    [Display(Name = "Content")]
    Content = 2,
    [Display(Name = "Sad")]
    Sad = 3,
    [Display(Name = "Miserable")]
    Miserable = 4
}

