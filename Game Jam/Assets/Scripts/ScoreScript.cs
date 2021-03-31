using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    private int totalCoins;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "Total Coins Collected: " + totalCoins;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
            totalCoins++;
            Destroy(gameObject);
        }
    }
}
