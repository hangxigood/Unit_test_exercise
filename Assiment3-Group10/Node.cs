namespace Assignment_3_skeleton;

public class Node(object data)
{
    public object Data { get; set; } = data;
    public Node? Next { get; set; } = null;
}