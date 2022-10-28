using Entity.Dtos.AnnouncementDtos;
using Entity.Dtos.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class AnnouncementUpdateModel
    {
        public AnnouncementUpdateDto announcementUpdateDto { get; set; }
        public List<CityListDto> cityListDto { get; set; }
    }
}
