using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    
    class Jogador
    {
        public long ID { get; set; }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }

        public bool IsCaptain { get; set; } = false;

        public Jogador(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            ID = id;
            TeamId = teamId;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
        }
    }
}
