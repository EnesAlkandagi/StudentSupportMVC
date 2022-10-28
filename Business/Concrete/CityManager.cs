using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Dtos.CityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal) 
        {
            _cityDal = cityDal;
        }
        public IDataResult<List<CityListDto>> GetListCity()
        {
            var result = new List<CityListDto>();
            var cityList = _cityDal.GetList();

            foreach (var city in cityList)
            {
                var cityListDto = new CityListDto
                {
                    Id = city.Id,
                    CityName = city.Name
                };
                result.Add(cityListDto);
            }


            return new SuccessDataResult<List<CityListDto>>(result);
        }


    }
}
