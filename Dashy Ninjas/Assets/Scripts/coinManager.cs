using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour {
    public Text coins;

    void Update()
    {
        coins.text = CoinCounter.counter.ToString();
    }
}
