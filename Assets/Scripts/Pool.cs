using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private Factory _factory;

    private ObjectPool<Cube> _cubes;

    private void Awake()
    {
        _cubes = new ObjectPool<Cube>(
            createFunc: _factory.Create,
            actionOnGet: cube => cube.gameObject.SetActive(true),
            actionOnRelease: cube => cube.gameObject.SetActive(false),
            actionOnDestroy: cube => Destroy(cube.gameObject),
            defaultCapacity: 10,
            maxSize: 20
        );
    }

    public Cube Get()
    {
        return _cubes.Get();
    }

    public void Release(Cube cube)
    {
        _cubes.Release(cube);
    }
}