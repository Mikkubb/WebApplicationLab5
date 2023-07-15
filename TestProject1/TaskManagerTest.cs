using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationLab5;

namespace TestProject1
{
    internal class TaskManagerTest
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
            var task = new WebApplicationLab5.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new WebApplicationLab5.Task("Test task");
            _taskManager.AddTask(task);
            int initialTaskCount = _taskManager.GetTasks().Count;

            // Act
            var result = _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(initialTaskCount - 1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            var task = new WebApplicationLab5.Task("Test task");
            _taskManager.AddTask(task);
            int initialTaskCount = _taskManager.GetTasks().Count;

            // Act
            var result = _taskManager.RemoveTask(-1);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(initialTaskCount, _taskManager.GetTasks().Count);
        }

    }
}
