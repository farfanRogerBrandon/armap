using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public Item_SO so;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameController.instance.setISO(so);
        AudioManager.instance.PlaySFX(GameController.instance. acRight);
    }
}
