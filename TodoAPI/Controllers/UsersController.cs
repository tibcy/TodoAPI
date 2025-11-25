using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Dtos;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IUserService _userService;

        public UsersController(TodoContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var user = await _context.Users.Include(r => r.Roles).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                LastLogin = user.LastLogin,
                Created = user.Created,
                Modified = user.Modified,
                Active = user.Active,
                Roles = user.Roles
            };
        }

        [HttpGet("{id}/todos")]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetUserTodos(int id)
        {
            var user = await _context.Users.Include(u => u.TodoItems).FirstOrDefaultAsync(u => u.Id == id);
            
            if (user == null)
            {
                return NotFound();
            
            }

            var todoItems = user.TodoItems.Select(x => new TodoItemDTO
            {
                Id = x.Id,
                Name = x.Name,
                IsComplete = x.IsComplete,
                Priority = x.Priority != null ? x.Priority.Name : null,
                Category = x.Category != null ? x.Category.Name : null
            });

            return Ok(todoItems);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> PostUser(UserCreateDto userDto)
        {
            var roles = await _context.Roles
                .Where(r => userDto.Roles != null && userDto.Roles.Contains(r.Id))
                .ToListAsync();

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,     
                LastLogin = userDto.LastLogin,
                Created = DateTime.Now,
                Modified = userDto.Modified,
                Active = userDto.Active,
                Roles = roles
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, userDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
