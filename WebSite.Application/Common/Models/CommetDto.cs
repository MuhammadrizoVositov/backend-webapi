using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Models;
public class CommetDto
{
    public Guid SenderId { get; set; }
    public Guid ItemId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}
