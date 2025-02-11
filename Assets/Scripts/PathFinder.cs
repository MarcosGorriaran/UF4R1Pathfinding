

using System.Collections.Generic;
using System.Linq;

public class PathFinder
{
    Node _startingPoint;
    Node[,] _nodeList;

    private List<Node> _queue = new List<Node>();
    private List<Node> closedList { get; set; } = new List<Node>();
    public List<Way> Path { get; private set; }
    public PathFinder(IntVector2 startingPoint , Node[,]nodeList)
    {
        _nodeList = nodeList;
        _queue.Add(nodeList[startingPoint.X, startingPoint.Y]);
    }
    
    public Node FindPath()
    {
        while (true)
        {
            float minCost = _queue.Min(obj => obj.GetPathCost());
            Node searchNode = _queue.Where(obj => obj.GetPathCost() == minCost).FirstOrDefault();
            _queue.Remove(searchNode);
            closedList.Add(searchNode);
            if (searchNode.Heuristic == 0)
            {
                return searchNode;
            }

        }
        
    }

}
