namespace Assignment_3_skeleton;

public class SLL : ILinkedListADT
{
    private Node? head;

    public SLL()
    {
        this.head = null;
    }

    //Check if the linked list is empty.
    public bool IsEmpty()
    {
        return this.head == null;
    }

    //Clear all items in the linked list.
    public void Clear()
    {
        this.head = null;
    }

    //Append an item to the end of the linked list.
    public void Append(object data)
    {
        if (IsEmpty())
        {
            head = new Node(data);
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new Node(data);
    }

    //Prepend an item to the beginning of the linked list.
    public void Prepend(object data)
    {
        Node newHead = new Node(data) { Next = head };
        head = newHead;
    }
    
    //Insert an item at a specific index in the linked list.
    public void Insert(object data, int index)
    {
        if (index < 0 || (index > 0 && IsEmpty()))
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        if (index == 0)
        {
            Prepend(data);
            return;
        }

        Node current = head;
        for (int i = 0; i < index - 1; i++)
        {
            if (current.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            current = current.Next;
        }
        Node newNode = new Node(data) { Next = current.Next };
        current.Next = newNode;
    }

    //Replace an item in the linked list.
    public void Replace(object data, int index)
    {
        if (IsEmpty() || index < 0)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            if (current.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            current = current.Next;
        }
        current.Data = data;
    }

    //Get the number of items in the linked list.
    public int Size()
    {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            count ++;
            current = current.Next;
        }
        return count;
    }

    //Remove an item at an index in the linked list.
    public void Delete(int index)
    {
        if (IsEmpty() || index < 0)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
        
        // Delete the first Node
        if (index == 0)
        {
            head = head.Next;
            return;
        }

        //find the Node then delete it.
        Node current = head;
        for (int i = 0; i < index - 1; i++)
        {
            if (current.Next == null || current.Next.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            current = current.Next;
        }
        current.Next = current.Next.Next;
    }

    //Get an item at an index in the linked list.
    public object Retrieve(int index)
    {
        if (IsEmpty() || index < 0)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            if (current.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            current = current.Next;
        }
        return current.Data;
    }

    //Get the index of an item in the linked list.
    public int IndexOf(object data)
    {
        int index = 0;
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return index;
            }
            current = current.Next;
            index++;
        }
        return -1;
    }

    //Check if the linked list has an item.
    public bool Contains(object data)
    {
        return IndexOf(data) != -1;
    }

    //transfer the linked list to a list.
    public List<User> ToList()
    {
        var userList = new List<User>();
        Node current = head;
        while (current != null)
        {
            if (current.Data is User user)
            {
                userList.Add(user);
            }
            current = current.Next;
        }
        return userList;
    }

    //transfer the list to linked list.
    public void FromList(List<User> userList)
    {
        Clear();
        foreach (var user in userList)
        {
            Append(user);
        }
    }
}