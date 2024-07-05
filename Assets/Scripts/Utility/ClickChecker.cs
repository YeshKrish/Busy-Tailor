using UnityEngine;
using UnityEngine.EventSystems;

public static class ClickChecker
{

    public static void CheckClick(System.Action onClickOutsideUI)
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (!IsPointerOverUIObject())
            {
                onClickOutsideUI?.Invoke();
            }
        }
    }

    private static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
