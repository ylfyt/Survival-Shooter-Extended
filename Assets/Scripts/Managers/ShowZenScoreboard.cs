using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowZenScoreboard : MonoBehaviour
{
    public GameObject cellPrefab;
    void Start()
    {
        var data = DataManager.LoadPlayer("zen");
        if (data.Length == 0)
        {
            return;
        }

        var idxMax = 0;
        for (int i = 0; i < data.Length; i++)
        {
            idxMax = i;
            for (int j = i + 1; j < data.Length; j++)
            {
                if (data[j].score > data[idxMax].score)
                {
                    idxMax = j;
                }
            }

            var temp = data[i];
            data[i] = data[idxMax];
            data[idxMax] = temp;
        }

        foreach (var item in data)
        {
            var obj = Instantiate(cellPrefab);
            obj.transform.SetParent(this.gameObject.transform, false);
            obj.transform.GetChild(0).GetComponent<Text>().text = item.name;
            obj.transform.GetChild(1).GetComponent<Text>().text = item.score.ToString();
        }
    }
}
