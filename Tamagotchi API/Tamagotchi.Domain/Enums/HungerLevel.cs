using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domain.Enums;

/// <summary>
/// Enumeration representing the hunger status of a pet.
/// Each value has a display name for use in UI or AI prompts.
/// </summary>
public enum HungerLevel
{
    [Display(Name = "Starving")]
    Starving = 0,
    [Display(Name = "Hungry")]
    Hungry = 1,
    [Display(Name = "Peckish")]
    Peckish = 2,
    [Display(Name = "Satisfied")]
    Satisfied = 3,
    [Display(Name = "Full")]
    Full = 4
}

