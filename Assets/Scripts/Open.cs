using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Open : MonoBehaviour
{
    public GameObject key;
    public GameObject keyPad;
    public Material staticMat;
    public Material successMat;
    public Material failMat;
    public Animation hinge;
    public AudioSource elevator;
    public bool locked = false;
    public TextMeshProUGUI textObject;
    public float timeDelay;

    void Start()
    {
        keyPad.GetComponent<MeshRenderer>().material = staticMat;
    }

    void OnTriggerStay()
    {
        Key keyCard = key.gameObject.GetComponent<Key>();
        
        //If press E
        if (Input.GetKey (KeyCode.E))
        {
            //if door unlocked
            if (locked == false)
            {
                keyPad.GetComponent<MeshRenderer>().material = successMat;
                hinge.Play ();
                elevator.Play ();
            }

            //if door locked and no key
            if (locked == true && keyCard.hasKey == false)
            {
                keyPad.GetComponent<MeshRenderer>().material = failMat;
                StartCoroutine(Wait());
            }

            //if door locked and key
            if (locked == true && keyCard.hasKey == true)
            {
                locked = false;
                keyPad.GetComponent<MeshRenderer>().material = successMat;
                hinge.Play ();
                elevator.Play ();
            }
        }
    }

    IEnumerator Wait()
    {
        textObject.enabled = true;
        textObject.text = "THIS DOOR IS LOCKED";
        timeDelay = 3f;
        yield return new WaitForSeconds(timeDelay);
        textObject.enabled = false;
    }

}