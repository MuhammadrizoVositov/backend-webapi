using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Domain.Common.Entity;
public class BookUploadModel : Entity
{
    public required string Title { get; set; }

    public required string Author { get; set; }

    public string? Description { get; set; }


    public required IFormFile File { get; set; }
}
