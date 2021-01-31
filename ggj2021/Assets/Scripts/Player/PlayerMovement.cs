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
        GameManager.instance.checkLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canMove && !GameManager.instance.isInBigMap) {
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
        
        List<PassZone> zones = new List<PassZone>();
        foreach(var hit in hits) {
            
            Jigsaw curjig = GameManager.instance.currLevel.GetComponent<Jigsaw>();
            if((hit.collider.GetComponent<PassZone>() != null)) {
                    zones.Add(hit.collider.GetComponent<PassZone>());
                    continue;
                    // yield break;
            }

            if(hit.collider.tag == "Block" || hit.collider.tag == "Enemy" || hit.collider.tag == "DeadZone") {
                yield break;
            } else if (hit.collider.tag == "Cell") {
                hasCell = true;
            }
            // else if(hit == hits[hits.Length- 1 ]) {

            // }
        }
        if(zones.Count == 2) {
            foreach(var zone in zones) {
                if(zone.canpass == false) 
                    yield break;
            }
            foreach(var zone in zones) {
                if(zone != GameManager.instance.currLevel.GetComponent<Jigsaw>()) {
                    Vector2 pos = new Vector2(transform.position.x + (2 * dir.x), transform.position.y + (2 * dir.y));
                    transform.position = new Vector3(pos.x, pos.y, transform.position.z);
                    GameManager.instance.checkLevel();
                    yield break;
                }
            }
        }
        if(hasCell) {
            transform.DOMove(dir, .5f).SetRelative();
            StartCoroutine(GameManager.instance.enemyTrun());
            // yield return new WaitForSeconds(.5f);
        }
    }
}
