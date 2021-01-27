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

        //Ribbon Tests - CRUD
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
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
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

        [Fact]
        public void User_Can_Delete_Ribbon_With_Snag()
        {
            var ribbonwithSnag = 1;
            var repo = new RibbonRepository(_context);

            // Attempt to delete it
            repo.Delete(ribbonwithSnag);

            // Now attempt to get it
            var result = repo.GetById(ribbonwithSnag);

            Assert.Null(result);
        }

        //Ribbon Test - Search
        [Fact]
        public void Search_Should_Match_Only_User_Ribbon_Title()
        {
            var repo = new RibbonRepository(_context);
            var results = repo.Search("Test", 1);

            Assert.Equal(3, results.Count);
            Assert.Equal("Test Video 3", results[0].Title);
            Assert.Equal("Test Video 2", results[1].Title);
            Assert.Equal("Test Video 1", results[2].Title);
        }

        [Fact]
        public void Search_Should_Match_Only_User_Ribbon_Decription()
        {
            var repo = new RibbonRepository(_context);
            var results = repo.Search("decription of", 2);

            Assert.Single(results);
            Assert.Equal("Test Video 4", results[0].Title);
        }

        [Fact]
        public void Search_Should_Match_Only_User_Ribbon_Snag()
        {
            var repo = new RibbonRepository(_context);
            var results = repo.Search("note 2", 1);

            Assert.Single(results);
            Assert.Equal("Test Video 3", results[0].Title);
        }

        [Fact]
        public void Search_Should_Return_Empty_List_If_No_Matches()
        {
            var repo = new RibbonRepository(_context);
            var results = repo.Search("foobarbazcatgrill", 1);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void Search_Should_Return_Empty_List_If_Empty_String()
        {
            var repo = new RibbonRepository(_context);
            var results = repo.Search("", 1);

            Assert.NotNull(results);
            Assert.Empty(results);
        }


        [Fact]
        public void Search_Should_Return_Empty_List_If_All_Whitespace()
        {
            var repo = new RibbonRepository(_context);
            var results = repo.Search("     ", 1);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        //Snag Tests
        [Fact]
        public void User_Can_Add_New_Snag()
        {
            var repo = new SnagRepository(_context);
            var startingSnags = repo.GetByRibbon(1);
            var startingCount = startingSnags.Count;

            var newSnag = new Snag()
            {
                RibbonId = 1,
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
                Note = "snag note 1",
                Seconds = 70
            };

            //add new snag
            repo.Add(newSnag);

            //Get all snags again
            var resultingRibbons = repo.GetByRibbon(1);
            var resultingCount = resultingRibbons.Count;

            //Check that one has been added
            Assert.NotEqual(0, newSnag.Id);
            Assert.Equal(startingCount + 1, resultingCount);
        }

        [Fact]
        public void User_Can_Delete_Snag()
        {
            var snag = 1;
            var repo = new SnagRepository(_context);

            // Attempt to delete it
            repo.Delete(snag);

            // Now attempt to get it
            var result = repo.GetById(snag);

            Assert.Null(result);
        }

        //UserProfile Test
        [Fact]
        public void User_Can_Add_UserProfile()
        {
            var repo = new UserProfileRepository(_context);
            var startingUsers = repo.GetAll();
            var startingCount = startingUsers.Count;

            var newUser = new UserProfile()
            {
                UserName = "Stewie",
                Email = "stewie@gmail.com",
                ImageUrl = "image.jpeg",
                FirebaseUserId = "TEST_FIREBASE_UID_2"
            };

            //add new user
            repo.Add(newUser);

            //Get all snags again
            var resultingUsers = repo.GetAll();
            var resultingCount = resultingUsers.Count;

            //Check that one has been added
            Assert.NotEqual(0, newUser.Id);
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
                Type = "youtube",
            };

            var source2 = new Source()
            {
                Type = "local",
            };
            _context.Add(source1);
            _context.Add(source2);
            _context.SaveChanges();

            var category1 = new Category()
            {
                Name = "Sports",
                UserProfileId = 1
            };

            var category2 = new Category()
            {
                Name = "Tech",
                 UserProfileId = 1
            };
            var category3 = new Category()
            {
                Name = "Games",
                UserProfileId = 2
            };
            _context.Add(category1);
            _context.Add(category2);
            _context.Add(category3);
            _context.SaveChanges();

            var ribbon1 = new Ribbon()
            {
                Title = "Test Video 1",
                Decription = "decription of test video 1",
                CategoryId = 1,
                SourceId = 1,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
            };
            var ribbon2 = new Ribbon()
            {
                Title = "Test Video 2",
                Decription = "decription of test video 2",
                CategoryId = 1,
                SourceId = 1,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
            };

            var ribbon3 = new Ribbon()
            {
                Title = "Test Video 3",
                Decription = "decription of test video 3",
                CategoryId = 2,
                SourceId = 2,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
            };

            var ribbon4 = new Ribbon()
            {
                Title = "Test Video 4",
                Decription = "decription of test video 4",
                CategoryId = 3,
                SourceId = 2,
                URL = "www.url.com",
                DateCreated = DateTime.Now - TimeSpan.FromDays(365),
            };
            _context.Add(ribbon1);
            _context.Add(ribbon2);
            _context.Add(ribbon3);
            _context.Add(ribbon4);
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
