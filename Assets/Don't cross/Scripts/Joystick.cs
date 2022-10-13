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
    //private bool joystickPressed;
    void Start()
    {
       
    }
    
    void OnMouseDown()
    {
        if(!StateController.Get().InGame())
        {
            StateController.Get().CurrentState = GAME_STATES.IN_GAME;
            character.GetComponent<Main>().score.gameObject.SetActive(true);
            character.GetComponent<Main>().balance.gameObject.SetActive(true);
            camdistance = new Vector3(0f, 9f, -8f);
        } 
    }
    private void OnMouseDrag()
    {
        targetPos = new Vector3(joystick.rectTransform.localPosition.x, character.transform.position.y, joystick.rectTransform.localPosition.y);
        character.transform.position = Vector3.MoveTowards(character.transform.position, targetPos, speed * Time.deltaTime);
        character.transform.LookAt(targetPos);
    }
    void Update()
    {
        Vector3 distance = character.transform.position + camdistance;
        cam.transform.position = Vector3.Lerp(cam.transform.position, distance, cameraSmoothSpeed * Time.deltaTime);
        cam.transform.LookAt(character.transform.position);
    }

}
