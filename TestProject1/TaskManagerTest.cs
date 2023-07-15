using lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = lab5.Task;

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
            var task = new Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new Task("Test task");
            _taskManager.AddTask(task);
            int taskCount = _taskManager.GetTasks().Count;
            // Act
            var result = _taskManager.RemoveTask(task.Id);
            // Assert
            Assert.AreEqual(taskCount - 1, _taskManager.GetTasks().Count);
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            var task = new Task("Test task");
            _taskManager.AddTask(task);
            int taskCount = _taskManager.GetTasks().Count;
            // Act
            var result = _taskManager.RemoveTask(-1);
            // Assert
            Assert.AreEqual(taskCount, _taskManager.GetTasks().Count);
            Assert.IsFalse(result);
        }
    }
}
