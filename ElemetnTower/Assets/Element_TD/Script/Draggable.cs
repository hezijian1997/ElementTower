﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler, IPointerClickHandler
{
    private Vector2 offSet;
    public Transform parentToReturnTo = null;
    public GameObject Tower;
    public bool TowerCreate = false;
    BuildManager bm;

    void Start()
    {
        //init all thing
        parentToReturnTo = transform.parent;
        bm = BuildManager.instance;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = transform.parent;
        offSet = eventData.position - new Vector2(transform.position.x, transform.position.y);
        transform.SetParent(transform.parent.parent);

        //This make the card no long block cursor message
        GetComponent<CanvasGroup>().blocksRaycasts = false;


    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position-offSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentToReturnTo);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (TowerCreate)
        {
            Destroy(this.gameObject);
        }
    }

    // this is used for genetae appropriate tower
    public GameObject GetTower()
    {
        return Tower;
    }

    // this is to set TowerCreate true to destory itself
    public void TowerSuccessCreate()
    {
        TowerCreate = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Update parent everytime of event
        parentToReturnTo = transform.parent;
        Debug.Log("We click on the card");
        bm.CardClicked(this.gameObject);
       
    }
}
