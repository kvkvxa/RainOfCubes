using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Factory _factory;
    [SerializeField] private Timer _timer;

    private float _spawnPointX = 0f;
    private float _spawnPointY = 5f;
    private float _spawnPointZ = 0f;

    private float _offsetXMin = -5f;
    private float _offsetXMax = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();
    }

    private void Spawn()
    {
        Cube cube = _pool.Get();
        Vector3 spawnPoint = new Vector3(_spawnPointX + Random.Range(_offsetXMin, _offsetXMax), _spawnPointY, _spawnPointZ);

        _factory.Init(cube);

        cube.Bump += Despawn;

        cube.transform.position = spawnPoint;
    }

    private void Despawn(Cube cube)
    {
        cube.Bump -= Despawn;

        _timer.StartCounting(() => _pool.Release(cube));
    }
}