using System;
using System.Data;

namespace DomainLayer.Models
{
    public class TodoTask
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

        public DateTime? CompletionDate { get; private set; }
        public bool IsComplete { get; set; }

        public TodoTask(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreationDate = DateTime.Now;

            IsComplete = false;
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
            IsComplete = true;
            CompletionDate = DateTime.Now;
        }

        public void MarkAsIncomplete()
        {
            IsComplete = false;
            CompletionDate = null;
        }
    }
}
