using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;

    public int EnemyCount;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < number)
        {
            xPos = Random.Range(-259, 962);
            zPos = Random.Range(-323, 856);
            Instantiate(theEnemy, new Vector3(xPos, -4, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);

            EnemyCount += 1;
        }
    }
}
