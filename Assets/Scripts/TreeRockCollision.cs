using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRockCollision : MonoBehaviour
{
    // rock reference
    public GameObject rock;

    // inventory instnace
    public Inventory inv;

    // get material to provide outline
    public Material mat;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == rock)
        {
            PuzzleManagerWorld1.Instance.DropKey();
            mat.SetFloat("_Outline", 0.0f);
            DisplayManager.Instance.SetHelpText("");
            StartCoroutine(DestroyRock());
        }
    }

    private void OnMouseEnter()
    {
        if (inv.GetCurrentItem() == rock)
        {
            mat.SetFloat("_Outline", 0.1f);
            DisplayManager.Instance.SetHelpText("Press 'T' to throw rock");
        }
    }

    private void OnMouseExit()
    {
        mat.SetFloat("_Outline", 0.0f);
        DisplayManager.Instance.SetHelpText("");
    }

    private IEnumerator DestroyRock()
    {
        yield return new WaitForSeconds(1);
        Destroy(rock);
    }
}
