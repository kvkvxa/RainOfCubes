using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private readonly List<Color> _colors = new();
    private readonly Color _defaultColor = Color.white;

    private void Awake()
    {
        FillColors();
    }

    public Cube Create()
    {
        return Instantiate(_cubePrefab);
    }

    public void Init(Cube cube)
    {
        SetDefaultColor(cube);
        cube.Bump += SetColor;
    }

    private void SetColor(Cube cube)
    {
        cube.Bump -= SetColor;
        Renderer renderer = cube.Renderer;
        renderer.material.color = GetRandomColor();
    }

    private void SetDefaultColor(Cube cube)
    {
        Renderer renderer = cube.Renderer;
        renderer.material.color = _defaultColor;
    }

    private void FillColors()
    {
        _colors.Add(Color.red);
        _colors.Add(Color.green);
        _colors.Add(Color.blue);
        _colors.Add(Color.cyan);
        _colors.Add(Color.magenta);
        _colors.Add(Color.yellow);
        _colors.Add(Color.black);
        _colors.Add(Color.gray);
    }

    private Color GetRandomColor()
    {
        return _colors[Random.Range(0, _colors.Count)];
    }
}