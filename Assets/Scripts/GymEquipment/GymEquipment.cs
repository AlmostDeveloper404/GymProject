using UnityEngine;

public class GymEquipment : MonoBehaviour
{

    public Customer Customer;

    private float _timer;
    [SerializeField]private float _timerToGetUpgrade;

    public void SetCustomer(Customer customer)
    {
        //_timer = 0;
        Customer = customer;
        if (!Customer)
        {
            return;
        }
        Customer.transform.position = transform.position+new Vector3(0f,0f,-1f);
    }

    private void Update()
    {
        if (Customer)
        {
            _timer += Time.deltaTime;
            if (_timer>_timerToGetUpgrade)
            {
                Train();
                _timer = 0;
            }
        }
        
        
    }

    public virtual void Train()
    {        
        Customer.SetPartsToArray();
        Customer._progressDisplayer.UpdateProgress(Customer);
    }
}
