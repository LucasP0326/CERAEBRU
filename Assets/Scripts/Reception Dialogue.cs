using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReceptionDialogue : MonoBehaviour
{

    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI caller;
    public GameObject transmission;
    public float timeDelay;
    public float timeDelay2;
    public float timeDelay3;
    public bool hasSprinted = false;
    public bool hasAccessedTerminal = false;
    public bool showedDoorTutorial = false;
    public bool showedDoorTutorial2 = false;
    public bool showedEnemyTutorial = false;
    public GameObject player;
    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        transmission.SetActive(false);
        StartCoroutine(Wait());
        StartCoroutine(SprintWait());
        StartCoroutine(TerminalWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            hasSprinted = true;

        if (player.GetComponent<Player>().informationDeleted > 0 || player.GetComponent<Player>().informationSaved > 0)
            hasAccessedTerminal = true;

        if (door.GetComponent<Open>().usedLockedDoor == true && showedDoorTutorial == false)
        {
            StartCoroutine(DoorWait());
            showedDoorTutorial = true;
        }

        if (door.GetComponent<Open>().openedLockedDoor == true && showedDoorTutorial2 == false)
        {
            StartCoroutine(DoorWait2());
            showedDoorTutorial2 = true;
        }

        if (player.GetComponent<Player>().killCount == 3 && showedEnemyTutorial == false)
        {
            StartCoroutine(EnemyWait());
            showedEnemyTutorial = true;
        }
    }

    //Reception Opening Transmission
    IEnumerator Wait()
    {
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(true);
        caller.text = "CERAEBRU SECURITY DISPATCH";
        dialogue.text = "Good work, operative.  You are inside the facility and have reached the reception area.";
        yield return new WaitForSeconds(timeDelay);
        dialogue.text = "As all other entrances have been sealed for containment purposes, we could not deploy you closer to the security wing.  You will need to reach it on your own.";
        yield return new WaitForSeconds(timeDelay);
        dialogue.text = "Make your way through the reception area, and remember your objective: clear out any hostiles and erase any sensitive information from the terminals.";
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
    }

    //Sprint Tutorial Prompt
    IEnumerator SprintWait()
    {
        timeDelay2 = 60f;
        yield return new WaitForSeconds(timeDelay2);
        if (hasSprinted == false)
        {
            transmission.SetActive(true);
            caller.text = "CERAEBRU SECURITY DISPATCH";
            dialogue.text = "There is no harm in taking your time, operative, but if you want to move through the facility faster, you can run by pressing the ‘Sprint’ button.";
        }
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
    }

    IEnumerator TerminalWait()
    {
        timeDelay3 = 90f;
        yield return new WaitForSeconds(timeDelay3);
        if (hasAccessedTerminal == false)
        {
            transmission.SetActive(true);
            caller.text = "CERAEBRU SECURITY DISPATCH";
            dialogue.text = "Remember, operative, that wiping all information from this facility is essential.  You can access a terminal by approaching one that seems activated and pressing the ‘Interact’ button.";
        }
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
    }

    IEnumerator DoorWait()
    {
        transmission.SetActive(true);
        caller.text = "CERAEBRU SECURITY DISPATCH";
        dialogue.text = "This door is locked, operative.  You won’t be able to access it without proper authorization.  Search your surroundings for a proper keycard.  The terminal entries may hint at where to find them if you haven’t yet wiped them.";
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
    }

    IEnumerator DoorWait2()
    {
        transmission.SetActive(true);
        caller.text = "CERAEBRU SECURITY DISPATCH";
        dialogue.text = "Careful, operative.  These are the rogue experiments you’ve been warned about.  Use your service weapon to dispatch them.  Aim by holding down the ‘Aim’ button and fire with the ‘Fire’ button.";
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
    }

    IEnumerator EnemyWait()
    {
        transmission.SetActive(true);
        caller.text = "CERAEBRU SECURITY DISPATCH";
        dialogue.text = "Good work, operative.  This area is clear.  Enter the elevator to access the security wing.  We can make further plans from there.";
        timeDelay = 5f;
        yield return new WaitForSeconds(timeDelay);
        transmission.SetActive(false);
    }
}