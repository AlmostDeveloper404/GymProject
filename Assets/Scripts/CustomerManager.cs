using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : Singleton<CustomerManager>
{
    [SerializeField] List<Customer> _allCustomers = new List<Customer>();

    public void DisableStats(ProgressDisplayer progressDisplayer)
    {
        for (int i = 0; i < _allCustomers.Count; i++)
        {
            if (!_allCustomers[i]._gymEquipment) continue;

            if (progressDisplayer!=_allCustomers[i]._progressDisplayer)
            {
                _allCustomers[i]._progressDisplayer.HideProgressPanal();
            }
            
        }
    }

    public void AddToList(Customer customer)
    {
        _allCustomers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        _allCustomers.Remove(customer);
    }
}
