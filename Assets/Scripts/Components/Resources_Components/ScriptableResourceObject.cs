using Gameplay.GameResources;
using UnityEngine;

namespace Components.Resources_Components
{
    [CreateAssetMenu(
        fileName = "ScriptableResourceObject",
        menuName = "Gameplay/Resources/New ScriptableResourceObject"
    )]
    public sealed class ScriptableResourceObject : ScriptableObject
    {
        [SerializeField]
        public ResourceType type;

        [SerializeField]
        public int count;
    }
}