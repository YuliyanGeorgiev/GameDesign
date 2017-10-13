using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoop : MonoBehaviour {

    public GameObject Poop;
    private int poopCount;
    public Text countText;
    public Text goEat;

    // Use this for initialization
    void Start () {
        poopCount = 3;
        SetCount();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        // Start timer when r is pressed
        if (Input.GetKeyDown("r"))
        {
            if (poopCount > 0)
            {
                StartCoroutine(processTask());
                poopCount--;
                SetCount();
            }
            else if (poopCount == 0)
            {
                goEat.text = "Go eat!";
            }
        }
    }

    IEnumerator processTask()
    {
        // wait for 2 seconds and then instanciate the poop
        yield return new WaitForSeconds(2);
        Instantiate(Poop, transform.position, transform.rotation);
    }

    void SetCount()
    {
        countText.text = "Poop: " + poopCount.ToString();
    }
}

