// Assignment 3: Singly Linked Lists, Serialization and Testing
// OOP-2 Using C#
// Group Project
// Members: Ahmed Obad, Fernando Horta, Hangxi Xiang
// March 24th, 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    // implementation of SLL class using ILinkedListADT interface provided for this assignment
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int size;

        // starting with an empty linked list
        public SLL()
        {
            head = null;
            size = 0;
        }

        // method to verify if the linked list is empty by checking if the first node exists or not
        public bool IsEmpty()
        {
            return head == null;
        }

        // method to clear the linked list by "removing" its head, thus destroying the link to any other nodes
        public void Clear()
        {
            head = null;
            size = 0;
        }

        // method to append an item to the end of the list
        public void Append(Object data)
        {
            // if head is null (list is empty), assigns the new node to head position
            if (head == null)
            {
                head = new Node(data);
            }
            
            // if list is not empty
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    // loops through the nodes until finds the last item (one with no "next")
                    current = current.Next;
                }
                // creates a new node after the last position
                current.Next = new Node(data);
            }
            // increses the variable that holds the number of nodes by 1
            size++;
        }

        // method to create a new node at the beginning of the linked list
        public void Prepend(Object data)
        {
            // creates a new node
            Node newHead = new Node(data);            
            // assign the head node to next position for this new node
            newHead.Next = head;
            // assign head position to the new node, effectively placing it at the beginning of the linked list
            head = newHead;
            // increses the variable that holds the number of nodes by 1
            size++;
        }

        // method to Insert an item at a specific index in the linked list.
        public void Insert(Object data, int index)
        {
            // checks if is invalid (either an impossible value below 0 or a value that is greater than the size of the linked list using variable size for that)
            if (index < 0 || index > size)
            {
                // throws exception if that happens
                throw new IndexOutOfRangeException("Oh, no! This index out of range :(");
            }

            // if the chosen position is 0 (aka the beginning of the list), calls for the Prepend method
            if (index == 0)
            {
                Prepend(data);
            }
            // if the position equal to the size of the list, calls Append method to add to the end of the list
            else if (index == size)
            {
                Append(data);
            }
            // for everything in between, loops through nodes using a for loop until finding the specific index
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                // creates a new node
                Node newNode = new Node(data);
                // defines its "Next" position to whatever node was the next of the node currently occupying that index
                newNode.Next = current.Next;
                // defines the "former current" node "next" position to this newly created node
                current.Next = newNode;
                // increses the variable that holds the number of nodes by 1
                size++;
            }
        }

        public void Replace(Object data, int index)
        {
            // checks if is invalid (either an impossible value below 0 or a value that is equal or greater than the size of the linked list using variable size for that)
            if (index < 0 || index >= size)
            {
                // throws exception if that happens
                throw new IndexOutOfRangeException("Oh, no. A different case of Index out of range");
            }

            // iterates through the linked list with a for loop until finding the specified index
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            // replaces the specific node data with the values passed to this method
            current.Data = data;
        }

        // method to get the number of items in the linked list
        public int Size()
        {
            // simply returns the value of the size variable
            return size;
        }

        // method to Remove an item at an index in the linked list.
        public void Delete(int index)
        {
            // checks if is invalid (either an impossible value below 0 or a value that is equal or greater than the size of the linked list using variable size for that)
            if (index < 0 || index >= size)
            {
                // throws exception if that happens
                throw new IndexOutOfRangeException("Can't delete if the index is out of range");
            }

            // checks if the index is 0 (beginning of the list)
            if (index == 0)
            {
                // assigns the head to whatever node comes after the current one, effectively removing it from the list
                head = head.Next;
            }
            // for all other cases
            else
            {
                // iterates through the nodes until finding the item that is one behind the specified index
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                // assign the next position to the "next of next", removing the link to that node
                current.Next = current.Next.Next;
            }
            // decreases the size of the list
            size--;
        }

        // method to Get an item at an index in the linked list.
        public Object Retrieve(int index)
        {
            // checks if is invalid (either an impossible value below 0 or a value that is equal or greater than the size of the linked list using variable size for that)
            if (index < 0 || index >= size)
            {
                // throws exception if index doesn't exist
                throw new IndexOutOfRangeException("Can't find this index, it's out of range");
            }

            // iterates through the linked list with a for loop until finding the specified index
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            // returns the item of that specific index
            return current.Data;
        }

        // method to Get the index of an item in the linked list.

        public int IndexOf(Object data)
        {
            
            Node current = head;
            int index = 0;
            // runs a while loop to iterate throught the objects in the list as long as they exist, starting at index 0
            while (current != null)
            {
                // if "data" matches the item passed to the method
                if (current.Data.Equals(data))
                {
                    // returns the index of the found item
                    return index;
                }
                current = current.Next;
                index++;
            }
            // returns a negative number to trigger the out of index result if the item is not found
            return -1;
        }

        // method to Check if the linked list has an item.
        public bool Contains(Object data)
        {
            return IndexOf(data) != -1;
        }

        // method to Reverse the order of the nodes in the linked list.
        public void Reverse()
        {
            Node previous = null;
            Node current = head;
            Node next = null;

            // iterates through all items
            while (current != null)
            {
                // sets the next variable to what is currently the next node
                next = current.Next;
                // sets the next position to the value of the previous variable
                current.Next = previous;
                // sets the previous variable to the position of the current node
                previous = current;
                // sets the current variable to the position of the next variable
                current = next;
            }
            // sets the head to the last value of previous variable once the loop is over and all items in the list were reversed
            head = previous;
        }

        // implementation of the class Node
        private class Node
        {
            // getter and setter for the Object Data
            public Object Data { get; set; }
            // getter and setter for the Node Next
            public Node Next { get; set; }

            // constructor for Node with Data holding the item data and Next being set to null
            public Node(Object data)
            {
                Data = data;
                Next = null;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
