using Tamagotchi.Domain.Enums;

namespace Tamagotchi.Domain.Entities;

/// <summary>
/// Represents a Tamagotchi pet entity.
/// Inherits from the abstract Entity class.
/// </summary>
public class Pet : Entity
{
    public Pet()
    {
        Happiness = HappinessLevel.Content;
        Hunger = HungerLevel.Satisfied;
    }
    
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
    /// Throws InvalidOperationException if already Full.
    /// </summary>
    public void Feed()
    {
        if (Hunger == HungerLevel.Full)
            throw new InvalidOperationException("Pet is already full.");
        var maxHunger = Enum.GetValues(typeof(HungerLevel)).Cast<int>().Max();
        if ((int)Hunger < maxHunger)
            Hunger = (HungerLevel)((int)Hunger + 1);
        LastFed = DateTime.UtcNow;
    }

    /// <summary>
    /// Play with the pet: increment Happiness by 1 (up to max), and update LastPlayedWith.
    /// Throws InvalidOperationException if already Ecstatic.
    /// </summary>
    public void Play()
    {
        if (Happiness == HappinessLevel.Ecstatic)
            throw new InvalidOperationException("Pet is already ecstatic.");
        var maxHappiness = Enum.GetValues(typeof(HappinessLevel)).Cast<int>().Max();
        if ((int)Happiness < maxHappiness)
            Happiness = (HappinessLevel)((int)Happiness + 1);
        LastPlayedWith = DateTime.UtcNow;
    }

    /// <summary>
    /// Starve the pet: decrement Hunger by 1 (down to min). Throws InvalidOperationException if already Starving.
    /// </summary>
    public void Starve()
    {
        if (Hunger == HungerLevel.Starving)
            throw new InvalidOperationException("Pet has died of starvation.");
        var minHunger = Enum.GetValues(typeof(HungerLevel)).Cast<int>().Min();
        if ((int)Hunger > minHunger)
            Hunger = (HungerLevel)((int)Hunger - 1);
    }

    /// <summary>
    /// Neglect the pet: decrement Happiness by 1 (down to min). Throws InvalidOperationException if already Miserable.
    /// </summary>
    public void Neglect()
    {
        if (Happiness == HappinessLevel.Miserable)
            throw new InvalidOperationException("Pet has run away due to misery.");
        var minHappiness = Enum.GetValues(typeof(HappinessLevel)).Cast<int>().Min();
        if ((int)Happiness > minHappiness)
            Happiness = (HappinessLevel)((int)Happiness - 1);
    }
}
