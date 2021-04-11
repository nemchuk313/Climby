using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{

    [SerializeField]
    private GameObject alive, dead , drop;
    private void Start()
    {
        
    }

    public void DeleteEnemy()
   {
        alive.SetActive(false);
        dead.SetActive(false);

        drop.transform.position = dead.transform.position;
        drop.SetActive(true);
   }
}
