using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static NodeManager;

public class Node : MonoBehaviour
{
    public int id;

    public Node[] childrenNodes;

    public void OpenNode(){
        if(!transform.GetChild(0).gameObject.activeSelf && !nodeManager.isActive[id]){
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = nodeManager.nodeType[id] +"\n"+ nodeManager.nodeLevels[id] +"/"+ nodeManager.nodeLevelCap[id];
        }
        else CloseNode();

        nodeManager.updateAllNodes();
    }

    public void CloseNode(){
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void UpdateUI(){
        nodeManager.player.ChangeValues();
        if(nodeManager.isActive[id]) GetComponent<Image>().color = Color.green;
        else if(nodeManager.isReachable[id]) GetComponent<Image>().color = Color.white;
        else{
            Color temp = Color.gray;
            temp.a = 128;
            GetComponent<Image>().color = temp;
        }
    }

    public void Buy(){
        if(nodeManager.sapCost[id] >= nodeManager.player.sap || nodeManager.nodeLevels[id] == nodeManager.nodeLevelCap[id]) return;
        nodeManager.player.sap -= nodeManager.sapCost[id];
        nodeManager.isActive[id] = true;

        foreach(Node child in childrenNodes){
            nodeManager.isReachable[child.id] = true;
            child.GetComponent<Button>().enabled = true;
        }

        CloseNode();
        nodeManager.updateAllNodes();
    }
}
