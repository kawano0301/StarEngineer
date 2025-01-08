using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour,IPointerDownHandler
{
    public List<UnityEvent> OnEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < OnEvent.Count; i++)
        {
            OnEvent[i].Invoke();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
