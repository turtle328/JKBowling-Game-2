using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFigurePoser : MonoBehaviour
{
    Animator animator;
    int selectedPose = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        DisplayManager.Instance.SetHelpText("Press E to change pose");
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedPose++;
            selectedPose %= 3;

            animator.SetInteger("SelectedPose", selectedPose);
        }
    }
}
