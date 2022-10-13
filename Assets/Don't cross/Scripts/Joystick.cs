﻿using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public Camera cam;
    public Image joystick;
    private float speed = 2f;
    public GameObject character;
    
    void OnMouseDown()
    {
        if(!StateController.Get().InGame())
        {
            StateController.Get().CurrentState = GAME_STATES.IN_GAME;
            character.GetComponent<Main>().score.gameObject.SetActive(true);
            character.GetComponent<Main>().balance.gameObject.SetActive(true);
        } 
    }
    private void OnMouseDrag()
    {
        Vector3 pos = new Vector3(joystick.rectTransform.localPosition.x, character.transform.position.y, joystick.rectTransform.localPosition.y);
        character.transform.position = Vector3.MoveTowards(character.transform.position, pos, speed * Time.deltaTime);
        character.transform.LookAt(pos);
    }

}
