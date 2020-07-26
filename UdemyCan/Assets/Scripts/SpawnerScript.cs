using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - t > 0.5)
        {
            float x = Random.Range(-9f, 9f);
            float y = Random.Range(5f, 10f);
            float z = Random.Range(-9f, 9f);

            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);

            t = Time.time;
        }
    }
}
