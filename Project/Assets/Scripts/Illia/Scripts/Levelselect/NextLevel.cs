using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        
        LevelCtrl.instance.youWin();
    }
}
