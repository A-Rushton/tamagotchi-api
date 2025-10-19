using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domain.Enums;

/// <summary>
/// Enumeration representing the hunger status of a pet.
/// Each value has a display name for use in UI or AI prompts.
/// </summary>
public enum HungerLevel
{
    [Display(Name = "Full")]
    Full = 0,
    [Display(Name = "Satisfied")]
    Satisfied = 1,
    [Display(Name = "Peckish")]
    Peckish = 2,
    [Display(Name = "Hungry")]
    Hungry = 3,
    [Display(Name = "Starving")]
    Starving = 4
}

