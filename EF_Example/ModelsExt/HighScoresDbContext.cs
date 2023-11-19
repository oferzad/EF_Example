using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace EF_Example.Models;

public partial class HighScoresDbContext : DbContext
{
    public List<Player> GetPlayers()
    {
        List<Player> players = this.Players.AsNoTracking().ToList();
                                   
        return players;
    }

    public void UpdatePlayer(Player player)
    {
        this.Entry(player).State = EntityState.Modified;
        SaveChanges();
    }

    public void AddPlayer(Player player)
    {
        this.Entry(player).State = EntityState.Added;
        SaveChanges();
    }

    public Player? GetFullPlayerData(int playerID)
    {
        Player? p = this.Players.AsNoTracking()
                                .Where(p => p.PlayerId == playerID)
                                .Include(p => p.HighScores)
                                .ThenInclude(h => h.Game)
                                .FirstOrDefault();
        return p;
    }

    public void AddHighScoreToPlayer(HighScore h)
    {
        this.Entry(h).State = EntityState.Added;
        SaveChanges();
    }
}

