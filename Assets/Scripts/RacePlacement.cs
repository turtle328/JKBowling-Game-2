using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlacement : MonoBehaviour
{
    public Puzzle02Manager _mngr;
    public bool isActive = true;

    private bool correctCar = false;
    public GameObject currentCar = null;
    public Inventory inventory = null;
    public float height;
    public int place = 0;

    ArrayList validObjects = new ArrayList{ "toycar_01", "toycar_02", "toycar_03" };

    void Start()
    {
        _mngr = Puzzle02Manager.Instance;
    }

    private void OnMouseEnter()
    {
        if (isActive && this.enabled )
        {
            if (currentCar == null)
            {
                GameObject selectedItem = inventory.GetCurrentItem();
                if (selectedItem != null)
                {
                    if (validObjects.Contains(selectedItem.name))
                    {
                        DisplayManager.Instance.SetHelpText("Press E to place car");
                    }
                }
            }
            else
            {
                DisplayManager.Instance.SetHelpText("Press E to pick up car");
            }
        }
    }

    private void OnMouseExit()
    {
        if (isActive && this.enabled )
        {
            DisplayManager.Instance.SetHelpText("");
        }
    }

    private void OnMouseOver()
    {
        if ( isActive && this.enabled )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentCar == null)
                {
                    GameObject selectedItem = inventory.GetCurrentItem();
                    if ( selectedItem != null )
                    {
                        if (validObjects.Contains(selectedItem.name))
                        {
                            currentCar = selectedItem;
                            Vector3 pos = transform.localPosition;
                            pos.y = height;
                            selectedItem.transform.localPosition = pos;
                            selectedItem.SetActive(true);
                            inventory.RemoveCurrentItem();

                            _mngr.OnChangedRacePuzzle(currentCar, place);
                        }
                    }
                }
                else
                {
                    int index = 0;
                    while (inventory.inventory[index] != null)
                    {
                        index++;
                        if (index >= Inventory.MAX_INVENTORY)
                        {
                            break;
                        }
                    }

                    if (index < Inventory.MAX_INVENTORY)
                    {
                        DisplayManager.Instance.SetHelpText("");
                        inventory.inventory[index] = currentCar;

                        KeyItem k = currentCar.GetComponent<KeyItem>();
                        k.attachedToWorldState = false;
                        DisplayManager.Instance.SetImage(index, k.inventoryImage);

                        currentCar.SetActive(false);
                        currentCar = null;

                        _mngr.OnChangedRacePuzzle(null, place);
                    }
                }
            }
        }
    }

}
