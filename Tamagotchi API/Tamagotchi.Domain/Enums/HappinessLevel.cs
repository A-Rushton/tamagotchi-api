using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domain.Enums;

/// <summary>
/// Enumeration representing the happiness status of a pet.
/// Each value has a display name for use in UI or AI prompts.
/// </summary>
public enum HappinessLevel
{
    [Display(Name = "Miserable")]
    Miserable = 0,
    [Display(Name = "Sad")]
    Sad = 1,
    [Display(Name = "Content")]
    Content = 2,
    [Display(Name = "Happy")]
    Happy = 3,
    [Display(Name = "Ecstatic")]
    Ecstatic = 4
}

