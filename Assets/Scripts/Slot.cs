using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Customer Customer;

    public void SetCustomerToSlot(Customer customer)
    {
        Customer = customer;
        if (!Customer) return;


        Customer.transform.position = transform.position+ new Vector3(0f,0f,-1f);
    }
}
