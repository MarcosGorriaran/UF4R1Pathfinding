

using System;
using System.Collections.Generic;
using System.Linq;

public class PathFinder
{

    private List<Node> _queue = new List<Node>();
    private List<Node> closedList { get; set; } = new List<Node>();
    public PathFinder(IntVector2 startingPoint , Node[,]nodeList)
    {
        _queue.Add(nodeList[startingPoint.X, startingPoint.Y]);
    }
    
    public Node FindPath()
    {
        Node resolvedResult = ReturnResolvedResult();
        if (resolvedResult != null) return resolvedResult;

        float minCost = _queue.Min(obj => obj.GetPathCost());
        Node searchNode = _queue.Where(obj => obj.GetPathCost() == minCost).First();
        _queue.Remove(searchNode);
        closedList.Add(searchNode);
            
        if (searchNode.Heuristic == 0)
        {
            return searchNode;
        }
        foreach (Way way in searchNode.WayList)
        {
            if (!closedList.Contains(way.NodeDestiny))
            {
                _queue.Add(way.NodeDestiny);
                way.NodeDestiny.NodeParent = searchNode;
            }
        }
        return FindPath();
        
    }
    public Node FindNextStep()
    {
        Node resolvedResult = ReturnResolvedResult();
        if (resolvedResult != null) return resolvedResult;

        float minCost = _queue.Min(obj => obj.GetPathCost());
        Node searchNode = _queue.Where(obj => obj.GetPathCost() == minCost).First();
        _queue.Remove(searchNode);
        closedList.Add(searchNode);

        if (searchNode.Heuristic == 0)
        {
            return searchNode;
        }
        foreach (Way way in searchNode.WayList)
        {
            if (!closedList.Contains(way.NodeDestiny))
            {
                _queue.Add(way.NodeDestiny);
                way.NodeDestiny.NodeParent = searchNode;
            }
        }
        return searchNode;
    }
    /**
     * <param>
     * A method to prevent any attempt by the class instance to resolve an already resolved path.
     * </param>
     */
    private Node ReturnResolvedResult()
    {
        try
        {
            if (closedList.Last().Heuristic == 0) return closedList.Last();
        }
        catch (InvalidOperationException)
        {
            
        }
        return null;
    }

}
