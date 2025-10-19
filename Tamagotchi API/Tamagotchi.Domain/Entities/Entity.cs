// Entity base class for domain-driven design.
// Properties: Id (Guid), CreatedAt (DateTime), UpdatedAt (DateTime).
// These are standard for tracking identity and lifecycle of domain entities.
// Added as per AI prompt: "Add basic properties for an entity" using copilot.
namespace Tamagotchi.Domain.Entities;

public abstract class Entity
{
    // Should there be an additional layer of abstraction for Game Entities which inherit from Entity?
    // Game entities could store settings such as day length, hunger rate, happiness rate, etc.
    
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
}