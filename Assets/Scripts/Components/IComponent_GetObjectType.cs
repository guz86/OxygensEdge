using GameEngine;
using GameEngine.ObjectTypes;

namespace Components
{
    public interface IComponent_GetObjectType 
    {
        ObjectType ObjectType { get; }
    }
}