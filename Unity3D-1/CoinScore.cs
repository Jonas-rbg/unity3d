using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour

// Start is called before the first frame update

{

    public GameObject scoreText;
    public static int theScore;

    void Update()
    {


        
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;

    }
}