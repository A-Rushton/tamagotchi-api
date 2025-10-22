using System;
using Microsoft.Extensions.Time.Testing;
using Tamagotchi.Domain.Entities;
using Tamagotchi.Domain.Enums;
using Xunit;

namespace Tamagotchi.Domain.Tests;

public class PetTests
{
    private readonly FakeTimeProvider _timeProvider;

    public PetTests()
    {
        _timeProvider = new FakeTimeProvider();
        _timeProvider.SetUtcNow(new DateTime(2025, 10, 20, 10, 0, 0));
    }
    
    [Fact]
    public void Pet_Starts_Neutral()
    {
        // Arrange
        var pet = new Pet();
        // Act
        // (No action needed)
        // Assert
        Assert.Equal(HungerLevel.Peckish, pet.Hunger);
        Assert.Equal(HappinessLevel.Content, pet.Happiness);
    }

    [Fact]
    public void Feed_Pet_Increases_Hunger_Level()
    {
        // Arrange
        var pet = new Pet { Hunger = HungerLevel.Peckish };
        // Act
        pet.Feed(_timeProvider.GetUtcNow());
        // Assert
        Assert.Equal(HungerLevel.Satisfied, pet.Hunger);
    }

    [Fact]
    public void Feed_Pet_Cannot_Exceed_Full_Hunger_Level()
    {
        // Arrange
        var pet = new Pet { Hunger = HungerLevel.Full };
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pet.Feed(_timeProvider.GetUtcNow()));
    }

    [Fact]
    public void Play_Pet_Increases_Happiness_Level()
    {
        // Arrange
        var pet = new Pet { Happiness = HappinessLevel.Happy };
        // Act
        pet.Play(_timeProvider.GetUtcNow());
        // Assert
        Assert.Equal(HappinessLevel.Ecstatic, pet.Happiness);
    }

    [Fact]
    public void Play_Pet_Cannot_Exceed_Ecstatic_Happiness_Level()
    {
        // Arrange
        var pet = new Pet { Happiness = HappinessLevel.Ecstatic };
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pet.Play(_timeProvider.GetUtcNow()));
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

    [Fact]
    public void Checkup_Starves_And_Neglects_Pet_After_Time()
    {
        // Arrange
        var pet = new Pet();
        pet.Feed(_timeProvider.GetUtcNow());
        pet.Play(_timeProvider.GetUtcNow());
        
        // Act
        pet.Checkup(_timeProvider.GetUtcNow().AddMinutes(3));
        
        // Assert
        Assert.Equal(HungerLevel.Peckish, pet.Hunger);
        Assert.Equal(HappinessLevel.Content, pet.Happiness);
    }
    
    [Fact]
    public void Checkup_Does_Not_Starve_Or_Neglect_Pet_Before_Time()
    {
        // Arrange
        var pet = new Pet();
        pet.Feed(_timeProvider.GetUtcNow());
        pet.Play(_timeProvider.GetUtcNow());
        
        // Act
        pet.Checkup(_timeProvider.GetUtcNow().AddMinutes(1));
        
        // Assert
        Assert.Equal(HungerLevel.Satisfied, pet.Hunger);
        Assert.Equal(HappinessLevel.Happy, pet.Happiness);
    }
}