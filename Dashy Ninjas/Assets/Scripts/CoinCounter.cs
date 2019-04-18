using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {
    public static int counter;
    public static int highScore;
    [SerializeField] Text text;
    private void Update()
    {
        if(counter > highScore)
        {
            highScore = counter;
            text.text = highScore.ToString();
        }
    }
}
