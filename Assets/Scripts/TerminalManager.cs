using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TerminalManager : MonoBehaviour
{
    // Action Terminal
    [SerializeField] private GameObject inputObject;
    private Image terminalImage;
    private TMP_InputField inputTerminal;
    public bool isTerminalClosed = true;

    private void Awake()
    {
        terminalImage = inputObject.GetComponent<Image>();
        inputTerminal = inputObject.GetComponent<TMP_InputField>();
    }
        
    private void Update()
    {
        // Action Terminal controls
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (inputTerminal.enabled == false && terminalImage.enabled == false) 
            {
                inputTerminal.enabled = true;
                terminalImage.enabled = true;
                isTerminalClosed = false;
                inputTerminal.Select();
            }
            else if (inputTerminal.enabled == true && terminalImage.enabled == true)
            {
                inputTerminal.enabled = false;
                terminalImage.enabled = false;
                isTerminalClosed = true;

                // Checks if there is a text input selected
                var currentEvent = EventSystem.current;
                if (!currentEvent.alreadySelecting) 
                { 
                    // If one is open, deselect it
                    currentEvent.SetSelectedGameObject(null); 
                }
            }
        }
        // Ensures that you can't click off of the Input Field
        if (Input.GetMouseButton(0))
        {
            if (inputTerminal.enabled && terminalImage.enabled)
            {
                inputTerminal.Select();
            }
        }
    }
}
