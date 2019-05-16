using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Jobs;

namespace JobSystemECS
{
    public class MovementSystem : JobComponentSystem
    {

        struct MoveJob:IJobForEach<Translation,InputComponent>
        {
            public float DeltaTime;

            public void Execute(ref Translation translation, [ReadOnly] ref InputComponent inputComponent)
            {
                var vector = new float3(inputComponent.Horizontal, 0, inputComponent.Vertical);
                float speed = inputComponent.Speed;
                translation.Value += vector * DeltaTime * speed;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new MoveJob()
            {
                DeltaTime = Time.deltaTime
            };

            return job.Schedule(this, inputDependencies);
        }
    }
}
