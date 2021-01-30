using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("对话框")]
    public Image Dialog;
    public Image headIMG;
    public Text NameText;
    public Text TalkText;
    public TextAsset talkAsset;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        // 控制对话框
        Dialog.gameObject.SetActive(false);


        // showText("tdm say:", "zlxkcjoivcxugoiuqwedjcsoixzcoiuwoidjaslkdjcxoizcjioj");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showText(string name, string talk, Sprite sprite = null) {
        Dialog.gameObject.SetActive(true);
        if(sprite == null) {
            headIMG.enabled = false;
        }else {

            headIMG.enabled = true;
            headIMG.sprite = sprite;
        }
        NameText.text = name;
        // 对话
        StartCoroutine(slowShowText(talk));
    }
    IEnumerator slowShowText(string text) {
        TalkText.text = "";
        foreach(var c in text) {
            TalkText.text += c;
            yield return new WaitForSeconds(.1f);
        }
        // over
        yield return new WaitForSeconds(2f);
        Dialog.gameObject.SetActive(false);
    }
}
