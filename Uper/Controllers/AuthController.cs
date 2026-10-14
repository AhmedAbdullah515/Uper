using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Uper.DTOs;
using Uper.Model;
using Uper.Repo;

namespace Uper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configration;
        public AuthController(IUnitOfWork unit, IMapper mapper, IConfiguration configration)
        {
            _unit = unit;
            _mapper = mapper;
            _configration = configration;
        }
        private string GeneratToken(User user)
        {
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
               new Claim(ClaimTypes.Name,user.FullName),
               new Claim(ClaimTypes.Role,user.Role),
               new Claim (ClaimTypes.Email,user.Email)
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["JWT:Key"]!));
            var credt = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenObject = new JwtSecurityToken(
                issuer: _configration["JWT:Issuer"],
                audience: _configration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credt
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenObject);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _unit.AuthRepo.GetbyEmail(dto.Email);
            if (user == null)
            {
                return BadRequest("Invalid Email");
            }
            if (user.Password != dto.Password)
            {
                return BadRequest("Invalid Password");
            }
            var token = GeneratToken(user);
            return Ok(token);
        }
        [HttpPost("Registeration")]
        public async Task<IActionResult> Register(RgisterDTO dto)
        {
            var email = await _unit.AuthRepo.GetbyEmail(dto.Email);
            if (email != null)
            {
                return BadRequest("Email Already Exist");
            }
            var user = _mapper.Map<User>(dto);
            await _unit.AuthRepo.Register(user);
            _unit.Save();
            return Created();
        }
    }
}
