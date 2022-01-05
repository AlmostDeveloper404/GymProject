using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : GymEquipment
{
    [Header("BodyPartsToUpgrade")]
    [SerializeField] private int _arm;
    [SerializeField] private int _shoulder;

    public override void Train()
    {
        base.Train();

        Customer.RightArm += _arm;
        Customer.LeftArm += _arm;
        Customer.RightShoulder += _shoulder;
        Customer.LeftShoulder += _shoulder;

        Customer.CheckForFinish();
    }
}
