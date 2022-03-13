using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CorrectPlace : MonoBehaviour, IDropHandler
{
    [SerializeField] private int id;
    [SerializeField] private Transform parent;
    [SerializeField] private float rangeX;
    [SerializeField] private float rangeY;

    private Vector2 position;
    
    public int ID
    {
        get
        {
            return id;
        }
    }

    private void Awake()
    {
        position = GetComponent<RectTransform>().anchoredPosition;
        rangeX = 15f;
        rangeY = 15f;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (id == eventData.pointerDrag.GetComponent<InteractableElement>().ID) //проверка по ID
        {
            if (InRange(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition) == true)
            {
                eventData.pointerDrag.GetComponent<InteractableElement>().Place(GetComponent<RectTransform>().anchoredPosition);
                FindObjectOfType<Game>().IncrementAnswer();
                FindObjectOfType<Game>().CheckFinish();
            }
        }
    }

    private bool InRange(Vector2 targetPosition)
    {
        if (targetPosition.x < 0)
        {
            if (targetPosition.x >= (position.x - rangeX) && 
                targetPosition.x <= (position.x + rangeX))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (targetPosition.x >= (position.x - rangeX) &&
                targetPosition.x <= (position.x + rangeX))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
