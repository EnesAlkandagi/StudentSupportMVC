using Entity.Dtos.AnnouncementDtos;
using Entity.Dtos.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class AnnouncementCreateModel
    {
        public AnnouncementCreateDto createDto { get; set; }
        public List<CityListDto> cityListDto { get; set; }
    }
}
