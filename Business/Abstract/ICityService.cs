using Core.Utilities.Results;
using Entity.Dtos.CityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<CityListDto>> GetListCity();
    }
}
