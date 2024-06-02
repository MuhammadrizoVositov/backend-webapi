using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Models;
public class ItemDto
{
    public required string Name { get; set; }

    [NotMapped]
    public IFormFile Image { get; set; }

    [Obsolete]
    public required string ImageUrl { get; set; }
    public string? Comments {  get; set; }
    public required Guid UserId { get; set; }
    public required DateTimeOffset CreateAt { get; set; }
    public required DateTimeOffset UpdateAt { get; set; }
    public string? Description { get; set; }
    public Guid ItemTypeId { get; set; }
}
