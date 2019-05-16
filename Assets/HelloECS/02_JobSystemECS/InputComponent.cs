using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace JobSystemECS
{
    [SerializeField]
    public struct InputComponent : IComponentData
    {
        public float Speed;
        public float Horizontal;
        public float Vertical;
    }
}
