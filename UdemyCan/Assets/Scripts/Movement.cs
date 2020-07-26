using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject gun,gun2;
    Rigidbody rb;
   
    public GameObject cam;
    public Vector3 mousePos;
    public bool shooting=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }
   
    void Update()
    {

        if (Input.GetKey("space"))
        {
            Debug.Log("space");
            transform.position=transform.position + new Vector3(0f,40f,0f)*Time.deltaTime;


            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                
            }

            if (shooting)
            {
                GameObject closest1 = gun.GetComponent<GunScript>().closest;
                GameObject closest2 = gun2.GetComponent<GunScript>().closest;

                float x = (closest1.transform.position - transform.position).magnitude;
                float y = (closest2.transform.position - transform.position).magnitude;

                if (x > y)
                {
                    Quaternion rotTarget = Quaternion.LookRotation(closest2.transform.position - transform.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 200f * Time.deltaTime);
                }
                else
                {
                    Quaternion rotTarget = Quaternion.LookRotation(closest1.transform.position - transform.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 200f * Time.deltaTime);
                }
            }
            else
            {
                Quaternion rotTarget = Quaternion.LookRotation(hit.point - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 250f * Time.deltaTime);

                mousePos = hit.point;
            }
        }
        else
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, 50f * Time.deltaTime);
            }

            if (shooting)
            {
                GameObject closest1 = gun.GetComponent<GunScript>().closest;
                GameObject closest2 = gun2.GetComponent<GunScript>().closest;

                float x = (closest1.transform.position - transform.position).magnitude;
                float y = (closest2.transform.position - transform.position).magnitude;

                if (x > y)
                {
                    Quaternion rotTarget = Quaternion.LookRotation(closest2.transform.position - transform.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 200f * Time.deltaTime);
                }
                else
                {
                    Quaternion rotTarget = Quaternion.LookRotation(closest1.transform.position - transform.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 200f * Time.deltaTime);
                }
            }
            else
            {
                Quaternion rotTarget = Quaternion.LookRotation(hit.point - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 250f * Time.deltaTime);

                mousePos = hit.point;
            }
        }
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + 80f, transform.position.z - 40f);
        cam.transform.LookAt(transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Dead!!");
        }
    }
}
