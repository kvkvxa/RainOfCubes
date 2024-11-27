using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Bump;

    [field: SerializeField]
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Bump?.Invoke(this);
        }
    }
}