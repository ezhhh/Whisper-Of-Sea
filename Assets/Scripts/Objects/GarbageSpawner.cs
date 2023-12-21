using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] toSpawn;
    [SerializeField] private float _spawnRadius = 150.0f;
    [SerializeField] private float _quantity = 150.0f;

    public void Start()
    {
        SpawnGarbage();
    }

    private void SpawnGarbage()
    {
        for (int i = 0; i < _quantity; i++)
        {
            float x = transform.position.x + _spawnRadius * Random.Range(-1.0f, 1.0f);
            float z = transform.position.z + _spawnRadius * Random.Range(-1.0f, 1.0f);

            if (Physics.Raycast(new Vector3(x, 200, z), Vector3.down, out var hit, 999))
            {
                GameObject obj = Instantiate(toSpawn[0], hit.point, Quaternion.Euler(hit.normal));
                Vector3 rotation = obj.transform.eulerAngles;
                rotation.y = Random.Range(-180.0f, 180.0f);

                obj.transform.eulerAngles = rotation;
                obj.isStatic = true;
            }
        }
    }
}
