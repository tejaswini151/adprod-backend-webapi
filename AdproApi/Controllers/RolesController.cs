using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdproApi.Context;
using AdproApi.Models;
using Microsoft.OpenApi.Any;
using System.Net;
using System.Data;

namespace AdproApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public RolesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
          if (_context.Roles == null)
          {
              return Problem("Entity set 'DataBaseContext.Roles'  is null.");
          }
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/Roles
        [HttpGet("menus/{roleid}")]
        public dynamic GetRoleMenus(int roleid)
        {
            var result = (from menu in _context.Menus
                          join rolemenu in _context.RoleMenus
                          on menu.Id equals rolemenu.MenuId
                          //where rolemenu.RoleId == roleid
                          into Details
                          from data in Details.DefaultIfEmpty()
                          select new
                          {
                              id = menu.Id,
                              title = menu.Title,
                              canhavechild = menu.Canhavechild,
                              link = menu.Link,
                              icon = menu.Icon,
                              parentmenuid = menu.Parentmenuid,
                              rolemenuid = (int?)data.Id ?? 0
                          }).ToList();


            //var result = _context.Menus.ToList();
            //var result = _context.Database.SqlQueryRaw<Menu>($"Select M.* AS rolemenuid FROM menus AS M LEFT OUTER JOIN rolemenus AS RM ON M.id = RM.menuid AND RM.roleid = { roleid }").ToList();
            //var result = _context.Database.SqlQueryRaw<Menu>($"Select M.* FROM menus AS M").ToList();
            return result;
        }

        [HttpPost("add/{roleid}/{menuid}")]
        public async Task<ActionResult<Role>> AddRoleMenu(int roleid, int menuid)
        {
            RoleMenu roleMenu = new RoleMenu();
            roleMenu.RoleId = roleid;
            roleMenu.MenuId = menuid;
            roleMenu.Id = 0;
            _context.RoleMenus.Add(roleMenu);
            await _context.SaveChangesAsync();
            return Ok("success");
        } 

        [HttpPost("remove/{rolemenuid}")]
        public async Task<ActionResult<Role>> RemoveRoleMenu(int rolemenuid)
        {
            var rolemenu = await _context.RoleMenus.FindAsync(rolemenuid);
            if (rolemenu == null)
            {
                return NotFound();
            }
            _context.RoleMenus.Remove(rolemenu);
            await _context.SaveChangesAsync();
            return Ok("success");
        }

    }
}
