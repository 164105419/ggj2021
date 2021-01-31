using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue")]
//这样你在project窗口右键就可以新建一个对话数据库

public class Dialogue : ScriptableObject
{
    //set up the structure for the scripatble object we want -- dialogue
    public Texture2D NPCAvatar;

    public string[] DialogSlides;
    
}
