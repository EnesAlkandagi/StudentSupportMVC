using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Dtos.AnnouncementDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private IAnnouncementDal _announcementDal;
        private ICityDal _cityDal;

        public AnnouncementManager(IAnnouncementDal announcementDal, ICityDal cityDal)
        {
            _announcementDal = announcementDal;
            _cityDal = cityDal;
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<List<AnnouncementListDto>> GetListAnnouncement()
        {
            var result = new List<AnnouncementListDto>();
            var announcmentList = _announcementDal.GetList();

            foreach (var announcment in announcmentList)
            {
                var announcmentDto = new AnnouncementListDto
                {
                    Id = announcment.Id,
                    Title = announcment.Title,
                    CityName = GetCityName(announcment.CityId)
                };
                result.Add(announcmentDto);
            }


            return new SuccessDataResult<List<AnnouncementListDto>>(result);
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<Announcement> Create(AnnouncementCreateDto registerDto)
        {
            var announcement = new Announcement
            {
                Title = registerDto.Title,
                Text = registerDto.Text,
                UserId = registerDto.UserId,
                CityId = registerDto.CityId
            };
            _announcementDal.Add(announcement);
            return new SuccessDataResult<Announcement>(announcement);

        }

        private string GetCityName(int cityId)
        {
            var cityName = _cityDal.Get(x => x.Id == cityId);
            return cityName.Name;
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<AnnouncementGetDto> GetById(int id)
        {
            var anno = _announcementDal.Get(u => u.Id == id);
            if (anno == null) throw new NullReferenceException();

            var annoGet = new AnnouncementGetDto { Id = anno.Id, Text = anno.Text, Title = anno.Title };

            return new SuccessDataResult<AnnouncementGetDto>(annoGet);
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<Announcement> AnnouncementUpdate(int id, AnnouncementUpdateDto announcementUpdateDto)
        {
            var announcementToCheck = _announcementDal.Get(u => u.Id == id);
            announcementToCheck.Title = announcementUpdateDto.Title;
            announcementToCheck.Text = announcementUpdateDto.Text;
            announcementToCheck.CityId = announcementUpdateDto.CityId;
            _announcementDal.Update(announcementToCheck);
            return new SuccessDataResult<Announcement>("Duyuru Başarıyla Güncellendi");
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<List<AnnouncementUserListDto>> GetUserListAnnouncement(int userId)
        {
            var result = new List<AnnouncementUserListDto>();
            var announcmentUserList = _announcementDal.GetList();

            foreach (var announcment in announcmentUserList)
            {
                if (announcment.UserId == userId)
                {
                    var announcmentDto = new AnnouncementUserListDto
                    {
                        Id = announcment.Id,
                        Title = announcment.Title,
                        UserId = announcment.UserId,
                        CityName = GetCityName(announcment.CityId)
                    };
                    result.Add(announcmentDto);
                }

            }


            return new SuccessDataResult<List<AnnouncementUserListDto>>(result);
        }
    }
}
