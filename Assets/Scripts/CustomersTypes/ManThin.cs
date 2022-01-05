using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManThin : Customer
{
    [Header("CurrentPercent")]
    [SerializeField] private int _arms, _chest, _legs, _belly;
    public override void SetupCustomerStats()
    {
        LeftArm = _arms;
        RightArm = _arms;
        RightShoulder = _arms;
        LeftShoulder = _arms;
        Chest = _chest;
        Belly = _belly;
        RightLeg = _legs;
        LeftLeg = _legs;
        RightLowerLeg = _legs;
        LeftLowerLeg = _legs;
    }
}
