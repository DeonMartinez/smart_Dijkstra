using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Connection> mConnections;

    //connections out from the node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public void Build(bool difficultTerrain)
    {
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost;

                if (difficultTerrain == true)
                {

                    if (fromNode.gameObject.tag == "difficultTerrain" && toNode.gameObject.tag == "difficultTerrain")
                    {
                        cost = ((toNode.transform.position - fromNode.transform.position).magnitude) * 4;
                    }
                    else
                    {
                        cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                    }

                    Connection c = new Connection(cost, fromNode, toNode);
                    mConnections.Add(c);
                }

                else
                {
                    cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                    Connection c = new Connection(cost, fromNode, toNode);
                    mConnections.Add(c);
                }
            }
        }
    }
}

public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost()
    {
        return cost;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}
