using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace JobChunk
{
    public class InputSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(ComponentType.ReadWrite<InputComponent>());
        }

        [BurstCompile]
        private struct InputSystemJob : IJobChunk
        {
            public float Horizontal;
            public float Vertical;

            public ArchetypeChunkComponentType<InputComponent> InputComponent;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var chunkInputs = chunk.GetNativeArray(InputComponent);
                for (var i = 0; i < chunk.Count; i++)
                {
                    float speed = chunkInputs[i].Speed;
                    chunkInputs[i] = new InputComponent
                    {
                        Speed = speed,
                        Horizontal = Horizontal,
                        Vertical = Vertical
                    };
                }
            }
        }


        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var inputType = GetArchetypeChunkComponentType<InputComponent>(false);

            var job = new InputSystemJob()
            {
                InputComponent = inputType,
                Horizontal = Input.GetAxis("Horizontal"),
                Vertical = Input.GetAxis("Vertical")
            };

            return job.Schedule(m_Group, inputDeps);
        }
    }
}
