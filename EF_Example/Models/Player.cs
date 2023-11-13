using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Example.Models;

[Table("Player")]
public partial class Player
{
    [Key]
    public int PlayerId { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    public int BirthYear { get; set; }

    [InverseProperty("Player")]
    public virtual ICollection<HighScore> HighScores { get; set; } = new List<HighScore>();
}
