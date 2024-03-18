using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment_3
{
    public class SerializationTests
    {
        private SLL userList;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            userList = new SLL();
            userList.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            userList.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            userList.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            userList.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.userList.Clear();
        }

        //Tests the object was serialized.
        [Test]
        public void TestSerialization()
        {
            List<User> usersToSerialize = userList.ToList();
            SerializationHelper.SerializeUsers(usersToSerialize, testFileName);
            Assert.That(File.Exists(testFileName), Is.True);
        }

        [Test]
        public void TestDeSerialization()
        {
            // Serialize
            List<User> usersToSerialize = userList.ToList();
            SerializationHelper.SerializeUsers(usersToSerialize, testFileName);

            // Deserialize
            List<User> deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            //Creat a new SLL from deserialized list
            SLL deserializedList = new();
            deserializedList.FromList(deserializedUsers);

            //Verify the SLL content
            Assert.That(deserializedList.Size(), Is.EqualTo(userList.Size()));

            for (int i = 0; i < userList.Size(); i++)
            {
                User originalUser = (User)userList.Retrieve(i);
                User deserializedUser = (User)deserializedList.Retrieve(i);

                Assert.Multiple(() =>
                {
                    Assert.That(deserializedUser.Id, Is.EqualTo(originalUser.Id));
                    Assert.That(deserializedUser.Name, Is.EqualTo(originalUser.Name));
                    Assert.That(deserializedUser.Email, Is.EqualTo(originalUser.Email));
                });
            }
        }

    }
}
