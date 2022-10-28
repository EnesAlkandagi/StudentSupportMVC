using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Dtos.AnnouncementDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        IDataResult<List<AnnouncementListDto>> GetListAnnouncement();
        IDataResult<Announcement> Create(AnnouncementCreateDto registerDto);
        IDataResult<AnnouncementGetDto> GetById(int id);
        IDataResult<Announcement> AnnouncementUpdate(int id, AnnouncementUpdateDto announcementUpdateDto);
        IDataResult<List<AnnouncementUserListDto>> GetUserListAnnouncement(int userId);

    }
}
