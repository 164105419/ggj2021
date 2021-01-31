using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public List<Vector3> enemyPos;
    private void Awake() {
        enemies = new List<Enemy>();
        enemyPos = new List<Vector3>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void registEnemy(Enemy enemy) {
        enemies.Add(enemy);
        enemyPos.Add(enemy.transform.position);
    }
    public void LevelRefresh() {
        for(int i = 0 ; i < enemies.Count ; ++i) {
            enemies[i].transform.position = enemyPos[i];
        }
    }
}
