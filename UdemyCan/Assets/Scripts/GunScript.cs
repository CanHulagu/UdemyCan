using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    float t = 0;

    [HideInInspector] public GameObject closest, player;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in enemies)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (closest != null)
        {
            if ((closest.transform.position - transform.position).magnitude < 75f)
            {
                player.GetComponent<Movement>().shooting = true;

                if (Time.time - t > 0.17f)
                {
                    GameObject bulletobject = Instantiate(bullet, transform.position, transform.rotation);
                    t = Time.time;
                }
                Quaternion rotTarget = Quaternion.LookRotation(closest.transform.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 200f * Time.deltaTime);
            }
            else
            {               
                Quaternion rotTarget = Quaternion.LookRotation(player.GetComponent<Movement>().mousePos - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 250f * Time.deltaTime);

                player.GetComponent<Movement>().shooting = false;

            }
        }
    }
}
