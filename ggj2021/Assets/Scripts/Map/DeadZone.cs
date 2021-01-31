using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null) {
            enemy.Dead();
        }
        // if(other.collider.tag == "Enemy") {
        //     other.collider.GetComponent<Enemy>().Dead();
        // }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Enemy") {
            other.collider.GetComponent<Enemy>().Dead();
        }
    }
}
