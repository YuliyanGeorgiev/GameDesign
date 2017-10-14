using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoop : MonoBehaviour {

    public GameObject Poop;
    private int poopCount;
    public Text countText;
    public Text goEat;
    public Text pressE;
    public GameObject currentObg = null;

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
                SetEat();
            }
        }

        if (Input.GetKeyDown("e") && currentObg)
        {
            Destroy(currentObg);
            poopCount += 3;
            SetCount();
            ResetEat();
            ResetPressE();
        }
    }

    IEnumerator processTask()
    {
        // wait for 2 seconds and then instanciate the poop
        yield return new WaitForSeconds(2);
        Instantiate(Poop, transform.position, transform.rotation);
    }

    // Set number of poops
    void SetCount()
    {
        countText.text = "Poop: " + poopCount.ToString();
    }

    void SetEat()
    {
        goEat.text = "Go eat!";
    }

    void ResetEat()
    {
        goEat.text = "";
    }

    void pressEtoEat()
    {
        pressE.text = "Press E to eat.";
    }

    void ResetPressE()
    {
        pressE.text = "";
    }


    // Detect food and add 3 poops
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            currentObg = other.gameObject;
            ResetEat();
            pressEtoEat();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            if (other.gameObject == currentObg)
            {
                currentObg = null;
                ResetPressE();
                if (poopCount == 0)
                {
                    SetEat();
                }
            }
        }
    }

}

