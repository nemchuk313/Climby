using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI; 

public class LevelManagerr : MonoBehaviour
{
    public static int countUnlockLvl = 1;

    [SerializeField]
    Sprite unLocked;

    [SerializeField]
    Sprite locked;


    void Start()
    {
        for(int i = 0; i < transform.childCount; i++ )
        {
            #region RenameButtonsAndChangeText
            transform.GetChild(i).gameObject.name = (i + 1).ToString();
            int numLvl = i + 1;
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();
            #endregion

            if (i < countUnlockLvl)
            {
                #region FirstStateBtn
                transform.GetChild(i).GetComponent<Image>().sprite = unLocked;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
                #endregion

            }
            else
            {
                #region SndStateBtn
                transform.GetChild(i).GetComponent<Image>().sprite = locked;
                transform.GetChild(i).GetComponent<Button>().interactable = false;
                #endregion

            }
        }
    }

}
