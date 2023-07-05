using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TaskApi.Entities;
using TaskApi.Entities.ConfigModels;
using TaskApi.Entities.ErrorModel;
using TaskApi.Logger;
using TaskApi.Shared.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace TaskApi.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(DtoUserRegistration userForRegistration);
        Task<IEnumerable<DtoUser>> GetAll();
        Task<DtoUser> FindUserById(string id);
        Task<DtoUser> FindUserByEmail(string email);
        Task<IdentityResult> UpdateUser(string id, DtoUserUpdate dtoUser);
        Task<IdentityResult> DeleteUser(string id);
    }
    public class UserService : IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(DtoUserRegistration dtoUser)
        {
            var user = _mapper.Map<User>(dtoUser);
            var result = await _userManager.CreateAsync(user, dtoUser.Password);
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, dtoUser.Role);
            return result;
        }

        public async Task<DtoUser> FindUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);

            var res = _mapper.Map<DtoUser>(user);
            res.Rol = roles[0];

            return res;
        }
        public async Task<DtoUser> FindUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            var res = _mapper.Map<DtoUser>(user);
            res.Rol = roles[0];

            return res;
        }
        public async Task<IdentityResult> UpdateUser(string id, DtoUserUpdate dtoUser)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                throw new UserNotFoundException(id);

            var roles = await _userManager.GetRolesAsync(user);

            _mapper.Map(dtoUser, user);

            var result = await _userManager.UpdateAsync(user!);
            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, roles[0]);
                await _userManager.AddToRoleAsync(user, dtoUser.Role);
            }

            return result;
        }
        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                throw new UserNotFoundException(id);

            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<IEnumerable<DtoUser>> GetAll()
        {
            var users = _userManager.Users.ToList();

            var res = new List<DtoUser>();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);
                var workerTaskDto = _mapper.Map<ICollection<DtoWorkerTask>>(item.WorkerTasks);
                var dptoDto = _mapper.Map<DtoDepartment>(item.Department);

                var userDto = new DtoUser
                {
                    Id = item.Id,
                    Active = true,
                    Department = dptoDto,
                    DepartmentId = item.DepartmentId,
                    Email = item.Email,
                    FName = item.FName,
                    LName = item.LName,
                    UrlImg = item.UrlImg,
                    Rol = roles[0],
                    WorkerTasks = workerTaskDto
                };

                res.Add(userDto);
            }

            return res;
        }
    }
}
