using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {

        private List<Time> _times = new List<Time>();
        private List<Jogador> _jogadores = new List<Jogador>();

        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {           
              if (_times.Any(x => x.TeamID == id))                
                throw new UniqueIdentifierException();
                
              _times.Add(new Time(id, name, createDate, mainShirtColor, secondaryShirtColor));

        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {            
            if (_jogadores.Any(x => x.ID == id))
                throw new UniqueIdentifierException();

            _jogadores.Add(new Jogador(id, teamId, name, birthDate, skillLevel, salary));

        }

        public void SetCaptain(long playerId)
        {
            if (!(_jogadores.Any(x => x.ID == playerId)))
                throw new PlayerNotFoundException("Jogador n�o encontrado.");

            foreach(Jogador J in _jogadores)
            {
                J.IsCaptain = false;
            }
            Jogador capitao = _jogadores.Find(j => j.ID == playerId);
            capitao.IsCaptain = true;
        }

        public long GetTeamCaptain(long teamId)
        {
            if ( !(_times.Any(x => x.TeamID == teamId)) )
            {
                throw new TeamNotFoundException("Este time nao existe!");
            }
            Jogador Capitao = _jogadores.FirstOrDefault(x => x.TeamId == teamId && x.IsCaptain);

            if (Capitao is null)
            {
                throw new CaptainNotFoundException("Este time nao possui capitao!");
            }
            return Capitao.ID;
        }

        public string GetPlayerName(long playerId)
        {
            if (!(_jogadores.Any(x => x.ID == playerId)))
            {
                throw new PlayerNotFoundException("Não existe um jogador com esta ID!");
            }
            Jogador jogador = _jogadores.FirstOrDefault(x => x.ID == playerId);

            return jogador.Name;
        }

        public string GetTeamName(long teamId)
        {
            if (!(_times.Any(x => x.TeamID == teamId)))
            {
                throw new TeamNotFoundException("Não existe um time com esta ID!");
            }
            Time _time = _times.FirstOrDefault(x => x.TeamID == teamId);

            return _time.TeamName;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!(_times.Any(x => x.TeamID == teamId)))
            {
                throw new TeamNotFoundException("Não existe um time com esta ID!");
            }
            
            return _jogadores.Where(x => x.TeamId == teamId).OrderBy(id => id.ID).Select(j => j.ID).ToList();
            
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!(_times.Any(x => x.TeamID == teamId)))
            {
                throw new TeamNotFoundException("Não existe um time com esta ID!");
            }

            return _jogadores.Where(x => x.TeamId == teamId)
                             .OrderByDescending(id => id.SkillLevel)
                             .ThenBy(id => id.ID)
                             .Select(j => j.ID)
                             .FirstOrDefault(); // para converter de lista para long;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!(_times.Any(x => x.TeamID == teamId)))
            {
                throw new TeamNotFoundException("Não existe um time com esta ID!");
            }

            return _jogadores.Where(x => x.TeamId == teamId)
                             .OrderBy(id => id.BirthDate)
                             .ThenBy(id => id.ID)
                             .Select(j => j.ID)
                             .FirstOrDefault(); // para converter de lista para long;

        }

        public List<long> GetTeams()
        {
            if (!_times.Any()) // Se não houver qualquer time na lista _times...
                return new List<long>();

            return _times.OrderBy(id => id.TeamID).Select(id => id.TeamID).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!(_times.Any(x => x.TeamID == teamId)))
            {
                throw new TeamNotFoundException("Não existe um time com esta ID!");
            }
            
            return _jogadores.Where(id => id.TeamId == teamId)
                             .OrderByDescending(p => p.Salary)
                             .ThenBy(id => id.ID)
                             .Select(id => id.ID)
                             .FirstOrDefault();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (!(_jogadores.Any(x => x.ID == playerId)))
            {
                throw new PlayerNotFoundException("Não existe um jogador com esta ID!");
            }

            return _jogadores.Where(id => id.ID == playerId)
                             .Select(id => id.Salary)
                             .FirstOrDefault();

        }

        public List<long> GetTopPlayers(int top)
        {
            if (!(_jogadores.Any()))
                return new List<long>();

            return _jogadores.OrderByDescending(t => t.SkillLevel)
                .ThenBy(id => id.ID)
                .Select(id => id.ID)
                .Take(top) // seleciona a quantidade 'top' de jogadores
                .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if (!(_times.Any(id => id.TeamID == teamId)))
            {
                throw new TeamNotFoundException("Não existe um time da casa com esta ID!");
            }
            else if (!(_times.Any(id => id.TeamID == visitorTeamId)))
            {
                throw new TeamNotFoundException("Não existe um time visitante com esta ID!");
            }

            if (_times.Find(x => x.TeamID == teamId).MainShirtColor == _times.Find(x => x.TeamID == visitorTeamId).MainShirtColor)
            {
                return _times.Find(x => x.TeamID == visitorTeamId).SecondaryShirtColor.ToString();
            }
            else
                return _times.Find(x => x.TeamID == visitorTeamId).MainShirtColor;
        }   

    }
}
