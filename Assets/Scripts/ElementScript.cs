using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    public ElementScript myElement;
    public Color color;
    
    private bool _inPoint;
    private bool _pointerEntered;
    private LineRenderer _lineRenderer;
    private bool _isDragging;
    private Camera _cam;
    private Vector3[] _linePoints = new Vector3[2];
    private GameData _gameData;
    
    public void Init()
    {
        _cam = Camera.main;
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _gameData = FindObjectOfType<GameData>();
        
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
        
        GetComponent<Image>().color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }
    
    private void Update()
    {
        if (!_isDragging || _inPoint) return;

        _linePoints[1] = GetMousePos();
        _lineRenderer.SetPositions(_linePoints);
        
        if(!myElement._pointerEntered) return;

        _inPoint = true;
        myElement._inPoint = true;

        _gameData.CorrectLink();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_inPoint) return;
        
        _lineRenderer.enabled = true;
        
        _linePoints[0] = GetMousePos();
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_inPoint) return;
        
        _lineRenderer.enabled = false;
        _isDragging = false;
        
        _linePoints[1] = _linePoints[0];
        _lineRenderer.SetPositions(_linePoints);
    }

    private Vector3 GetMousePos()
    {
        var pos = _cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(myElement._isDragging)
            _pointerEntered = true;
    }
}
