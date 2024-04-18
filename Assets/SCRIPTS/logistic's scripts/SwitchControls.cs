using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchControls : MonoBehaviour
{
    public Toggle controlesClavier;

    public Toggle controlesManette;

    private void Awake()
    {
        controlesClavier = GameObject.FindGameObjectWithTag("KeyBoardType").GetComponent<Toggle>();
        controlesManette = GameObject.FindGameObjectWithTag("ControllerType").GetComponent<Toggle>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controlesClavier.isOn = true;
        controlesManette.isOn = false; 
    }

    public void SwitchIntoKeyBoard()
    {
        controlesManette.isOn = !controlesClavier.isOn;
    }

    public void SwitchIntoController()
    {
        controlesClavier.isOn = !controlesManette.isOn;
    }
}
