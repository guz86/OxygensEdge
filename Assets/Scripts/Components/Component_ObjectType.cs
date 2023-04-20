using GameEngine;
using GameEngine.ObjectTypes;
using UnityEngine;

namespace Components
{
    public class Component_ObjectType : MonoBehaviour, IComponent_GetObjectType
    {
    
    public ObjectType ObjectType
    {
        get { return this.objectType.Value; }
    }


    [SerializeField]
    private ObjectTypeAdapter objectType;
    }
}