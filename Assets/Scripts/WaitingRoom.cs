using UnityEngine;
using System.Collections.Generic;

public class WaitingRoom : Singleton<WaitingRoom>
{
    [SerializeField]private List<Customer> _customersInQueue = new List<Customer>();
    [SerializeField] private Slot[] _slots;

    [SerializeField] private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _slots = new Slot[transform.childCount];
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = transform.GetChild(i).GetComponent<Slot>();
        }
    }

    private void Start()
    {
        FillWaitingRoom();
    }

    public void AddCustomerToQueue(Customer customer)
    {
        for (int i = 0; i < _customersInQueue.Count; i++)
        {
            if (_customersInQueue[i] == customer) return;
        }
        _customersInQueue.Add(customer);

        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].Customer) continue;

            _slots[i].SetCustomerToSlot(customer);
            return;
        }
    }

    private void FillWaitingRoom()
    {
        int currentCustomer = 0;

        for (int i = 0; i < _customersInQueue.Count; i++)
        {
            _slots[i].SetCustomerToSlot(_customersInQueue[currentCustomer]);
            currentCustomer++;
        }
    }

    public void CheckTheSameCustomerIsQueue(Customer customer)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].Customer==customer)
            {

                _slots[i].SetCustomerToSlot(null);
                RemoveCustomerFromQueue(customer);
            }
        }
    }

    public void RemoveCustomerFromQueue(Customer customer)
    {
        _customersInQueue.Remove(customer);
    }
}
