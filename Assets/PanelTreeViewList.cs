using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTreeViewList : MonoBehaviour
{
    /// <summary>
    /// 间距
    /// </summary>
    public int jianJv = 30;

    public GameObject prefabOneTreeViewItem;
    public Transform content;

    void Start()
    {
        CreateOneTreeViewItem(0);
        CreateOneTreeViewItem(1);
        CreateOneTreeViewItem(2);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(2);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(0);
        CreateOneTreeViewItem(1);
        CreateOneTreeViewItem(2);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(2);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(3);
        CreateOneTreeViewItem(0);
    }

    public void CreateOneTreeViewItem(int layer)
    {
        var obj = Instantiate(prefabOneTreeViewItem, content);
        if (layer != 0)
        {
            obj.GetComponent<OneTreeViewItem>().SetStartSuoJin(new Vector2(jianJv * layer, 0));
        }
    }
}