using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public int damage = 1;
    public GameObject Player;
    public Attack Attack;

    void Start()
    {
        time = Time.time;
        gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(0, 0, 1000));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 25);
        
        CleanUp();
    }

    void CleanUp()
    {
        if (Time.time - time > 2) {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage, Player, Attack);
            Destroy(gameObject);
        }
        
    }
}
