using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMowement : MonoBehaviour, IDamage
{
    private float HP = 100;
    private Rigidbody rb;
    private bool flag = true;
    public List<GameObject> TypsOfBullets;

    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] Transform PlaseForBullet;

    private int i = 0;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        TypsOfBullets.Add(bullet1);
        TypsOfBullets.Add(bullet2);
        Debug.Log(TypsOfBullets[0]);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * 20000 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward * -20000 * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (flag==true)
            {
                StartCoroutine(shootLunch(TypsOfBullets[i]));
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            i = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            i = 1;
        }
    }
    private IEnumerator shootLunch(GameObject bullet)
    {
        flag = false;
        Instantiate(bullet, PlaseForBullet.position, Quaternion.Euler(0,180,0));
        yield return new WaitForSeconds(1);
        flag = true;
        Debug.Log("!");
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