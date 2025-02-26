﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheQuyen.OnlinePainting.Data.Context;
using TheQuyen.OnlinePainting.Data.Models;

namespace TheQuyen.OnlinePainting.MVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly OnlinePaintingContext _context;

        public CommentsController(OnlinePaintingContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var onlinePaintingContext = _context.Comments.Include(c => c.Customer).Include(c => c.Painting).Include(c => c.ParentComment);
            return View(await onlinePaintingContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Customer)
                .Include(c => c.Painting)
                .Include(c => c.ParentComment)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["PaintingId"] = new SelectList(_context.Paintings, "PaintingId", "PaintingId");
            ViewData["ParentCommentId"] = new SelectList(_context.Comments, "CommentId", "CommentId");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CommentDate,Rating,LikeCount,CustomerId,PaintingId,ParentCommentId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", comment.CustomerId);
            ViewData["PaintingId"] = new SelectList(_context.Paintings, "PaintingId", "PaintingId", comment.PaintingId);
            ViewData["ParentCommentId"] = new SelectList(_context.Comments, "CommentId", "CommentId", comment.ParentCommentId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", comment.CustomerId);
            ViewData["PaintingId"] = new SelectList(_context.Paintings, "PaintingId", "PaintingId", comment.PaintingId);
            ViewData["ParentCommentId"] = new SelectList(_context.Comments, "CommentId", "CommentId", comment.ParentCommentId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Content,CommentDate,Rating,LikeCount,CustomerId,PaintingId,ParentCommentId")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", comment.CustomerId);
            ViewData["PaintingId"] = new SelectList(_context.Paintings, "PaintingId", "PaintingId", comment.PaintingId);
            ViewData["ParentCommentId"] = new SelectList(_context.Comments, "CommentId", "CommentId", comment.ParentCommentId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Customer)
                .Include(c => c.Painting)
                .Include(c => c.ParentComment)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
