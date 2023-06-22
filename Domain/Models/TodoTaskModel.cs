using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DomainLayer.Models
{
    public class TodoTaskModel
    {
        public Guid Id = Guid.NewGuid();

        private string _title;
        public string Title 
        { 
            get { return _title; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                throw new NoNullAllowedException("Title cannot be null or whitespace.");

                _title = value;
            }
        }

        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public DateTime CreationDate { get; }

        public IEnumerable<TodoTaskModel> BlockingTasks { get; private set; }
        public IEnumerable<TodoTaskModel> SubTasks { get; private set; }

        public DateTime? CompletionDate { get; private set; }
        public eCompletionState CompletionState { get; set; }

        public TodoTaskModel(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreationDate = DateTime.Now;

            CompletionState = eCompletionState.Incomplete;
            CompletionDate = null;
        }

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
            LastModifiedDate = DateTime.Now;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
            LastModifiedDate = DateTime.Now;
        }

        public void UpdateDueDate(DateTime newDueDate)
        {
            DueDate = newDueDate;
            LastModifiedDate = DateTime.Now;
        }

        public void MarkAsComplete()
        {
            CompletionState = eCompletionState.Complete;
            CompletionDate = DateTime.Now;
        }

        public void MarkAsIncomplete()
        {
            CompletionState = eCompletionState.Incomplete;
            CompletionDate = null;
        }

        public void AddBlockingTask(TodoTaskModel blockingTask)
        {
            (BlockingTasks as List<TodoTaskModel>).Add(blockingTask);
        }

        public void AddSubTask(TodoTaskModel subTask)
        {
            (SubTasks as List<TodoTaskModel>).Add(subTask);
        }

        public enum eCompletionState
        {
            Complete,
            Incomplete
        }
    }
}
