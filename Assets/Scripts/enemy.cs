using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour , IDamage
{
    private float HP = 20;

    private Rigidbody rb;
    private int nextTimeShoot;
    [SerializeField] private Transform ShootPlase;
    [SerializeField] private GameObject bullet;
    private bool flag = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce((ShootPlase.position-transform.position)*20);
    }
    void Update()
    {
        if (flag==true)
        {
            StartCoroutine(shootLunch());
        }
    }
    private IEnumerator shootLunch()
    {
        flag = false;
        nextTimeShoot = Random.Range(5, 10);
        yield return new WaitForSeconds(nextTimeShoot);
        shoot(bullet);
        flag = true;
    }
    private void shoot(GameObject bullet)
    {
        Instantiate(bullet,ShootPlase.position,Quaternion.identity);
    }
    public void DoDamage(float damage)
    {
        HP = HP - damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}