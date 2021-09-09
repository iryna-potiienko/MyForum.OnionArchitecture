
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Persistence.Context;

namespace MyForum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ApplicationDbContext _myForumContext;
        
        
        public TestController(ApplicationDbContext myForumContext)
        {
            _myForumContext = myForumContext;
        }


        [HttpGet]
        public List<Chapter> Index()
        {
            
            _myForumContext.Chapters.Add(new Chapter()); 
            _myForumContext.SaveChanges();
            
            var chapters = _myForumContext.Chapters.ToList();
            return chapters;
        }
    }
}