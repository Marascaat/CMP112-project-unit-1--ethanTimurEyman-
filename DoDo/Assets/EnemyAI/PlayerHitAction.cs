using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerHit", story: "[Player] is Hit", category: "Action", id: "48d44d518e70135205f22e34b9d0a464")]
public partial class PlayerHitAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    protected override Status OnUpdate()
    {
        if (Player.Value != null)
        {
            playerHP hp = Player.Value.GetComponent<playerHP>();
            hp.PlayerHit();
            return Status.Success;
        }

        return Status.Failure;
    }

}

