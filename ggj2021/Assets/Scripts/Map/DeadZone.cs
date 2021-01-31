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
    private void OnCollisionStay2D(Collision2D other) {
        Debug.Log("dead enter");
        if(other.collider.tag == "Enemy") {
            other.collider.GetComponent<Enemy>().Dead();
        }
    }
}
