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
        string name = GetComponent<KeyItem>().prettyName;
        txtToDisplay.text = "Acquired " + name;
        gameObject.SetActive(false);
    }
}
