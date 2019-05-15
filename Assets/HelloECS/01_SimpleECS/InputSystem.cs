using Unity.Entities;
using UnityEngine;

namespace SimpleECS
{
    public class InputSystem : ComponentSystem
    {
        //private struct Data
        //{
        //    //结构体长度，即数据数量
        //    public readonly int Length;

        //    //获取所有包含InputComponent的数组
        //    public ComponentArray<InputComponent> InputComponents;
        //}

        //private struct InputStruct
        //{
        //    public InputComponent InputComponent;
        //}

        ////Unity会自动注入满足此字段的对象
        //[Inject] Data data;

        protected override void OnUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            //foreach (var e in GetEntities<InputStruct>())
            //{
            //    e.InputComponent.Horizontal = horizontal;
            //    e.InputComponent.Vertical = vertical;
            //}
            //for (int i = 0; i < data.Length; i++)
            //{
            //    data.InputComponents[i].Horizontal = horizontal;
            //    data.InputComponents[i].Vertical = vertical;
            //}

            Entities.ForEach((ref InputComponent inputComponent) =>
            {
                inputComponent.Horizontal = horizontal;
                inputComponent.Vertical = vertical;
            });

        }
    }
}
