using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float cellLenth = 1f;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator enemyMove() {
        yield return 0;
        bool findPlayer = false;
        bool findBlock = false;
        bool findCell = false;
        // 上
        var hitsUp = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y + cellLenth), Vector2.zero);
        var hitsDown = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y - cellLenth), Vector2.zero);
        var hitsLeft = Physics2D.RaycastAll(new Vector2(transform.position.x - cellLenth, transform.position.y), Vector2.zero);
        var hitsRight = Physics2D.RaycastAll(new Vector2(transform.position.x + cellLenth, transform.position.y), Vector2.zero);
        foreach(var hit in hitsUp) {

        }
    }
    public IEnumerator enemyWantMove(Vector2 dir) {
        var hits = Physics2D.RaycastAll(new Vector2(transform.position.x + dir.x, transform.position.y + dir.y), Vector2.zero);
        bool hasCell = false;
        foreach(var hit in hits) {
            if(hit.collider.tag == "Block" || hit.collider.tag == "Player" ) {
                yield break;
            } else if (hit.collider.tag == "Cell") {
                hasCell = true;
            }
            // else if(hit == hits[hits.Length- 1 ]) {

            // }
        }
        if(hasCell) {
            transform.DOMove(dir, .5f).SetRelative();
        }
    }
}
