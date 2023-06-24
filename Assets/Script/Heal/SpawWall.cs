using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawWall : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;

    public int xRot;
    public int zRot;
    public int yRot;
    public int EnemyCount;
    public int number;
    public int rotation;
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
            xRot = Random.Range(0, rotation);
            yRot = Random.Range(0, 360);
            zRot = Random.Range(0, rotation);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.Euler(xRot, yRot, zRot));
            yield return new WaitForSeconds(0.1f);

            EnemyCount += 1;
        }
    }
}
