using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public Image headIMG;
    public Text nameText;
    public Text talkText;
    void Start()
    {
        UIManager.instance.Dialog = GetComponent<Image>();
        UIManager.instance.headIMG = headIMG;
        UIManager.instance.NameText = nameText;
        UIManager.instance.TalkText = talkText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
