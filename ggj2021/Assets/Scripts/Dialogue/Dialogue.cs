using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue")]
//��������project�����Ҽ��Ϳ����½�һ���Ի����ݿ�

public class Dialogue : ScriptableObject
{
    //set up the structure for the scripatble object we want -- dialogue
    public Texture2D NPCAvatar;

    public string[] DialogSlides;
    
}
