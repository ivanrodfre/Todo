using System;
using System.Diagnostics.CodeAnalysis;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals([AllowNull] Entity other)
        {
            return Id == other.Id;
        }
    }
}
