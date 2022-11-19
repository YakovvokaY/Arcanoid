using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vall : MonoBehaviour, IDamage
{
    private float HP = 1;
    public void DoDamage(float damage)
    {
        HP = HP - damage;
        if (HP<=0)
        {
            Destroy(gameObject);
        }
    }
}