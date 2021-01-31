using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager currLevel;
    public PlayerMovement player;
    public Jigsaw dragingJigsaw;
    public static GameManager instance;
    public List<Enemy> enemies;
    // 是否处于大地图下
    public bool isInBigMap = false;
    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        enemies = new List<Enemy>();
    }
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Refresh")) {
            currLevel.LevelRefresh();
        }
        if(Input.GetKeyDown(KeyCode.M)) {
            if(isInBigMap) {
                CameraManager.instance.toLevel(currLevel);

            }else {
                CameraManager.instance.toBigMap();
            }
        }
    }

    // 交换两个拼图
    public void swapJigsaw(Jigsaw jigsaw1, Jigsaw jigsaw2) {
        Vector3 tempPos = jigsaw1.transform.position;
        jigsaw1.transform.position = jigsaw2.transform.position;
        jigsaw2.transform.position = tempPos;
    }

    // 回合制控制,分为我方回合及地方回合。我方回合则角色可以移动，敌方回合则敌人移动
    public void myTrun() {
        player.canMove = true;
    }
    public IEnumerator enemyTrun() {
        player.canMove = false;
        yield return new WaitForSeconds(.5f);
        // 敌人行动
        for(int i = enemies.Count - 1 ; i >= 0 ; --i) {
            yield return StartCoroutine(enemies[i].enemyMove());
        }
        // foreach(var enemy in enemies) {
        //     yield return StartCoroutine(enemy.enemyMove());
        // }
        myTrun();
    }
    public void changeLevel(LevelManager level) {
        if(currLevel != null)
            currLevel.GetComponent<Jigsaw>().moveAble = true;
        currLevel = level;
        currLevel.GetComponent<Jigsaw>().moveAble = false;
        CameraManager.instance.toLevel(level);
    }
    public void checkLevel() {
        var hits = Physics2D.RaycastAll(new Vector2(player.transform.position.x, player.transform.position.y), Vector2.zero);
        foreach(var hit in hits) {
            if(hit.collider.tag == "PieceGroup") {
                changeLevel(hit.collider.GetComponent<LevelManager>());
            }
        }
    }
}
