using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour {
    public int counter = 0;
    public Text coins;

    void Update()
    {
        coins.text = counter.ToString();
    }
}
