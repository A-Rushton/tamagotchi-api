# PetTests.cs Transcript

This document provides a transcript of the PetTests.cs file, including all test cases for the Tamagotchi Pet domain logic. The tests are organized using Arrange, Act, and Assert comments for clarity.

```csharp
using System;
using Tamagotchi.Domain.Entities;
using Tamagotchi.Domain.Enums;
using Xunit;

namespace Tamagotchi.Domain.Tests;

public class PetTests
{
    // Pet starts neutral
    
    // Feed pet increases hunger level
    // Feed pet cannot exceed full hunger level
    // Feed pet throws if pet is already full
    
    // Play with pet increases happiness level
    // Play with pet cannot exceed ecstatic happiness level
    // Play with pet throws if pet is already ecstatic
    
    // Starve pet decreases hunger level
    // Starve pet cannot go below starving hunger level
    // Starve pet causes death if pet is already starving
    
    // Neglect pet decreases happiness level
    // Neglect pet cannot go below miserable happiness level
    // Neglect pet causes run away if pet is already miserable
    
    // These are not domain concerns, domain concerns itself with just
    // making sure it can update happiness and hunger levels correctly.
    //// Pet loses happiness over time
    //// Pet loses hunger over time
    
    [Fact]
    public void Pet_Starts_Neutral()
    {
        // Arrange
        var pet = new Pet();
        // Act
        // (No action needed)
        // Assert
        Assert.Equal(HungerLevel.Satisfied, pet.Hunger);
        Assert.Equal(HappinessLevel.Content, pet.Happiness);
    }

    [Fact]
    public void Feed_Pet_Increases_Hunger_Level()
    {
        // Arrange
        var pet = new Pet { Hunger = HungerLevel.Peckish };
        // Act
        pet.Feed();
        // Assert
        Assert.Equal(HungerLevel.Satisfied, pet.Hunger);
    }

    [Fact]
    public void Feed_Pet_Cannot_Exceed_Full_Hunger_Level()
    {
        // Arrange
        var pet = new Pet { Hunger = HungerLevel.Full };
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pet.Feed());
    }

    [Fact]
    public void Play_Pet_Increases_Happiness_Level()
    {
        // Arrange
        var pet = new Pet { Happiness = HappinessLevel.Happy };
        // Act
        pet.Play();
        // Assert
        Assert.Equal(HappinessLevel.Ecstatic, pet.Happiness);
    }

    [Fact]
    public void Play_Pet_Cannot_Exceed_Ecstatic_Happiness_Level()
    {
        // Arrange
        var pet = new Pet { Happiness = HappinessLevel.Ecstatic };
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pet.Play());
    }

    [Fact]
    public void Starve_Pet_Decreases_Hunger_Level()
    {
        // Arrange
        var pet = new Pet { Hunger = HungerLevel.Hungry };
        // Act
        pet.Starve();
        // Assert
        Assert.Equal(HungerLevel.Starving, pet.Hunger);
    }

    [Fact]
    public void Starve_Pet_Cannot_Go_Below_Starving_Hunger_Level()
    {
        // Arrange
        var pet = new Pet { Hunger = HungerLevel.Starving };
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pet.Starve());
    }

    [Fact]
    public void Neglect_Pet_Decreases_Happiness_Level()
    {
        // Arrange
        var pet = new Pet { Happiness = HappinessLevel.Sad };
        // Act
        pet.Neglect();
        // Assert
        Assert.Equal(HappinessLevel.Miserable, pet.Happiness);
    }

    [Fact]
    public void Neglect_Pet_Cannot_Go_Below_Miserable_Happiness_Level()
    {
        // Arrange
        var pet = new Pet { Happiness = HappinessLevel.Miserable };
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pet.Neglect());
    }
}
```

