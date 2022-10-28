using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc.Models;
using Entity.Dtos.AnnouncementDtos;
using Business.BusinessAspects.Autofac;

namespace Mvc.Controllers.Announcement
{
    public class AnnouncementController : Controller
    {
        IHttpContextAccessor _httpContext;
        IAnnouncementService _announcementService;
        ICityService _cityService;

        public AnnouncementController(IHttpContextAccessor httpContext, IAnnouncementService announcementService, ICityService cityService)
        {
            _httpContext = httpContext;
            _announcementService = announcementService;
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _announcementService.GetListAnnouncement();
            if (result.Success)
            {
                var model = new AnnouncementListModel
                {
                    announcementListDto = result.Data
                };
                return View(model);
            }
            return View();
        }

        public IActionResult Create()
        {
            var cityListDto = _cityService.GetListCity();
            return View(new AnnouncementCreateModel
            {
                cityListDto = cityListDto.Data
            });

        }

        [HttpPost]
        public IActionResult Create(AnnouncementCreateModel announcementCreateModel)
        {
            var userId = (int)_httpContext.HttpContext.Session.GetInt32("userId");
            announcementCreateModel.createDto.UserId = userId;
            var result = _announcementService.Create(announcementCreateModel.createDto);

            return Json(new { success = result.Success, message = result.Message });

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _announcementService.GetById(id);
            if (result.Success)
            {
                var model = new AnnouncementGetModel
                {
                    getDto = result.Data
                };
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult MyAnnouncements()
        {
            var userId = (int)_httpContext.HttpContext.Session.GetInt32("userId");
            var result = _announcementService.GetUserListAnnouncement(userId);
            if (result.Success)
            {
                var model = new AnnouncementUserListModel
                {
                    announcementUserListDto = result.Data
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(AnnouncementUpdateModel announcementUpdateModel)
        {
            var annId = (int)_httpContext.HttpContext.Session.GetInt32("annId");
            var result = _announcementService.AnnouncementUpdate(annId, announcementUpdateModel.announcementUpdateDto);
            //if (result.Success)
            //{
            //    var model = new AnnouncementUpdateModel
            //    {
            //        announcementUpdateDto = result.Data
            //    };
            //    return View(model);
            //}
            //return View();
            return Json(new { success = result.Success, message = result.Message });
        }

        public IActionResult Update(int id)
        {
            var result = _announcementService.GetById(id);
            var cityListDto = _cityService.GetListCity();

            var updateDto = new AnnouncementUpdateDto
            {
                Id = result.Data.Id,
                Text = result.Data.Text,
                Title = result.Data.Title
            };

            _httpContext.HttpContext.Session.SetInt32("annId", id);

            return View(new AnnouncementUpdateModel
            {
                cityListDto = cityListDto.Data,
                announcementUpdateDto = updateDto
            });

        }

    }
}
