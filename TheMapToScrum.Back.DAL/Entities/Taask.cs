using System;
using System.Collections.Generic;
using System.Text;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class Taask : EntityBase
    {
        
        public string Label { get; set; }
        public int Number { get; set; }
        public string Feature { get; set; }
        public int? EstimatedDuration { get; set; }
        public string Assumption { get; set; } 
        public int Priority { get; set; }
        public string AcceptanceCriteria { get; set; }
        public string Risk { get; set; }
        public int TaskStatus { get; set; }
        public int ProjectId { get; set; }
        public int DeveloperId { get; set; }
        public int? UserStoryId { get; set; }
        public Developer Developer { get; set; }
        public Project Project { get; set; }
        public UserStory UserStory { get; set; }
    }
}
