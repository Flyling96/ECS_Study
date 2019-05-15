using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace SimpleECS
{
    public class MovementSystem : ComponentSystem
    {
        private struct Components
        {
            public Transform Transform;
            public InputComponent InputComponent;
        }

        protected override void OnUpdate()
        {
            var deltaTime = Time.deltaTime;

            //遍历所有的所有包含结构体中组件的Entity
            //foreach (var e in GetEntities<Components>())
            //{
            //    var vector = new Vector3(e.InputComponent.Horizontal, 0, e.InputComponent.Vertical);

            //    e.Transform.Translate(vector * deltaTime * speed);
            //}

            Entities.ForEach((ref InputComponent inputComponent,ref Translation translation) =>
            {
                var vector = new float3(inputComponent.Horizontal, 0, inputComponent.Vertical);
                float speed = inputComponent.Speed;
                translation.Value += vector * deltaTime * speed;
            });
        }
    }
}
