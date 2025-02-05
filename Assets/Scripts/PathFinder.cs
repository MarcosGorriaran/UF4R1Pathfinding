

using System.Collections.Generic;

public class PathFinder
{
    Node _startingPoint;
    Node[,] _nodeList;

    private List<Way> _queue = new List<Way>();
    public List<Way> closedList { get; private set; } = new List<Way>();
    public PathFinder(IntVector2 startingPoint , Node[,]nodeList)
    {
        _nodeList = nodeList;
        _startingPoint = nodeList[startingPoint.X, startingPoint.Y];
    }
    private void FindPath(Node processPoint)
    {
        foreach(Way option in processPoint.WayList)
        {
            
            _queue.Add(option);
        }
    }


}
