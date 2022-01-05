using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weights : GymEquipment
{
    [Header("BodyPartsToUpgrade")]
    [SerializeField] private int _upperLeg;
    [SerializeField] private int _lowerLeg;

    public override void Train()
    {
        base.Train();

        

        Customer.LeftLeg += _upperLeg;
        Customer.RightLeg += _upperLeg;
        Customer.RightLowerLeg += _lowerLeg;
        Customer.LeftLowerLeg += _lowerLeg;

        Customer.CheckForFinish();
    }


}
