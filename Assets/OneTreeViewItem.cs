using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneTreeViewItem : MonoBehaviour
{
    /// <summary>
    /// 头缩进
    /// </summary>
    public RectTransform startSuoJin;

    /// <summary>
    /// 收缩
    /// </summary>
    public Button btnShouSuo;

    public List<GameObject> closes = new List<GameObject>();

    public IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        var index = transform.GetSiblingIndex() + 1;
        bool isCanSuoJin = index < transform.parent.childCount &&
            transform.parent.GetChild(index).GetComponent<OneTreeViewItem>().
            startSuoJin.sizeDelta.x > startSuoJin.sizeDelta.x;
        if (isCanSuoJin)
        {
            btnShouSuo.onClick.AddListener(OnClickBtnShouSuo);
        }
        else
        {
            btnShouSuo.GetComponent<Graphic>().color = Color.clear;
            btnShouSuo.GetComponent<Graphic>().raycastTarget = false;
        }
    }

    public void SetStartSuoJin(Vector2 suoJin)
    {
        startSuoJin.sizeDelta = suoJin;
    }

    public void OnClickBtnShouSuo()
    {
        if (closes.Count != 0)
        {
            for (int i = 0; i < closes.Count; i++)
            {
                closes[i].gameObject.SetActive(true);
            }
            closes.Clear();
            return;
        }

        bool b = IsNextSiblingActive();
        var index = transform.GetSiblingIndex() + 1;
        while (index < transform.parent.childCount)
        {
            if (transform.parent.GetChild(index).GetComponent<OneTreeViewItem>().
                startSuoJin.sizeDelta.x > startSuoJin.sizeDelta.x)
            {
                if (b && transform.parent.GetChild(index).gameObject.activeSelf )
                {
                    closes.Add(transform.parent.GetChild(index).gameObject);
                }

                transform.parent.GetChild(index).gameObject.SetActive(!b);
            }
            else
            {
                break;
            }
            index++;
        }
    }

    public bool IsNextSiblingActive()
    {
        var index = transform.GetSiblingIndex() + 1;
        if (index < transform.parent.childCount)
        {
            return transform.parent.GetChild(index).gameObject.activeSelf;
        }
        throw new Exception();
    }
}