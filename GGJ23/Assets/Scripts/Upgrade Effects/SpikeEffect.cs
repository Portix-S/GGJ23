using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NodeManager;

public class SpikeEffect : MonoBehaviour
{
    private Player player;
    [SerializeField]private Node node;

    void Awake(){
        player = GameObject.Find("/Plant").GetComponent<Player>();
        player.attack += 2;
    }

    void LeafLevelUp(){
        player.attack += player.totalSpikes * nodeManager.nodeLevels[node.id];
    }
}
