using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    Rigidbody keyRB;
    public Text txtToDisplay;
    public DoorController DC;

    public void GiveKey()
    {
        DC.gotKey = true;
        txtToDisplay.gameObject.SetActive(true);
        txtToDisplay.text = "Kitchen Key Acquired";
        gameObject.SetActive(false);
    }
}
