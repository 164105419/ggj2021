using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Jigsaw = 拼图
/// </summary>
public class Jigsaw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }
}
