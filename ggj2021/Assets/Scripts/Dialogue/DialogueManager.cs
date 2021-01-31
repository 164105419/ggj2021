using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue _currentDialogue;

    int _currentSlideIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShowSlide();
        LoadAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogText").gameObject;
        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        textComponent.text = _currentDialogue.DialogSlides[_currentSlideIndex];
    }

    void LoadAvatar()
    {
        GameObject avatarObj = transform.Find("Avatar").gameObject;
        avatarObj.GetComponent<RawImage>().texture = _currentDialogue.NPCAvatar;
    }
}
