using System;
using Xunit;
using System.Collections.Generic;
using System.Text;
using Ribboned.Models;
using Ribboned.Repositories;

namespace Ribboned.Tests
{
    public class RibbonedRepositoryTest : EFTestFixture
    {
        public RibbonedRepositoryTest()
        {
            AddSampleData();
        }

        //Ribbon Tests
        [Fact] 
        public void RibbonRepository_Can_Add_New_Ribbon()
        {
            var repo = new RibbonRepository(_context);
            var startingRibbons = repo.GetByUserId(1);
            var startingCount = startingRibbons.Count;

            // create new Ribbon
            var newRibbon = new Ribbon()
            {
                Title = "Test Video 4",
                Decription = "decription of test video 4",
                CategoryId = 2,
                SourceId = 2,
                UserProfileId = 1,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                DurationSeconds = 500
            };

            //add new ribbon
            repo.Add(newRibbon);

            //Get all ribbons again
            var resultingRibbons = repo.GetByUserId(1);
            var resultingCount = resultingRibbons.Count;

            //Check that one has been added
            Assert.NotEqual(0, newRibbon.Id);
            Assert.Equal(startingCount + 1, resultingCount);
        }


        //Add sample data
        public void AddSampleData()
        {
            var user1 = new UserProfile()
            {
                UserName = "Meg",
                Email = "meg@gmail.com",
                ImageUrl = "image.jpeg",
                FirebaseUserId = "TEST_FIREBASE_UID_2"
            };

            var user2 = new UserProfile()
            {
                UserName = "Chris",
                Email = "chris@gmail.com",
                ImageUrl = "image.jpeg",
                FirebaseUserId = "TEST_FIREBASE_UID_2"
            };
            _context.Add(user1);
            _context.Add(user2);
            _context.SaveChanges();

            var source1 = new Source()
            {
                Type = "youtube"
            };

            var source2 = new Source()
            {
                Type = "local"
            };
            _context.Add(source1);
            _context.Add(source2);
            _context.SaveChanges();

            var category1 = new Category()
            {
                Name = "Sports"
            };

            var category2 = new Category()
            {
                Name = "Tech"
            };
            _context.Add(category1);
            _context.Add(category2);
            _context.SaveChanges();

            var ribbon1 = new Ribbon()
            {
                Title = "Test Video 1",
                Decription = "decription of test video 1",
                CategoryId = 1,
                SourceId = 1,
                UserProfileId = 1,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                DurationSeconds = 900
            };
            var ribbon2 = new Ribbon()
            {
                Title = "Test Video 2",
                Decription = "decription of test video 2",
                CategoryId = 1,
                SourceId = 1,
                UserProfileId = 2,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                DurationSeconds = 1000
            };

            var ribbon3 = new Ribbon()
            {
                Title = "Test Video 3",
                Decription = "decription of test video 3",
                CategoryId = 2,
                SourceId = 2,
                UserProfileId = 2,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                DurationSeconds = 500
            };
            _context.Add(ribbon1);
            _context.Add(ribbon2);
            _context.Add(ribbon3);
            _context.SaveChanges();

            var snag1 = new Snag()
            {
                RibbonId = 1,
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                Note = "snag note 1",
                Seconds = 30
            };

            var snag2 = new Snag()
            {
                RibbonId = 1,
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                Note = "snag note 2",
                Seconds = 45
            };

            var snag3 = new Snag()
            {
                RibbonId = 2,
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                Note = "snag note 3",
                Seconds = 30
            };

            var snag4 = new Snag()
            {
                RibbonId = 2,
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                Note = "snag note 4",
                Seconds = 55
            };
            _context.Add(snag1);
            _context.Add(snag2);
            _context.Add(snag3);
            _context.Add(snag4);
            _context.SaveChanges();
        }
    }
}