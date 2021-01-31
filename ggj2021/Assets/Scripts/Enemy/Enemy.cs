using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float enemyPosOffsetY = -.5f;
    public float cellLenth = 1f;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.enemies.Add(this);
        var level = GetComponentInParent<LevelManager>();
        level.registEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator enemyMove() {
        // 一格
        var hits = Physics2D.CircleCastAll(new Vector2(transform.position.x, transform.position.y + enemyPosOffsetY), (float)(cellLenth / 2 * 1.4), Vector2.zero);
        foreach(var hit in hits) {
            if(hit.collider.tag == "Player") {
                Debug.Log("PlayerFind");
                Vector2 playerPos = new Vector2(hit.transform.position.x, hit.transform.position.y + 
                    hit.collider.GetComponent<PlayerMovement>().playerPosOffsetY);
                Vector2 enemyPos = new Vector2(transform.position.x, transform.position.y + enemyPosOffsetY);
                Debug.Log("playerPos: " + playerPos + " enemyPos: " + enemyPos);
                if(playerPos.x == enemyPos.x || playerPos.y == enemyPos.y) {
                    yield return StartCoroutine(enemyWantMove(enemyPos - playerPos));
                }
            }
        }
    }
    public IEnumerator enemyWantMove(Vector2 dir) {
        var hits = Physics2D.RaycastAll(new Vector2(transform.position.x + dir.x, transform.position.y + dir.y + enemyPosOffsetY), Vector2.zero);
        bool hasCell = false;
        foreach(var hit in hits) {
            if(hit.collider.tag == "Block" || hit.collider.tag == "Player" || hit.collider.tag == "Enemy") {
                yield break;
            } else if (hit.collider.tag == "Cell") {
                hasCell = true;
            }
            // else if(hit == hits[hits.Length- 1 ]) {

            // }
        }
        if(hasCell) {
            transform.DOMove(dir, .5f).SetRelative();
            yield return new WaitForSeconds(.5f);
            checkDead();
        }
    }
    public void Dead() {
        GameManager.instance.enemies.Remove(this);
        transform.position = new Vector3(999, 999, 0);
        // Destroy(gameObject, .15f);
    }
    public void checkDead() {
        var hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y + enemyPosOffsetY), Vector2.zero);
        foreach(var hit in hits) {
            if(hit.collider.tag == "DeadZone") {
                Dead();
            }
        }
    }
}
