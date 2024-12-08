using AutoMapper;
using generic_framework.Filters;
using Main.Server.Core.DTOs;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Services.IServices;
using Main.Server.Service.Services.AllServices;
using Microsoft.AspNetCore.Mvc;
using Main.Server.Core.DTOs.UserDTOs;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.DTOs.UserDTOs.UpdateDTOs;
using Main.Server.Core.Entities;
using Main.Server.Service.Hashing;
using Microsoft.AspNetCore.Authorization;

namespace generic_framework.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _userService.GetAll();
            var dtos = _mapper.Map<List<UserDto>>(users).ToList();

            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            var userDtos = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var user = await _userService.GetByIdAsync(id);

            user.UpdatedBy = userId;

            _userService.ChangeStatus(user);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(UserDto userDto)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<User>(userDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePassword(userDto.Password, out passwordHash, out passwordSalt);

            processEntity.PasswordHash = passwordHash;
            processEntity.PasswordSalt = passwordSalt;

            var user = await _userService.AddAsync(processEntity);

            var userResponseDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userResponseDto));

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserUpdateDto updateDto)
        {
            int userId = GetUserFromToken();

            var currentUser = await _userService.GetByIdAsync(updateDto.Id);

            currentUser.UpdatedBy = userId;
            currentUser.Name = updateDto.Name;
            currentUser.Surname = updateDto.Surname;

            _userService.Update(currentUser);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            Token token = await _userService.Login(userLoginDto);

            if (token == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(401, "Bilgiler Uyuşmadı"));
            }
            return CreateActionResult(CustomResponseDto<Token>.Success(200, token));
        }

        //[HttpPost("Register")]
        //public async Task<IActionResult> Register(UserDto userRegisterDto)
        //{
        //    // Kullanıcı adı veya e-posta adresi ile daha önce kayıtlı kullanıcı olup olmadığını kontrol et
        //    var existingUser =  _userService.GetByEmail(userRegisterDto.Email);
        //    if (existingUser != null)
        //    {
        //        return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(400, "Bu e-posta adresi ile daha önce bir hesap oluşturulmuş."));
        //    }

        //    // Kullanıcıyı User entity'sine dönüştür
        //    var user = _mapper.Map<User>(userRegisterDto);
        //    int userId = GetUserFromToken();

        //    // Kullanıcının oluşturulma işlemi ile ilgili ekleme işlemleri
        //    user.CreatedBy = userId;
        //    user.UpdatedBy = userId;

        //    // Şifreyi hash'le ve salt oluştur
        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePassword(userRegisterDto.Password, out passwordHash, out passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    // Kullanıcıyı veritabanına kaydet
        //    var createdUser = await _userService.AddAsync(user);

        //    // Kullanıcı DTO'su ile cevap oluştur
        //    var userResponseDto = _mapper.Map<UserDto>(createdUser);

        //    return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userResponseDto));
        //}

    }
}
