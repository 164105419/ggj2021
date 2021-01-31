using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    public float playerPosOffsetY = -.5f;
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
                StartCoroutine(playerWantMove(new Vector2(0, 1)));
                // transform.DOMoveY(distance, .5f).SetRelative();
                // // StartCoroutine(walkCD());
                // StartCoroutine(GameManager.instance.enemyTrun());
            } else if (Input.GetButtonDown("Down")) {
                StartCoroutine(playerWantMove(new Vector2(0, -1)));
            } else if (Input.GetButtonDown("Right")) {
                StartCoroutine(playerWantMove(new Vector2(1, 0)));
            }else if (Input.GetButtonDown("Left")) {
                StartCoroutine(playerWantMove(new Vector2(-1, 0)));
            }
        }
    }
    IEnumerator walkCD() {
        canMove = false;
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }
    public IEnumerator playerWantMove(Vector2 dir) {
        var hits = Physics2D.RaycastAll(new Vector2(transform.position.x + dir.x, transform.position.y + dir.y + playerPosOffsetY), Vector2.zero);
        bool hasCell = false;
        foreach(var hit in hits) {
            if(hit.collider.tag == "Block" || hit.collider.tag == "Enemy" || hit.collider.tag == "DeadZone") {
                yield break;
            } else if (hit.collider.tag == "Cell") {
                hasCell = true;
            }
            // else if(hit == hits[hits.Length- 1 ]) {

            // }
        }
        if(hasCell) {
            transform.DOMove(dir, .5f).SetRelative();
            StartCoroutine(GameManager.instance.enemyTrun());
            // yield return new WaitForSeconds(.5f);
        }
    }
}
