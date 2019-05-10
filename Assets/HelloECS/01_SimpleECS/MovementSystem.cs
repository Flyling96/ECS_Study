using UnityEngine;
using Unity.Entities;

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
            var speed = 5.0f;

            //遍历所有的所有包含结构体中组件的Entity
            foreach (var e in GetEntities<Components>())
            {
                var vector = new Vector3(e.InputComponent.Horizontal, 0, e.InputComponent.Vertical);

                e.Transform.Translate(vector * deltaTime * speed);
            }
        }
    }
}
