using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    public Jigsaw currJigsaw;
    // Start is called before the first frame update
    void Start()
    {
        var hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
        foreach(var hit in hits) {
            
            if(hit.collider.tag == "Jigsaw") {
                // Debug.Log("hit: " + transform.position);
                currJigsaw = hit.collider.GetComponent<Jigsaw>();
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
