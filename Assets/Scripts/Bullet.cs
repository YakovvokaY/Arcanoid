using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 120;
    [SerializeField] private float Damage = 10;
    private Rigidbody rb;
    [SerializeField] Transform Forward;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce((Forward.position-transform.position)* speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        var Damaging = other.GetComponent<IDamage>();
        if (Damaging != null)
        {
            Damaging.DoDamage(Damage);
            Destroy(gameObject);
        }
    }
}
