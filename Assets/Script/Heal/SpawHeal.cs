using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawHeal : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;
    public int EnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 40)
        {
            xPos = Random.Range(-259, 962);
            zPos = Random.Range(-323, 856);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);

            EnemyCount += 1;
        }
    }
}
