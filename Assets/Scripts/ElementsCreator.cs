using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ElementsCreator : MonoBehaviour
{
    [SerializeField]
    private ElementScript _elementScript;

    public Transform rightSide;
    public Transform leftSide;
    public int numOfElements;
    
    private List<ElementScript> _listOfElements;

    public void RemoveElements()
    {
        for (int i = 0; i < rightSide.childCount; i++)
        {
            Destroy(rightSide.GetChild(i).gameObject);
            Destroy(leftSide.GetChild(i).gameObject);
        }
    }
    
    public void CreateElements()
    {
        _listOfElements = new List<ElementScript>();
        
        RightSideElements();
        LeftSideElements();
    }
    
    private void RightSideElements()
    {
        for (int i = 0; i < numOfElements; i++)
        {
            var element = Instantiate(_elementScript, Vector3.zero, Quaternion.identity);
            element.transform.SetParent(rightSide);
            element.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            element.Init();
            element.name = "el" + i;
            _listOfElements.Add(element);
        }
    }
    
    private void LeftSideElements()
    {
        _listOfElements.Shuffle();
        
        foreach (var el in _listOfElements)
        {
            var newElement = Instantiate(el, Vector3.zero, Quaternion.identity);
            newElement.myElement = el;
            el.myElement = newElement;
            newElement.transform.SetParent(leftSide);
            newElement.Init();
        }
    }
    
    
}
