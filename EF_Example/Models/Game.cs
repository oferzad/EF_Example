using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Example.Models;

[Table("Game")]
public partial class Game
{
    [Key]
    public int GameId { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    public int MinimumAge { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<HighScore> HighScores { get; set; } = new List<HighScore>();
}
