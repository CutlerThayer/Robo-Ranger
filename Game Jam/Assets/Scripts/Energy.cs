using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Energy : MonoBehaviour
{

    public static int energy;
    private float lastTime;
    private float newTime;
    private bool depleted;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        energy = 10;   
        lastTime = Time.time; 
        depleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        newTime = Time.time;
        
        if(newTime - lastTime >= 1 && !depleted) {
            lastTime = newTime;

            energy--;
            //Debug.Log("Energy level: " + energy);
            text.text = "Energy level: " + energy;
        }

        if(energy == 0 && !depleted) {
            Debug.Log("Energy depleted!");
            depleted = true;
            text.text = "You died!";
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
