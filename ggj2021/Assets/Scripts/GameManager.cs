using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // 是否处于大地图下
    public bool isInBigMap = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 交换两个拼图
    public void swapJigsaw(Jigsaw jigsaw1, Jigsaw jigsaw2) {
        Vector3 tempPos = jigsaw1.transform.position;
        jigsaw1.transform.position = jigsaw2.transform.position;
        jigsaw2.transform.position = tempPos;
    }
}
