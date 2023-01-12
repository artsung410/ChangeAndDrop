using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


// ###############################################
//             NAME : ARTSUNG                      
//             MAIL : artsung410@gmail.com         
// ###############################################

public class ClickPanel : MonoBehaviour, IPointerDownHandler
{
    public static event Action onSwitichingEvent = delegate { };

    public void OnPointerDown(PointerEventData eventData)
    {
        onSwitichingEvent.Invoke();
    }
}
