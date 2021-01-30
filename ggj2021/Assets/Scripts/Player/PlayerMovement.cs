using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    [Header("移动")]
    public float distance = 1f;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) {
            if(Input.GetButtonDown("Up")) {
                transform.DOMoveY(distance, .5f).SetRelative();
                StartCoroutine(walkCD());
            } else if (Input.GetButtonDown("Down")) {
                transform.DOMoveY(-distance, .5f).SetRelative();
                StartCoroutine(walkCD());
            } else if (Input.GetButtonDown("Right")) {
                transform.DOMoveX(distance, .5f).SetRelative();
                StartCoroutine(walkCD());
            }else if (Input.GetButtonDown("Left")) {
                transform.DOMoveX(-distance, .5f).SetRelative();
                StartCoroutine(walkCD());
            }
        }
    }
    IEnumerator walkCD() {
        canMove = false;
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }
}
