using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

namespace SimpleECS
{
    [RequiresEntityConversion]
    public class InputProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float speed = 0.5f;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new InputComponent {Speed = speed};
            dstManager.AddComponentData(entity, data);
        }
    }
}

