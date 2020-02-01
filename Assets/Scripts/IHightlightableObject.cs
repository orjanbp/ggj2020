using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHightlightableObject
{
    void HightlightStart();
    void HightlightEnd();
    GameObject GetGameObject();
}
