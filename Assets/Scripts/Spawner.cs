using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    [SerializeField] private ObjectHandler _template;

    public event Action<ObjectHandler> Spawned;

    public void Add()
    {
        float positionX = UnityEngine.Random.Range(_startPoint.x, _endPoint.x);
        float positionY = UnityEngine.Random.Range(_startPoint.y, _endPoint.y);
        float positionZ = UnityEngine.Random.Range(_startPoint.z, _endPoint.z);

        var objectHandler = Instantiate(_template);
        objectHandler.transform.position = new Vector3(positionX, positionY, positionZ);

        Spawned?.Invoke(objectHandler);
    }
}
