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
    public void Test1()
    {
    }
}