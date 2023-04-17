using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaboratoriesEventManager : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI caller;
    public GameObject transmission;
    public GameObject player;
    public float timeDelay;
    public AudioSource music;
    public bool dialogueActive = false;
    public GameObject labFootage;

    // Start is called before the first frame update
    void Start()
    {
        dialogueActive = false;
        transmission.SetActive(false);
        StartCoroutine(Wait()); 
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive == true)
        {
            music.GetComponent<AudioSource>().volume = 0.25f;
        }
        if (dialogueActive == false)
        {
            music.GetComponent<AudioSource>().volume = 1f;
        }
    }

    IEnumerator Wait()
    {
        dialogueActive = true;
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(true);
        labFootage.SetActive(false);
        caller.text = "CERAEBRU SECURITY DISPATCH";
        dialogue.text = "Operative, you have reached the laboratories and…wait.  Do not go past that door.";
        timeDelay = 6f;
        yield return new WaitForSeconds(timeDelay);
        labFootage.SetActive(true);
        dialogue.text = "I am reading numerous hostile signals on the other side of that door.  Far too many for you to handle.";
        timeDelay = 7f;
        yield return new WaitForSeconds(timeDelay);
        labFootage.SetActive(false);
        dialogue.text = "Operative, do not engage the enemy.  I suggest looking for another way around.  Remember your objective–wipe all information.";
        timeDelay = 8f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
        dialogueActive = false;

    }
}