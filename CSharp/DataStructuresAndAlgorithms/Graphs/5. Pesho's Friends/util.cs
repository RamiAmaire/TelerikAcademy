using System;

class util
{
    //ResetWeights(nodes, node);
    //FindShortestPath(node, new HashSet<int>(), new OrderedBag<Node<int>>());

    //private static void ResetWeights(List<Node<int>> nodes, Node<int> startingNode)
    //{
    //    foreach (var node in nodes)
    //    {
    //        if (node != startingNode)
    //        {
    //            node.Weight = double.PositiveInfinity;
    //        }
    //    }

    //    startingNode.Weight = 0;
    //}

    //private static void FindShortestPath(Node<int> currentNode, HashSet<int> visitedNodes,
    //     OrderedBag<Node<int>> nextNodes)
    //{
    //    visitedNodes.Add(currentNode.Symbol);
    //    foreach (var connection in currentNode.Connections)
    //    {
    //        Node<int> childNode = connection.toNode;
    //        if (!visitedNodes.Contains(childNode.Symbol))
    //        {
    //            double temporaryWeight = currentNode.Weight + connection.Distance;
    //            if (temporaryWeight < childNode.Weight)
    //            {
    //                nextNodes.Remove(childNode);
    //                childNode.Weight = temporaryWeight;
    //                nextNodes.Add(childNode);
    //            }
    //        }
    //    }

    //    if (nextNodes.Count == 0)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        Node<int> nextNode = nextNodes[0];
    //        nextNodes.Remove(nextNodes[0]);
    //        FindShortestPath(nextNode, visitedNodes, nextNodes);
    //    }
    //}

}
