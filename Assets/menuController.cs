using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour {
    [SerializeField]
    private Text escapeText;
  
    private void Update()
    {
        if (ScoreManager.playerDead)
        {
            escapeText.enabled = false;
            
        }

    }
}
