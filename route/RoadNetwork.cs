using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace route
{
    class RoadNetwork
    {
        private int numNodes;
        private int numEdges;
        //nodes that have adjacent arcs
        private IList<long> nodesIds;
        private AdjacencyList<Node> adjacentArcs;
        //Map nodeId->Node. Contains all nodes
        private IDictionary<long, Node> mapNodeId;

        public RoadNetwork()
        {
            nodesIds = new List<long>();
            adjacentArcs = new AdjacencyList<Node>();
            mapNodeId = new Dictionary<long, Node>();
        }
        public IList<long> NodesIds
        {
            set{ nodesIds = value;}
            get{ return nodesIds; }
        } 
        public AdjacencyList<Node> AdjacentArcs
        {
            set { adjacentArcs = value; }
            get { return adjacentArcs; }
        }
        public IDictionary<long, Node> MapNodeId
        {
            set { mapNodeId = value;}
            get { return mapNodeId; }
        }
        /// <summary>
        /// add a node with the given Osm id
        /// </summary>
        /// <param name="tailNode"></param>
        public void addNode(Node tailNode)
        {
            if (tailNode != null)
            {
                long nodeId = tailNode.id;
                bool alreadyInNetwork = mapNodeId.ContainsKey(nodeId);
                if (!alreadyInNetwork)
                {
                    mapNodeId.Add(nodeId,tailNode);
                }
            }
        }
        public void addEdge(Node headNode, Node tailNode, Arc arc)
        {
            if (tailNode != null && arc != null)
            {
                long tailNodeId = tailNode.id;
                if (!mapNodeId.ContainsKey(tailNodeId))
                {
                    addNode(tailNode);
                }
                adjacentArcs.AddNode(headNode);
                adjacentArcs.AddNode(tailNode);
                adjacentArcs.AddEdge(headNode,tailNode);
            }
        }

        //读取osm文件
       // public void readFromOsmFile();
    }
}
