using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class PositionComponent : IComponent
{
    [PrimaryEntityIndex]
    public Vector2Int value;
}
