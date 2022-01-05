using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abs : GymEquipment
{
    [Header("BodyPartsToUpgrade")]
    [SerializeField] private int _absBoost;

    public override void Train()
    {
        base.Train();

        Customer.Belly += _absBoost;

        Customer.CheckForFinish();
    }
}
