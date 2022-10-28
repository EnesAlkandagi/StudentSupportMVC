using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos.CityDtos
{
    public class CityListDto : IDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}
