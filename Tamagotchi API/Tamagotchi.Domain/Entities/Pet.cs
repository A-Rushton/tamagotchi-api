using Tamagotchi.Domain.Enums;

namespace Tamagotchi.Domain.Entities;

/// <summary>
/// Represents a Tamagotchi pet entity.
/// Inherits from the abstract Entity class.
/// </summary>
public class Pet : Entity
{
    // --- AI Prompt Comments ---
    // This class models a Tamagotchi pet for the domain layer.
    // It inherits the unique Id, CreatedAt, and UpdatedAt from Entity.
    // Add properties such as Name, Age, HungerLevel, and HappinessLevel to represent the pet's state.

    /// <summary>
    /// The name of the pet.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The age of the pet in days.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// The hunger level of the pet.
    /// Uses the HungerLevel enumeration for status and display name.
    /// </summary>
    public HungerLevel Hunger { get; set; }

    /// <summary>
    /// The happiness level of the pet.
    /// Uses the HappinessLevel enumeration for status and display name.
    /// </summary>
    public HappinessLevel Happiness { get; set; }

    /// <summary>
    /// The date and time when the pet was last fed.
    /// Can only be set by this entity.
    /// </summary>
    public DateTime LastFed { get; private set; }

    /// <summary>
    /// The date and time when the pet was last played with.
    /// Can only be set by this entity.
    /// </summary>
    public DateTime LastPlayedWith { get; private set; }

    /// <summary>
    /// Feed the pet: increment Hunger by 1 (up to max), and update LastFed.
    /// </summary>
    public void Feed()
    {
        var maxHunger = Enum.GetValues(typeof(HungerLevel)).Cast<int>().Max();
        if ((int)Hunger < maxHunger)
            Hunger = (HungerLevel)((int)Hunger + 1);
        LastFed = DateTime.UtcNow;
    }

    /// <summary>
    /// Play with the pet: increment Happiness by 1 (up to max), and update LastPlayedWith.
    /// </summary>
    public void Play()
    {
        var maxHappiness = Enum.GetValues(typeof(HappinessLevel)).Cast<int>().Max();
        if ((int)Happiness < maxHappiness)
            Happiness = (HappinessLevel)((int)Happiness + 1);
        LastPlayedWith = DateTime.UtcNow;
    }
}
