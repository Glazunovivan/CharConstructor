using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableElement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 StartPosition;

    [SerializeField] private Transform parentStart;
    [SerializeField] private Transform parentInDrag;
    [SerializeField] private int id;

    [SerializeField] private List<CorrectPlace> correctPlaces;

    private bool isPlace = false;
    public int ID 
    {
        get 
        { 
            return id; 
        }
    }

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        StartPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //таргетим только определенный Place
        foreach (CorrectPlace correctPlace in correctPlaces)
        {
            if (correctPlace.ID != id)
            {
                correctPlace.gameObject.GetComponent<Image>().raycastTarget = false;
            }
        }
        isPlace = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Debug.Log($"{rectTransform.anchoredPosition}");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlace == false)
        {
            canvasGroup.blocksRaycasts = true;  
        }
        else
        {
            canvasGroup.blocksRaycasts = false;
        }

        rectTransform.anchoredPosition = StartPosition;
        foreach (CorrectPlace correctPlace in correctPlaces)
        {
            correctPlace.gameObject.GetComponent<Image>().raycastTarget = true;
        }
    }

    public void Place(Vector2 position)
    {
        StartPosition = position;
        isPlace = true;
    }
}
