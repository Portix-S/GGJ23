using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NodeManager;

public class LeafEffect : MonoBehaviour
{
    private Player player;
    [SerializeField]private Node node;

    void Awake(){
        player = GameObject.Find("/Plant").GetComponent<Player>();

        node.amountResource += 2;
        player.totalLeafs++;
    }

    void LeafLevelUp(){
        node.amountResource += (player.totalLeafs + 1) * nodeManager.nodeLevels[node.id];
    }
}
