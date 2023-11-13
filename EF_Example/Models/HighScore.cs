using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Example.Models;

[PrimaryKey("GameId", "PlayerId")]
public partial class HighScore
{
    [Key]
    public int GameId { get; set; }

    [Key]
    public int PlayerId { get; set; }

    public int Score { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("HighScores")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("PlayerId")]
    [InverseProperty("HighScores")]
    public virtual Player Player { get; set; } = null!;
}
