﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookCollectionLibrary.API.Model.Base;

public class BaseEntity
{
    [Column("id")]
    public long Id { get; set; }
}
