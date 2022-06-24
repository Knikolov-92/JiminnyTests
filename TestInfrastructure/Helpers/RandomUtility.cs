using Faker;
using Jiminny.UITests.TestInfrastructure.Models;
using System.Collections.Generic;

namespace Jiminny.UITests.TestInfrastructure.Helpers
{
    public static class RandomUtility
    {
        public static List<ToDoItem> CreateListOfToDoITems(int numberOfItems)
        {
            var listOfItems = new List<ToDoItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var item = new ToDoItem()
                {
                    Name = Lorem.Sentence()
                };
                listOfItems.Add(item);
            }

            return listOfItems;
        }
    }
}
