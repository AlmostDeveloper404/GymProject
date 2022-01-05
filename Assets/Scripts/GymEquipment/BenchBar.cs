using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchBar : GymEquipment
{
    [Header("BodyPartsToUpgrade")]
    [SerializeField] private int _chestBoost;

    public override void Train()
    {
        base.Train();
        Customer.Chest += _chestBoost;

        Customer.CheckForFinish();
    }
}
