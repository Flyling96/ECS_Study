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
    public class InputSystem : JobComponentSystem
    {
        struct InputJob : IJobForEach<Translation, InputComponent>
        {
            public float Horizontal;
            public float Vertical;

            public void Execute([ReadOnly] ref Translation translation, ref InputComponent inputComponent)
            {
                inputComponent.Horizontal = Horizontal;
                inputComponent.Vertical = Vertical;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new InputJob()
            {
                Horizontal = Input.GetAxis("Horizontal"),
                Vertical = Input.GetAxis("Vertical")
            };

            return job.Schedule(this, inputDependencies);
        }
    }
}
