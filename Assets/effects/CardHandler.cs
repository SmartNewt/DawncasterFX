using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CardHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> cards;
    [SerializeField] List<GameObject> handVfx, holdVfx, dropVfx, cardProps;

    public GameObject selected;
    Vector3 selectedPos;
    Quaternion selectedRot;
    List<GameObject> selectedHandVfx, selectedHoldVfx, selectedDropVfx, selectedCardProps;

    int movementSpeed = 10;
    int index = 0;

    void Start()
    {
        selectedDropVfx = new List<GameObject>();
        selectedHandVfx = new List<GameObject>();
        selectedHoldVfx = new List<GameObject>();
        selectedCardProps = new List<GameObject>();
        foreach (GameObject card in cards)
        {
            foreach (Transform child in card.transform)
            {

                for (int i = 0; i < handVfx.Count; i++)
                {
                   if (child.name == handVfx[i].name) child.gameObject.SetActive(true);
                }
            }
        }
        selected = cards[index];
        SelectCard();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResetSelected();
            if (index >= cards.Count - 1) index = 0;
            else index++;
            SelectCard();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ResetSelected();
            if (index <= 0) index = cards.Count - 1;
            else index--;
            SelectCard();
        }

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            foreach(GameObject go in selectedHandVfx)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in selectedHoldVfx)
            {
                go.SetActive(true);
            }
            selected.transform.rotation = Quaternion.identity;
            selected.transform.position = Vector3.MoveTowards(selected.transform.position, new Vector3(0, 0, selectedPos.z), movementSpeed * Time.deltaTime);
            if (selected.transform.position == new Vector3(0, 0, selectedPos.z))
            {
                foreach (GameObject go in selectedHoldVfx)
                {
                    go.SetActive(false);
                }
                foreach (GameObject go in selectedDropVfx)
                {
                    go.SetActive(true);
                }
                foreach (GameObject go in selectedCardProps)
                {
                    go.SetActive(false);
                }
            }
        }
    }

    private void SelectCard()
    {
        selected = cards[index];
        selectedPos = new Vector3(selected.transform.position.x, selected.transform.position.y, selected.transform.position.z);
        selectedRot = selected.transform.rotation;
        foreach (Transform child in selected.transform)
        {
            for (int i = 0; i < handVfx.Count; i++)
            {
                if (child.name == handVfx[i].name) selectedHandVfx.Add(child.gameObject);
            }
            for (int i = 0; i < holdVfx.Count; i++)
            {
                if (child.name == holdVfx[i].name) selectedHoldVfx.Add(child.gameObject);
            }
            for (int i = 0; i < dropVfx.Count; i++)
            {
                if (child.name == dropVfx[i].name) selectedDropVfx.Add(child.gameObject);
            }
            for (int i = 0; i < cardProps.Count; i++)
            {
                if (child.name == cardProps[i].name) selectedCardProps.Add(child.gameObject);
            }
        }
    }

    private void ResetSelected()
    {
        selected.transform.position = selectedPos;
        selected.transform.rotation = selectedRot;
        foreach (GameObject go in selectedHoldVfx)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in selectedHandVfx)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in selectedDropVfx)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in selectedCardProps)
        {
            go.SetActive(true);
        }
        selectedHandVfx = new List<GameObject>();
        selectedHoldVfx = new List<GameObject>();
        selectedDropVfx = new List<GameObject>();
        selectedCardProps = new List<GameObject>();
    }

}
   
