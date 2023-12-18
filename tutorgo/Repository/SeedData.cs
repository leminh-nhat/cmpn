using Microsoft.EntityFrameworkCore;
using tutorgo.Models;

namespace tutorgo.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();
            if(!_context.Courses.Any())
            {
                CategoryModel design = new CategoryModel { Name = "Design", Slug = "design", Description = "", Status = 1};
                CategoryModel marketing = new CategoryModel { Name = "Marketing", Slug = "marketing", Description = "", Status = 1 };
                CategoryModel programming = new CategoryModel { Name = "Programming", Slug = "programming", Description = "", Status = 1 };
                CategoryModel business = new CategoryModel { Name = "Business", Slug = "business", Description = "", Status = 1 };

                _context.Courses.AddRange(
                    new CourseModel { Name = "Photoshop CS6 Crash Course", Slug = "", Description = "Photoshop CS6 will be yours to command in 4 hours!", Image = "de1.jpg", Category = design, Price = 19 },
                    new CourseModel { Name = "Photoshop Master Course: From Beginner to Photoshop Pro", Slug = "", Description = "This Adobe Photoshop Beginner Course will teach a Beginner Photoshop user all essentials of Adobe Photoshop CC", Image = "de2.jpg", Category = design, Price = 45 },
                    new CourseModel { Name = "Adobe Audition CC Tutorial - Audition Made Easy", Slug = "", Description = "Audio and video editors learn the art of audio editing and enhancement in Audition from a leading Adobe certified expert", Image = "de3.jpg", Category = design, Price = 49 },
                    new CourseModel { Name = "Graphic Design Masterclass - Learn GREAT Design", Slug = "", Description = "The Ultimate Graphic Design Course Which Covers Photoshop, Illustrator, InDesign, Design Theory, Branding & Logo Design", Image = "de4.jpg", Category = design, Price = 99 },
                    new CourseModel { Name = "Figma UI UX Design Essentials", Slug = "", Description = "Use Figma to get a job in UI Design, User Interface, User Experience design, UX Design & Web Design", Image = "de5.jpg", Category = design, Price = 49 },

                    new CourseModel { Name = "Social Media For Business Strategy", Slug = "", Description = "Create a compelling mix with the latest Social Media Strategies. Achieve business growth goals stay ahead of competitors", Image = "ma1.jpg", Category = marketing, Price = 29 },
                    new CourseModel { Name = "Digital Marketing: 16 Strategic and Tactical Courses in 1", Slug = "", Description = "Master DM: AI,SEO,TIK TOK, Social Media, Analytics, CRO, PPC, Email, WebCopy, UX, Content Marketing, E-commerce", Image = "ma2.jpg", Category = marketing, Price = 59 },
                    new CourseModel { Name = "How to Market Yourself as a Coach or Consultant", Slug = "", Description = "Learn a Proven, Step-by-Step Process You Can Use to Package, Brand, Market, & Sell Your Coaching or Consulting Services", Image = "ma3.jpg", Category = marketing, Price = 59 },
                    new CourseModel { Name = "Google Ads for Beginners", Slug = "", Description = "Learn how to effectively use Google Ads to reach more customers online and grow your business.", Image = "ma4.jpg", Category = marketing, Price = 39 },
                    new CourseModel { Name = "Marketing Research: support your marketing decisions", Slug = "", Description = "Discover the extra advantage of any Business. A practical step by step guide to Marketing Information and Research.", Image = "ma5.jpg", Category = marketing, Price = 45 },

                    new CourseModel { Name = "Beginning C++ Programming - From Beginner to Beyond", Slug = "", Description = "Obtain Modern C++ Object-Oriented Programming (OOP) and STL skills. C++14 and C++17 covered. C++20 info see below.", Image = "pr1.jpg", Category = programming, Price = 89 },
                    new CourseModel { Name = "100 Days of Code: The Complete Python Pro Bootcamp for 2023", Slug = "", Description = "Master Python by building 100 projects in 100 days. Learn data science, automation, build websites, games and apps!", Image = "pr2.jpg", Category = programming, Price = 59 },
                    new CourseModel { Name = "React - The Complete Guide 2023 (incl. React Router & Redux)", Slug = "", Description = "Dive in and learn React.js from scratch! Learn React, Hooks, Redux, React Router, Next.js, Best Practices and way more!", Image = "pr3.jpg", Category = programming, Price = 99 },
                    new CourseModel { Name = "JavaScript Basics for Beginners", Slug = "", Description = "JavaScript - Master the Fundamentals in 6 Hours", Image = "pr4.jpg", Category = programming, Price = 75 },
                    new CourseModel { Name = "The Complete Flutter Development Bootcamp with Dart", Slug = "", Description = "Officially created in collaboration with the Google Flutter team.", Image = "pr5.jpg", Category = programming, Price = 49 },

                    new CourseModel { Name = "Powerful Business Writing: How to Write Concisely", Slug = "", Description = "A concise business writing course for punchy, professional and powerful writing – at work, at university, on your blog", Image = "bu1.jpg", Category = business, Price = 42 },
                    new CourseModel { Name = "Chief Financial Officer Leadership Program", Slug = "", Description = "An ever expanding program of courses helping financial professionals aspire to the top levels of financial leadership", Image = "bu2.jpg", Category = business, Price = 62 },
                    new CourseModel { Name = "Sales and Persuasion Skills for Startups", Slug = "", Description = "The entrepreneur's sure guide to getting a 'Yes'", Image = "bu3.jpg", Category = business, Price = 37 },
                    new CourseModel { Name = "Master Your Mindset & Brain: Framestorm Your Way to Success", Slug = "", Description = "Excel in any situation. Tweak your mindset in brain-smart ways. Master class in reframing based on neuroscience.", Image = "bu4.jpg", Category = business, Price = 49 },
                    new CourseModel { Name = "Improve Communication: Speak Smoothly, Clearly & Confidently", Slug = "", Description = "Learn How You Can Clear Interviews, Express Your Ideas, & Make Presentations Smoothly & Confidently!5", Image = "bu5.jpg", Category = business, Price = 37 }
                );
                _context.SaveChanges();
            }
        }
    }
}
