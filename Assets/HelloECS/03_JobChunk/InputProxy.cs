using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace JobChunk
{
    [RequiresEntityConversion]
    public class InputProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float speed = 2.5f;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new InputComponent { Speed = speed };
            dstManager.AddComponentData(entity, data);
        }
    }
}
