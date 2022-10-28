using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Dtos.AnnouncementDtos;

namespace Mvc.Models
{
    public class AnnouncementListModel
    {
        public List<AnnouncementListDto> announcementListDto { get; set; }
    }
}
