using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos.AnnouncementDtos
{
    public class AnnouncementUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CityId { get; set; }
    }
}
