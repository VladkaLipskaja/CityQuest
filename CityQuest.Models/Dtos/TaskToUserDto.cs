namespace CityQuest.Models.Dtos
{
    public class TaskToUserDto
    {
        public int Count { get; set; }

        public Task[] Tasks { get; set; }

        public class Task
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public int? Points { get; set; }
        }
    }
}
