using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeManager : MonoBehaviour
{
    public static NodeManager nodeManager;
    private void Awake() => nodeManager = this;

    public int[] nodeLevels, nodeLevelCap;

    public bool[] isActive;
    public bool[] isReachable;

    public List<Node> nodeList;
    public GameObject plant;

    public Player player;

    public int sapExpansionCost = 6;
    public int sapUpgradeCost = 10;
    public int sapLevelUpCost = 8;

    int waterGain;
    int mineralGain;
    int sunGain;

    private void Start()
    {
        foreach(var Node in plant.GetComponentsInChildren<Node>()) nodeList.Add(Node);
        int TotalNodes = nodeList.Count; // alterar quando tiver a quantidade de vértices certa
        for(int i = 0; i < nodeList.Count; i++) nodeList[i].id = i;

        waterGain = 0;
        mineralGain = 0;
        sunGain = 0;

        nodeLevels = new int[TotalNodes];

        nodeLevelCap = new int[TotalNodes];
        for(int i = 0; i < TotalNodes; i++){
            nodeLevelCap[i] = 3;
        }

        isReachable = new bool[TotalNodes];
        for(int i = 1; i < TotalNodes; i++){
            isReachable[i] = false;
        }
        isReachable[0] = true;

        isActive = new bool[TotalNodes];
        for(int i = 1; i < TotalNodes; i++){
            isActive[i] = false;
        }
        isActive[0] = true;

        nodeList[0].GetComponent<Button>().enabled = true;
        foreach(Node child in nodeList[0].childrenNodes){
            isReachable[child.id] = true;
            child.gameObject.GetComponent<Button>().enabled = true;
        }

        updateAllNodes();
    }

    // Call this at the begining of the upgrade phase
    public void updateResources(){
        foreach(var Node in nodeList){
            if(isActive[Node.id]){
                if(Node.resource == Node.WATER) waterGain += Node.amountResource;
                else if(Node.resource == Node.MINERALS) mineralGain += Node.amountResource;
                else if(Node.resource == Node.SUN) sunGain += Node.amountResource;
            }
        }

        player.sap += sunGain*waterGain*mineralGain + sunGain*waterGain + sunGain*mineralGain + waterGain*mineralGain + waterGain + sunGain + mineralGain;
    }

    public void updateAllNodes(){
        player.ChangeValues();
        foreach(var Node in nodeList){
            Node.UpdateUI();
        }
    }
}
