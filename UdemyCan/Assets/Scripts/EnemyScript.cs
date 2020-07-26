using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject hedef;
    public float step;
    public bool go;
    public GameObject effectCube;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        hedef = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            if (transform.localScale.magnitude < 5f)
            {
                transform.localScale += new Vector3(1.4f, 2f, 1.4f) * Time.deltaTime;
            }
            else
            {
                //Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                //rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
            if (Mathf.Abs((transform.position - hedef.transform.position).magnitude) < 200f)
            {
                transform.position = Vector3.MoveTowards(transform.position, hedef.transform.position, step * Time.deltaTime);             
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("hit");
            go = true;           
        }
    }
    public void Death()
    {
        float curV = (transform.localScale.x) * (transform.localScale.y) * (transform.localScale.z);
        float v = 0;
        while (v < curV/4)
        {
            float vol = Random.Range(0.2f, 0.6f);
            v = v + vol;
            float y = Random.Range(-0.15f, 0.3f);
            float x = Random.Range(-0.12f, 0.12f);
            float z = Random.Range(-0.12f, 0.12f);
            GameObject cube = Instantiate(effectCube, transform.position + new Vector3(x, -y, z), Quaternion.identity); ;
            cube.transform.localScale = new Vector3(vol, vol, vol);
            //cube.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
            cube.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);

        }


        Destroy(gameObject);
    }
}
