using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_5; // Dodane
using static Lab_5.TaskMenager;

namespace TestLab_5
{
    public class TaskMenagerTest
    {
        private TaskManager _taskManager;

        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }

        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new Lab_5.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void GetTasks_ShouldReturnAllAddedTasks()
        {
            // Arrange
            var task1 = new Lab_5.Task("Task 1");
            var task2 = new Lab_5.Task("Task 2");

            _taskManager.AddTask(task1);
            _taskManager.AddTask(task2);

            // Act
            var tasks = _taskManager.GetTasks();

            // Assert
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
            Assert.AreEqual(2, tasks.Count);
        }

        [Test]
        public void RemoveTask_ShouldDecreaseTaskCountForExistingTask()
        {
            // Arrange
            var task = new Lab_5.Task("Task");
            _taskManager.AddTask(task);

            // Act
            bool result = _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, _taskManager.GetTasks().Count);
        }
    }
}
