using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawChecker : MonoBehaviour
{
    public MapPiece map;
    void Start()
    {
        map = GetComponentInParent<MapPiece>();
    }


}
