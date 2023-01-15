using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


// ###############################################
//             NAME : ARTSUNG                      
//             MAIL : artsung410@gmail.com         
// ###############################################

public class ClickPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Action onSwitichingEvent;
    public static Action onGameStartEvent;
    public static Action onDropEvent;
    private bool isAbleSwitich = false;
    private bool isOnDrop;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isOnDrop)
        {
            onGameStartEvent?.Invoke();
        }

        if (isAbleSwitich)
        {
            onSwitichingEvent?.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!isOnDrop)
        {
            onDropEvent?.Invoke();
            isAbleSwitich = true;
            isOnDrop = true;
        }
    }
}
