// Entity base class for domain-driven design.
// Properties: Id (Guid), CreatedAt (DateTime), UpdatedAt (DateTime).
// These are standard for tracking identity and lifecycle of domain entities.
// Added as per AI prompt: "Add basic properties for an entity" using copilot.
namespace Tamagotchi.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
}