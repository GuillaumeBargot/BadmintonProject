using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour
{

    private static PopupSystem instance;
    public static PopupSystem Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private GameObject greyPanel;

    private List<Popup> visiblePopups;



    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        visiblePopups = new List<Popup>();
    }

    public T InstantiatePopup<T>(T prefab)
              where T : Popup
    {
        T popup = (T)Instantiate(prefab, Vector3.zero, Quaternion.identity, this.transform);
        popup.transform.localPosition = Vector3.zero;
        ((Popup)popup).SetParentPopupSystem(this);
        AddPopupToList((Popup)popup);

        return popup;
    }

    public void ClosePopup(Popup popup)
    {
        //Debug.Log("Not sure if it exists? " + (visiblePopups.Contains(popup)));
        visiblePopups.Remove(popup);
        Destroy(popup.gameObject);
        CheckAndCorrectPanelVisibility();
    }

    private void AddPopupToList(Popup popup)
    {
        visiblePopups.Add((Popup)popup);
        CheckAndCorrectPanelVisibility();
    }

    private void CheckAndCorrectPanelVisibility()
    {
        if (visiblePopups.Count > 0)
        {
            if (greyPanel.activeSelf) return;
            greyPanel.SetActive(true);
        }
        else
        {
            if (!greyPanel.activeSelf) return;
            greyPanel.SetActive(false);
        }
    }

}
