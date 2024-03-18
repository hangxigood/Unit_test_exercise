using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test_Assignment_3
{
    public class LinkedListTests
    {
        private SLL linkedList;

        [SetUp]
        public void Setup()
        {
            // Create your concrete linked list class and assign to to linkedList.
            this.linkedList = new SLL();
        }

        [TearDown]
        public void TearDown()
        {
            this.linkedList.Clear();
        }

        //Test the linked list is empty.
        [Test]
        public void TestIsEmpty()
        {
            Assert.True(this.linkedList.IsEmpty());
            Assert.AreEqual(0, this.linkedList.Size());
        }

        //Tests appending elements to the linked list.
        [Test]
        public void TestAppendNode()
        {
            this.linkedList.Append("a");
            this.linkedList.Append("b");
            this.linkedList.Append("c");
            this.linkedList.Append("d");

            /**
             * Linked list should now be:
             * 
             * a -> b -> c -> d
             */

            // Test the linked list is not empty.
            Assert.False(this.linkedList.IsEmpty());

            // Test the size is 4
            Assert.That(this.linkedList.Size(), Is.EqualTo(4));

            // Test the first node value is a
            Assert.That(this.linkedList.Retrieve(0), Is.EqualTo("a"));

            // Test the second node value is b
            Assert.That(this.linkedList.Retrieve(1), Is.EqualTo("b"));

            // Test the third node value is c
            Assert.That(this.linkedList.Retrieve(2), Is.EqualTo("c"));

            // Test the fourth node value is d
            Assert.That(this.linkedList.Retrieve(3), Is.EqualTo("d"));
        }

        //Tests prepending nodes to linked list.
        [Test]
        public void testPrependNodes()
        {
            this.linkedList.Prepend("a");
            this.linkedList.Prepend("b");
            this.linkedList.Prepend("c");
            this.linkedList.Prepend("d");

            /**
             * Linked list should now be:
             * 
             * d -> c -> b -> a
             */

            // Test the linked list is not empty.
            Assert.False(this.linkedList.IsEmpty());

            // Test the size is 4
            Assert.That(this.linkedList.Size(), Is.EqualTo(4));

            // Test the first node value is a
            Assert.That(this.linkedList.Retrieve(0), Is.EqualTo("d"));

            // Test the second node value is b
            Assert.That(this.linkedList.Retrieve(1), Is.EqualTo("c"));

            // Test the third node value is c
            Assert.That(this.linkedList.Retrieve(2), Is.EqualTo("b"));

            // Test the fourth node value is d
            Assert.That(this.linkedList.Retrieve(3), Is.EqualTo("a"));
        }

        //Tests inserting node at valid index.
        [Test]
        public void TestInsertNode()
        {
            this.linkedList.Append("a");
            this.linkedList.Append("b");
            this.linkedList.Append("c");
            this.linkedList.Append("d");

            this.linkedList.Insert("e", 2);

            /**
             * Linked list should now be:
             * 
             * a -> b -> e -> c -> d
             */

            // Test the linked list is not empty.
            Assert.False(this.linkedList.IsEmpty());

            // Test the size is 4
            Assert.That(this.linkedList.Size(), Is.EqualTo(5));

            // Test the first node value is a
            Assert.That(this.linkedList.Retrieve(0), Is.EqualTo("a"));

            // Test the second node value is b
            Assert.That(this.linkedList.Retrieve(1), Is.EqualTo("b"));

            // Test the third node value is e
            Assert.That(this.linkedList.Retrieve(2), Is.EqualTo("e"));

            // Test the third node value is c
            Assert.That(this.linkedList.Retrieve(3), Is.EqualTo("c"));

            // Test the fourth node value is d
            Assert.That(this.linkedList.Retrieve(4), Is.EqualTo("d"));
        }

        //Tests replacing existing nodes data.
        [Test]
        public void TestReplaceNode()
        {
            this.linkedList.Append("a");
            this.linkedList.Append("b");
            this.linkedList.Append("c");
            this.linkedList.Append("d");

            this.linkedList.Replace("e", 2);

            /**
             * Linked list should now be:
             * 
             * a -> b -> e -> d
             */

            // Test the linked list is not empty.
            Assert.False(this.linkedList.IsEmpty());

            // Test the size is 4
            Assert.That(this.linkedList.Size(), Is.EqualTo(4));

            // Test the first node value is a
            Assert.That(this.linkedList.Retrieve(0), Is.EqualTo("a"));

            // Test the second node value is b
            Assert.That(this.linkedList.Retrieve(1), Is.EqualTo("b"));

            // Test the third node value is e
            Assert.That(this.linkedList.Retrieve(2), Is.EqualTo("e"));

            // Test the fourth node value is d
            Assert.That(this.linkedList.Retrieve(3), Is.EqualTo("d"));
        }

        //Tests deleting node from linked list.
        [Test]
        public void TestDeleteNode()
        {
            this.linkedList.Append("a");
            this.linkedList.Append("b");
            this.linkedList.Append("c");
            this.linkedList.Append("d");

            this.linkedList.Delete(2);

            /**
             * Linked list should now be:
             * 
             * a -> b -> d
             */

            // Test the linked list is not empty.
            Assert.False(this.linkedList.IsEmpty());

            // Test the size is 4
            Assert.That(this.linkedList.Size(), Is.EqualTo(3));

            // Test the first node value is a
            Assert.That(this.linkedList.Retrieve(0), Is.EqualTo("a"));

            // Test the second node value is b
            Assert.That(this.linkedList.Retrieve(1), Is.EqualTo("b"));

            // Test the fourth node value is d
            Assert.That(this.linkedList.Retrieve(2), Is.EqualTo("d"));
        }

        //Tests finding and retrieving node in linked list.
        [Test]
        public void TestFindNode()
        {
            this.linkedList.Append("a");
            this.linkedList.Append("b");
            this.linkedList.Append("c");
            this.linkedList.Append("d");

            /**
             * Linked list should now be:
             * 
             * a -> b -> c -> d
             */

            bool contains = this.linkedList.Contains("b");
            Assert.True(contains);

            int index = this.linkedList.IndexOf("b");
            Assert.That(index, Is.EqualTo(1));

            string value = (string)this.linkedList.Retrieve(1);
            Assert.That(value, Is.EqualTo("b"));
        }
        [Test]
        public void TestToList()
        {
            // Initialize the SLL and populate it with User instances
            SLL linkedList = new();
            linkedList.Append(new User(1, "Alice", "alice@example.com", "password1"));
            linkedList.Append(new User(2, "Bob", "bob@example.com", "password2"));
            linkedList.Append(new User(3, "Charlie", "charlie@example.com", "password3"));

            // Convert the list to an array
            List<User> list = linkedList.ToList();

            // Assert that the array is not null
            Assert.That(list, Is.Not.Null, "The resulting array should not be null.");

            // Assert that the array length matches the list size
            Assert.That(list.Count, Is.EqualTo(3), "The array length should match the number of elements in the list.");

            // Assert that each element in the array matches the expected User object
            Assert.That(list[0].Name, Is.EqualTo("Alice"), "The first element in the array should be Alice.");
            Assert.That(list[1].Name, Is.EqualTo("Bob"), "The second element in the array should be Bob.");
            Assert.That(list[2].Name, Is.EqualTo("Charlie"), "The third element in the array should be Charlie.");
        }
    }
}
