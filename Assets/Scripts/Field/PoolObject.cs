using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class PoolObject : MonoBehaviour
{
    [SerializeField] protected Container Container;

    private readonly List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab, int number)
    {
        for (int j = 0; j < number; j++)
        {
            var cube = Instantiate(prefab, Container.transform);
            cube.SetActive(false);
            _pool.Add(cube);
        }
    }

    protected bool TryGet(out GameObject result)
    {
        int maxRandomValue = _pool.Count(cube => cube.activeSelf == false);
        int random = Random.Range(0, maxRandomValue);

        return result = _pool.Where(cube => cube.activeSelf == false).ElementAt(random);
    }
}