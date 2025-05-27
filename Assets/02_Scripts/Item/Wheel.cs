using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Item
{
    public override void OnItemAcquired(PlayerController player)
    {
        player.Heal();
    }
}
