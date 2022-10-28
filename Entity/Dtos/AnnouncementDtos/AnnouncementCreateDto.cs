using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos.AnnouncementDtos
{
    public class AnnouncementCreateDto : IDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
    }
}
