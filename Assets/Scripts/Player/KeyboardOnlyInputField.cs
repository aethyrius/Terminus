using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardOnlyInputField : TMP_InputField
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ActivateInputField();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        // Do nothing
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        ActivateInputField();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        ActivateInputField();
    }

    // Disable the Escape key
    protected override void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivateInputField();
        }

        base.LateUpdate();
    }
}