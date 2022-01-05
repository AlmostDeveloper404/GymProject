using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersSpawner : Singleton<CustomersSpawner>
{
    [SerializeField] private Customer[] _allTypesOfCustomers;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _timeToSpawn = 10f;
    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timeToSpawn)
        {
            SpawnCustomer();
            _timer = 0;
        }
    }

    public void SpawnCustomer()
    {
        int randomIndex = Random.Range(0, _allTypesOfCustomers.Length);

        Customer customer = Instantiate(_allTypesOfCustomers[randomIndex], _spawnPoint.position, Quaternion.identity);
        CustomerManager.Instance.AddToList(customer);
        WaitingRoom.Instance.AddCustomerToQueue(customer);


    }
}
