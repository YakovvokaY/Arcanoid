using System.Collections;
using UnityEngine;

public class SpawnOnSquare : MonoBehaviour
{
    private int nextTimeSpawn;
    private bool flag = true;
    [SerializeField] GameObject Enemy;

    private float maxX = 1;
    private float maxZ = 20;
    private float minX = -1;
    private float minZ = -20;

    void Update()
    {
        if (flag == true)
        {
            StartCoroutine(shootLunch());
        }
    }
    private IEnumerator shootLunch()
    {
        flag = false;
        nextTimeSpawn = Random.Range(4, 10);
        yield return new WaitForSeconds(nextTimeSpawn);
        Instantiate(Enemy,new Vector3(Random.Range(minZ,maxX),0,Random.Range(minZ,maxZ))+transform.position ,Quaternion.Euler(0,90,0) );
        flag = true;
    }
}