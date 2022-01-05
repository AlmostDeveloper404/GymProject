using UnityEngine;
using UnityEngine.UI;

public class ProgressDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _displayPanal;

    private Customer _currentCustomer;

    [SerializeField] private Text _rightArm, _leftArm, _rightShoulder, _leftShoulder, _chest, _belly, _rightLeg, _leftLeg, _rightLowerLeg, _leftLowerLeg;
    public void SetSelectedCustomerProgress(Customer customer)
    {

        if (customer==_currentCustomer)
        {
            if (customer._gymEquipment)
            {
                HideProgressPanal();
            }
            _currentCustomer = null;
            return;
        }

        _currentCustomer = customer;
        
        _displayPanal.SetActive(true);

        _rightArm.text = $"{customer.RightArm}%";
        _leftArm.text = $"{customer.LeftArm}%";
        _rightShoulder.text = $"{customer.RightShoulder}%";
        _leftShoulder.text = $"{customer.LeftShoulder}%";
        _chest.text = $"{customer.Chest}%";
        _belly.text = $"{customer.Belly}%";
        _rightLeg.text = $"{customer.RightLeg}%";
        _leftLeg.text = $"{customer.LeftLeg}%";
        _rightLowerLeg.text = $"{customer.RightLowerLeg}%";
        _leftLowerLeg.text = $"{customer.LeftLowerLeg}%";
    }

    public void HideProgressPanal()
    {
        _currentCustomer = null;
        _displayPanal.SetActive(false);
    }
    public void OpenProgressPanal()
    {
        _displayPanal.SetActive(true);
    }

    public void UpdateProgress(Customer customer)
    {
       
        _rightArm.text = $"{customer.RightArm}%";
        _leftArm.text = $"{customer.LeftArm}%";
        _rightShoulder.text = $"{customer.RightShoulder}%";
        _leftShoulder.text = $"{customer.LeftShoulder}%";
        _chest.text = $"{customer.Chest}%";
        _belly.text = $"{customer.Belly}%";
        _rightLeg.text = $"{customer.RightLeg}%";
        _leftLeg.text = $"{customer.LeftLeg}%";
        _rightLowerLeg.text = $"{customer.RightLowerLeg}%";
        _leftLowerLeg.text = $"{customer.LeftLowerLeg}%";
    }

}
