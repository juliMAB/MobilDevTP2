using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public Camera cam;
    public Image joystick;
    private float speed = 2f, cameraSmoothSpeed = 1f;
    public GameObject character, scriptmanager;
    public Vector3 targetPos, camdistance = new Vector3(0f, 13f, -14f);
    private bool joystickPressed;
    void Start()
    {
       
    }
    
    void OnMouseDown()
    {
        joystickPressed = true;
        if(character.GetComponent<Main>().isGameStarted == false)
        {
            character.GetComponent<Main>().isGameStarted = true;
            character.GetComponent<Main>().score.gameObject.SetActive(true);
            character.GetComponent<Main>().balance.gameObject.SetActive(true);
            camdistance = new Vector3(0f, 9f, -8f);
        } 
    }
    void OnMouseUp()
    {
        joystickPressed = false;
    }
    void Update()
    {
        if(joystickPressed == true)
        {
            targetPos = new Vector3(joystick.rectTransform.localPosition.x, character.transform.position.y, joystick.rectTransform.localPosition.y);
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetPos, speed * Time.deltaTime);
            character.transform.LookAt(targetPos);
        }
        Vector3 distance = character.transform.position + camdistance;
        cam.transform.position = Vector3.Lerp(cam.transform.position, distance, cameraSmoothSpeed * Time.deltaTime);
        cam.transform.LookAt(character.transform.position);
    }

}
