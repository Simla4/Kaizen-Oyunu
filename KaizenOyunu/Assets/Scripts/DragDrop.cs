using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Cards _myCard;

    private int _lastFieldID;
    private Vector2 _firstPosition;
    

    private void Start()
    {
        _firstPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");

        if (MatchManager.instance.GetMatch(_myCard.id, _lastFieldID))
            Destroy(this);
        else
            transform.DOMove(_firstPosition, 1f).SetEase(Ease.InOutElastic);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _lastFieldID = other.GetComponent<Field>().id;


    }
}
