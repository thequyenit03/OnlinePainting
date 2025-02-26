using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TheQuyen.OnlinePainting.Data.Context;
using TheQuyen.OnlinePainting.Data.Models;
using TheQuyen.OnlinePainting.MVC.Models;

namespace TheQuyen.OnlinePainting.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlinePaintingContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, OnlinePaintingContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            //Artist artist = new Artist
            //{
            //    Name = "Ma The Quyen",
            //    Bio = "No",
            //    BirthDate = new DateTime(2003, 06, 21),
            //    Nationality = "Viet Nam",
            //    Website = "PaintingOnline.Com"
            //};
            //Post post = new Post
            //{
            //    Title = "TQuyen POST",
            //    Description = "Hnay that tuyet !"
            //};
            //db.Artists.Add(artist);
            //db.Posts.Add(post);
            //db.SaveChanges();

            //var listArtists = db.Artists.ToList();
            //foreach(var item in listArtists)
            //{
            //    Console.WriteLine($"ID: {item.ArtistId}, Name: {item.Name}, Bio: {item.Bio}, Website: {item.Website}, BirthDay: {item.BirthDate}, Nationaly: {item.Nationality}");
            //}
            //Category category1 = new Category
            //{
            //    Name = "Danhmuc1",
            //    Description = "DM01 Test"
            //};
            //Category category2 = new Category
            //{
            //    Name = "Danhmuc2",
            //    Description = "DM02 Test"
            //};
            //Category category3 = new Category
            //{
            //    Name = "Danhmuc3",
            //    Description = "DM03 Test"
            //};
            //db.Categories.AddRange(category1, category2, category3);
            //db.SaveChanges();
            //var categories = db.Categories.ToList();

            //foreach (var category in categories)
            //{
            //    Console.WriteLine($"Category ID: {category.CategoryId}, Name: {category.Name}, Description: {category.Description}");
            //}

            //// Thêm một Painting mới
            //var newPainting = new Painting
            //{
            //    Title = "Sunset Over Mountains",
            //    Description = "A beautiful sunset over the mountains.",
            //    Price = 300.00M,
            //    ImageUrl = "http://example.com/sunset.jpg",
            //    CreatedDate = DateTime.Now,
            //    Dimensions = "24x36 inches",
            //    Medium = "Oil on canvas",
            //    ArtistId = 1,
            //    CategoryId = 1
            //};
            //db.Paintings.Add(newPainting);
            //db.SaveChanges();

            // Truy vấn một Category
            //var category1 = db.Categories.FirstOrDefault(c => c.CategoryId == 1);

            //// Lúc này, các bài viết chưa được tải
            //if (category1 != null)
            //{
            //    // Truy cập vào thuộc tính Paintings sẽ kích hoạt Lazy Loading
            //    var paintings = category1.Paintings.ToList();

            //    foreach (var item in paintings)
            //    {
            //        Console.WriteLine($"Title: {item.Title}, Artist: {item.Artist?.Name}");
            //    }
            //}
            // Truy vấn một Category với các Painting liên quan
            //var category2 = db.Categories
            //            .Include(c => c.Paintings)
            //            .ThenInclude(p => p.Artist)
            //            .FirstOrDefault(c => c.CategoryId == 1);

            //if (category2 != null)
            //{
            //    foreach (var painting in category1.Paintings)
            //    {
            //        Console.WriteLine($"Title: {painting.Title}, Artist: {painting.Artist?.Name ?? "Artist is null"}");
            //    }

            //}


            return View();
        }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
