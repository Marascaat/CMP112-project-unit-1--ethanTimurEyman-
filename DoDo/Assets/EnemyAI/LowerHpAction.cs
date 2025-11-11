using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "LowerHp", story: "[PlayerHp] decreased", category: "Action", id: "131c7d144349a70ff81df7fa7e12b9e9")]
public partial class LowerHpAction : Action
{
    [SerializeReference] public BlackboardVariable<playerHP> PlayerHp;
    protected override Status OnUpdate()
    {
        PlayerHp.Value.PlayerHit();
        return PlayerHp.Value == null ? Status.Failure : Status.Success;
    }
}

