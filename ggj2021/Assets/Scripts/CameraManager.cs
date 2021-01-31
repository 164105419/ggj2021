using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraManager : MonoBehaviour
{
    Camera Camera;
    public float smallSize = 7f;
    public float bigSize = 22.5f;
    public Transform midTran;
    public static CameraManager instance;
    private void Awake() {
        // DontDestroyOnLoad(gameObject);
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toLevel(LevelManager level) {
        GameManager.instance.isInBigMap = false;
        Camera.DOOrthoSize(smallSize, 1f);
        transform.DOMove(new Vector3(level.transform.position.x, level.transform.position.y, transform.position.z), 1f);
        // DOTween.To(() => camera.DORect)
    }
    public void toBigMap() {
        GameManager.instance.isInBigMap = true;
        Camera.DOOrthoSize(bigSize, 1f);
        transform.DOMove(new Vector3(midTran.position.x, midTran.position.y, transform.position.z), 1f);

    }

}
