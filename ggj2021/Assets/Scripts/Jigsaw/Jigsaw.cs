using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// Jigsaw = 拼图
/// </summary>
public class Jigsaw : MonoBehaviour
{
    // 目前所在的地点
    public MapPiece currMap;
    public bool moveAble = true;
    [Header("通行情况")]
    public bool walkUp = true;
    public GameObject UpZone;
    public bool walkDown = true;
    public GameObject DownZone;
    public bool walkLeft = true;
    public GameObject LeftZone;
    public bool walkRight = true;
    public GameObject RightZone;
    public PassZone upPass;
    public PassZone downPass;
    public PassZone leftPass;
    public PassZone RightPass;


    // Start is called before the first frame update
    void Start()
    {
        var hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
        foreach(var hit in hits) {
            if(hit.collider.tag == "JigsawChecker") {
                // Debug.Log("hit: " + transform.position);
                currMap = hit.collider.GetComponentInParent<MapPiece>();
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag() {
        if(moveAble && GameManager.instance.isInBigMap){
            GameManager.instance.dragingJigsaw = this;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }
    /// <summary>
    /// 移动到目标位置
    /// </summary>
    /// <param name="targetTran"></param>
    public void moveTo(Transform targetTran) {
        transform.DOMove(new Vector3(targetTran.position.x, targetTran.position.y, transform.position.z), .5f);
    }
    /// <summary>
    /// 拼图归位
    /// </summary>
    public void locateJigsaw() {
        transform.DOMove(new Vector3(currMap.transform.position.x, currMap.transform.position.y, transform.position.z), .5f);
    }
    private void OnMouseEnter() {
        Debug.Log("jigsaw enter");
    }
    private void OnMouseUp() {
        if(!moveAble)
            return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        var hits = Physics2D.RaycastAll(new Vector2(mousePos.x, mousePos.y), Vector2.zero);
        foreach(var hit in hits) {
            if(hit.collider.tag == "JigsawChecker") {
                    var checker = hit.collider.GetComponent<JigsawChecker>();
                    if(checker.map.currJigsaw != null && !checker.map.currJigsaw.moveAble) {
                        changeJigsawPosition(currMap);
                        break;
                    }
                    if(checker.map.currJigsaw != this) {
                        if(checker.map.currJigsaw != null)
                            checker.map.currJigsaw.changeJigsawPosition(currMap);
                        changeJigsawPosition(checker.map);
                        // checker.map.currJigsaw.moveTo(currMap.transform);
                        // checker.map.currJigsaw.updateJigsawInfo(currMap);
                        // updateJigsawInfo();
                        // moveTo(currMap.transform);
                    }else {
                        changeJigsawPosition(currMap);
                    }
                break;
            }
            else if(hit == hits[hits.Length - 1]) {
                changeJigsawPosition(currMap);
            }
        }
    }
    public void changeJigsawPosition(MapPiece map) {
        if(currMap.currJigsaw == this)
            currMap.currJigsaw = null;
        currMap = map;
        map.currJigsaw = this;
        moveTo(currMap.transform);
    }
}
