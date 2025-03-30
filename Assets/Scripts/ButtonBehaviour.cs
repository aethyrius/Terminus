using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<CommandHandler>().UnlockCommand("invisible");
            Debug.Log(@"Unlocked command: ""Invisible""");
            Destroy(gameObject);
        }
    }
}
