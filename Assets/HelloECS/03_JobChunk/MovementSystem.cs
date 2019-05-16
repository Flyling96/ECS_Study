using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace JobChunk
{
    public class MovementSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(ComponentType.ReadOnly<InputComponent>(),ComponentType.ReadWrite<Translation>());
        }

        [BurstCompile]
        private struct MoveSystemJob : IJobChunk
        {
            public float DeltaTime;
            [ReadOnly] public ArchetypeChunkComponentType<InputComponent> InputComponent;
            public ArchetypeChunkComponentType<Translation> Translation;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var chunkInputs = chunk.GetNativeArray(InputComponent);
                var chunkTrans = chunk.GetNativeArray(Translation);

                for (var i = 0; i < chunk.Count; i++)
                {
                    var vector = new float3(chunkInputs[i].Horizontal, 0, chunkInputs[i].Vertical);
                    float3 originValue = chunkTrans[i].Value;
                    float speed = chunkInputs[i].Speed;

                    chunkTrans[i] = new Translation
                    {
                        Value = originValue + vector * DeltaTime * speed
                    };
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var inputType = GetArchetypeChunkComponentType<InputComponent>(true);
            var moveType = GetArchetypeChunkComponentType<Translation>(false);

            var job = new MoveSystemJob()
            {
                InputComponent = inputType,
                Translation = moveType,
                DeltaTime = Time.deltaTime
            };

            return job.Schedule(m_Group, inputDeps);
        }


    }
}