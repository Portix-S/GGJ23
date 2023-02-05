using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NodeManager;

public class PoisonEffect : MonoBehaviour
{
    private Player player;
    [SerializeField]private Node node;

    void Awake(){
        player = GameObject.Find("/Plant").GetComponent<Player>();
        player.attack += 1;
    }

    void LeafLevelUp(){
        player.attack += nodeManager.nodeLevels[node.id];
    }
}
