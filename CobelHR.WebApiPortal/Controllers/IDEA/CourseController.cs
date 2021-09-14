using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.IDEA.Abstract;
using CobelHR.Entities.IDEA;

namespace CobelHR.ApiServices.Controllers.IDEA
{
    [Route("api/IDEA")]
    public class CourseController : BaseController
    {
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        private ICourseService courseService { get; set; }

        [HttpGet]
        [Route("Course/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.courseService.RetrieveById(id, Course.Informer, this.UserCredit).ToActionResult<Course>();
        }

        [HttpPost]
        [Route("Course/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.courseService.RetrieveAll(Course.Informer, paginate, this.UserCredit).ToActionResult<Course>();
        }
            

        
        [HttpPost]
        [Route("Course/Save")]
        public IActionResult Save([FromBody] Course course)
        {
            return this.courseService.Save(course, this.UserCredit).ToActionResult<Course>();
        }

        
        [HttpPost]
        [Route("Course/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Course course)
        {
            return this.courseService.SaveAttached(course, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Course/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Course> courseList)
        {
            return this.courseService.SaveBulk(courseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Course/Seek")]
        public IActionResult Seek([FromBody] Course course)
        {
            return this.courseService.Seek(course).ToActionResult<Course>();
        }

        [HttpGet]
        [Route("Course/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.courseService.SeekByValue(seekValue, Course.Informer).ToActionResult<Course>();
        }

        [HttpPost]
        [Route("Course/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Course course)
        {
            return this.courseService.Delete(course, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfTraining
        [HttpPost]
        [Route("Course/{course_id:int}/Training")]
        public IActionResult CollectionOfTraining([FromRoute(Name = "course_id")] int id, Training training)
        {
            return this.courseService.CollectionOfTraining(id, training).ToActionResult();
        }
    }
}