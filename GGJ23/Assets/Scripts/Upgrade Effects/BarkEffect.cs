using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NodeManager;

public class BarkEffect : MonoBehaviour{
    private Player player;
    [SerializeField]private Node node;

    void Awake(){
        player = GameObject.Find("/Plant").GetComponent<Player>();
        player.health++;
        player.absorption += 1;
    }

    void BarkLevelUp(){
        player.absorption += nodeManager.nodeLevels[node.id];
    }
}
