using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static NodeManager;

public class Node : MonoBehaviour
{
    public int id;

    // Node types:
    public const int CORE = 0; // 0 -> core or empty
    public const int ROOT = 1;// 1 -> root
    public const int TRUNK = 2;// 2 -> trunk
    public int type;

    // Resources:
    public const int WATER = 1;     // 1 -> water
    public const int MINERALS = 2;  // 0 -> sun
    public const int SUN = 3;       // 2 -> minerals
    
    public int resource;
    public int amountResource = 6;

    public Node[] childrenNodes;

    // Functions to expand tree
    public void OpenNode(){
        if(!nodeManager.isActive[id] && nodeManager.isReachable[id]){
            if(!transform.GetChild(0).gameObject.activeSelf){
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else CloseNode(0);
        }

        nodeManager.updateAllNodes();
    }

    public void CloseNode(int n){
        transform.GetChild(n).gameObject.SetActive(false);
    }

    public void Buy(){
        if(nodeManager.sapExpansionCost > nodeManager.player.sap) return;
        
        nodeManager.player.sap -= nodeManager.sapExpansionCost;
        nodeManager.isActive[id] = true;

        foreach(Node child in childrenNodes){
            nodeManager.isReachable[child.id] = true;
            child.GetComponent<Button>().enabled = true;
        }

        CloseNode(0);
        nodeManager.updateAllNodes();
    }

    // Functions to upgrade node
    public void UpgradeNode(){
        if(nodeManager.isActive[id] && nodeManager.nodeLevels[id] == 0){
            if(!transform.GetChild(1).gameObject.activeSelf){
                transform.GetChild(1).gameObject.SetActive(true);
                if(type == 1){
                    transform.GetChild(1).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = "Tuber";     // temp name, really weird
                    transform.GetChild(1).GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = "Poison";
                    transform.GetChild(1).GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text = "Drainer";   // temp name, really weird 
                }
                else if(type == 2){
                    transform.GetChild(1).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = "Leaf";
                    transform.GetChild(1).GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = "Spike";
                    transform.GetChild(1).GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text = "Bark";
                }
                else CloseNode(1);
            }
            else CloseNode(1);
        }

        nodeManager.updateAllNodes();
    }

    public void SelectUpgrade(int SelectedUpgrade){ 
        if(nodeManager.sapUpgradeCost > nodeManager.player.sap) return;

        nodeManager.player.sap -= nodeManager.sapUpgradeCost;
        for(int i = 0; i < 6; i++){
            transform.GetChild(i+3).gameObject.SetActive(false);
        }
        transform.GetChild(SelectedUpgrade + 3).gameObject.SetActive(true);
        nodeManager.nodeLevels[id] = 1;

        CloseNode(1);
        nodeManager.updateAllNodes();
    }

    // Functions to level up nodes
    public void LevelUpNode(){
        if(nodeManager.isActive[id] && nodeManager.nodeLevels[id] > 0){
            if(!transform.GetChild(2).gameObject.activeSelf){
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else CloseNode(2);
        }

        nodeManager.updateAllNodes();
    }

    public void LevelUp(){
        if(nodeManager.sapLevelUpCost > nodeManager.player.sap || nodeManager.nodeLevels[id] == nodeManager.nodeLevelCap[id]) return;

        nodeManager.player.sap -= nodeManager.sapLevelUpCost;
        nodeManager.nodeLevels[id]++;

        CloseNode(2);
        nodeManager.updateAllNodes();
    }

    public void UpdateUI(){
        if(nodeManager.isActive[id]) GetComponent<Image>().color = Color.green;
        else if(nodeManager.isReachable[id]) GetComponent<Image>().color = Color.white;
        else GetComponent<Image>().color = new Color(0.55f, 0.55f, 0.55f, 1f);

        if(nodeManager.sapExpansionCost > nodeManager.player.sap){
            transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.red;
        }
    }
}
